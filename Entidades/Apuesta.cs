using System.ComponentModel.DataAnnotations;

namespace WebApiRuleta.Entidades
{
    public class Apuesta
    {
        public string Usuario { get; set; }
        [Range(0, 10000)]
        public double MontoApuesta { get; set; }
        [Range(0, 36)]
        public int NumeroApuesta { get; set; }
        public Color ColorApuesta { get; set; }
    }
}
