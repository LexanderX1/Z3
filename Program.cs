using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
namespace _1
{      
    class Program
    {
        static void Main(string[] args)
        {
            int BufferMas = 0;
            int number = 0;
            if (args.Length >= 3 & args.Length % 2 != 0)
            {
                for (int a = 1; a < args.Length; a++)
                {
                    if (args[BufferMas] == args[a])
                    {
                        Console.WriteLine("Duplicate error");
                        Environment.Exit(0);
                    }
                    if ( args[BufferMas] != args[BufferMas + 1])
                    {
                        BufferMas++;
                        a = BufferMas;
                    }
                }
            }
            else
            {
                Console.WriteLine("Even number of lines entered or less than 3");
                Environment.Exit(0);
            }


            string key;
            byte[] random = new Byte[16];
            var generator = RandomNumberGenerator.Create();
            generator.GetBytes(random);
            key = BitConverter.ToString(random).Replace("-", string.Empty).ToLower();
            

            int sch = 1;
            int lenght = args.Length;
            int pol = lenght / 2;
            Random rnd = new Random();
            int value = rnd.Next(1, args.Length + 1);

            
                byte[] bkey = Encoding.Default.GetBytes(key);
            var hmac = new HMACSHA1(bkey);
                
                    byte[] bstr = Encoding.Default.GetBytes(args[value-1]);
                    var bhash = hmac.ComputeHash(bstr);

            Console.WriteLine("HMAC    "+ BitConverter.ToString(bhash).Replace("-", string.Empty).ToLower());



            Console.WriteLine("Available moves:");

            Console.WriteLine("0" + " - " + "Exit");
            foreach (var s in args)
            {
                Console.WriteLine(sch + " - " + s.ToString());
                sch++;
            }
            Console.Write("Enter your move:");
            number = Convert.ToInt32(Console.ReadLine());
            while (number > args.Length)
            {

                Console.WriteLine("нет данных");
                Console.Write("Enter your move:");

                number = Convert.ToInt32(Console.ReadLine());
            }
            if (number == 0)
            {
                Console.WriteLine("GAME OVER");
                Environment.Exit(0);
               
            }
         
            int zn=number;
            int zn2 = value;
            int zn3 = number;
            int zn4 = value;



            Console.WriteLine("Your move:  "  + args[number - 1]);
            Console.WriteLine("Computer move:  " + args[value - 1]);


            for (int i = 0; i <= pol; i++)
            {


                if (zn == zn2 & i == 0)
                {
                    Console.WriteLine("DRAW");
                    i = pol + 1;
                }
                else
                if (zn == zn2)
                {
                    Console.WriteLine("GAME OVER");
                    i = pol + 1;
                }
              else
                    if(zn3 == zn4)
                {
                    Console.WriteLine("YOU WIN");
                    i = pol + 1;
                }


                if (zn3 == 1)
                    zn3 = args.Length;
                else
                    zn3--;

                if (zn == args.Length)
                    zn = 1;
                else
                zn++;

            }


            Console.WriteLine("KEY  "+ key);





        }


    }
    }
