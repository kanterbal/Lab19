using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab19
{
    class Computer
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string ProcessorType { get; set; }
        public double ProcessorFrequency { get; set; }
        public int MemoryCapacity { get; set; }
        public int HDDCapacity { get; set; }
        public int VideoCapacity { get; set; }
        public double Cost { get; set; }
        public int Stock { get; set; }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Computer> listComputer = new List<Computer>()
            {
                new Computer(){Code="314G1EA", Name="HP ZBook 15 Studio G8", ProcessorType="Intel Core i7",ProcessorFrequency=4800, MemoryCapacity=32, HDDCapacity=1024, VideoCapacity=6, Cost=272500, Stock = 3 },
                new Computer(){Code="119X5EA", Name="HP ZBook 15 Fury 15 G7", ProcessorType="Intel Core i7",ProcessorFrequency=5100, MemoryCapacity=32, HDDCapacity=1024, VideoCapacity=6, Cost=247400, Stock = 3},
                new Computer() { Code = "1J3S1EA", Name = "HP ZBook 15 Create G7", ProcessorType = "Intel Core i7", ProcessorFrequency = 5000, MemoryCapacity = 32, HDDCapacity = 1024, VideoCapacity = 8, Cost = 234590, Stock = 3},
                new Computer() { Code = "119W0EA", Name = "HP ZBook 15 Fury 17 G7", ProcessorType = "Intel Core i7",ProcessorFrequency = 5000, MemoryCapacity = 32, HDDCapacity = 1024, VideoCapacity = 4, Cost = 232760, Stock = 3},
                new Computer() { Code = "358W0EA", Name = "HP Elite Dragonfly G2", ProcessorType = "Intel Core i7",ProcessorFrequency = 4700, MemoryCapacity = 32, HDDCapacity = 2048, VideoCapacity =  0, Cost = 195200, Stock = 3},
                new Computer() { Code = "2C9N0EA", Name = "HP ZBook Power G7", ProcessorType = "Intel Xeon",ProcessorFrequency = 5100, MemoryCapacity = 16, HDDCapacity = 512, VideoCapacity = 4,Cost = 186720, Stock = 30}
    };
            Console.Write("Tip processora: ");
            string processorType = Console.ReadLine();

            List<Computer> computers = (from d in listComputer
                                        where d.ProcessorType == processorType
                                        select d).ToList();

            foreach (Computer comp in computers)
            {
                Console.WriteLine($"{comp.Code} {comp.Name} {comp.Cost} {comp.Stock}");
            }
            Console.WriteLine("...");
            Console.Write("OZU ne nize: ");
            int capacityMemory = Convert.ToInt32(Console.ReadLine());

            computers = (from d in listComputer
                         where d.MemoryCapacity >= capacityMemory
                         select d).ToList();

            foreach (Computer comp in computers)
            {
                Console.WriteLine($"{comp.Code} {comp.Name} {comp.MemoryCapacity} {comp.Cost} {comp.Stock}");
            }
            Console.WriteLine("...");
            Console.WriteLine("Sortirovka po cene");

            computers = (from d in listComputer
                         orderby d.Cost ascending
                         select d).ToList();

            foreach (Computer comp in computers)
            {
                Console.WriteLine($"{comp.Code} {comp.Name} {comp.Cost}");
            }
            Console.WriteLine("...");
            Console.WriteLine("Grupirovka po tipu processora");
            var groupComputers = (from d in listComputer
                                 group d by d.ProcessorType).ToList();

            foreach (var i in groupComputers)
            {
                Console.WriteLine(i.Key);
                foreach (var j in i)
                {
                    Console.WriteLine($"{j.Code} {j.Name} {j.Cost}");
                }
            }

            double max = listComputer.Max(m => m.Cost);
            computers = (from d in listComputer
                         where d.Cost == max
                         select d).ToList();
            
            Console.WriteLine("...");
            Console.WriteLine("Samjij dorogoj kompjuter");
            foreach (Computer comp in computers)
            {
                Console.WriteLine($"{comp.Code} {comp.Name} {comp.Cost} {comp.Stock}");
            }
            double min = listComputer.Min(m => m.Cost);
            computers = (from d in listComputer
                         where d.Cost == min
                         select d).ToList();
            Console.WriteLine("...");
            Console.WriteLine("Samjij bjudzetnjij kompjuter");
            foreach (Computer comp in computers)
            {
                Console.WriteLine($"{comp.Code} {comp.Name} {comp.Cost} {comp.Stock}");
            }

            Console.WriteLine("...");
            Console.WriteLine("Nalicie na sklade kompjutera v kolicestve ne menee 30 stuk");
            bool countThirty = listComputer.Any(c => c.Stock >= 30);
            if (countThirty)
            {
                Console.WriteLine("Da");
            }
            else
            {
                Console.WriteLine("Net");
            }


            
            Console.ReadKey();
        }
    }
}
