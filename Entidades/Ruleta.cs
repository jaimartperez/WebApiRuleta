using System;
using System.Collections.Generic;

namespace WebApiRuleta.Entidades
{
    public class Ruleta
    {
        public string Id { get; set; }
        public Estado Estado { get; set; }
        public List<Apuesta> LstApuestas { get; set; }
        public Ruleta()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
