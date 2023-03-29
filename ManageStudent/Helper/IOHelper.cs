using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ManageStudent.Helper
{
    internal static class IOHelper
    {
       public static int InputNumber(string fieldName)
        {
            int number;
            while (true)
            {
                Console.Write($"Nhap {fieldName}: ");
                var text = Console.ReadLine();

                if (int.TryParse(text, out number))
                    break;
                else
                    Console.WriteLine($"{fieldName} chi nhap so. Vui long nhap lai: ");
            }

            return number;
        }

    }
}
