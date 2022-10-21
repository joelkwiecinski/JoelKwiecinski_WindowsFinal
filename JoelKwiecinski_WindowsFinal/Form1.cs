using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace JoelKwiecinski_WindowsFinal
{
    public partial class Form1 : Form
    {

        string nombre;
        string apellido;
        string puesto;
        double sueldo;
        double[] cargaHoraria;
        string[] diasSemana;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnValidaciones_Click(object sender, EventArgs e)
        {
            ValidarDatos();
        }

        private void ValidarDatos()
        {
            nombre = txtNombre.Text;
            apellido = txtApellido.Text;
            puesto = txtPuesto.Text;
            bool sueldoConvertido = double.TryParse(txtSueldo.Text, out sueldo);
            if (!sueldoConvertido)
            {
                MessageBox.Show("Verifica que el campo de sueldo esté completado con números.");
            } else
            {
                if (nombre.Length > 2 && nombre.Length < 50 && apellido.Length > 2 && apellido.Length < 50)
                {
                    // Tenemos todos los datos OK, seguimos
                    if (sueldo > 0)
                    {
                        // Sueldo mayor a 0, seguimos
                        if (puesto.ToUpper() == "SOPORTE TÉCNICO" || puesto.ToUpper() == "DBA" || puesto.ToUpper() == "DESARROLLADOR")
                        {
                            // Puesto OK, validaciones terminadas
                            MessageBox.Show("Todos los datos son correctos.");
                        }
                        else
                        {
                            MessageBox.Show("Verifica que tu puesto sea correcto.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("El sueldo debe ser mayor a 0.");
                    }
                }
                else
                {
                    MessageBox.Show("Verifica que el nombre y el apellido posean entre 2 y 50 caracteres.");
                }
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("TU NOMBRE ES " + txtNombre.Text.ToUpper() + " " + txtApellido.Text.ToUpper() + " Y TU PUESTO ES " + txtPuesto.Text.ToUpper());
        }

        private void btnIngresarHoras_Click(object sender, EventArgs e)
        {
            cargaHoraria = new double[5];
            diasSemana = new string[5] { "lunes", "martes", "miércoles", "jueves", "viernes"};
            double horasTotales = 0;
            string diaPocoTrabajo = "";
            for (int i = 0; i < cargaHoraria.Length; i++)
            {
                bool numeroConvertido = double.TryParse(Interaction.InputBox("Ingresa las horas trabajadas el día " + diasSemana[i]), out double horasTrabajadas);
                while (!numeroConvertido)
                {
                    MessageBox.Show("Debes ingresar un valor en números.");
                    numeroConvertido = double.TryParse(Interaction.InputBox("Ingresa las horas trabajadas el día " + diasSemana[i]), out horasTrabajadas);
                }

                // Verificamos si trabajó menos de 4 horas
                if (horasTrabajadas < 4)
                {
                    diaPocoTrabajo = diasSemana[i];
                }

                // Asignamos las horas trabajadas en nuestro array, y lo sumamos a las horas totales
                cargaHoraria[i] = horasTrabajadas;
                horasTotales += horasTrabajadas;
            }
            MessageBox.Show("Trabajaste un total de " + horasTotales + " horas.\nEl promedio de tus horas trabajadas es de " + (horasTotales / cargaHoraria.Length) + ".\nEl día que trabajaste menos de 4 horas fue el " + diaPocoTrabajo + ".");
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtPuesto.Clear();
            txtSueldo.Clear();
            nombre = "";
            apellido = "";
            puesto = "";
            sueldo = 0;
        }
    }
}
