using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Tellimus
    {
        [Key]
        public int TellimusID { get; set; }
        public int TootajaID { get; set; }
        public Tootaja? Tootaja { get; set; }
        public int TeenusID { get; set; }
        public Teenus? Teenus { get; set; }
        
        public string? email { get; set;}

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Kuupaev { get; set; }
        [DataType(DataType.Time)]
        public DateTime Aeg { get; set; }

    }
}
