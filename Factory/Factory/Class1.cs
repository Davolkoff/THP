using System;
using ElectricalAppliances;
using System.Collections.Generic;

namespace Factory
{
    public interface ICalculator
    {
        int CalculatingConsumption();
    }
    public class ProductCalculator : ICalculator
    {
        private static List<Drill> listDrills = new List<Drill>();
        public static int indInstrument = -1;
        public void InitCalculator()
        {
            if (listDrills.Count == 0)
            {
                Drill makita = new Drill();
                ElectricalAppliancesFactory factory = new ElectricalAppliancesFactory();
                makita = factory.ProvideDrill();
                listDrills.Add(makita);
            }
        }
        
        public string[] GetInstruments()
        {
            string[] mas = new string[listDrills.Count];
            for (int i = 0; i < listDrills.Count; i++)
            {
                mas[i] = String.Format("{0} - {1}", listDrills[i].Name, listDrills[i].Price);
            }
            return mas;
        }
        public Drill GetInstrument()
        {
            Drill drill = listDrills[indInstrument];
            return drill;
        }
        public void DeleteInstrument(int index)
        {
            listDrills.RemoveAt(index);
        }
        public int CalculatingConsumption()
        {
            int totalConsumption = 0;
            foreach (Drill drill in listDrills){
                totalConsumption += drill.Consumption;
            }
            return totalConsumption;
        }

        public void AddingInstrument(string name, int price, int consumption, int power, string type, int maxChuk, int numSpeed)
        {
            listDrills.Add(new Drill() { 
                Name = name,
                Price = price,
                Consumption = consumption,
                Power = power,
                TypeOfPowerSupply = type,
                MaxChukSize = maxChuk,
                NumberOfSpeeds = numSpeed
            });
        }
        public void EditInstrument(string name, int price, int consumption, int power, string type, int maxChuk, int numSpeed)
        {
            Drill drill = new Drill()
            {
                Name = name,
                Price = price,
                Consumption = consumption,
                Power = power,
                TypeOfPowerSupply = type,
                MaxChukSize = maxChuk,
                NumberOfSpeeds = numSpeed
            };
            listDrills[indInstrument] = drill;
        }
    }
    public class ElectricalAppliancesFactory
    {
        public Drill ProvideDrill()
        {
            Drill drill = new Drill();
            drill.Name = "Makita HP1630";
            drill.Price = 5361;
            drill.Description = "Дрель Makita HP1630 оснащена ключевым патроном, что гарантирует надёжное закрепление оснастки.";
            drill.Consumption = 730;
            drill.Power = 710; ;
            drill.TypeOfPowerSupply = "От разетки. Длина кабеля 2 м.";
            drill.MaxChukSize = 13;
            drill.NumberOfSpeeds = 1;
            return drill;
        }
    }
}
