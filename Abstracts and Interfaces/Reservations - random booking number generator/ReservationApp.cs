using System;
using System.Collections.Generic;
using System.Text;

namespace Reservations
{
    public class ReservationApp
    {
        
        static void Main(string[] args)
        {
            Reservation reservationSystem = new Reservation();
            reservationSystem.GetDowBooking();

            reservationSystem.RandomCharGenerator();

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Booking# {reservationSystem.GetCodeBooking()} for {reservationSystem.GetDowBooking()}");
            }
        }
    }
}
