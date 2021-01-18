using System;

namespace Deloitte_Case_Backend_Cinema_App
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("------------------ Backend Case App ------------------");
            (int numberOfRows, int numberOfSeatsPerRow) =  GetInitialRowsAndSeats();
            Cinema cinema = new Cinema(numberOfRows, numberOfSeatsPerRow);
            
            Console.WriteLine($"You entered:\nRows: {numberOfRows} \nSeats per row: {numberOfSeatsPerRow}\n");
        }

        private static (int , int) GetInitialRowsAndSeats()
        {
            Console.WriteLine("Please enter the number of rows: ");
            string rowInput = Console.ReadLine();
            int numberOfRows;

            while (!int.TryParse(rowInput, out numberOfRows) || numberOfRows<=0)
            {
                Console.WriteLine("The entered input is not a valid number of rows, please try again.");
                rowInput = Console.ReadLine();
            }

            Console.WriteLine("Please enter the number of seats per row: ");
            string seatsInput = Console.ReadLine();
            int numberOfSeatsPerRow;
            
            while (!int.TryParse(seatsInput, out numberOfSeatsPerRow) || numberOfSeatsPerRow<=0)
            {
                Console.WriteLine("The entered input is not a valid number of seats, please try again.");
                seatsInput = Console.ReadLine();
            }
            return (numberOfRows, numberOfSeatsPerRow);
        }
    }
}