using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
   public class Sentencias
    {

        Conexion cn = new Conexion();
        OdbcCommand comm;


        //--------------------------------------------------------------------OBTENER COD SIGUIENTE--------------------------------------------------------------------//
        public string obtenerfinal(string tabla, string campo)
        {
            String camporesultante = "";
            try
            {
                string sql = "SELECT MAX(" + campo + "+1) FROM " + tabla + ";"; //SELECT MAX(idFuncion) FROM `funciones`     
                OdbcCommand command = new OdbcCommand(sql, cn.conexionbd());
                OdbcDataReader reader = command.ExecuteReader();
                reader.Read();
                camporesultante = reader.GetValue(0).ToString();

                if (String.IsNullOrEmpty(camporesultante))
                    camporesultante = "1";
            }
            catch (Exception)
            {
                Console.WriteLine(camporesultante);
            }
            return camporesultante;
        }

        //---------------Insertar Departamento
        public OdbcDataReader InsertarDepartamento(string sCodigo, string sNombre)
        {
            try
            {
                cn.conexionbd();
                string consulta = "insert into departamento values('" + sCodigo + "' , '" + sNombre + "','1');";
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }


        //---------------Modificar Departamento
        public OdbcDataReader modificarDepartamento(string sCodigo,string sNombre)
        {
            try
            {
                cn.conexionbd();
                string consulta = "UPDATE departamento set nombre_departamento='" + sNombre + "' where codigo_departamento = " + sCodigo + ";";
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        //---------------Eliminar Departamento
        public OdbcDataReader eliminarDepartamento(string sCodigo)
        {
            try
            {
                cn.conexionbd();
                string consulta = "UPDATE departamento set estatus_departamento='0' where codigo_departamento='" + sCodigo + "';";
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        //----------Consultar Departamento
        public OdbcDataReader consultaDepartamento()
        {
            try
            {
                cn.conexionbd();
                string consulta = "SELECT * FROM departamento WHERE estatus_departamento = 1 ;";
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }

        }


        //---------------Insertar Puesto
        public OdbcDataReader InsertarPuesto(string sCodigo, string sNombre)
        {
            try
            {
                cn.conexionbd();
                string consulta = "insert into puesto values('" + sCodigo + "' , '" + sNombre + "','1');";
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }


        //---------------Modificar Puesto
        public OdbcDataReader modificarPuesto(string sCodigo, string sNombre)
        {
            try
            {
                cn.conexionbd();
                string consulta = "UPDATE puesto set nombre_puesto='" + sNombre + "' where codigo_puesto = " + sCodigo + ";";
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        //---------------Eliminar Puesto
        public OdbcDataReader eliminarPuesto(string sCodigo)
        {
            try
            {
                cn.conexionbd();
                string consulta = "UPDATE puesto set estatus_puesto='0' where codigo_puesto='" + sCodigo + "';";
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        //----------Consultar Puesto
        public OdbcDataReader consultaPuesto()
        {
            try
            {
                cn.conexionbd();
                string consulta = "SELECT * FROM puesto WHERE estatus_puesto = '1' ;";
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }

        }

        //---------------Insertar Empleado
        public OdbcDataReader InsertarEmpleado(string sCodigo, string sNombre, string sPuesto, string sDepartamento, string sueldo)
        {
            try
            {
                cn.conexionbd();
                string consulta = "insert into empleado values('" + sCodigo + "' , '" + sNombre + "','"+sPuesto+"','"+sDepartamento+"','"+sueldo+"','1');";
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }


        //---------------Modificar Empleado
        public OdbcDataReader modificarEmpleado(string sCodigo, string sNombre, string sPuesto, string sDepartamento, string sueldo)
        {
            try
            {
                cn.conexionbd();
                string consulta = "UPDATE empleado set nombre_departamento='" + sNombre + "', codigo_puesto='"+sPuesto+"', codigo_departamento='"+sDepartamento+"',sueldo_empleado='"+sueldo+"' codigo_empleado = " + sCodigo + ";";
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        //---------------Eliminar Empleado
        public OdbcDataReader eliminarEmpleado(string sCodigo)
        {
            try
            {
                cn.conexionbd();
                string consulta = "UPDATE empleado set estatus_empleado='0' where codigo_empleado='" + sCodigo + "';";
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        //----------Consultar Empleado
        public OdbcDataReader consultaEmpleado()
        {
            try
            {
                cn.conexionbd();
                string consulta = "SELECT * FROM empleado WHERE estatus_empleado = 1 ;";
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }

        }


        public OdbcDataReader modificarconcepto(string sCodigo, string sNombre, string sTipoconcepto)
        {
            try
            {
                cn.conexionbd();
                string consulta = "UPDATE concepto set nombre_concepto='" + sNombre + "',efecto_concepto='" + sTipoconcepto + "',estatus_concepto='1' where codigo_concepto='" + sCodigo + "';";
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }
        public OdbcDataReader Insertarconcepto(string sCodigo, string sNombre, string sTipoconcepto)
        {
            try
            {
                cn.conexionbd();
                string consulta = "insert into concepto values(" + sCodigo + ", '" + sNombre + "' ,'" + sTipoconcepto + "','1');";
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }
        public OdbcDataReader eliminarconcepto(string sCodigo)
        {
            try
            {
                cn.conexionbd();
                string consulta = "UPDATE concepto set estatus_concepto='0' where codigo_concepto='" + sCodigo + "';";
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }
        }

        public OdbcDataReader consultaconcepto()
        {
            try
            {
                cn.conexionbd();
                string consulta = "SELECT * FROM concepto WHERE estatus_concepto = '1' ;";
                comm = new OdbcCommand(consulta, cn.conexionbd());
                OdbcDataReader mostrar = comm.ExecuteReader();
                return mostrar;
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
                return null;
            }

        }

    }
}
