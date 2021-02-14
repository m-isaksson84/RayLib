using System;
using System.Numerics;
using System.Linq;
using System.Collections.Generic;

namespace GFX
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("skriv vilket tal som helst, efter det kommer programmet visa alla tal upp till det tal du valt som kan divideras med 3.");
            string input = Console.ReadLine();
            
            int value = int.Parse(input);

            // Metoden anropas, nums blir behållaren för det som GetDivide returnerar.
            int[] nums = GetDivide(value);

            // Här skapas metoden och definierar datatypen som används samt variabeln "max" som är användarens input.
            static int[] GetDivide(int max)
            {   
            
            // Här skapas en lista som skapar x antal behållare beroende på användarens input (max).
            List<int> ListDivide = new List<int>() {max};
            
            // Här räknar programmet alla 3-tal mellan 0 och det angivna maxvärdet.
            for (int i = 0; i < max+1; i += 3)
            {
                // Här skrivs alla talen ut och 
                //Console.WriteLine(i);
                ListDivide.Add(i);
            }

            int[] GetDivide = ListDivide.ToArray();
            return GetDivide;
        }

        for (int i = 0; i < nums.Length; i++)
            {
                Console.WriteLine(nums[i]);
            }

        Console.ReadLine();
        }
    }
}
