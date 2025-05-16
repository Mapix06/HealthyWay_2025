using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HealthyWay_2025.models;

namespace HealthyWay_2025.controllers
{
    public class ControllerCategory
    {
        internal bool InsertCategory(Category objC)
        {
            bool result = false;

            string sql = "insert into categories(nameCategory, descriptionCategory)" 
                + "values('" + objC.NameCategory + "', '" + objC.DescriptionCategory + "');";

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

        internal List<Category> selectCategories()
        {
            List<Category> listC = new List<Category>();
            Category objC = new Category();
            string sql = "select * from categories";
            listC = objC.SelectCategories(sql);

            return listC;
        }
    }
}
