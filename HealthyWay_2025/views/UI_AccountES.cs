using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthyWay.Controllers;
using HealthyWay_2025.models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HealthyWay_2025.views
{
    public partial class UI_AccountES : Form
    {
        private readonly ControllerAccount _ctrl = new ControllerAccount();
        public UI_AccountES()
        {
            InitializeComponent();

            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            button1.Click += Button1_Click;

            textBox8.Visible = false;
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var rol = comboBox1.SelectedItem?.ToString();
            if (rol == "Estudiante")
            {
                textBox8.Visible = true;
                textBox8.Focus();
            }
            else
            {
                textBox8.Visible = false;
                textBox8.Text = string.Empty;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            // Validar campos obligatorios
            if (string.IsNullOrWhiteSpace(textBox1.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) ||
                string.IsNullOrWhiteSpace(textBox6.Text) ||
                string.IsNullOrWhiteSpace(textBox7.Text))
            {
                MessageBox.Show(
                    "Por favor completa todos los campos obligatorios.",
                    "Datos Incompletos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Si es estudiante, asegurar código ingresado
            if (comboBox1.SelectedItem.ToString() == "Estudiante" &&
                string.IsNullOrWhiteSpace(textBox8.Text))
            {
                MessageBox.Show(
                    "Debes ingresar el código de estudiante.",
                    "Falta Código",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Construir objeto Account
            var account = new Account(
                textBox1.Text.Trim(),    // FirstName
                textBox2.Text.Trim(),    // SecondName (opcional)
                textBox3.Text.Trim(),    // LastName1
                textBox4.Text.Trim(),    // LastName2 (opcional)
                textBox5.Text.Trim(),    // Email
                textBox6.Text,           // Password
                textBox7.Text.Trim(),    // Identification
                textBox8.Text.Trim()     // StudentCode (si aplica)
            );

            // Insertar en BD usando insertAccount en lugar de AddAccount
            var success = _ctrl.insertAccount(account);
            if (success)
            {
                MessageBox.Show(
                    "¡Cuenta creada exitosamente!",
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

        private void cuenta_Load(object sender, EventArgs e)
        {
        }
    }
}
    