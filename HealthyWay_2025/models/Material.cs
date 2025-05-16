using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyWay_2025.models
{
    public class Material
    {
        private int idMaterial;
        private string titulo;
        private string descripcionM;
        private string archivo;
        private string fecha_publicacion;
        private string fecha_creacion_registro;

        ConnectDB objDB = new ConnectDB();

        public Material()
        {
        }

        public Material(int idMaterial, string titulo, string descripcionM, string archivo, string fecha_publicacion, string fecha_creacion_registro)
        {
            this.idMaterial = idMaterial;
            this.titulo = titulo;
            this.descripcionM = descripcionM;
            this.archivo = archivo;
            this.fecha_publicacion = fecha_publicacion;
            this.fecha_creacion_registro = fecha_creacion_registro;
        }

        public Material(string titulo, string descripcionM)
        {
            this.titulo = titulo;
            this.descripcionM = descripcionM;
        }

        public Material(string titulo, string descripcionM, string archivo)
        {
            this.titulo = titulo;
            this.descripcionM = descripcionM;
            this.archivo = archivo;
        }

        public int IdMaterial { get => idMaterial; set => idMaterial = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public string DescripcionM { get => descripcionM; set => descripcionM = value; }
        public string Archivo { get => archivo; set => archivo = value; }
        public string Fecha_publicacion { get => fecha_publicacion; set => fecha_publicacion = value; }
        public string Fecha_creacion_registro { get => fecha_creacion_registro; set => fecha_creacion_registro = value; }
    }

}
