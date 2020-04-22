using Capa_Datos;
using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Logica
{
    public class Logica
    {
        Sentencias sn = new Sentencias();
        /*OBTENER COD SIGUIENTE*/
        public string siguiente(string tabla, string campo)
        {
            string llave = sn.obtenerfinal(tabla, campo);
            return llave;
        }

        //----Insertar Departamento
        public OdbcDataReader InsertarDepartamento(string sCodigo, string sNombre)
        {
            return sn.InsertarDepartamento(sCodigo, sNombre);

        }

        //----Modificar Departamento
        public OdbcDataReader modificarDepartamento(string sCodigo, string sNombre)
        {
            return sn.modificarDepartamento(sCodigo, sNombre);

        }

        //----Eliminar Departamento
        public OdbcDataReader eliminarDepartamento(string sCodigo)
        {
            return sn.eliminarDepartamento(sCodigo);

        }

        //-----Consultar Concepto
        public OdbcDataReader consultarDepartamento()
        {
            return sn.consultaDepartamento();
        }


        //----Insertar Puesto
        public OdbcDataReader InsertarPuesto(string sCodigo, string sNombre)
        {
            return sn.InsertarPuesto(sCodigo, sNombre);

        }

        //----Modificar Puesto
        public OdbcDataReader modificarPuesto(string sCodigo, string sNombre)
        {
            return sn.modificarPuesto(sCodigo, sNombre);

        }

        //----Eliminar Puesto
        public OdbcDataReader eliminarPuesto(string sCodigo)
        {
            return sn.eliminarPuesto(sCodigo);

        }

        //-----Consultar Puesto
        public OdbcDataReader consultarPuesto()
        {
            return sn.consultaPuesto();
        }


        //----Insertar Empleado
        public OdbcDataReader InsertarEmpleado(string sCodigo, string sNombre, string sPuesto, string sDepartamento, string sueldo)
        {
            return sn.InsertarEmpleado(sCodigo, sNombre,sPuesto,sDepartamento,sueldo);

        }

        //----Modificar Empleado
        public OdbcDataReader modificarEmpleado(string sCodigo, string sNombre, string sPuesto, string sDepartamento, string sueldo)
        {
            return sn.modificarEmpleado(sCodigo, sNombre,sPuesto,sDepartamento,sueldo);

        }

        //----Eliminar Puesto
        public OdbcDataReader eliminarEmpleado(string sCodigo)
        {
            return sn.eliminarEmpleado(sCodigo);

        }

       //-----Consultar Empleado
        public OdbcDataReader consultarEmpleado()
        {
            return sn.consultaEmpleado();
        }

        public OdbcDataReader modificarConcepto(string sCodigo, string sNombre, string sTipoconcepto)
        {
            return sn.modificarconcepto(sCodigo, sNombre, sTipoconcepto);
        }
        public OdbcDataReader Insertarconcepto(string sCodigo, string sNombre, string sTipoconcepto)
        {
            return sn.Insertarconcepto(sCodigo, sNombre, sTipoconcepto);

        }

        public OdbcDataReader eliminarconcepto(string sCodigo)
        {
            return sn.eliminarconcepto(sCodigo);

        }

        public OdbcDataReader consultarconcepto()
        {
            return sn.consultaconcepto();
        }


    }
}
