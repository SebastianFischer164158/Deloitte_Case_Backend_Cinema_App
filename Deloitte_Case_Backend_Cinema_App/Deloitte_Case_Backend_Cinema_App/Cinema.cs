using System;

namespace Deloitte_Case_Backend_Cinema_App
{
    public class Cinema
    {
        private readonly int _rows; 
        private readonly int _seats; //columns

        public int Capacity { get; } //no need for private set as only constructor can change Capacity
        private readonly int _low;
        private readonly int _high;
        private static Seat[,] _seatArray;
        public int NumberOfPurchasedTickets;
        
        public Cinema(int numberOfRows, int numberOfSeatsPerRow)
        {
            _rows = numberOfRows;
            _seats = numberOfSeatsPerRow;
            Capacity = _rows * _seats;
            _low = (int)Math.Floor((double) Capacity / 2);
            _high = (int)Math.Ceiling((double) Capacity / 2);
            _seatArray = new Seat[numberOfRows, numberOfSeatsPerRow];
            PopulateCinemaRoom(numberOfRows, numberOfSeatsPerRow);
        }

        public void BookSeat(int seatNumber)
        {
            //necessary logic to go from "1d" to 2d storing. 
            int column = seatNumber % _seats;
            int row = seatNumber / _seats;
            _seatArray[row, column].SeatStatus = 'R';
            NumberOfPurchasedTickets += 1;
        }
        
        private static void PopulateCinemaRoom(int numberOfRows, int numberOfSeatsPerRow)
        {
            int counter = 0;
            for (int iRow = 0; iRow < numberOfRows; iRow++)
            {
                for (int jSeat = 0; jSeat < numberOfSeatsPerRow; jSeat++)
                {
                    _seatArray[iRow, jSeat] = new Seat {SeatNumber = counter};
                    counter += 1;
                }
            }
        }
        
        public void OutputSeatsAndStatus()
        {
            for (var row = 0; row < _rows; row++)
            {
                for (var seat = 0; seat < _seats; seat++)
                {
                    Console.Write($"({_seatArray[row,seat].SeatNumber},{_seatArray[row,seat].SeatStatus})\t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public bool IsSeatOccupied(int seatNumber)
        {
            int column = seatNumber % _seats;
            int row = seatNumber / _seats;
            return _seatArray[row,column].SeatStatus == 'R';
        }

        public bool DoesSeatExist(int seatNumber)
        {
            int maxSeatNumber = _rows * _seats;
            return seatNumber < maxSeatNumber && seatNumber >= 0;
        }

        public decimal CalculatePercentageOccupied()
        {
            return (decimal)(100 * NumberOfPurchasedTickets) / (_rows*_seats);
        }
        
        public int CalculateCurrentIncome()
        {
            //could have put price logic in the booking as it would've made this part redundant
            int common_price = 10;
            int result = 0;

            if (Capacity<=50)
            {
                return NumberOfPurchasedTickets * common_price; //if capacity is 50 or below price is 10$ for all tickets
            }

            for (int i = 0; i < _rows; i++)
            {
                for (int j = 0; j < _seats; j++)
                {
                    int seatNumber = _seatArray[i, j].SeatNumber;
                    int seatStatus = _seatArray[i, j].SeatStatus;
                    if (seatStatus != 'R') continue;
                    if (seatNumber<= _low)
                    {
                        result += 12;

                    }
                    else if (seatNumber >= _high)
                    {
                        result += 10;
                    }
                }
            }
            return result;
        }
        
        public int PotentialTotalIncome()
        {
            if (Capacity <= 50)
            {
                return Capacity * 10;
            }
            return _high * 10 + _low * 12;
        }
    }
}