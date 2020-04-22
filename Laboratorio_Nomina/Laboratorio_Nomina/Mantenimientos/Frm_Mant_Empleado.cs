using Capa_Logica;
using Laboratorio_Nomina.Consultas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laboratorio_Nomina.Mantenimientos
{
    public partial class Frm_Mant_Empleado : Form
    {
        Logica logic = new Logica();
        string scampo;
        public Frm_Mant_Empleado()
        {
            InitializeComponent();
            scampo = logic.siguiente("empleado", "codigo_empleado");
            bloqueartxt();
            Txt_Cod.Text = scampo;
            Txt_nombre.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }

        public void bloqueartxt()
        {
            /*------------------------*/
            Btn_guardar.Enabled = false;
            Btn_editar.Enabled = false;
            Btn_borrar.Enabled = false;
            /*------------------------*/
            Txt_Cod.Enabled = false;
            Txt_nombre.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
        }

        public void desbloqueartxt()
        {
            /*------------------------*/
            Btn_guardar.Enabled = true;
            Btn_editar.Enabled = true;
            Btn_borrar.Enabled = true;
            /*------------------------*/
            Txt_Cod.Enabled = false;
            Txt_nombre.Enabled = true;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
        }

        public void limpiar()
        {
            Txt_Cod.Enabled = false;
            Txt_nombre.Enabled = false;
            Txt_Cod.Text = "";
            Txt_nombre.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

            scampo = logic.siguiente("puesto", "codigo_puesto");
            Txt_Cod.Text = scampo;
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_puesto_Click(object sender, EventArgs e)
        {
            Consulta_Puesto concep = new Consulta_Puesto();
            concep.ShowDialog();

            if (concep.DialogResult == DialogResult.OK)
            {

                textBox1.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                      Cells[0].Value.ToString();

            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Consulta_Departamento concep = new Consulta_Departamento();
            concep.ShowDialog();

            if (concep.DialogResult == DialogResult.OK)
            {

                textBox2.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                      Cells[0].Value.ToString();

            }
        }

        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            desbloqueartxt();
        }

        private void Btn_editar_Click(object sender, EventArgs e)
        {
            OdbcDataReader ejectuar = logic.modificarEmpleado(Txt_Cod.Text, Txt_nombre.Text,textBox1.Text,textBox2.Text,textBox3.Text);
            MessageBox.Show("Datos modificados correctamente.");
            limpiar();
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            OdbcDataReader cita = logic.InsertarEmpleado(Txt_Cod.Text, Txt_nombre.Text, textBox1.Text, textBox2.Text, textBox3.Text);
            MessageBox.Show("Datos registrados.");
            limpiar();
        }

        private void Btn_borrar_Click(object sender, EventArgs e)
        {
            OdbcDataReader cita = logic.eliminarEmpleado(Txt_Cod.Text);
            MessageBox.Show("Eliminado Correctamentee.");
            limpiar();
        }

        private void Btn_consultar_Click(object sender, EventArgs e)
        {
            Consulta_Empleado puesto = new Consulta_Empleado();
            puesto.ShowDialog();

            if (puesto.DialogResult == DialogResult.OK)
            {
                Txt_Cod.Text = puesto.Dgv_consulta.Rows[puesto.Dgv_consulta.CurrentRow.Index].
                      Cells[0].Value.ToString();
                Txt_nombre.Text = puesto.Dgv_consulta.Rows[puesto.Dgv_consulta.CurrentRow.Index].
                      Cells[1].Value.ToString();
            }
        }

        private void Btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
