using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace weekTask4Bouns
{
    class School
    {
        List<Student> students;
        List<Course> courses;
        List<Instructor> instructors;

        public School()
        {
            students = new();
            courses = new();
            instructors = new();
        }

        public virtual bool AddStudent(Student s)
        {
            
            foreach (var student in students)
            {
                if (student.StudentId == s.StudentId)
                {
                    return false; 
                }
            }
                        
            students.Add(s);
            return true;
        }
        public virtual bool AddCourse(Course c)
        {
            foreach (var course in courses)
            {
                if (course.CourseId == c.CourseId)
                {
                    return false; 
                }
            }

            courses.Add(c); 
            return true;


        }
        public virtual bool AddInstructor(Instructor i)
        {
            foreach (var instructor in instructors)
            {
                if (instructor.InstructorId == i.InstructorId)
                {
                    return false;
                }

            }
            instructors.Add(i);

            return true;

        }

        public virtual Student? FindStudent(int sId)
        {
            foreach (var item in students)
            {
                if (item.StudentId == sId)
                    return item;


            }
            return null;

        }
        public virtual Course? FindCourse(int cId)
        {
            foreach (var item in courses)
            {
                if (item.CourseId == cId)
                    return item;

            }
            return null;

        }
        public virtual Instructor? FindInstructor(int iId)
        {
            foreach (var item in instructors)
            {
                if (item.InstructorId == iId)
                    return item;

            }
            return null;

        }

        public bool EnrollStudentInCourse(int sId, int cId)
        {
            foreach (var student in students)
            {
                if (student.StudentId == sId)
                {
                    foreach (var cours in courses)
                    {
                        if (cours.CourseId == cId)
                        {
                            student.AddCourse(cours);
                            return true;

                        }


                    }
                    return false;

                }
            }
            return false;


        }

        public virtual string PrintDetails()
        {
            return "";
        }






    }
    class Student : School
    {
        public int StudentId { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }

        List<Course> courses;

        public Student(int studentId, int age, string name)
        {
            StudentId = studentId;
            Age = age;
            Name = name;
            courses = new();
        }
        public override bool AddCourse(Course c)
        {
            foreach (var course in courses)
            {
                if (course != c)
                {
                    courses.Add(c);

                    return true;
                }

            }
            return false;

        }
        public override string PrintDetails()
        {
            string result = "";


            result += $" Student ID: {StudentId} ,Student Name: {Name} ,Student Age: {Age} \n";

            foreach (Course course in courses)
            {
                result += course.PrintDetails();
            }

            return result;

        }

    }
    class Course : School
    {
        public int CourseId { get; set; }
        public string Title { get; set; }

        Instructor instructor;

        public Course(int courseId, string title)
        {
            CourseId = courseId;
            Title = title;

        }
        public override bool AddInstructor(Instructor i)
        {
            instructor = i; return true;

        }
        public override string PrintDetails()
        {
            string result = "";


            result += $" Course ID: {CourseId} ,Course Name: {Title}  \n";
            result += "================================ \n";

            return result;

        }
    }
    class Instructor : School
    {
        public Instructor(int instructorId, string name, string specialization)
        {
            InstructorId = instructorId;
            Name = name;
            Specialization = specialization;
        }

        public int InstructorId { get; set; }
        public string Name { get; set; }
        public string Specialization { get; set; }

        public override string PrintDetails()
        {
            string result = "";


            result += $" Instructor ID: {InstructorId} ,Instructor Name: {Name} ,Instructor Specialization: {Specialization} \n";
            result += "================================ \n";


            return result;

        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            School school = new School();
            List<Student> students = new List<Student>();
            List<Course> courses = new List<Course>();
            List<Instructor> instructors = new List<Instructor>();
            string customerString = "-1";
            do
            {

                Console.WriteLine("" +
                    "1. Add Student \r\n" +
                    "2. Add Instructor\r\n" +
                    "3. Add Course \r\n" +
                    "4. Enroll Student in Course\r\n" +
                    "5. Show All Students\r\n" +
                    "6. Show All Courses\r\n" +
                    "7. Show All Instructors\r\n" +
                    "8. Find the student by id or name\r\n" +
                    "9. Fine the course by id or name\r\n" +
                    "10. Exit");
                customerString = Console.ReadLine();

                switch (customerString)
                {
                    case "1":
                        Console.WriteLine("inter ID");
                        int sid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("inter Name");
                        string sname = Console.ReadLine();
                        Console.WriteLine("inter age");
                        int sage = Convert.ToInt32(Console.ReadLine());

                        Student s =new Student(sid, sage, sname);
                        students.Add(s);
                        school.AddStudent(s);
                        Student itemStudentt = school.FindStudent(sid);
                        if (itemStudentt != null)
                        {
                            Console.WriteLine(itemStudentt.PrintDetails());
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }


                        break;

                    case "2":
                        Console.WriteLine("inter ID");
                        int iId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("inter Name");
                        string iName = Console.ReadLine();
                        Console.WriteLine("inter Specialization");
                        string iS = Console.ReadLine();

                        Instructor ins = new Instructor(iId, iName, iS);
                        instructors.Add(ins);
                        school.AddInstructor(ins);
                        


                        break;

                    case "3":
                        Console.WriteLine("inter ID");
                        int cid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("inter Tital");
                        string cname = Console.ReadLine();

                        Course c = new Course(cid, cname);
                        courses.Add(c);
                        school.AddCourse(c);

                        break;
                    case "4":


                        Console.WriteLine("inter student id ");
                        int studentId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("inter couers id ");
                        int courseId = Convert.ToInt32(Console.ReadLine());

                        school.EnrollStudentInCourse(studentId, courseId);





                        break;
                    case "5":

                        for (int i = 0; i < students.Count; i++)
                        {
                            Console.WriteLine(students[i].Name);
                            Console.WriteLine(students[i].StudentId);
                            Console.WriteLine(students[i].Age);
                            Console.WriteLine("________________________________________");
                        }

                        break;

                    case "6":
                        for (int i = 0; i < courses.Count; i++)
                        {
                            Console.WriteLine(courses[i].Title);
                            Console.WriteLine(courses[i].CourseId);
                            Console.WriteLine("________________________________________");
                        }


                        break;
                    case "7":
                        for (int i = 0; i < instructors.Count; i++)
                        {
                            Console.WriteLine(instructors[i].Name);
                            Console.WriteLine(instructors[i].InstructorId);
                            Console.WriteLine(instructors[i].Specialization);
                            Console.WriteLine("________________________________________");
                        }
                        break;
                    case "8":

                        
                        Console.WriteLine("inter student id ");
                        int foundStudent =Convert.ToInt32(Console.ReadLine());
                       Student itemStudent= school.FindStudent(foundStudent) ;
                        if (itemStudent != null)
                        {
                            Console.WriteLine(itemStudent.PrintDetails());
                        }
                        else
                        {
                            Console.WriteLine("Student not found.");
                        }




                        break;
                    case "9":
                        Console.WriteLine("inter Course id ");
                        int foundCourse= Convert.ToInt32(Console.ReadLine());
                       Course itemCourse= school.FindCourse(foundCourse) ;

                        if (itemCourse!=null)
                        {
                            Console.WriteLine(itemCourse.PrintDetails());

                        }
                        else
                        {
                            Console.WriteLine("course not found.");

                        }

                        break;
                    case "10"://Quit

                        students.Clear();
                        courses.Clear();
                        instructors.Clear();
                        Console.WriteLine("Goodbye");

                        break;


                    default:
                        break;


                }

            } while (customerString != "10");


        }
    }






}



