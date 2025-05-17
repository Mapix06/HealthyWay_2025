using System;
using System.Windows.Forms;
using HealthyWay.Controllers;
using HealthyWay_2025.models;

namespace HealthyWay_2025.views
{
    public partial class UI_AccountDO : Form
    {
        private readonly ControllerAccount _ctrl = new ControllerAccount();

        public UI_AccountDO()
        {
            InitializeComponent();

            // Enmascarar la contraseña
            textBox6.UseSystemPasswordChar = true;

            // Click del botón “Crear”
            button1.Click += Button1_Click;

            // Enter activa el botón Crear
            this.AcceptButton = button1;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios (*)  
            // textBox1: Nombre  
            // textBox3: Apellido paterno  
            // textBox5: Email  
            // textBox6: Contraseña  
            // textBox7: Identificación  
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text))
            {
                MessageBox.Show(
                    "Por favor completa todos los campos obligatorios (*)",
                    "Datos Incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Construir objeto Account:
            // (firstName, secondName, lastName1, lastName2, email, password, rol, numIdentificacion, codigoEstudiante)
            var account = new Account(
                textBox1.Text.Trim(),   // Nombre
                textBox2.Text.Trim(),   // Nombre2 (opcional)
                textBox3.Text.Trim(),   // Apellido
                textBox4.Text.Trim(),   // Apellido2 (opcional)
                textBox5.Text.Trim(),   // Email
                textBox6.Text,          // Contraseña
                "Docente",              // rol fijo
                textBox7.Text.Trim(),   // Identificación
                ""                      // sin código de estudiante
            );

            // Insertar en BD
            bool success = _ctrl.insertAccount(account);
            if (success)
            {
                MessageBox.Show(
                    "¡Cuenta de docente creada exitosamente!",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show(
                    "Ocurrió un error al crear la cuenta. Inténtalo de nuevo.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}
