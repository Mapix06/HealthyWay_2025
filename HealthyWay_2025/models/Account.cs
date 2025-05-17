using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyWay_2025.models
{
    internal class Account
    {
        private int idACCOUNT;
        private string firstNameAccount;
        private string secondNameAccount;
        private string lastName1Account;
        private string lastName2Account;
        private string email;
        private string password;
        private string rol;
        private string numIdentificacion;
        private string codigoEstudiante;

        ConnectDB objConection = new ConnectDB();

        public Account()
        {
        }

        public Account(int idACCOUNT,
                       string firstNameAccount,
                       string secondNameAccount,
                       string lastName1Account,
                       string lastName2Account,
                       string email,
                       string password,
                       string rol,
                       string numIdentificacion,
                       string codigoEstudiante)
        {
            this.idACCOUNT = idACCOUNT;
            this.firstNameAccount = firstNameAccount;
            this.secondNameAccount = secondNameAccount;
            this.lastName1Account = lastName1Account;
            this.lastName2Account = lastName2Account;
            this.email = email;
            this.password = password;
            this.rol = rol;
            this.numIdentificacion = numIdentificacion;
            this.codigoEstudiante = codigoEstudiante;
        }

        public Account(string firstNameAccount,
                       string secondNameAccount,
                       string lastName1Account,
                       string lastName2Account,
                       string email,
                       string password,
                       string rol,
                       string numIdentificacion,
                       string codigoEstudiante)
        {
            this.firstNameAccount = firstNameAccount;
            this.secondNameAccount = secondNameAccount;
            this.lastName1Account = lastName1Account;
            this.lastName2Account = lastName2Account;
            this.email = email;
            this.password = password;
            this.rol = rol;
            this.numIdentificacion = numIdentificacion;
            this.codigoEstudiante = codigoEstudiante;
        }

        public Account(string firstNameAccount,
                       string secondNameAccount,
                       string lastName1Account,
                       string lastName2Account,
                       string email,
                       string password,
                       string numIdentificacion,
                       string codigoEstudiante)
            : this(firstNameAccount,
                   secondNameAccount,
                   lastName1Account,
                   lastName2Account,
                   email,
                   password,
                   "Estudiante",        // rol por defecto
                   numIdentificacion,
                   codigoEstudiante)
        {
        }


        public int IdACCOUNT
        {
            get => idACCOUNT; set => idACCOUNT = value;
        }
        public string FirstNameAccount
        {
            get => firstNameAccount; set => firstNameAccount = value;
        }
        public string SecondNameAccount
        {
            get => secondNameAccount; set => secondNameAccount = value;
        }
        public string LastName1Account
        {
            get => lastName1Account; set => lastName1Account = value;
        }
        public string LastName2Account
        {
            get => lastName2Account; set => lastName2Account = value;
        }
        public string Email
        {
            get => email; set => email = value;
        }
        public string Password
        {
            get => password; set => password = value;
        }
        public string Rol
        {
            get => rol; set => rol = value;
        }
        public string NumIdentificacion
        {
            get => numIdentificacion; set => numIdentificacion = value;
        }
        public string CodigoEstudiante
        {
            get => codigoEstudiante; set => codigoEstudiante = value;
        }
    }
}
