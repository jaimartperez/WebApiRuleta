using System.Collections.Generic;
using System.Linq;
using WebApiRuleta.Entidades;

namespace WebApiRuleta.Models
{
    public class Repositorio
    {
        public static List<Ruleta> lstRuletas = new List<Ruleta>()
        {
            new Ruleta {Estado = Estado.abierto,
                LstApuestas = new List<Apuesta>(){ new Apuesta { Usuario = "J", MontoApuesta = 200, NumeroApuesta = 2, ColorApuesta = Color.negro} }
                }
        };
        public IEnumerable<Ruleta> ObtenerRuletas()
        {
            return lstRuletas;
        }
        public Ruleta ObtenerRuleta(string id)
        {
            return lstRuletas.Where(x => x.Id == id).FirstOrDefault();
        }
        public bool IniciarApuestas(string id)
        {
            Ruleta objRuleta = lstRuletas.Where(x => x.Id == id).FirstOrDefault();
            objRuleta.Estado = Estado.abierto;
            return true;
        }
        public List<Apuesta> CerrarApuestas(string id)
        {
            Ruleta objRuleta = lstRuletas.Where(x => x.Id == id).FirstOrDefault();
            objRuleta.Estado = Estado.cerrado;
            return objRuleta.LstApuestas;
        }
        public string CrearRuleta()
        {
            Ruleta objRuleta = new Ruleta();

            lstRuletas.Add(objRuleta);

            return objRuleta.Id;
        }
        public void CrearApuesta(string id, Apuesta objApuesta)
        {
            Ruleta objRuleta = lstRuletas.Where(x => x.Id == id).FirstOrDefault();
            objRuleta.LstApuestas.Add(objApuesta);
        }
    }
}
