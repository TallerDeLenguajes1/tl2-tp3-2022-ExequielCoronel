namespace CadeteriaTPN3
{
    class Persona
    {
        protected long ID;
        protected string Nombre;
        protected string Direccion;
        protected uint Telefono;

        public Persona()
        {
            ID = 0;
            Nombre = "";
            Direccion = "";
            Telefono = 0;
        }

        public Persona(long ID, string Nombre, string Direccion, uint Telefono)
        {
            this.ID = ID;
            this.Nombre = Nombre;
            this.Direccion = Direccion;
            this.Telefono = Telefono;
        }
    }
}