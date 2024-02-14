using System;
using System.Collections.Generic;

// Definición de la clase Libro que representa un libro en la biblioteca
public class Libro : ILibro
{
    // Atributos del libro
    public int Codigo { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public DateTime FechaPublicacion { get; set; }
    public double Precio { get; set; }
    public bool Disponible { get; set; }

    // Constructores de la clase Libro
    public Libro(int codigo, string titulo, string autor, DateTime fechaPublicacion, double precio, bool disponible)
    {
        Codigo = codigo;
        Titulo = titulo;
        Autor = autor;
        FechaPublicacion = fechaPublicacion;
        Precio = precio;
        Disponible = disponible;
    }

    public Libro(string titulo, string autor, DateTime fechaPublicacion, double precio, bool disponible)
    {
        Titulo = titulo;
        Autor = autor;
        FechaPublicacion = fechaPublicacion;
        Precio = precio;
        Disponible = disponible;
    }

    public Libro(string autor, DateTime fechaPublicacion, double precio, bool disponible)
    {
        Autor = autor;
        FechaPublicacion = fechaPublicacion;
        Precio = precio;
        Disponible = disponible;
    }

    public Libro(DateTime fechaPublicacion, double precio, bool disponible)
    {
        FechaPublicacion = fechaPublicacion;
        Precio = precio;
        Disponible = disponible;
    }
    public Libro(double precio, bool disponible)
    {
        Precio = precio;
        Disponible = disponible;
    }

    public Libro(bool disponible)
    {
        Disponible = disponible;
    }

    // Implementación de los métodos de la interfaz ILibro
    public void Prestar()
    {
        if (Disponible)
        {
            Disponible = false;
            Console.WriteLine($"El que indicas '{Titulo}' está alquilado o en prestamo de momento.");
            Console.WriteLine("Le invitamos a elegir otro libro de nuestra colección");
        }
        else
        {
            Console.WriteLine($"El libro '{Titulo}' no se encuentra en stock.");
        }
    }

    public void Devolver()
    {
        if (!Disponible)
        {
            Disponible = true;
            Console.WriteLine($"As devuelto el libro '{Titulo}', muchas gracias!.");
        }
        else
        {
            Console.WriteLine($"El libro '{Titulo}' ya se encuentra disponible.");
        }
    }

    public void Consultar()
    {
        Console.WriteLine($"Información del libro:");
        Console.WriteLine($"Código: {Codigo}");
        Console.WriteLine($"Título: {Titulo}");
        Console.WriteLine($"Autor: {Autor}");
        Console.WriteLine($"Fecha de publicación: {FechaPublicacion}");
        Console.WriteLine($"Precio: {Precio}");
        Console.WriteLine($"Disponible: {(Disponible ? "Sí" : "No")}\n");
    }
}

// Definición de la interfaz ILibro que define los métodos que deben implementar los libros
public interface ILibro
{
    void Prestar();
    void Devolver();
    void Consultar();
}

// Definición de la clase Biblioteca que contiene una lista de libros
public class Biblioteca
{
    public List<Libro> Libros { get; set; }
    private List<Libro> libros; // Lista que contiene los libros de la biblioteca

    // Constructor de la clase Biblioteca
    public Biblioteca()
    {
        libros = new List<Libro>();
    }

    // Método para agregar un libro a la biblioteca
    public void AgregarLibro(Libro libro)
    {
        libros.Add(libro);
        Console.WriteLine("Libro agregado a la biblioteca.");
    }

    // Método para eliminar un libro de la biblioteca
    public void EliminarLibro(int codigo)
    {
        var libro = libros.Find(l => l.Codigo == codigo);
        if (libro != null)
        {
            libros.Remove(libro);
            Console.WriteLine("Libro eliminado de la biblioteca.");
        }
        else
        {
            Console.WriteLine("No se encontró el libro en la biblioteca.");
        }
    }

    // Método para mostrar todos los libros de la biblioteca
    public void MostrarLibros()
    {
        foreach (var libro in libros)
        {
            libro.Consultar();
            Console.WriteLine();
        }
    }

    // Método para buscar un libro por su título
    public Libro BuscarLibroPorTitulo(string titulo)
    {
        return libros.Find(l => l.Titulo.ToLower() == titulo.ToLower());
    }

    // Método para buscar libros por el inicio del nombre del autor
    public List<Libro> BuscarLibrosPorInicioAutor(string inicioAutor)
    {
        return libros.FindAll(l => l.Autor.ToLower().StartsWith(inicioAutor.ToLower()));
    }

    // Otros métodos pueden ser agregados según sea necesario
}

// Clase principal del programa
class Program
{
    // Método principal del programa
    static void Main(string[] args)
    {
        Biblioteca biblioteca = new Biblioteca(); // Instancia de la biblioteca

      
        // Inicialización de los libros al inicio del programa
        Libro libro1 = new Libro(1, "El Señor de los Anillos", "J.R.R. Tolkien", new DateTime(1954, 7, 29), 25.99, true);
        Libro libro2 = new Libro(2, "Cien años de soledad", "Gabriel García Márquez", new DateTime(1967, 5, 30), 19.99, true);
        Libro libro3 = new Libro(3, "1984", "George Orwell", new DateTime(1949, 6, 8), 15.99, true);
        Libro libro4 = new Libro(4, "Harry Potter y la piedra filosofal", "J.K. Rowling", new DateTime(1997, 6, 26), 22.99, true);

        // Agregamos los libros a la biblioteca
        biblioteca.AgregarLibro(libro1);
        biblioteca.AgregarLibro(libro2);
        biblioteca.AgregarLibro(libro3);
        biblioteca.AgregarLibro(libro4);

        bool salir = false;
        while (!salir) // Bucle principal para mostrar el menú y manejar las opciones
        {
            Console.WriteLine("Menú de opciones:");
            Console.WriteLine("1. Agregar un libro a la biblioteca");
            Console.WriteLine("2. Eliminar un libro de la biblioteca");
            Console.WriteLine("3. Mostrar todos los libros de la biblioteca");
            Console.WriteLine("4. Buscar libros por título");
            Console.WriteLine("5. Mostrar libro de mayor precio");
            Console.WriteLine("6. Mostrar los tres libros más baratos");
            Console.WriteLine("7. Buscar libros por inicio del nombre del autor");
            Console.WriteLine("8. Salir del programa\n");
            Console.Write("Ingrese el número de la opción deseada: ");

            int opcion;
            if (int.TryParse(Console.ReadLine(), out opcion)) // Se lee la opción ingresada por el usuario
            {
                switch (opcion) // Se ejecuta el bloque correspondiente a la opción seleccionada
                {
                    case 1:
                        // Agregar un libro a la biblioteca
                        Console.Write("Ingrese el código del libro: ");
                        int codigo = int.Parse(Console.ReadLine());
                        Console.Write("Ingrese el título del libro: ");
                        string titulo = Console.ReadLine();
                        Console.Write("Ingrese el autor del libro: ");
                        string autor = Console.ReadLine();
                        Console.Write("Ingrese la fecha de publicación del libro (YYYY-MM-DD): ");
                        DateTime fechaPublicacion = DateTime.Parse(Console.ReadLine());
                        Console.Write("Ingrese el precio del libro: ");
                        double precio = double.Parse(Console.ReadLine());
                        Console.Write("¿Está disponible el libro? (true/false): ");
                        bool disponible = bool.Parse(Console.ReadLine());

                        Libro nuevoLibro = new Libro(codigo, titulo, autor, fechaPublicacion, precio, disponible);
                        biblioteca.AgregarLibro(nuevoLibro);
                        break;

                    case 2:
                        // Eliminar un libro de la biblioteca
                        Console.Write("Ingrese el código del libro a eliminar: ");
                        int codigoEliminar = int.Parse(Console.ReadLine());
                        biblioteca.EliminarLibro(codigoEliminar);
                        break;

                    case 3:
                        // Mostrar todos los libros de la biblioteca
                        biblioteca.MostrarLibros();
                        break;

                    case 4:
                        // Buscar libros por título
                        Console.Write("Ingrese el título del libro a buscar: ");
                        string tituloBuscar = Console.ReadLine();
                        Libro libroEncontrado = biblioteca.BuscarLibroPorTitulo(tituloBuscar);
                        if (libroEncontrado != null)
                        {
                            libroEncontrado.Consultar();
                        }
                        else
                        {
                            Console.WriteLine("No se encontró ningún libro con ese título.");
                        }
                        break;

                    case 5:
                        if (biblioteca.Libros.Count > 0)
                        {
                            Libro libroMayorPrecio = biblioteca.Libros[0]; // Inicializamos con el primer libro
                            foreach (var libro in biblioteca.Libros)
                            {
                                if (libro.Precio > libroMayorPrecio.Precio)
                                {
                                    libroMayorPrecio = libro; // Actualizamos si encontramos un libro con un precio mayor
                                }
                            }

                            Console.WriteLine("Libro de mayor precio:");
                            libroMayorPrecio.Consultar();
                        }
                        else
                        {
                            Console.WriteLine("No hay libros en la biblioteca.");
                        }
                        break;

                    case 6:
                        // Mostrar los tres libros más baratos
                        if (biblioteca.Libros.Count > 0)
                        {
                            List<Libro> librosMasBaratos = biblioteca.Libros.OrderBy(l => l.Precio).Take(3).ToList();
                            Console.WriteLine("Los tres libros más baratos:");
                            foreach (Libro libro in librosMasBaratos)
                            {
                                libro.Consultar();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No hay libros en la biblioteca.");
                        }
                        break;

                    case 7:
                        // Buscar libros por inicio del nombre del autor
                        Console.Write("Ingrese el inicio del nombre del autor: ");
                        string inicioAutor = Console.ReadLine();
                        List<Libro> librosAutor = biblioteca.BuscarLibrosPorInicioAutor(inicioAutor);
                        if (librosAutor.Count > 0)
                        {
                            Console.WriteLine($"Libros cuyos autores tienen el nombre que comienza con '{inicioAutor}':");
                            foreach (var libro in librosAutor)
                            {
                                libro.Consultar();
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontraron libros con el inicio del nombre del autor especificado.");
                        }
                        break;

                    case 8:
                        salir = true; // Se sale del bucle y termina el programa
                        Console.WriteLine("Saliendo del programa...");
                        break;
                    default:
                        Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Entrada no válida. Por favor, ingrese un número correspondiente a una opción del menú.");
            }

            Console.WriteLine();
        }
    }
}