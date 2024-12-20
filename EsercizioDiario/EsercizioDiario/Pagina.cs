using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility;

namespace EsercizioDiario
{
    internal class Pagina : Entity
    {
        public DateTime DataGiorno { get; set; }
        public double CoordinataX { get; set; }
        public double CoordinataY { get; set; }
        public string Luogo {  get; set; }
        public string Descrizione { get; set; }

        public Pagina() { }

        public override string ToString()
        {
            return base.ToString() + $"Data Giorno: {DataGiorno} \nCoordinata X: {CoordinataX} \nCoordinata Y: {CoordinataY} \nLuogo: {Luogo} \nDescrizione: {Descrizione}\n";
        }

    }
}
