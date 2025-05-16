using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using HealthyWay_2025.models;

namespace HealthyWay.Controllers
{
    internal class ControllerAccount
    {

        /// <param name="objA">Objeto Account con la información a guardar.</param>
        internal bool insertAccount(Account objA)
        {
            const string sql = @"
                INSERT INTO accounts
                ( firstNameAccount, secondNameAccount, lastName1Account, lastName2Account, email, password, rol, numIdentificacion, codigoEstudiante )
                VALUES
                ( @firstName, @secondName, @lastName1, @lastName2, @Email, @Password, @Rol, @NumIdentificacion, @CodigoEstudiante );";

            try
            {
                using (var conn = new ConnectDB().DataSource())
                using (var cmd = new MySqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@firstName", objA.FirstNameAccount);
                    cmd.Parameters.AddWithValue(
                        "@secondName",
                        string.IsNullOrWhiteSpace(objA.SecondNameAccount)
                            ? (object)DBNull.Value
                            : objA.SecondNameAccount);
                    cmd.Parameters.AddWithValue("@lastName1", objA.LastName1Account);
                    cmd.Parameters.AddWithValue(
                        "@lastName2",
                        string.IsNullOrWhiteSpace(objA.LastName2Account)
                            ? (object)DBNull.Value
                            : objA.LastName2Account);
                    cmd.Parameters.AddWithValue("@Email", objA.Email);
                    cmd.Parameters.AddWithValue("@Password", objA.Password);
                    cmd.Parameters.AddWithValue("@Rol", objA.Rol);
                    cmd.Parameters.AddWithValue("@NumIdentificacion", objA.NumIdentificacion);

                    var code = string.IsNullOrWhiteSpace(objA.CodigoEstudiante) ? string.Empty : objA.CodigoEstudiante;
                    cmd.Parameters.AddWithValue("@CodigoEstudiante", code);

                    conn.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Error al crear cuenta:\n{ex.Message}",
                    "Error BD",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
