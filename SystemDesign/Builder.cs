using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;


// Builder real time example
namespace SystemDesign
{
    //Product
    public class Computer
    {
        public string CPU { get; set; }
        public string RAM { get; set; }
        public string HardDrive { get; set; }
        public string GraphicsCard { get; set; }
        public string SoundCard { get; set; }


        public void DisplaySpecifications()
        {
            Console.WriteLine("The specifications are : ");
            Console.WriteLine($"CPU: {CPU}");
            Console.WriteLine($"RAM: {RAM}");
            Console.WriteLine($"Hard Drive: {HardDrive}");
            Console.WriteLine($"Graphics Card: {GraphicsCard ?? "Not present"}");
            Console.WriteLine($"Sound Card: {SoundCard ?? "Not present"}");
        }
    }

    //Builder (Abstract)
    public abstract class ComputerBuilder
    {
        protected Computer Computer { get; private set; }  = new Computer();
        public abstract void SetCPU();
        public abstract void SetRAM();
        public abstract void SetHardDrive();
        public virtual void SetGraphicsCard() { } // Optional
        public virtual void SetSoundCard() { }    // Optional
        public Computer GetComputer() => Computer;


    }

    public class GamingComputerBuilder : ComputerBuilder
    {
        public override void SetCPU()
        {
            Computer.CPU = "High Performance CPU";
        }
        public override void SetRAM()
        {
            Computer.RAM = "16 GB DDR4";
        }
        public override void SetHardDrive()
        {
            Computer.HardDrive = "1 TB SSD";
        }
        public override void SetGraphicsCard()
        {
            Computer.GraphicsCard = "High-end Graphics Card";
        }
        public override void SetSoundCard()
        {
            Computer.SoundCard = "7.1 Surround Sound Card";
        }

    }

    //Director
    public class ComputerShop
    {
        public void ConstructComputer(ComputerBuilder builder)
        {
            builder.SetCPU();
            builder.SetRAM();
            builder.SetHardDrive();
            builder.SetGraphicsCard();
            builder.SetSoundCard();
        }
    }

    // client code
    // testing the builder Design Pattern
    public class Builder
    {
        public static void Main()
        {
            ComputerShop shop = new ComputerShop();
            ComputerBuilder builder = new GamingComputerBuilder();

            shop.ConstructComputer(builder);
            Computer computer = builder.GetComputer();
            computer.DisplaySpecifications();
            Console.ReadKey();
        }
    }
}

