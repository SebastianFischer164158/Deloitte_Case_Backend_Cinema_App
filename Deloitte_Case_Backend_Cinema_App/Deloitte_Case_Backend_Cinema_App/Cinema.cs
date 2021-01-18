using System;

namespace Deloitte_Case_Backend_Cinema_App
{
    public class Cinema
    {
        private readonly int _rows; 
        private readonly int _seats; //columns
        
        private static Seat[,] _seatArray;
        public Cinema(int numberOfRows, int numberOfSeatsPerRow)
        {
            _rows = numberOfRows;
            _seats = numberOfSeatsPerRow;
            Capacity = _rows * _seats;
            _seatArray = new Seat[numberOfRows, numberOfSeatsPerRow];
            PopulateCinemaRoom(numberOfRows, numberOfSeatsPerRow);
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