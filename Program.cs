using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_final
{
    internal class Program
    {
        //Metodo 1: Validar Datos
        static bool validar_datos(double precio, double cantidad)
        {
            if (precio > 0 && cantidad > 0)
            {
                return true;
            }
            else 
            {
                Console.WriteLine("ALERTA: Precio o cantidad no validos.");
                return false;
            }
        }
        //Metodo 2: Buscar Orden
        static void BuscarOrden(string codigo, string[] codigos, string[] proveedores, double[] montos) 
        {
            bool encontrado = false;
            if (string.IsNullOrWhiteSpace(codigo)) 
            {
                Console.WriteLine("ERROR: La entrada esta vacia.");
                return;
            }
            for (int i = 0; i < codigos.Length; i++)
            {
                if (codigos[i].Equals(codigo.Trim(), StringComparison.OrdinalIgnoreCase)) 
                {
                    Console.WriteLine("¡¡¡ORDEN ENCONTRADA!!!");
                    Console.Write("Codigo: " + codigo[i]);
                    Console.WriteLine("Proveedor: " + proveedores[i]);
                    Console.WriteLine("Monto: $ " + montos[i].ToString("N2"));
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
            {
                Console.WriteLine("ERROR: Codigo no encontrado.");
            }
        }

        //METODO PRINCIPAL
        static void Main(string[] args)
        {
            const int N = 6;
            //ARREGLO DE CODIGOS
            string[] codigos = {
        "OC-101", "OC-102", "OC-103",
        "OC-104", "OC-105", "OC-106"
      };

            //ARREGLO DE PROVEEDORES
            string[] proveedores = {
        "TechCorp 1",
        "LogiExpress",
        "InsumosGlobal",
        "TechCorp 2",
        "AlfaSuministros",
        "ServiRedes"
      };

            //MATRIZ FINANCIERA
            //Columna 0: Precio unitario
            //Columna 1: Cantidad
            double[,] datos = {
        {150.0, 10},
        {450.0, 2},
        {80.0, 50},
        {1200.0, 1},
        {25.0, 100},
        {600.0, 3}
      };

            //VARIABLES Y ACUMULADORES
            double[] montos = new double[N];
            double totalGeneral = 0;
            int comprasCriticas = 0;
            Console.WriteLine("******************************************");
            Console.WriteLine("  CONTROL DE ORDENES DE COMPRA");
            Console.WriteLine("******************************************");

            //VALIDACION Y CALCULO DE MONTOS
            for (int i = 0; i < N; i++)
            {
                double precio = datos[i, 0];
                double cantidad = datos[i, 1];
                if (validar_datos(precio, cantidad))
                {
                    montos[i] = precio * cantidad;
                    totalGeneral += montos[i];
                    if (montos[i] > 1000)
                    {
                        comprasCriticas++;
                    }
                }
            }

            //ORDENAMIENTO BURBUJA
            for (int i = 0; i < N - 1; i++)
            {
                for (int j = 0; j < N - 1 - i; j++)
                {
                    if (montos[j] < montos[j + 1])
                    {
                        //INTERCAMBIAR MONTOS
                        double tempMonto = montos[j];
                        montos[j] = montos[j + 1];
                        montos[j + 1] = tempMonto;

                        //INTERCAMBIAR CODIGOS
                        string tempCodigo = codigos[j];
                        codigos[j] = codigos[j + 1];
                        codigos[j + 1] = tempCodigo;

                        //INTERCAMBIAR PROVEEDORES
                        string tempProveedor = proveedores[j];
                        proveedores[j] = proveedores[j + 1];
                        proveedores[j + 1] = tempProveedor;

                        //INTERCAMBIAR FILAS DE LA MATRIZ
                        for (int k = 0; k < 2; k++)
                        {
                            double temp = datos[j, k];
                            datos[j, k] = datos[j + 1, k];
                            datos[j + 1, k] = temp;
                        }
                    }
                }
            }

            //MOSTRAR REPORTE ORDENADO
            Console.WriteLine("\n*** REPORTE ORDENADO POR MONTO NETO ***");
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(
                  "{0}. Codigo: {1} | Prov: {2} | Monto: $ {3:N2}",
                  i + 1, codigos[i], proveedores[i], montos[i]
                );
            }
            //MOSTRAR METRICAS
            Console.WriteLine("\n******************************************");
            Console.WriteLine("METRICAS RESUMEN:");
            Console.WriteLine("Gran Total Acumulado: $ " +
              totalGeneral.ToString("N2"));
            Console.WriteLine("Compras Criticas (> $1,000): " +
              comprasCriticas + " ordenes");

            //BUSQUEDA POR CODIGO

            Console.WriteLine("\n******************************************");
            Console.Write("Ingrese el codigo que desea buscar: ");
            string codigoBuscar = Console.ReadLine();
            BuscarOrden(codigoBuscar, codigos, proveedores, montos);
            Console.WriteLine("\n****************************************");
            Console.WriteLine("     FIN DEL PROGRAMA");
            Console.WriteLine("******************************************");
            Console.ReadKey();
        }
            }
        }
    

