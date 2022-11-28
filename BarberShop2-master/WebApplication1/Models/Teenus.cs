using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Teenus
    {
        [Key]
        public int TeenusID { get; set; }
        public string Nimetus { get; set; }
        public int Hind { get; set; }
        [DataType(DataType.Time)]
        public DateTime Kestvus { get; set; }
    }
}
