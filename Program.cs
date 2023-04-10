internal class Program
{
    static List<Persona> listaPersonas = new List<Persona>();
    private static void Main(string[] args)
    {
        int menu;
        do
        {
            menu = ingresarInt("Ingrese la opción: \ni. Cargar Nueva Persona\nii. Obtener Estadísticas del Censo\niii. Buscar Persona\niv. Modificar Mail de una Persona.\nv. Salir");

            switch (menu)
            {
                case 1:
                    cargarNuevaPersona();
                    break;

                case 2:
                    obtenerEstadísticasCenso();
                    break;

                case 3:
                    buscarPersona();
                    break;

                case 4:
                    modificarMailPersona();
                break;
            }
            Console.ReadKey();
            Console.Clear();
        } while (menu != 5);

    }

    static string ingresarString(string mensaje)
        {
            Console.WriteLine(mensaje);
            return Console.ReadLine();
        }

        static int ingresarInt(string mensaje)
        {
            int entero;
            Console.WriteLine(mensaje);
            entero = int.Parse(Console.ReadLine());
            while(entero <= 0){
                Console.WriteLine("ERROR. El ingreso debe ser mayor a cero");
                Console.WriteLine(mensaje);
                entero = int.Parse(Console.ReadLine());
            }
            return entero;
        }

        static DateTime ingresarDateTime(string mensaje)
        {
            DateTime ingreso;
            Console.WriteLine(mensaje);
            ingreso = Convert.ToDateTime(Console.ReadLine());
            while(ingreso > DateTime.Today){
                Console.WriteLine("ERROR. La fecha debe ser anterior o igual a la actual");
                Console.WriteLine(mensaje);
                ingreso = Convert.ToDateTime(Console.ReadLine());
            }
            return ingreso;
        }


        static void cargarNuevaPersona()
        {
            int dni;
            dni = ingresarInt("Ingrese:\nDNI: ");
            if(verificarDNI(dni) != null){
                Console.WriteLine("El DNI ingresado ya existe en las personas registradas en el Censo");
            }
            else{
                string apellido = ingresarString("Apellido: ");
                string nombre = ingresarString("Nombre: ");
                DateTime fechaDeNacimiento = ingresarDateTime("Fecha de nacimiento: ");
                string email = ingresarString("Email: ");
                listaPersonas.Add(new Persona(dni, apellido, nombre, fechaDeNacimiento, email));
                Console.WriteLine("Se ha creado la persona " + nombre + " " + apellido + " y se ha agregado a la lista.");
            }
        }

        static Persona verificarDNI(int dni){
            int i = 0;
            while(i < listaPersonas.Count){
                if(dni == listaPersonas[i].DNI){
                    return listaPersonas[i];
                }
                else{
                    i++;
                }
            };

            return null;
        }

        static void obtenerEstadísticasCenso(){
            if(listaPersonas.Count > 0){
                Console.WriteLine("Estadísticas del Censo: \nCantidad de Personas: " + listaPersonas.Count + "\nCantidad de Personas habilitadas para votar: " + calcularVotantes() + "\nPromedio de Edad: " + calcularPromedioEdad());
            }else{
                Console.WriteLine("Aún no se ingresaron personas en la lista");
            }
        }

        static int calcularVotantes(){
            int votantes = 0;
            foreach(Persona p in listaPersonas){
                if(p.PuedeVotar()){
                    votantes += 1;
                }
            }

            return votantes;
        }

        static int calcularPromedioEdad(){
            int suma = 0;
            foreach(Persona p in listaPersonas){
                suma += p.ObtenerEdad();
            }
            return (suma/listaPersonas.Count);
        }

        static void buscarPersona(){
            int dniBusqueda = ingresarInt("Ingrese el DNI que quiere buscar: ");
            Persona persona = verificarDNI(dniBusqueda);
            if(persona == null){
                Console.WriteLine("No se encuentra el DNI");
            }
            else{
                Console.WriteLine("Apellido: " + persona.Apellido + "\nNombre: " + persona.Nombre + "\nFecha de nacimiento: " + persona.FechaNacimiento + "\nEdad: " + persona.ObtenerEdad() + "\nEmail: " + persona.Email);
                if(persona.PuedeVotar()){
                    Console.WriteLine("Puede votar");
                }
                else{
                    Console.WriteLine("No puede votar");
                }
            }

        }

        static void modificarMailPersona(){
            string nuevoEmail;
            int dniIngresado = ingresarInt("Ingrese el DNI que quiere buscar: ");
            Persona persona = verificarDNI(dniIngresado);
            if(persona == null){
                Console.WriteLine("No se encuentra el DNI");
            }
            else{
                nuevoEmail = ingresarString("Ingrese el nuevo email: ");
                persona.Email = nuevoEmail;
            }
        }
}