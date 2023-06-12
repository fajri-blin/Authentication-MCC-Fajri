using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Authentication
{
    public class EvenOdd
    {
        private static Menu menu = new Menu();
        public static void PrintEvenOdd(int limit, string choice)
        {
            // menampilkan urutan bilangan sampai pada limitnya
            Console.WriteLine($"Print bilangan 1 - {limit} : ");
            //
            if (limit > 0)
            {
                // menentukan jenis urutan bilangan antara ganjil atau genap
                int pilihan = (choice == "ganjil") ? 1 : (choice == "genap") ? 0 : 3;
                switch (pilihan)
                {
                    case 0:
                        for (int i = 2; i <= limit; i += 2)
                        {
                            Console.Write(i + ",");
                        }
                        break;
                    case 1:
                        for (int i = 1; i <= limit; i += 2)
                        {
                            Console.Write(i + ",");
                        }
                        break;
                    case 3:
                        Console.Write("Input pilihan tidak valid");
                        break;
                }
            }
            else
            {
                Console.Write("Input limit tidak valid");
            }
            Console.WriteLine("");
        }

        public static string EvenOddCheck(int input)
        {
            if (input > 0)
            {
                if (input % 2 == 0)
                {
                    return "Genap";
                }
                else
                {
                    return "Ganjil";
                }
            }
            else
            {
                return "Invalid Input !!!";
            }
        }
    }
}
