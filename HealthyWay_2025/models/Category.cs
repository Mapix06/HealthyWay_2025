using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace HealthyWay_2025.models
{
    public class Category
    {
        private int idCategory;
        private string nameCategory;
        private string descriptionCategory;

        ConnectDB objConection = new ConnectDB();

        public Category()
        {
        }

        public Category(int idCategory, string nameCategory, string descriptionCategory)
        {
            this.idCategory = idCategory;
            this.nameCategory = nameCategory;
            this.descriptionCategory = descriptionCategory;
        }

        public Category(string nameCategory, string descriptionCategory)
        {
            NameCategory = nameCategory;
            DescriptionCategory = descriptionCategory;
        }

        public int IdCategory { get => idCategory; set => idCategory = value; }
        public string NameCategory { get => nameCategory; set => nameCategory = value; }
        public string DescriptionCategory { get => descriptionCategory; set => descriptionCategory = value; }

        internal List<Category> SelectCategories(string sql)
        {
            List<Category> listCategory = new List<Category>();
            try
            {
                MySqlCommand cmd = new MySqlCommand(sql, objConection.DataSource());
                objConection.ConnectOpened();
                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int idCategory = reader.GetInt32(0);
                        string nameCategory = reader.GetString(1);
                        string descriptionCategory = reader.GetString(2);

                        Category objc = new Category(idCategory, nameCategory, descriptionCategory);

                        listCategory.Add(objc);
                    }
                }
            }
            catch (Exception w)
            {
                Console.WriteLine("ERROOOOOOR " + w.Message);
                objConection.ConnectClosed();
            }
            finally
            {
                objConection.ConnectClosed();
            }


            return listCategory;
        }
    }
}
