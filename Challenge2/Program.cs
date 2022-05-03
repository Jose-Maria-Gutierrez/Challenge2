using System.Globalization;
using Challenge2;

Persona[] empleados = new Persona[175];
DateTime fechaActual;
lecturaPersonal(empleados);
fechaActual = leeControl();
leerArchivoHoras(empleados, fechaActual);


void lecturaPersonal(Persona[] empleados) //lee los datos de los empleados y los carga en el array
{
    String linea;
    String[] valores;
    StreamReader arch = new StreamReader(File.OpenRead(@"C:\\Users\\Gutie\\Desktop\\Data.csv"));
    linea = arch.ReadLine();
    
    while (linea!=null) //supongo que no lee mas de 175 lineas
    {
        valores = linea.Split(';');  //array de String con cada dato del empleado
        
        empleados.Append( new Persona(int.Parse(valores[0]),valores[1],double.Parse(valores[2]),
            int.Parse(valores[3]),double.Parse(valores[4]),valores[5]) );

        linea = arch.ReadLine();    
    }

}

DateTime leeControl() //lee la fecha ingesada y valida
{
    String fecha;
    DateTime parsedDate;
    int dia, mes, anio;
    do
    {
        Console.WriteLine("ingrese dia");
        dia = int.Parse(Console.ReadLine());
        Console.WriteLine("ingrese mes");
        mes = int.Parse(Console.ReadLine());
        Console.WriteLine("ingrese anio");
        anio = int.Parse(Console.ReadLine());
    } while (dia<1 || dia>30 || mes<1 || mes>12 || anio<2011 || anio>2013); //valido la fecha

    fecha = dia.ToString();
    fecha.Concat("-");
    fecha.Concat(mes.ToString());
    fecha.Concat("-");
    fecha.Concat(anio.ToString());
    String patron = "dd-MM-yyyy";
    return (DateTime.TryParseExact(fecha, patron, null, DateTimeStyles.None, out parsedDate)) ? parsedDate : DateTime.Now; ;
}

void leerArchivoHoras(Persona[] empleados,DateTime fecha) //lee el archivo Horas para actualizar el array de empleados
{
    String linea,legajo;
    String[] valores;
    int ind,acum = 0;
    BinaryWriter archBinario = new BinaryWriter(File.OpenWrite("C:\\Users\\Gutie\\Desktop\\error.dat"));
    StreamReader arch = new StreamReader(File.OpenRead(@"C:\\Users\\Gutie\\Desktop\\Horas.csv"));
    linea = arch.ReadLine();

    valores = linea.Split(';');  //array de String con legajo y horas 

    while (linea != null)
    {
        legajo = valores[0];
        while (legajo.Equals(valores[0]))
        {
            acum += int.Parse(valores[1]); //acumulador de horas trabajadas
            linea = arch.ReadLine();
            valores = linea.Split(';');
        }
        ind = busquedaLegajo(empleados, int.Parse(legajo));
        if (ind<175) //existe
        {
            empleados[ind]._horasTrabajadas = empleados[ind]._horasTrabajadas + acum; //actualizo las horas
            empleados[ind]._sueldos = empleados[ind]._horasTrabajadas * empleados[ind]._hora; //actualizo sueldo
            empleados[ind]._fecha = fecha; //actualizo fecha
        }
        else
        {
            archBinario.Write(legajo + acum); //graba en error.dat
        }

    }
    archBinario.Close();
    arch.Close();
}

int busquedaLegajo(Persona[] empleados,int legajo) //devuelve el indice donde se encuentra el empleado con el legajo pasado
{
    int i = 0;
    while (i < 175 && empleados[i]._legajo != legajo) //ya se que hay 175 
    {
        i++;
    }

    return i;
}