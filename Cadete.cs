using System;
using System.Collections.Generic;

namespace CadeteriaTPN3
{
    class Cadete:Persona
    {

        List<Pedido> Pedidos;

        public Cadete(long ID, string Nombre, string Direccion, uint Telefono):base(ID, Nombre, Direccion, Telefono)
        {
            Pedidos = new List<Pedido>();
        }

        public void cambiarEstadoPedido(uint NumeroPedido)
        {
            Pedido pedidoAcambiarEstado;
            foreach (var item in Pedidos)
            {
                if(item.getNumeroPedido() == NumeroPedido)
                {
                    pedidoAcambiarEstado = item;
                    Pedidos.Remove(item);
                    pedidoAcambiarEstado.cambiarEstadoPedido();
                    Pedidos.Add(pedidoAcambiarEstado);
                }
            }
        }

        public void EliminarPedidoAsignado(uint numeroPedido)
        {
            foreach (var item in Pedidos)
            {
                if(item.getNumeroPedido()==numeroPedido)
                {
                    Pedidos.Remove(item);
                }
            }
        }

        public Pedido obtenerPedido(uint numeroPedido)
        {
            foreach (var item in Pedidos)
            {
                if(numeroPedido == item.getNumeroPedido())
                {
                    return item;
                }
            }
            return null;
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
                    total = total + 300;
                }
           }
           return total;
        }

        public long getID()
        {
            return ID;
        }
    }
}