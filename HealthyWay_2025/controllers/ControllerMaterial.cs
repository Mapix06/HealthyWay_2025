using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthyWay_2025.models;

namespace HealthyWay_2025.controllers
{
    public class ControllerMaterial
    {
        internal bool InsertMaterial(Material objM)
        {
            bool result = false;

            string sql = "insert into materials(titulo, descripcionM)"
                + "values('" + objM.Titulo + "', '" + objM.DescripcionM + "');";

            ConnectDB objDB = new ConnectDB();

            result = objDB.ExecuteQuery(sql);
            if (result)
            {
                MessageBox.Show("Insert Correct ");
            }
            else
            {
                MessageBox.Show("Inser not Correct");
            }
            return result;
        }
    }
}
