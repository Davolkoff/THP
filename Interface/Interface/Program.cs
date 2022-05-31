using System;
using ElectricalAppliances;
using Factory;

namespace Interface
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of drills: ");
            int numberOfDrills = Convert.ToInt32(Console.ReadLine());
            ProductCalculator calculator = new ProductCalculator();
            Console.WriteLine(String.Format("Total power consumption is {0}",calculator.CalculatingConsumption()));
            
            Console.ReadLine();
        }
    }
}
