using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel
{
    class Hotel
    {
        public int Id { get; }
        public string Name { get; }
        private List<Room> Rooms { get; }

        public Hotel(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Hotel adı mütləqdir!");

            Id = ++Id;
            Name = name;
            Rooms = new List<Room>();
        }

        public void AddRoom(Room room)
        {
            Rooms.Add(room);
        }

        public List<Room> FindAllRooms(Func<Room, bool> predicate)
        {
            return Rooms.Where(predicate).ToList();
        }

        public void MakeReservation(int? roomId, int guestCount)
        {
            if (roomId == null)
                throw new NullReferenceException("Room ID null ola bilməz!");

            Room room = Rooms.FirstOrDefault(r => r.Id == roomId);

            if (room == null)
                throw new ArgumentException("Göstərilən ID ilə otaq tapılmadı!");

            if (!room.IsAvailable)
                throw new NotAvailableException("Otaq artıq rezerv edilib!");

            if (guestCount > room.PersonCapacity)
                throw new ArgumentException("Müştəri sayı otağın tutumundan çox ola bilməz!");

            room.Reserve();
        }
    }
}
}
