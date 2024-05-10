using System;
using SQLite;

namespace EbApp.Models
{
    [Table("Appointments")]

    public class Appointment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public DateTime DateClass { get; set; }
        public TimeSpan TimeClass { get; set; }
        public int NumOfSeats { get; set; }
        public int TrainerId { get; set; }
    }
}
