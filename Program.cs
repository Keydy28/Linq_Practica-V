using System;
using System.Linq;
using System.Collections.Generic;


namespace Linq_Practica_V
{
    class Program
    {
        static void Main(string[] args)
        {

            ProductoCategoria PC = new ProductoCategoria();
            foreach (var item in PC.ListarProductos())
            {
                Console.WriteLine("Id {0}, Nombre {1} con CategoriaID {2}, Marca {3} con Modelo {4} y Precio {5} ",
                    item.Id, item.Nombre, item.CategoriaID, item.Marca, item.Modelo, item.Precio);
            }
            Console.WriteLine("\n\nEsta lista muestra los productos con un precio mayor  a 3000 y ordenado de manera descendente");
            foreach (var item in PC.OrdenarPrecioDescendente())
            {
                Console.WriteLine("Id {0}, Nombre {1} con CategoriaID {2}, Marca {3} con Modelo {4} y Precio {5} ",
                    item.Id, item.Nombre, item.CategoriaID, item.Marca, item.Modelo, item.Precio);
            }
           
           
            Console.WriteLine("\n\nEsta lista muestra los productos con el JOIN");
            foreach (var item in PC.CategoriaJoin())
            {
                Console.WriteLine("Producto {0}, Marca {1} con Modelo {2}, Precio {3} con Categoria {4} ",
                    item.NombreProducto, item.Marca, item.Modelo, item.Precio, item.NombreCategoria);
            }
        }
    }
    public class ProductoCategoria
    {
        public List<Productos> ListaProducto;
        public List<Categoria> ListaCategoria;
        public ProductoCategoria()
        {
            ListaProducto = new List<Productos>();
            ListaCategoria = new List<Categoria>();

            ListaCategoria.Add(new Categoria { Id = 1, Nombre = "Electronicos" });
            ListaCategoria.Add(new Categoria { Id = 2, Nombre = "Papeleria" });
            ListaCategoria.Add(new Categoria { Id = 3, Nombre = "Sonido" });
            ListaCategoria.Add(new Categoria { Id = 4, Nombre = "Tintas" });
            ListaCategoria.Add(new Categoria { Id = 5, Nombre = "Ascesorios" });

            ListaProducto.Add(new Productos { Id = 1, Nombre = "Laptop", CategoriaID = 1, Marca = "HP", Modelo = "Pavillion", Precio = 20000 });
            ListaProducto.Add(new Productos { Id = 2, Nombre = "PC Escritorio", CategoriaID = 1, Marca = "DELL", Modelo = "Satelite", Precio = 25000 });
            ListaProducto.Add(new Productos { Id = 3, Nombre = "Bocinas", CategoriaID = 3, Marca = "Logitech", Modelo = "FS1500", Precio = 5000 });
            ListaProducto.Add(new Productos { Id = 4, Nombre = "Toner", CategoriaID = 4, Marca = "DELL", Modelo = "RF2000", Precio = 3000 });
            ListaProducto.Add(new Productos { Id = 5, Nombre = "Monitor", CategoriaID = 1, Marca = "SONY", Modelo = "Plano", Precio = 6000 });
            ListaProducto.Add(new Productos { Id = 6, Nombre = "Libreta", CategoriaID = 2, Marca = "MIA", Modelo = "A2021", Precio = 500 });
            ListaProducto.Add(new Productos { Id = 7, Nombre = "Mouse", CategoriaID = 5, Marca = "DELL", Modelo = "USB01", Precio = 400 });
            ListaProducto.Add(new Productos { Id = 8, Nombre = "Resma Papel", CategoriaID = 2, Marca = "BOON", Modelo = "Carta 8*11", Precio = 600 });
            ListaProducto.Add(new Productos { Id = 9, Nombre = "Audifonos", CategoriaID = 3, Marca = "SONY", Modelo = "VZ100", Precio = 1000 });
            ListaProducto.Add(new Productos { Id = 10, Nombre = "Microfono", CategoriaID = 5, Marca = "HP", Modelo = "MF200", Precio = 1500 });
        }

        public List<Productos> ListarProductos()
        {
            var producto = from pro in ListaProducto
                           where pro.CategoriaID == 1
                           select pro;
            return producto.ToList();
        }

        public List<Productos> OrdenarPrecioDescendente()
        {
            var producto1 = ListaProducto.Where(p => p.Precio >= 3000).OrderByDescending(x => x.Precio <= 5000);
            return producto1.ToList();

          
        }

        public List<DetalleDeProductoMasCategoria> CategoriaJoin()
        {
            var producto2 = from pro in ListaProducto
                            join c in ListaCategoria on pro.CategoriaID equals c.Id
                            where pro.Precio >= 3000
                            select new DetalleDeProductoMasCategoria 
                            { 
                                NombreProducto = pro.Nombre, 
                                Marca = pro.Marca, 
                                Modelo = pro.Modelo,
                                Precio = pro.Precio,
                                NombreCategoria = c.Nombre
                            };
            return producto2.ToList();
        }

    }

    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CategoriaID { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public double Precio { get; set; }
        public void DatosProductos()
        {
            Console.WriteLine("Producto {0} con Id{1}, Nombre{2} con CategoriaID{3}, Marca {4} con Modelo {5} y Precio {5} ",
                Id, Nombre, CategoriaID, Marca, Modelo, Precio);
        }

    }
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public void DatosCategoria()
        {
            Console.WriteLine("Categoria {0} con Id {1} Nombre {2}", Id, Nombre);
        }

    }

    public class DetalleDeProductoMasCategoria
    {
        public int ProductoId { get; set; }
        public int CategoriaId { get; set; }

        public string NombreProducto { get; set; }
        public string NombreCategoria { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public double Precio { get; set; }
    }

}