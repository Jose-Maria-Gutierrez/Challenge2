using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
    internal class Persona
    {
        private int legajo;
        private String ayn;
        private double hora;
        private int horasTrabajadas;
        private double sueldos;
        private DateTime fecha;

        public Persona(int legajo, string ayn, double hora, int horasTrabajadas, double sueldos, String fecha)
        {
            this.legajo = legajo;
            this.ayn = ayn;
            this.hora = hora;
            this.horasTrabajadas = horasTrabajadas;
            this.sueldos = sueldos;
            DateTime parsedDate;
            String patron = "dd-MM-yyyy";
            this.fecha = (DateTime.TryParseExact(fecha, patron, null, DateTimeStyles.None, out parsedDate)) ? parsedDate : DateTime.Now;
        }

        public int _legajo
        {
            get { return this.legajo; }
            set { this.legajo = value; }
        }

        public String _ayn
        {
            get { return this.ayn;  }
            set { this.ayn = value; }
        }

        public double _hora
        {
            get { return this.hora; }
            set { this.hora = value; }
        }

        public int _horasTrabajadas
        {
            get { return this.horasTrabajadas; }
            set { this.horasTrabajadas = value; }
        }

        public double _sueldos
        {
            get { return this.sueldos; }
            set { this.sueldos = value; }
        }
        public DateTime _fecha
        {
            get { return this.fecha; }
            set { this.fecha = value; }
        }

    }
}
