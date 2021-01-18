namespace Deloitte_Case_Backend_Cinema_App
{
    public class Seat
    {
        //probably should've just used a struct
        public int SeatNumber { get; set; }
        //Let's assume that initially everything is available, e.g. all seats are 'A'
        public char SeatStatus { get; set; } = 'A';
    }
}