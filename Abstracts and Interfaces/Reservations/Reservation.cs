using System;
using System.Collections.Generic;
using System.Text;

namespace Reservations
{
    public enum Days
    {
        MON = 1,
        TUE = 2,
        WED = 3,
        THU = 4,
        FRI = 5,
        SAT = 6,
        SAN = 7
    }
    public class Reservation : IReservationy
    {
        public string reservationCode;
        public string DOW;
        public string GetCodeBooking()
        {
            string bookingNumber = "";
            for (int i = 0; i < 8; i++)
            {
                bookingNumber += RandomCharGenerator();
            }
            return bookingNumber;
        }

        public char RandomCharGenerator()
        {
            string chars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            Random random = new Random();
            char x = chars[random.Next(0, chars.Length)];
            return x;
        }

        public string GetDowBooking()
        {
            // Random day generator
            Random random = new Random();
            int randomNumber = random.Next(1, 7);

            // Get a shortened date name based on the position in enum
            string dow = Enum.GetName(typeof(Days), randomNumber);

            return dow;
        }
    }
}
