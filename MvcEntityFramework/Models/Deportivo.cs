using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Models
{
    public class Deportivo: Coche, ICoche
    {
        public Deportivo (string marca, string modelo, string imagen, int velocidadmaxima)
        {
            this.Marca = marca;
            this.Modelo = modelo;
            this.Imagen = imagen;
            this.VelocidadMaxima = velocidadmaxima;
            this.Velocidad = 0;
        }
        public Deportivo()
        {
            this.Marca = "Pontiac";
            this.Modelo = "Firebard";
            this.Imagen = "pontiac.jpg";
            this.Velocidad = 0;
            this.VelocidadMaxima = 240;
        }
    }
}
