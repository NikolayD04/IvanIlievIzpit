using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer;

namespace PresentationLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Choose();              
        }
        public static void Choose()
        {
            while (true)
            {
                Console.WriteLine("Choose Database to Change");
                Console.WriteLine("1) Company\n2) Game\n3) Person\n4) Exit");
                int choice = int.Parse(Console.ReadLine());
            
                switch (choice)
                {
                    case 1:
                        CompanyInteract.Start();
                        break;
                    case 2:
                        GameInteract.Start();
                        break;
                    case 3:
                        PersonInteract.Start();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("No such option");
                        break;
                }

            }
        }
    }
}
