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
            MenuHandler(cinema);
        }

        private static void MenuHandler(Cinema cinema)
        {
            bool userExit = false;
            while (!userExit)
            {
                Console.WriteLine("------------------ MENU ------------------");
                Console.WriteLine("Press 1 to buy a Ticket");
                Console.WriteLine("Press 2 to show seats and their status");
                Console.WriteLine("Press 3 to output metrics for the cinema room");
                Console.WriteLine("Press 4 to exit and close the app");
                Console.WriteLine("------------------------------------------");
                string userChoice = Console.ReadLine();

                switch (userChoice)
                {
                    case "1":
                        Console.WriteLine("------------ You pressed 1 --------------");
                        if (cinema.NumberOfPurchasedTickets == cinema.Capacity)
                        {
                            Console.WriteLine("The cinema is fully booked!");
                            break;
                        }
                        int userSeat = GetSeatInput(cinema);
                        cinema.BookSeat(userSeat);
                        break;
                    case "2":
                        Console.WriteLine("------------ You pressed 2 --------------");
                        cinema.OutputSeatsAndStatus();
                        break;
                    case "3":
                        Console.WriteLine("------------ You pressed 3 --------------");
                        decimal percentageOccupied = cinema.CalculatePercentageOccupied();
                        Console.WriteLine($"Number of purchased tickets: {cinema.NumberOfPurchasedTickets}\n" +
                                          $"Percentage currently occupied: {percentageOccupied:N3}%\n" +
                                          $"Current Income (Sum of Reserved Tickets): {cinema.CalculateCurrentIncome()}\n" + 
                                          $"Potential total income: {cinema.PotentialTotalIncome()}\n");
                        break;
                    case "4":
                        Console.WriteLine("------------ You pressed 4 --------------");
                        Console.WriteLine("------------    EXITING    --------------");
                        userExit = true;
                        break;
                    
                    default:
                        Console.WriteLine("Wrong option entered - Please pick one between 1 <-> 4");
                        break;
                }
            }
        }

        private static int GetSeatInput(Cinema cinema)
        {
            int seatNumber = 0;
            bool validSeatInput = false;
            while (!validSeatInput)
            {
                Console.WriteLine($"Please enter a seat number between 0 and {cinema.Capacity - 1}");
                string seatInput = Console.ReadLine();
                if (!int.TryParse(seatInput, out seatNumber) || !cinema.DoesSeatExist(seatNumber))
                {
                    Console.WriteLine("The entered seat does not exist, please try again.");
                }
                else if (cinema.IsSeatOccupied(seatNumber))
                {
                    Console.WriteLine("The entered seat is already booked! Pick another available seat!");
                }
                else
                {
                    validSeatInput = true;
                }
            }
            return seatNumber;
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