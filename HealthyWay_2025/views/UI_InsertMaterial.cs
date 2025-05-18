using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using HealthyWay_2025.controllers;
using HealthyWay_2025.models;
using MySql.Data.MySqlClient;

namespace HealthyWay_2025.views
{
    public partial class UI_InsertMaterial : Form
    {
        public List<Category> listC = null;

        public UI_InsertMaterial()
        {
            InitializeComponent();
            CargarCategorias();
            CargarCuentasDocentes();

            // Asociar eventos
            button1.Click += button1_Click;
            button2.Click += button2_Click;
        }

        /// <summary>
        /// Llena comboBox1 con un placeholder "Cuenta" y luego los emails de usuarios con rol "Docente".
        /// </summary>
        private void CargarCuentasDocentes()
        {
            try
            {
                var db = new ConnectDB();
                using (var conn = db.DataSource())
                {
                    conn.Open();
                    const string sql = @"
                        SELECT email
                          FROM accounts
                         WHERE rol = 'Docente';";

                    using (var cmd = new MySqlCommand(sql, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        comboBox1.Items.Clear();
                        comboBox1.Items.Add("Cuenta");
                        while (reader.Read())
                        {
                            comboBox1.Items.Add(reader.GetString("email"));
                        }
                    }
                }

                comboBox1.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error cargando cuentas: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga las categorías desde la base de datos en comboBox2.
        /// </summary>
        private void CargarCategorias()
        {
            try
            {
                var objCC = new ControllerCategory();
                listC = objCC.selectCategories();

                if (listC == null || listC.Count == 0)
                {
                    MessageBox.Show(
                        "No se encontraron categorías en la base de datos.",
                        "Sin Categorías",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                comboBox2.Items.Clear();
                foreach (var cat in listC)
                    comboBox2.Items.Add(cat.NameCategory);

                comboBox2.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Error cargando categorías: " + ex.Message,
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Inserta el material usando ControllerMaterial al hacer clic en button1.
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            string titulo = textBox1.Text.Trim();
            string descripcion = textBox2.Text.Trim();

            var material = new Material(titulo, descripcion /*archivo*/);
            var controller = new ControllerMaterial();
            bool ok = controller.InsertMaterial(material);

            if (ok)
            {
                MessageBox.Show(
                    "Material insertado correctamente.",
                    "Éxito",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
            }
            else
            {
                MessageBox.Show(
                    "Ocurrió un error al insertar el material.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Abre un diálogo para seleccionar una imagen y la muestra en pictureBox1.
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            using (var dlg = new OpenFileDialog())
            {
                dlg.Title = "Selecciona una imagen";
                dlg.Filter = "Archivos de Imagen|*.jpg;*.jpeg;*.png;*.bmp|Todos|*.*";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = Image.FromFile(dlg.FileName);
                }
            }
        }
    }
}
