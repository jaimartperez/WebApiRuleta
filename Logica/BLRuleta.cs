using System.Collections.Generic;
using WebApiRuleta.AccesoDatos;
using WebApiRuleta.Entidades;
namespace WebApiRuleta.Negocio
{
    public class BLRuleta
    {
        public IEnumerable<Ruleta> ObtenerRuletas()
        {
            List<Ruleta> lstRuleta = new DLRuleta().ConsultarRuletas();
            foreach (var item in lstRuleta)
            {
                item.LstApuestas = new DLApuesta().ConsultarApuestaIdRuleta(item.Id);
            }
            return lstRuleta;
        }
        public Ruleta ObtenerRuletaID(int id)
        {
            Ruleta objRuleta = new DLRuleta().ConsultarRuletaID(id);
            if (objRuleta != null)
                objRuleta.LstApuestas = new DLApuesta().ConsultarApuestaIdRuleta(objRuleta.Id);

            return objRuleta;
        }
        public int CrearRuleta()
        {
            return new DLRuleta().CrearRuleta(new Ruleta());
        }
        public bool CrearApuesta(Apuesta objApuesta)
        {
            bool rta = false;
            Ruleta objRuleta = new DLRuleta().ConsultarRuletaID(objApuesta.IdRuleta);
            if (objRuleta.Estado == Estado.abierto)
            {
                new DLApuesta().CrearApuesta(objApuesta);
                rta = true;
            }

            return rta;
        }
        public bool IniciarRuleta(int id)
        {
            bool rta = false;
            Ruleta objRuleta = new DLRuleta().ConsultarRuletaID(id);
            if (objRuleta != null)
            {
                new DLRuleta().CambiarEstadoRuleta(objRuleta);
                rta = true;
            }

            return rta;
        }
        public List<Apuesta> CerrarRuleta(int id)
        {
            Ruleta objRuleta = new DLRuleta().ConsultarRuletaID(id);
            objRuleta.Estado = Estado.cerrado;
            new DLRuleta().CambiarEstadoRuleta(objRuleta);

            return new DLApuesta().ConsultarApuestaIdRuleta(id);
        }
    }
}
