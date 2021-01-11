using MvcEntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace MvcEntityFramework.Data
{
    public class DepartamentosContextSQL : IDepartamentosContext
    {
        private SqlDataAdapter addept;
        private DataTable tabladept;
        private SqlConnection cn;
        private SqlCommand com;

        public DepartamentosContextSQL()
        {
            String cadena = "Data Source=LOCALHOST;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2020";
            this.addept = new SqlDataAdapter("SELECT * FROM DEPT", cadena);
            this.tabladept = new DataTable();
            this.addept.Fill(this.tabladept);
            this.cn = new SqlConnection(cadena);
            this.com = new SqlCommand();
            this.com.Connection = this.cn;
        }
        public DepartamentosContextSQL(string cadena)
        {
            //String cadena = "Data Source=LOCALHOST;Initial Catalog=HOSPITAL;Persist Security Info=True;User ID=SA;Password=MCSD2020";
            this.addept = new SqlDataAdapter("SELECT * FROM DEPT", cadena);
            this.tabladept = new DataTable();
            this.addept.Fill(this.tabladept);
        }
        public List<Departamento> GetDepartamentos()
        {
            //SELECT CON LINQ
            var consulta = from datos in this.tabladept.AsEnumerable() select datos;
            List<Departamento> departamentos = new List<Departamento>();
            //RECORREMOS TODOS LOS DATOS DE LA CONSULATA Y EXTRAEMOS CADA DEPARTAMENTO
            foreach(var dato in consulta)
            {
                //CREAMOS UN OBJETO DEPARTAMENTO Y LO AÑADIMOS A LA COLECCION
                Departamento dept = new Departamento();
                dept.Numero = dato.Field<int>("DEPT_NO");
                dept.Nombre = dato.Field<string>("DNOMBRE");
                dept.Localidad = dato.Field<string>("LOC");
                departamentos.Add(dept);
            }
            return departamentos;
        }
        public Departamento GetDepartamento( int iddept )
        {
            var consulta = from datos in this.tabladept.AsEnumerable() where datos.Field<int>("DEPT_NO") == iddept select datos;
            Departamento dept = new Departamento();
            var registro = consulta.First();
            dept.Numero = registro.Field<int>("DEPT_NO");
            dept.Nombre = registro.Field<string>("DNOMBRE");
            dept.Localidad = registro.Field<string>("LOC");
            return dept;
        }
        public int UpdateDepartamento (Departamento dept)
        {
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = "update dept set dnombre=@nombre, loc=@localidad where dept_no=@iddept";
            this.com.Parameters.AddWithValue("@nombre", dept.Nombre);
            this.com.Parameters.AddWithValue("@localidad", dept.Localidad);
            this.com.Parameters.AddWithValue("@iddept", dept.Numero);
            this.cn.Open();
            int updates = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return updates;
        }
        public int InsertDepartamento (Departamento dept)
        {
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = "insert into dept values(@iddept,@nombre,@localidad)";
            this.com.Parameters.AddWithValue("@iddept",dept.Numero);
            this.com.Parameters.AddWithValue("@nombre", dept.Nombre);
            this.com.Parameters.AddWithValue("@localidad", dept.Localidad);
            this.cn.Open();
            int inserts = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return inserts;
        }

        public int DeleteDepartamento(int iddept)
        {
            this.com.CommandType = CommandType.Text;
            this.com.CommandText = "delete from dept where dept_no=@iddept";
            this.com.Parameters.AddWithValue("@iddept", iddept);
            this.cn.Open();
            int deletes = this.com.ExecuteNonQuery();
            this.cn.Close();
            this.com.Parameters.Clear();
            return deletes;
        }
    }
}
