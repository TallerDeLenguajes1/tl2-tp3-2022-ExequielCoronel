namespace Cadeteria
{
    class Pedido
    {
        public const float PagoPorPedidoEntregado = 300;
        bool Estado;
        uint Numero;
        string Observacion;
        Cliente cliente;

        public Pedido(bool estado, uint Numero, string Observacion, string Nombre, long ID, uint telefono, string Direccion, string DatosDeReferencia)
        {
            Estado = estado;
            this.Numero = Numero;
            this.Observacion = Observacion;
            Cliente cliente = new Cliente(DatosDeReferencia, Nombre, telefono, Direccion, ID);
        }

        public bool ComprobarEstadoPedido()
        {
            return Estado;
        }
        public void EliminarPedido()
        {
            this.Numero = -1;
            this.Observacion = "";
            this.Estado = null;
            delete cliente;
        }
    }
}