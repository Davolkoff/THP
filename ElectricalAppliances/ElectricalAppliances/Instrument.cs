using System;

namespace ElectricalAppliances
{
    public abstract class AbstractInstrument
    {
        protected string name;  // Название 
        protected int price;  // Цена
        protected string description; // Описание

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public int Price
        {
            get { return price; }
            set { price = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
    }

    public class MeasurementInstrument : AbstractInstrument
    {
        protected string measuringRange;  // Диапазон измерений
        public string MeasuringRange
        {
            get { return measuringRange; }
            set { measuringRange = value; }
        }
    }

    public abstract class ElectricalTool : AbstractInstrument
    {
        protected int consumption; // Потребление энергии
        protected int power; // Мощность
        protected string typeOfPowerSupply; // Тип питания
        public int Consumption
        {
            get { return consumption; }
            set { consumption = value; }
        }
        public int Power
        {
            get { return power; }
            set { power = value; }
        }
        public string TypeOfPowerSupply
        {
            get { return typeOfPowerSupply; }
            set { typeOfPowerSupply = value; }
        }
    }
    public class Drill : ElectricalTool
    {
        protected int maxChukSize; // Максимальный размер патрона
        protected int numberOfSpeeds; // Число скоростей
        public int MaxChukSize
        {
            get { return maxChukSize; }
            set { maxChukSize = value; }
        }
        public int NumberOfSpeeds
        {
            get { return numberOfSpeeds; }
            set { numberOfSpeeds = value; }
        }
    }
}
