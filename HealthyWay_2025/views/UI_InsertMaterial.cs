using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthyWay_2025.controllers;
using HealthyWay_2025.models;

namespace HealthyWay_2025.views
{
    public partial class UI_InsertMaterial : Form
    {
        public List<Category> listC = null;
        public UI_InsertMaterial()
        {
            InitializeComponent();
            CargarCategorias();
        }

        private void selectCategory(object sender, EventArgs e)
        {
            ControllerCategory objCC= new ControllerCategory();
            listC = objCC.selectCategories();

            for (int i = 0; i < listC.Count; i++)
            {
                comboBox2.Items.Add(listC[i].NameCategory);

            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            string titulo = textBox1.Text;
            string descripcionM = textBox2.Text;

            Material objM = new Material(titulo, descripcionM /*archivo*/);

            ControllerMaterial objCM = new ControllerMaterial();

            bool result = objCM.InsertMaterial(objM);



            string selected = this.comboBox1.GetItemText(this.comboBox1.SelectedItem);

            int idcategory = 0;
            for (int i = 0; i < listC.Count; i++)
            {
                if (selected.Equals(listC[i].NameCategory))
                {
                    idcategory = listC[i].IdCategory;
                }

            }
        }

        private void CargarCategorias()
        {
            try
            {
                ControllerCategory objCC = new ControllerCategory();
                listC = objCC.selectCategories();

                if (listC.Count == 0)
                {
                    MessageBox.Show("No se encontraron categorías en la base de datos.");
                }

                foreach (var cat in listC)
                {
                    comboBox2.Items.Add(cat.NameCategory);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cargando categorías: " + ex.Message);
            }
        }

    }
}
