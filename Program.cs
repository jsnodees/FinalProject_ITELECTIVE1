using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject
{


    public class Student
    {
        public int student { get; set; }
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

                Console.WriteLine("Enter your choice: ");
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
                student.gender = Console.ReadLine();

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

                Console.Write("Enter country code: ");
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

        class Program_Tester
        {
            static void Main(string[] args)
            {
                StudentMainMenu studentmain = new StudentMainMenu();
                studentmain.Start();
            }
        }
    }