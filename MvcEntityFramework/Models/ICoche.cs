using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcEntityFramework.Models
{
    public interface ICoche
    {
        string Marca { get; set; }
        string Modelo { get; set; }
        string Imagen { get; set; }
        int Velocidad { get; set; }
        int VelocidadMaxima { get; set; }
        void Acelerar();
        void Frenar();
    }
}
