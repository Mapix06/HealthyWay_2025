using System;
using System.Windows.Forms;
using HealthyWay.Controllers;
using HealthyWay_2025.models;

namespace HealthyWay_2025.views
{
    public partial class UI_AccountES : Form
    {
        private readonly ControllerAccount _ctrl = new ControllerAccount();

        public UI_AccountES()
        {
            InitializeComponent();

            // Enmascarar la contraseña
            textBox6.UseSystemPasswordChar = true;

            // Asociar evento al botón Crear
            button1.Click += Button1_Click;

            // Enter presiona el botón Crear
            this.AcceptButton = button1;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // 1) Validar todos los campos obligatorios
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||  // Nombre
                string.IsNullOrWhiteSpace(textBox3.Text) ||  // Apellido paterno
                string.IsNullOrWhiteSpace(textBox5.Text) ||  // Email
                string.IsNullOrWhiteSpace(textBox6.Text) ||  // Contraseña
                string.IsNullOrWhiteSpace(textBox7.Text) ||  // Identificación
                string.IsNullOrWhiteSpace(textBox8.Text))    // Código de Estudiante
            {
                MessageBox.Show(
                    "Por favor completa todos los campos obligatorios (*)",
                    "Datos Incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // 2) Construir objeto Account con el constructor de 8 parámetros
            var account = new Account(
                textBox1.Text.Trim(),   // firstNameAccount
                textBox2.Text.Trim(),   // secondNameAccount (opcional)
                textBox3.Text.Trim(),   // lastName1Account
                textBox4.Text.Trim(),   // lastName2Account (opcional)
                textBox5.Text.Trim(),   // email
                textBox6.Text,          // password
                textBox7.Text.Trim(),   // numIdentificacion
                textBox8.Text.Trim()    // codigoEstudiante
            );

            // 3) Insertar en la base de datos
            bool success = _ctrl.insertAccount(account);
            if (success)
            {
                MessageBox.Show(
                    "¡Cuenta de estudiante creada exitosamente!",
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
