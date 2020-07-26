using System.Collections.Generic;
using System.Linq;
using WebApiRuleta.AccesoDatos;
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
        public List<Apuesta> CerrarApuestas(int id)
        {
            Ruleta objRuleta = lstRuletas.Where(x => x.Id == id).FirstOrDefault();
            objRuleta.Estado = Estado.cerrado;
            return objRuleta.LstApuestas;
        }
        public int CrearRuleta()
        {
            DLRuleta dlRuleta = new DLRuleta();
            return dlRuleta.CrearRuleta(new Ruleta());
        }
        public bool IniciarApuestas(int id)
        {
            Ruleta objRuleta = lstRuletas.Where(x => x.Id == id).FirstOrDefault();
            objRuleta.Estado = Estado.abierto;
            return true;
        }
        public Ruleta ConsultarRuleta(int id)
        {
            DLRuleta dlRuleta = new DLRuleta();

            return lstRuletas.Where(x => x.Id == id).FirstOrDefault();
        }
        public void CrearApuesta(int id, Apuesta objApuesta)
        {
            Ruleta objRuleta = lstRuletas.Where(x => x.Id == id).FirstOrDefault();
            objRuleta.LstApuestas.Add(objApuesta);
        }
    }
}
