using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace elective1_finaldrill
{
    public class Student
    {
        public int studentnumber { get; set; }
        public string surname { get; set; }
        public string firstname { get; set; }
        public string occupation { get; set; }
        public string gender { get; set; }
        public int countrycode { get; set; }
        public int areacode { get; set; }
        public string phonenumber { get; set; }
    }
    public class StudentMainMenu
    {
        private List<Student> studentsdatabase = new List<Student>();
        public void Start()
        {
            while (true)
            {
                Console.WriteLine("Main Menu:");
                Console.WriteLine("[1] Store to ASEAN phonebook");
                Console.WriteLine("[2] Edit entry in ASEAN phonebook");
                Console.WriteLine("[1] Search ASEAN phonebook by country");
                Console.WriteLine("[1] Exit");

                Console.Write("Enter your choice: ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        studentinfo();
                        break;
                    case "2":
                        editinfo();
                        break;
                    case "3":
                        searchinfo();
                        break;
                    case "4":
                        Console.WriteLine("Exiting program.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
                Console.WriteLine();
            }
        }

        private void studentinfo()
        {
            string another_entry = "Y";

            do
            {
                Student student = new Student();

                Console.Write("Enter student number: ");
                int studentNumber;
                if (int.TryParse(Console.ReadLine(), out studentNumber))
                {
                    student.studentnumber = studentNumber;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                    continue;
                }

                Console.Write("Enter surname: ");
                student.surname = Console.ReadLine();

                Console.Write("Enter first name: ");
                student.firstname = Console.ReadLine();

                Console.Write("Enter occupation: ");
                student.occupation = Console.ReadLine();

                Console.Write("Enter gender: ");
                student.gender = Console.ReadLine().ToUpper();

                while (student.gender != "M" && student.gender != "F")
                {
                    Console.Write("Invalid input. Try again.");
                    student.gender = Console.ReadLine().ToUpper();
                }

                Console.Write("Enter country code: ");
                int countryCode;
                if (int.TryParse(Console.ReadLine(), out countryCode))
                {
                    student.countrycode = countryCode;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                    continue;
                }

                Console.Write("Enter area code: ");
                int areaCode;
                if (int.TryParse(Console.ReadLine(), out areaCode))
                {
                    student.areacode = areaCode;
                }
                else
                {
                    Console.WriteLine("Invalid input. Try again.");
                    continue;
                }

                Console.Write("Enter number: ");
                student.phonenumber = Console.ReadLine();

                Console.WriteLine("Data entered succesfully. ");

                Console.Write("Do you want another entry? Y/N: ");
                another_entry = Console.ReadLine();

                studentsdatabase.Add(student);
            } while (another_entry.ToUpper() == "Y");
        }

        private void editinfo()
        {
            Console.Write("Enter student number to edit: ");
            if (!int.TryParse(Console.ReadLine(), out int EditedStudentNumber))
            {
                Console.WriteLine("Invalid input. Please try again.");
                return;
            }
            Console.WriteLine($"Searching for student with number {EditedStudentNumber}...");

            bool ExistingStudent = CheckIfStudentExists(EditedStudentNumber);

            Console.WriteLine($"Student Exists :{ExistingStudent}");

            if (!ExistingStudent)
            {
                Console.WriteLine("Student with the provided number does not exist");
                return;
            }

            DisplayInformation(EditedStudentNumber);

            Console.WriteLine("Which of the following information do you wish to change : ");
            Console.WriteLine("[1] Student Number ");
            Console.WriteLine("[2] Surname ");
            Console.WriteLine("[3] Gender ");
            Console.WriteLine("[4] Occupation ");
            Console.WriteLine("[5] Country Code ");
            Console.WriteLine("[6] Area Code ");
            Console.WriteLine("[7] Phone Number");
            Console.WriteLine("[8] None - Go back to Main Menu ");

            Console.Write("Enter Your Choice : ");
            string Choices = Console.ReadLine();

            switch (Choices)
            {
                case "1":
                    Update(EditedStudentNumber, "Student Number ");
                    break;

                case "2":
                    Update(EditedStudentNumber, "Surname ");
                    break;

                case "3":
                    Update(EditedStudentNumber, "Gender ");
                    break;

                case "4":
                    Update(EditedStudentNumber, "Occupation ");
                    break;

                case "5":
                    Update(EditedStudentNumber, "Country Code ");
                    break;

                case "6":
                    Update(EditedStudentNumber, "Area Code ");
                    break;

                case "7":
                    Update(EditedStudentNumber, "Phone Number ");
                    break;

                case "8":
                    Console.WriteLine("Going back to the Main Menu.");
                    break;

                default:
                    Console.WriteLine("Invalid Choice. Going back to the Main Menu.")
                    break;
            }
        }
        private bool CheckIfStudentExists(int studentNumber)
        {
            return studentsdatabase.Any(student => student.studentnumber == studentNumber);
        }

        private void DisplayInformation(int studentNumber)
        {
            Student student = studentsdatabase.FirstOrDefault(s => s.studentnumber == studentNumber);

            if (student != null)
            {
                Console.WriteLine($"Here is the existing information about {student.studentnumber}:");
                Console.WriteLine($"{student.firstname} {student.surname} is a {student.occupation}. His/Her phone number is {student.phonenumber}");
            }
            else
            {
                Console.WriteLine("Student not found.");
            }
        }
        
        private void Update(int editstudentnum, string neweditinfo)
        {
            Console.Write($"Enter new {neweditinfo}: ");
            string neweditedinfo = Console.ReadLine();

            var studentupdating = studentsdatabase.Find(s => s.studentnumber == editstudentnum);

            if (studentupdating != null)
            {
                typeof(Student).GetProperty(neweditinfo)?.SetValue(studentupdating, Convert.ChangeType(neweditedinfo, typeof(Student).GetProperty(neweditinfo)?.PropertyType));
                Console.WriteLine($"{neweditinfo} updated successfully.");

                UpdatedInformation(editstudentnum);
            }
        }

        private void UpdatedInformation(int studentnum)
        {
            Console.WriteLine("This is now the updated information:");
            DisplayInformation(studentnum);
        }

        private void searchinfo()
        {
            Console.WriteLine("From which country: ");

            Console.WriteLine("[1] Philippines");
            Console.WriteLine("[2] Thailand");
            Console.WriteLine("[3] Singapore");
            Console.WriteLine("[4] Indonesia");
            Console.WriteLine("[5] Malaysia");
            Console.WriteLine("[6] All");
            Console.WriteLine("[0] No More");

            Console.Write("Enter choice: ");
            string countrychoice = Console.ReadLine();

            switch (countrychoice)
            {
                case "1":
                    Displayinfobycountrycode(63);
                    break;

                case "2":
                    Displayinfobycountrycode(66);
                    break;

                case "3":
                    Displayinfobycountrycode(65);
                    break;

                case "4":
                    Displayinfobycountrycode(62);
                    break;

                case "5":
                    Displayinfobycountrycode(60);
                    break;

                case "6":
                    Displayinfobycountrycode(63, 66, 65, 62, 60);
                    break;

                case "0":
                    Console.WriteLine("No more countries are to be included in the search");
                    break;

                default:
                    Console.WriteLine("Invalid input.");
                    break;
             }
        }

        private void Displayinfobycountrycode(params int[] country_code)
        {
             var studentscountry = studentsdatabase.Where(student => country_code.Contains(student.countrycode)).ToList();
             if (studentscountry.Count > 0)
             {
                Console.WriteLine($"Here are the students from your chosen country: ");

                foreach (var student in studentscountry)
                {
                    Console.WriteLine($"{student.firstname}, {student.surname}, with student number {student.studentnumber}, is a {student.occupation}. His/Her phone number is {student.phonenumber}.");

                }
             }
             else
             {
                Console.WriteLine("No students found in the chosen countries.");
             }
        }
        

        class Program_Tester
        {
            static void Main(string[] args)
            {
                StudentMainMenu studentmain = new StudentMainMenu();
                studentmain.Start();
            }
        }
    }
}