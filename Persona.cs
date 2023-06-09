class Persona{
    public int DNI{get;private set;}
    public string Apellido{get;private set;}
    public string Nombre{get;private set;}
    public DateTime FechaNacimiento{get;private set;}
    public string Email{get;set;}

    public Persona(int dni, string ape, string nom, DateTime fnac, string email){
        DNI = dni;
        Apellido = ape;
        Nombre = nom;
        FechaNacimiento = fnac;
        Email = email;
    }

    public bool PuedeVotar(){
        const int EDAD_MAYOR = 18;
        return ObtenerEdad() >= EDAD_MAYOR;
    }

    public int ObtenerEdad(){
        DateTime fechaActual = DateTime.Today;
        int edad = fechaActual.Year - FechaNacimiento.Year;
        if(fechaActual.Month < FechaNacimiento.Month ||  fechaActual.Day < FechaNacimiento.Day){
            edad--;
        }

        return edad;
    }
}