// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using System.IO;
using System;
namespace CadeteriaTPN3
{
    class Program
    {
        static void Main(string[] args)
        {
            int salir = 0, opcion;
            Cadeteria cad1 = new Cadeteria("LS",467895);
            Cliente c1 = new Cliente("","Cordoba Mario",3819874345,"Av. Roca 1600", 01);
            List<Pedido> ListadoPedidos = new List<Pedido>();
            string RutaArchivoCSV = @"C:\Users\execo\Escritorio\Universidad\3ero\2doCuatrimestre\TallerDeLenguajesII\Practica\TPN3\cadetes.csv";
            var reader = new StreamReader(File.OpenRead(RutaArchivoCSV));
            while(!reader.EndOfStream)
            {
                string lines = reader.ReadLine();
                string [] datos = lines.Split(";");
                long ID = Convert.ToInt32(datos[0]); 
                uint telefono = Convert.ToUInt32(datos[3]);
                Cadete cadeteNuevo = new Cadete(ID,datos[1],datos[2],telefono);
                cad1.AgregarCadete(cadeteNuevo);
            }
            do 
            {
              try
              { 
                System.Console.WriteLine("Seleccione una opcion: \n\t1=Dar de alta un pedido\n\t 2=asignar un pedido a un cadete\n\t 3=cambiar estado a un pedido\n\t 4=Cambiar de cadete un pedido\n\t 0=Salir");
                opcion = Convert.ToInt32(Console.ReadLine());
                switch (opcion)
                {
                    case 0:
                        System.Console.WriteLine("Esta seguro? 1=SI, 0=NO, Volver al menu principal");
                        salir = Convert.ToInt32(Console.ReadLine());
                        if(salir == 1)
                        {
                            salir = -1;
                        }
                        break;
                    case 1:
                        uint Numero, TelefonoCliente;
                        long IDCliente;
                        string Observacion, NombreCliente, DireccionCliente, DatosDeReferenciaCliente;
                        System.Console.WriteLine("Ingrese el numero de Pedido: ");
                        Numero = Convert.ToUInt32(Console.ReadLine());
                        System.Console.WriteLine("Ingrese las observaciones del pedido: ");
                        Observacion = Console.ReadLine();
                        System.Console.WriteLine("Ingrese el nombre del cliente: ");
                        NombreCliente = Console.ReadLine();
                        System.Console.WriteLine("Ingrese el ID del cliente: ");
                        IDCliente = Convert.ToInt32(Console.ReadLine());
                        System.Console.WriteLine("Ingrese el telefono del cliente: ");
                        TelefonoCliente = Convert.ToUInt32(Console.ReadLine());
                        System.Console.WriteLine("Ingrese la direccion del cliente: ");
                        DireccionCliente = Console.ReadLine();
                        System.Console.WriteLine("Ingrese datos de referencia a la direccion del cliente: ");
                        DatosDeReferenciaCliente = Console.ReadLine();
                        Pedido nuevoPedido = new Pedido(Numero, Observacion, NombreCliente, IDCliente, TelefonoCliente, DireccionCliente, DatosDeReferenciaCliente);
                        ListadoPedidos.Add(nuevoPedido);
                        break;
                    case 2:
                        uint NumeroPedido;
                        long IdCadete;
                        Pedido PedidoAasignar = new Pedido();
                        System.Console.WriteLine("Ingrese el Numero de pedido: ");
                        NumeroPedido = Convert.ToUInt32(Console.ReadLine());
                        if(ExistePedido(ListadoPedidos,NumeroPedido))
                        {
                            foreach (var item in ListadoPedidos)
                            {
                                if(item.getNumeroPedido() == NumeroPedido)
                                {
                                    PedidoAasignar = item;
                                }
                            }
                        }
                        System.Console.WriteLine("Ingrese el ID del cadete a asignar el pedido");
                        IdCadete = Convert.ToInt32(Console.ReadLine());
                        if(cad1.ExisteCadete(IdCadete))
                        {
                            Cadete CadeteSeleccionado;
                            CadeteSeleccionado=cad1.buscarCadete(IdCadete);
                            cad1.EliminarCadete(IdCadete);
                            CadeteSeleccionado.AgregarPedido(PedidoAasignar);
                            cad1.AgregarCadete(CadeteSeleccionado);
                        }
                        break;
                    case 3:
                        uint NumeroPedidoACambiarEst;
                        long IDCadete;
                        System.Console.WriteLine("Ingrese el Numero de pedido: ");
                        NumeroPedidoACambiarEst = Convert.ToUInt32(Console.ReadLine());
                        System.Console.WriteLine("Ingrese el ID del cadete encargado de entregar el pedido: ");
                        IDCadete = Convert.ToInt32(Console.ReadLine());
                        if(cad1.ExisteCadete(IDCadete))
                        {
                            Cadete CadeteEncargadoDelPedido;
                            CadeteEncargadoDelPedido = cad1.buscarCadete(IDCadete);
                            CadeteEncargadoDelPedido.cambiarEstadoPedido(NumeroPedidoACambiarEst);
                        }
                        break;
                    case 4:
                        long IDCadeteOrigen, IdCadeteDestino;
                        uint NumeroPedidoACambiarCadete;
                        System.Console.WriteLine("Ingrese el numero del pedido: ");
                        NumeroPedidoACambiarCadete = Convert.ToUInt32(Console.ReadLine());
                        System.Console.WriteLine("Ingrese el ID del cadete que tiene asignado el pedido: ");
                        IDCadeteOrigen = Convert.ToInt32(Console.ReadLine());
                        System.Console.WriteLine("Ingres el ID del cadete al cual se le asignara el pedido: ");
                        IdCadeteDestino = Convert.ToInt32(Console.ReadLine());
                        if(cad1.ExisteCadete(IDCadeteOrigen) && cad1.ExisteCadete(IDCadeteOrigen))
                        {
                            Cadete CadeteOrigen, CadeteDestino;
                            Pedido pedidoAcambiar;
                            CadeteOrigen = cad1.buscarCadete(IDCadeteOrigen);
                            CadeteDestino = cad1.buscarCadete(IdCadeteDestino);
                            pedidoAcambiar=CadeteOrigen.obtenerPedido(NumeroPedidoACambiarCadete);
                            CadeteDestino.AgregarPedido(pedidoAcambiar);
                        }
                        break;
                    default:
                        break;
                }
              }
                catch(Exception e)
              {
                    System.Console.WriteLine($"Mensaje de error: {e.Message}");
              }
            }while(salir!=-1);
            

        }

        public static bool ExistePedido(List<Pedido> ListadoPedidos, uint NumeroPedido)
        {
            foreach (var Pedido in ListadoPedidos)
            {
                if(Pedido.getNumeroPedido() == NumeroPedido)
                {
                    return true;
                }
            }
            return false;
        }
    }
}



