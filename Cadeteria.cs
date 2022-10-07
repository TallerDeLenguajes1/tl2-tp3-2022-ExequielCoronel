using System.Collections.Generic;
namespace CadeteriaTPN3
{
    class Cadeteria
    {
        string Nombre;
        uint Telefono;
        List<Cadete> Cadetes = new List<Cadete>();

        public Cadeteria(string Nombre, uint Telefono)
        {
            this.Nombre = Nombre;
            this.Telefono = Telefono;
        }

        public bool ExisteCadete(long ID)
        {
            foreach (var Cadete in this.Cadetes)
            {
                if(Cadete.getID()==ID)
                {
                    return true;
                }
            }
            return false;
        }

        public Cadete buscarCadete(long ID)
        {
            foreach (var Cadete in Cadetes)
            {
                if(Cadete.getID() == ID)
                {
                    return Cadete;
                }
            }
            return null;
        }

        public bool EliminarCadete(long ID)
        {
            foreach (var Cadete in Cadetes)
            {
                if(Cadete.getID()==ID)
                {
                    Cadetes.Remove(Cadete);
                    return true;
                }
            }
            return false;
        }
        public void AgregarCadete(Cadete c)
        {
            this.Cadetes.Add(c);
        }

    }
}