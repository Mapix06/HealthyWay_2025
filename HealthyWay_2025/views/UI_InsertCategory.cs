using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthyWay_2025.models;
using HealthyWay_2025.controllers;

namespace HealthyWay_2025.views
{
    public partial class UI_InsertCategory : Form
    {
        public UI_InsertCategory()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nameCategory = textBox1.Text;
            string descriptionCategory = textBox2.Text;
                    
            Category objC = new Category(nameCategory, descriptionCategory);

            ControllerCategory objCC = new ControllerCategory();

            bool result = objCC.InsertCategory(objC);

        }
    }
}
