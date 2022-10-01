using System;
using System.Collections.Generic;

namespace CadeteriaTPN3
{
    class Cadete:Persona
    {

        List<Pedido> Pedidos;

        Cadete(long ID, string Nombre, string Direccion, uint Telefono):base(ID, Nombre, Direccion, Telefono)
        {
            Pedidos = new List<Pedido>();
        }

        public void AgregarPedido(Pedido p)
        {
            Pedidos.Add(p);
        }
        public float JornalACobrar()
        {
            float total = 0;
           foreach (var item in Pedidos)
           {
                if(item.ComprobarEstadoPedido())
                {
                    total = total + item.PagoPorPedidoEntregado;
                }
           }
           return total;
        }
    }
}