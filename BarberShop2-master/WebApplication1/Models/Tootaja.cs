using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Tootaja
    {
        [Key]
        public int TootajaID { get; set; }
        public string? Nimi { get; set; }
        public int Vanus { get; set; }
        public string? Epost { get; set; }
        public string? Telefoninumber { get; set; }
        public string? haridus { get; set; }
    }
}
