/*

Shemelin Pavel

1

Реализовать простейшую хэш-функцию.

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        /// <summary>
        /// хеш-код строки
        /// </summary>
        /// <param name="st">исходная строка</param>
        /// <param name="multi">произвольный множитель</param>
        /// <param name="t_size">размер получаемого ключа = максимальное значение типа UInt64</param>
        /// <returns></returns>
        static UInt64 MakeHash( string st, uint multi = 75, UInt64 t_size = UInt64.MaxValue )
        {
            UInt64 hash = 0;
            foreach (char item in st)
            {
                hash = multi * hash + (uint)item;
            }
            return hash % t_size;
        }

        static void Main( string[] args )
        {
            string val = "Реализовать простейшую хэш-функцию. На вход функции подается строка, на выходе получается сумма кодов символов.";
            Console.WriteLine( $"Строка: {val}" );
            Console.WriteLine( $"Хэш-код: {MakeHash( val ).ToString()}" );

            Console.WriteLine();

            val = "Реализовать простейшую хэш-функцию. На вход функции подается строка, на выходе получается сумма кодов символов!";
            Console.WriteLine( $"Строка: {val}" );
            Console.WriteLine( $"Хэш-код: {MakeHash( val ).ToString()}" );

            Console.ReadKey();
        }
    }
}
