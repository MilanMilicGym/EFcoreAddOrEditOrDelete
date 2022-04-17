using System;
using System.Linq;
using EFcoreAddOrEditOrDelete.Entities;

namespace EFcoreAddOrEditOrDelete
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
            Console.WriteLine("Bye!");
        }

        private static bool MainMenu()
        {
            Console.WriteLine("Promena  Employee... ");
            Console.WriteLine();
            Console.WriteLine("1) Dodaj novi Employee: ");
            Console.WriteLine("2) Izmeni postojeci Employee: ");
            Console.WriteLine("3) Obrisi postojeci Employee: ");

            Console.WriteLine("0) Izadji iz aplikacije: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddEmployee();
                    HitAnyKey();
                    return true;
                case "2":
                    EditEmployee();
                    HitAnyKey();
                    return true;
                case "3":
                    DeleteEmployee();
                    HitAnyKey();
                    return true;
                default:
                    return false;

            }
        }
        private static void EditEmployee()
        {
            Console.Clear();
            Console.WriteLine("Unesite ID korisnika: ");

          
            
            using (var db = new NorthwindContext())
            {
               var employeeId = Console.ReadLine();

                var employee = db.Employees.FirstOrDefault(x => x.EmployeeId ==int.Parse (employeeId));
                if (employee == null)
                {
                    Console.WriteLine("ID nije pronadjen...");

               
                }

                Console.WriteLine("IzmeniFirst Name (y/n)? ");
                if (Console.ReadLine() == "y")
                {
                    Console.WriteLine("Unesite novu vrednost: ");
                    employee.FirstName = Console.ReadLine();
                  

                }

                Console.WriteLine("Izmeni Last Name (y/n)? ");
                if (Console.ReadLine() == "y")
                {
                    employee.LastName = Console.ReadLine();
                   
                }
                db.Update(employee);
                db.SaveChanges();
                }
            }
                private static void AddEmployee ()
        { 
            Console.Clear ();   
            Console.WriteLine("Dodaj novi Employee... ");
            using (var db = new NorthwindContext())
            {
                Console.WriteLine("Dodaj Last name employee: ");

              
                var employeeLastName = Console.ReadLine();

                Console.WriteLine("Dodaj First name employee: ");

                
                var employeeFirstName = Console.ReadLine();

                Console.WriteLine("Dodaj  city employee: ");

               
               var  employeeCity = Console.ReadLine();

                var newEmployee = new Employee ();

                newEmployee.FirstName = employeeFirstName;
                newEmployee.LastName = employeeLastName;
                newEmployee.City = employeeCity;

                db.Employees.Add (newEmployee);
                db.SaveChanges();

            }
        }
        private static void DeleteEmployee ()
        {
            Console.Clear();
            using (var db = new NorthwindContext())
            {
                Console.WriteLine("Upisi ID employee kojeg zelis da izbrises: ");
                var employeeId = Console.ReadLine();

                var employee = db.Employees.FirstOrDefault(x => x.EmployeeId == int.Parse(employeeId));
                if (employee == null)
                {
                    Console.WriteLine("ID nije pronadjen...");

                    return;
                }
                db.Remove(employee);
                db.SaveChanges ();
            }
        }
        public static void HitAnyKey ()
        {
            Console.WriteLine("Prtisni bilo koje dugme... ");
            Console.ReadLine();
        }
    }
}
