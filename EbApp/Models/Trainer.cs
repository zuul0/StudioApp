using SQLite;
using System;
using System.Collections.Generic;
using System.Text;


namespace EbApp.Models
{

    public class Trainer 
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string PhoneNumber { get; set; }
        public string  Direction { get; set; }
        public byte[] Photo { get; set; }
    }
}

