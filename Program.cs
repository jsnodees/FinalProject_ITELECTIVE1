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
    }