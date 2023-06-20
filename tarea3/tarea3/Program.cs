using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tarea3
{
    //*******El patrón Bridge se utiliza para separar la abstracción de una compra
    //*******de su implementación del medio de pago.



    // Implementación
    // La implementación define la interfaz para todas las clases de implementación.
    // No tiene que coincidir con la interfaz de Abstraction. Las dos interfaces pueden ser
    // completamente diferentes. Por lo general, la interfaz de implementación proporciona solo
    // operaciones primitivas, mientras que la abstracción define operaciones de nivel superior basadas
    // en esas primitivas.


    // interface: Básicamente nos permiten definir un "contrato"
    // sobre el que podemos estar seguros de que, las clases que las implementen, lo van a cumplir.
    interface IMedioPago
    {
        void RealizarPago(double monto);
    }

    // Implementaciones concretas de la interfaz
    // Cada Implementación Concreta corresponde a una plataforma específica e implementa la interfaz
    // de Implementación utilizando la API de esa plataforma.
    class PagoEfectivo : IMedioPago
    {
        public void RealizarPago(double monto)
        {
            Console.WriteLine($"Realizando pago en efectivo por un monto de {monto}");
        }
    }

    class PagoTarjeta : IMedioPago
    {
        public void RealizarPago(double monto)
        {
            Console.WriteLine($"Realizando pago con tarjeta por un monto de {monto}");
        }
    }

    // Abstracción
    // La abstracción define la interfaz para la parte de "control" de las dos jerarquías de clases.
    // Mantiene una referencia a un objeto de la jerarquía de implementación y delega todo el trabajo
    // real a este objeto.
    abstract class Compra
    {
        protected IMedioPago medioPago;

        public Compra(IMedioPago medioPago)
        {
            this.medioPago = medioPago;
        }

        public abstract void ProcesarCompra(double monto);
    }

    // Clases concretas de la abstracción
    // Puede extender la Abstracción sin cambiar las clases de Implementación.
    class Producto : Compra
    {
        public Producto(IMedioPago medioPago) : base(medioPago)
        {
        }

        public override void ProcesarCompra(double monto)
        {
            Console.WriteLine("Realizando compra de un producto");
            medioPago.RealizarPago(monto);
        }
    }

    class Servicio : Compra
    {
        public Servicio(IMedioPago medioPago) : base(medioPago)
        {
        }

        public override void ProcesarCompra(double monto)
        {
            Console.WriteLine("Contratando un servicio");
            medioPago.RealizarPago(monto);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            //Creamos los objetos de implementación concreta
            IMedioPago pagoEfectivo = new PagoEfectivo();
            IMedioPago pagoTarjeta = new PagoTarjeta();

            // Creamos los objetos de abstracción con diferentes implementaciones
            Compra compraProducto = new Producto(pagoEfectivo);
            Compra compraServicio = new Servicio(pagoTarjeta);

            //Procesamos las compras utilizando diferentes medios de pago
            compraProducto.ProcesarCompra(50.0);
            compraServicio.ProcesarCompra(100.0);

            Console.ReadLine();
        }
    }
}
