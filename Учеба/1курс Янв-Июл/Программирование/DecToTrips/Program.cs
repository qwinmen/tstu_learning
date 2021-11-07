using System;
using System.Globalization;

namespace DecToTrips
{
    class Program
    {
        static void Main()
        {
            string trip="";
            while (trip != "12345")
            {
            Console.WriteLine("Введите число:");
            trip = Console.ReadLine();// 2*9 + 1*3 + 0 = 21
            int intTrip;
            while (!int.TryParse(trip, NumberStyles.Any, CultureInfo.CurrentCulture, out intTrip))
            {//На выходе int intTrip = Convert.ToInt32(trip) или Ошибка
                Console.WriteLine("Error: Wrong input!");
                Console.Write("Try again: ");
                trip = Console.ReadLine();
            }
                if (DecOrTrip(trip))
                    //true
                    Console.WriteLine(DecToTrip(intTrip) + "-троичное десятичное-" + TripToDec(intTrip));
                else
                    Console.WriteLine(DecToTrip(intTrip) + "-троичное");
                //Console.WriteLine(DecOrTrip(trip));//DecToTrip(intTrip)
            }
        }
        
        // перевод из троичной в десятичную
        private static int TripToDec(int value)
        {
            int res = 0, k = 1;
            while (value > 0)
            {
                res += (value % 10) * k;
                value /= 10;
                k *= 3;
            }
            return res;
        }

        // перевод из десятичной в троичную
        private static int DecToTrip(int value)
        {
            int res = 0, k = 1;
            while (value > 0)
            {
                res = res + (value % 3) * k;
                k *= 10;
                value /= 3;
            }
            return res;
        }
        private static bool DecOrTrip(string Strip)
        {//Определение выходного результата для входного числа
            //string Strip = "123412";
            char[] CharArrey = Strip.ToCharArray();
            bool ad=false;
            foreach (char ch in CharArrey)
            {
                if (ch <= '2')//()
                    ad=true;//Dec and Trip
                else if(ch>='3')
                    ad = false;//Only Dec
            }
            return ad;
        }
    }
}
