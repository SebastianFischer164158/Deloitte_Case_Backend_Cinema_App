using System;

namespace Deloitte_Case_Backend_Cinema_App
{
    public class Cinema
    {
        private readonly int _rows; 
        private readonly int _seats; //columns
        
        private static Seat[,] _seatArray;
        public int NumberOfPurchasedTickets;
        
        public Cinema(int numberOfRows, int numberOfSeatsPerRow)
        {
            _rows = numberOfRows;
            _seats = numberOfSeatsPerRow;
            Capacity = _rows * _seats;
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
        }
    }
}