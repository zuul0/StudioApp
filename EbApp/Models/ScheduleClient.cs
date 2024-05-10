
using SQLite;
namespace EbApp.Models
{

    public class ScheduleClient
    {

        [PrimaryKey, AutoIncrement, Column("Id")]
        public int Id { get; set; }

        public int IdClient { get; set; }

        public int IdClass { get; set; }
    }
}
