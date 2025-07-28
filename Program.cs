using System.Xml.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace weekTask4Bouns
{
    class School 
    {
        List<Student> students ;
        List<Course> courses;
        List<Instructor> instructors;

        public School()
        {
           students = new() ;
           courses = new() ;
           instructors = new() ;
        }

        public virtual bool AddStudent(Student s)
        {
            foreach (var student in students)
            {
                if (student != s)
                {
                    students.Add(s);

                    return true;
                }
                
            }
            return false;
        }
        public virtual bool AddCourse(Course c)
        {
            foreach (var course in courses)
            {
                if (course != c )
                {
                    courses.Add(c);

                    return true;
                }

            }
            return false;
           
        }
        public virtual bool AddInstructor(Instructor i)
        {
            foreach (var instructor in instructors)
            {
                if (instructor != i)
                {
                    instructors.Add(i);

                    return true;
                }

            }
            return false;
        }

        public virtual Student? FindStudent(int sId)
        {
            foreach (var item in students)
            {
                if(item.StudentId == sId)
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

        public bool EnrollStudentInCourse(int sId , int cId)
        {
            foreach(var student in students)
            {
                if(student.StudentId==sId)
                {
                    foreach(var cours in courses)
                    {
                        if (cours.CourseId==cId)
                        {
                            student.AddCourse(cours);
                            return true;

                        }


                    }return false;
                    
                }
            }return false;
        

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


            result += $" Course ID: {CourseId} ,Course Name: {Title} , Instructor : {instructor.Name} \n";
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

            List<Student> students = new List<Student>();
            List<Course> courses = new List<Course>();
            List<Instructor> instructors = new List<Instructor>();
            string customerString = "-1";
            do
            {

                Console.WriteLine("1. Add Student (hint: start with empty list of courses)\r\n2. Add Instructor\r\n3. Add Course (hint: select the instructor by id)\r\n4. Enroll Student in Course\r\n5. Show All Students\r\n6. Show All Courses\r\n7. Show All Instructors\r\n8. Find the student by id or name\r\n9. Fine the course by id or name\r\n10. Exit");
                customerString = Console.ReadLine().ToUpper();






                switch (customerString)
                {
                    case "1":
                        Console.WriteLine("inter ID");
                        int sid =Convert.ToInt32(Console.ReadLine()) ;                                  
                        Console.WriteLine("inter Name");
                        string sname =Console.ReadLine();                                  
                        Console.WriteLine("inter age");
                        int sage = Convert.ToInt32(Console.ReadLine());   
                        
                        students.Add( new Student(sid,sage,sname) );

                        break;

                    case "2":
                        Console.WriteLine("inter ID");
                        int cid = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("inter Tital");
                        string cname = Console.ReadLine();
                        

                        courses.Add(new Course(cid,cname));


                        break;

                    case "3":
                        Console.WriteLine("inter ID");
                        int iId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("inter Name");
                        string iName = Console.ReadLine();
                        Console.WriteLine("inter age");
                        string iS = Console.ReadLine();

                        instructors.Add(new Instructor(iId,iName,iS));
                        break;
                    case "4":
                        
                        break;
                    case "5":

                       for (int i = 0;i<students.Count;i++)
                        {
                            Console.WriteLine(students[i].Name);
                            Console.WriteLine(students[i].StudentId);
                            Console.WriteLine(students[i].Age);
                            Console.WriteLine( "________________________________________" );
                        }    

                        break;

                    case "6"://the smallest number
                        for (int i = 0; i < courses.Count; i++)
                        {
                            Console.WriteLine(courses[i].Title);
                            Console.WriteLine(courses[i].CourseId);
                            Console.WriteLine("________________________________________");
                        }


                        break;
                    case "7":
                        
                        break;
                    case "8":
                        
                        break;
                    case "9":
                        
                        break;
                    case "10"://Quit

                        
                        Console.WriteLine("Goodbye");

                        break;


                    default:
                        break;


                }

            } while (customerString != "10");
        }
    }






}
    

 
