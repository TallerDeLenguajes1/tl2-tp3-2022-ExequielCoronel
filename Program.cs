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
            int salir = 0;
            Cadeteria cad1 = new Cadeteria("LS",467895);
            Cliente c1 = new Cliente("","Cordoba Mario",3819874345,"Av. Roca 1600", 01);
            string RutaArchivoCSV = @"C:\Users\execo\Escritorio\Universidad\3ero\2doCuatrimestre\TallerDeLenguajesII\Practica\TPN3\cadetes.csv";
            var reader = new StreamReader(File.OpenRead(RutaArchivoCSV));
            while(!reader.EndOfStream)
            {
                string lines = reader.ReadLine();
                string [] datos = lines.Split(";");
                long ID = (long) datos[0]; 
                uint telefono = (uint) datos[3];
                Cadete cadeteNuevo = new Cadete(ID,datos[1],datos[2],telefono);
                cad1.AgregarCadete(cadeteNuevo);
            }
            do 
            {
                System.Console.WriteLine("Seleccione una opcion: \n\t1=Dar de alta un pedido\n\t 2=asignar un pedido a un cadete\n\t 3=cambiar estado a un pedido\n\t 4=Cambiar de cadete un pedido\n\t 0=Salir");

                switch (opcion)
                {

                }
                System.Console.WriteLine("Desea salir del programa? 1=SI, Cualquier tecla=NO");
                salir = Convert.ToInt32(Console.ReadLine());
                if(salir == 1)
                {
                    System.Console.WriteLine("Esta seguro? 1=SI, Cualquier tecla=NO, Volver al menu principal");
                    salir = Convert.ToInt32(Console.ReadLine());
                    if(salir == 1)
                    {
                        salir = -1;
                    }
                } else if(salir == -1) {
                    salir = 0; 
                }
            }while(salir!=-1);
            

        }
    }
}
