using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Dexter
{
    internal class Program
    {
        static int vagasok(char[,] table)
        {
            int vagasok = 0;

            int magassag = 0;

            // Kezdo magassag
            for (int i = 0; i < table.GetLength(0); i++)
            {
                if (table[i,0] == '.')
                {
                    magassag = i;
                }
            }

            // Számlálás
            for (int i = 0; i < table.GetLength(1); i++)
            {
                for (int z = 0; z < table.GetLength(0); z++)
                {
                    if (table[z,i] == 'O')
                    {

                        //Console.Write($"{i}. {magassag} : ");
                        Console.WriteLine(vagasok);
                        int g = (magassag - z) * (-1);

                        if (g >= 0)
                        {
                            vagasok += g;
                        }
                        else
                        {
                            vagasok += g * (-1);
                        }

                        /*
                         if (magassag > z)
                        {
                            vagasok += magassag - z;
                        }
                        else if (magassag == z)
                        {
                            vagasok += 0;
                        }
                        else if (magassag< z)
                        {
                            vagasok += z - magassag;
                        }



                        
                        Console.WriteLine($"{vagasok} = ({magassag} - {z}) * -1");
                         */

                        //Console.WriteLine(z);
                        Console.WriteLine($"{vagasok} = ({magassag} - {z}) * -1");
                        //Console.WriteLine($"{i}. {vagasok}");

                        //Console.WriteLine($"{vagasok} = ({magassag} - ({i}*(-1))");
                        magassag = z;
                        break;          
                    }

                    //Console.WriteLine(vagasok);

                }
            }
            /*
            for (int i = 0; i < table.GetLength(0); i++)
            {
                for (int z = 0; z < table.GetLength(1); z++)
                {
                    if (table[i, z] == 'O')
                    {
                        vagasok += magassag - z;

                        magassag = z;
                        Console.WriteLine(vagasok);

                        break;
                    }
                }
            }
            */
            return vagasok;
        }


        static void Main()
        {
            using (StreamReader sr = new StreamReader("input.txt"))
            {
                bool a = true;
                int sorszam = 0;
                while (a)
                {
                    string line = sr.ReadLine();
                    if (line == null) { a = false;}
                    else
                    {
                        string[] darab = line.Split(' ');
                        int n = int.Parse(darab[0]);
                        int m = int.Parse(darab[1]);

                        if (n > 0 && m > 0 && n < 100 && m < 100)
                        {
                            char[,] table = new char[n, m];

                            for (int i = 0; i < n; i++)
                            {
                                string sor = sr.ReadLine();

                                for (int z = 0; z < m; z++)
                                {
                                    table[i, z] = sor[z];
                                }
                            }
                            Console.Write($"{sorszam}. tábla vágás szám: ");
                            Console.WriteLine();
                            Console.WriteLine(vagasok(table));
                            
                        }
                        else
                        {
                            Console.WriteLine("A tábla túl nagy!");
                            for (int i = 0; i < n; i++)
                            {
                                sr.ReadLine();
                            }
                        }
                    }
                    sorszam++;
                }
            }

            Console.ReadKey();
        }
    }
}
