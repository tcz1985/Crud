using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CRUD.EntityLayer;
using System.Data;
using System.Data.SqlClient;

namespace CRUD.DataLayer
{
    public class EmpleadoDL
    {
        public List<Empleado> Lista()
        {
            List<Empleado> lista = new List<Empleado>();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from fn_empleados()", oConexion);
                cmd.CommandType = CommandType.Text;
                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Empleado
                            {

                                IdEmpleado = Convert.ToInt32(dr["IdEmpleado"].ToString()),
                                Nombres = dr["Nombres"].ToString(),
                                Apellidos = dr["Apellidos"].ToString(),
                                Departamento = new Departamento
                                {
                                    IdDepartamento = Convert.ToInt32(dr["IdDepartamento"].ToString()),
                                    Nombre = dr["Nombre"].ToString()
                                },
                                    Sueldo = (decimal)dr["Sueldo"],
                                    FechaContrato = dr["FechaContrato"].ToString()
                            });
                                
                        }
                    }
                    return lista;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Empleado Obtener(int IdEmpleado)  
        {
            Empleado entidad = new Empleado();
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("select * from fn_empleados(@IdEmpleado)", oConexion);
                cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                cmd.CommandType = CommandType.Text;
                try
                {
                    oConexion.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                       
                        if(dr.Read())
                            {
                                entidad.IdEmpleado = Convert.ToInt32(dr["IdEmpleado"].ToString());
                                entidad.Nombres = dr["Nombres"].ToString();
                                entidad.Apellidos = dr["Apellidos"].ToString();
                                entidad.Departamento = new Departamento
                                {
                                    IdDepartamento = Convert.ToInt32(dr["IdDepartamento"].ToString()),
                                    Nombre = dr["Nombre"].ToString()
                                };
                                entidad.Sueldo = (decimal)dr["Sueldo"];
                                entidad.FechaContrato = dr["FechaContrato"].ToString();
                            }
                        
                    }
                    return entidad;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    
        public bool Crear(Empleado entidad)
        {
            bool respuesta = false;
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_CrearEmpleado", oConexion);
                cmd.Parameters.AddWithValue("@Nombres", entidad.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", entidad.Apellidos);
                cmd.Parameters.AddWithValue("@IdDepartamento", entidad.Departamento.IdDepartamento);
                cmd.Parameters.AddWithValue("@Sueldo", entidad.Sueldo);
                cmd.Parameters.AddWithValue("@FechaContrato", entidad.FechaContrato);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                   int filasAfectadas = cmd.ExecuteNonQuery();
                    if(filasAfectadas > 0) respuesta = true;

                    return respuesta;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


        }

        public bool Editar(Empleado entidad)
        {
            bool respuesta = false;
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_EditarEmpleado", oConexion);
                cmd.Parameters.AddWithValue("@IdEmpleado", entidad.IdEmpleado);
                cmd.Parameters.AddWithValue("@Nombres", entidad.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", entidad.Apellidos);
                cmd.Parameters.AddWithValue("@IdDepartamento", entidad.Departamento.IdDepartamento);
                cmd.Parameters.AddWithValue("@Sueldo", entidad.Sueldo);
                cmd.Parameters.AddWithValue("@FechaContrato", entidad.FechaContrato);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0) respuesta = true;

                    return respuesta;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


        }

        public bool Eliminar(int IdEmpleado)
        {
            bool respuesta = false;
            using (SqlConnection oConexion = new SqlConnection(Conexion.cadena))
            {
                SqlCommand cmd = new SqlCommand("sp_EliminarEmpleado", oConexion);
                cmd.Parameters.AddWithValue("@IdEmpleado", IdEmpleado);
                cmd.CommandType = CommandType.StoredProcedure;
                try
                {
                    oConexion.Open();
                    int filasAfectadas = cmd.ExecuteNonQuery();
                    if (filasAfectadas > 0) respuesta = true;

                    return respuesta;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }


        }
    }
}
