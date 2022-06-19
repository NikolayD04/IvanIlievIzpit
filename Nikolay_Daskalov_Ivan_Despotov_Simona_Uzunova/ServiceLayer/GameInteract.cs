using BusinessLayer;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public static class GameInteract
    {
        private static readonly GameContext ctx = DBContextManager.GetGameContext();
        public static void Start()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Game Interaction Menu!");
                Console.WriteLine("Choose option:");
                Console.WriteLine("1) Create\n2) Read\n3) ReadAll\n4) Update\n5) Delete");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        Create();
                        break;
                    case 2:
                        Read();
                        break;
                    case 3:
                        ReadAll();
                        break;
                    case 4:
                        Update();
                        break;
                    case 5:
                        Delete();
                        break;
                    default:
                        Console.WriteLine("No such option");
                        Start();
                        break;
                }
            }
        }
        public static void Create()
        {
            //Change 
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Release price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Release Date:");
            string date = Console.ReadLine();
            Game item = new Game(name, price, date);
            ctx.Create(item);
        }
        public static void Read()
        {
            Console.WriteLine("ID: ");
            string id = Console.ReadLine();
            Game item = ctx.Read(id);
            Console.WriteLine(item.ToString());
            Console.ReadKey();
        }
        public static void ReadAll()
        {
            List<Game> items = (List<Game>)ctx.ReadAll();
            foreach (Game item in items)
            {
                Console.WriteLine(item.ToString());
            }
            Console.ReadKey();
        }
        public static void Update()
        {
            //Change
            Console.WriteLine("ID: ");
            string id = Console.ReadLine();
            Console.WriteLine("Name: ");
            string name = Console.ReadLine();
            Console.WriteLine("Release price: ");
            decimal price = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Release Date:");
            string date = Console.ReadLine();
            Game item = new Game(id, name, price, date);
            ctx.Update(item);
        }
        public static void Delete()
        {
            Console.WriteLine("ID: ");
            string id = Console.ReadLine();
            ctx.Delete(id);
        }
    }
}
