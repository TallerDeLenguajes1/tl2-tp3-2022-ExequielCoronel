using System.Collections.Generic;
namespace CadeteriaTPN3
{
    class Cadeteria
    {
        string Nombre;
        uint Telefono;
        List<Cadete> Cadetes = new List<Cadete>();

        Cadeteria(string Nombre, uint Telefono)
        {
            this.Nombre = Nombre;
            this.Telefono = Telefono;
        }

        public void AgregarCadete(Cadete c)
        {
            this.Cadetes.Add(c);
        }

    }
}