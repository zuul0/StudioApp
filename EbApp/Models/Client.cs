using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace EbApp.Models
{
      
  
        public class Client
       {
            [PrimaryKey, AutoIncrement]
            public int IdClient { get; set; }
            public string Surname { get; set; }
            public string Lastname { get; set; }
            public string Patronymic { get; set; }
            public string Email { get; set; }
        }

     
}
