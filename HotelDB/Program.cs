using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new HotelContext())
            {
                // Lav øvelser her!
                //1.List full details of all Hotels
                var allHotels = 
                    from b in db.Hotel
                    orderby b.Hotel_No
                    select b;

                Console.WriteLine("Full details of all hotels in the database:");
                foreach (var item in allHotels)
                {
                    Console.WriteLine("{0}, {1}, {2}", item.Hotel_No, item.Name, item.HotelAddress);
                }

                //2.List full details of all hotels in Roskilde
                var detailsRoskilde =
                    from b in db.Hotel
                    where b.HotelAddress.Contains("Roskilde")
                    select b;

                Console.WriteLine("\nFull details of hotels in Roskilde:");
                foreach (var item in detailsRoskilde)
                {
                    Console.WriteLine("{0}, {1}, {2}", item.Hotel_No, item.Name, item.HotelAddress);
                }

                //3.List hotel no and the hotels room numbers and room price for the individual room sorted by hotel no
                var roomNumbersAndPrice =
                    from room in db.Room
                    group room by room.Hotel_No;

                Console.WriteLine("\nAll hotels numbers with room numbers and price");
                foreach (var items in roomNumbersAndPrice)
                {
                    Console.WriteLine(items.Key);
                    foreach (var r in items)
                    {
                        Console.WriteLine("    Room # {0}, Price: {1}", r.Room_No, r.Price);
                    }

                }

                //4.List Guest Name, Room no, Hotel name and Booking date for the Guests with the name Goeg and Gokke
                string goeg = "Goeg";
                string gokke = "Gokke";

                var GoegOgGokke =
                    from a in db.Booking
                    join booking in db.Guest on a.Guest_No equals booking.Guest_No
                    join hotel in db.Hotel on a.Hotel_No equals hotel.Hotel_No
                    where a.Guest.Name == goeg || a.Guest.Name == gokke orderby a.Guest.Name ascending 
                    select new {a, hotel, booking};

                Console.WriteLine("\nBookings by Goeg and Gokke:");
                foreach (var v in GoegOgGokke)
                {
                    Console.WriteLine("{0} has booked room # {1} in {2} on the {3}", v.a.Guest.Name, v.a.Room_No, v.hotel.Name, v.a.Date_From);
                }

                //5.List the average price of a room ?
                var averagePriceOfRoom =
                    from a in db.Room
                    let price = a.Price
                    select price;

                var averagePrice = averagePriceOfRoom.Average();
                Console.WriteLine("\nThe average price of a room is: {0}", averagePrice);

                //6.List the average price of a single room ?

                var averagePriceSingleRoom =
                    from a in db.Room
                    where a.Types.Contains("S")
                    let price = a.Price
                    select price;

                var averagePriceSingle = averagePriceSingleRoom.Average();
                Console.WriteLine("\nThe average price of a single room is: {0}", averagePriceSingle);

                //7.List the price and type of all rooms at 'Prindsen'. using inner - join

                var allRoomsPrindsen =
                    from a in db.Room
                    join hotel in db.Hotel on a.Hotel_No equals hotel.Hotel_No
                    where a.Hotel.Name == "Prindsen"
                    select new {a, hotel,};

                Console.WriteLine("\nType and price of all rooms at Prindsen:");
                foreach (var v in allRoomsPrindsen)
                {
                    Console.WriteLine("Room type {0} with a price of: {1}", v.a.Types, v.a.Price);
                }

                

                Console.ReadKey();
            }
        }
    }
}
