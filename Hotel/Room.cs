using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Room
    {
        public int Id { get; }
        public string Name { get; }
        public decimal Price { get; }
        public int PersonCapacity { get; }
        public bool IsAvailable { get; private set; }
        public Room(string name, decimal price, int personCapacity)
        {
            if (string.IsNullOrEmpty(name) || price <= 0 || personCapacity <= 0)
                throw new ArgumentException();

            Id = ++Id;
            Name = name;
            Price = price;
            PersonCapacity = personCapacity;
            IsAvailable = true;
        }
        public string ShowInfo()
        {
            return $"Room ID: {Id}, Name: {Name}, Price: {Price}, Capacity: {PersonCapacity}, Available: {IsAvailable}";
        }

        public override string ToString()
        {
            return ShowInfo();
        }

        public void Reserve()
        {
            if (!IsAvailable)
                throw new NotAvailableException("Bu otaq artıq rezerv edilib!");
            IsAvailable = false;
        }

    }
}

