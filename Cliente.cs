namespace CadeteriaTPN3
{
    class Cliente : Persona
    {
        string DatosReferenciaDireccion;
        
        public Cliente(string DatosReferenciaDireccion, string Nombre, uint Telefono, string Direccion, long ID):base(ID, Nombre, Direccion, Telefono)
        {
            this.DatosReferenciaDireccion = DatosReferenciaDireccion;
        }
    }
}