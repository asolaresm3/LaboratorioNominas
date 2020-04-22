using Capa_Logica;
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
using Laboratorio_Nomina.Vistas;


namespace Laboratorio_Nomina.Mantenimientos
{
    public partial class Frm_Mant_Concepto : Form
    {
        Logica logic = new Logica();
        string scampo;

        public Frm_Mant_Concepto()
        {
            InitializeComponent();
            scampo = logic.siguiente("concepto", "codigo_concepto");
            bloqueartxt();
            this.Text = "CONCEPTOS";
            Txt_Cod.Text = scampo;
            txt_descripcion.Enabled = false;
            Txt_Cod.Enabled = false;
            Txt_nombre.Enabled = false;

        }

        private void btn_minimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btn_cerrar_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
            txt_descripcion.Enabled = true;
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
            txt_descripcion.Enabled = false;
        }

        public void limpiar()
        {
            Txt_Cod.Enabled = false;
            Txt_nombre.Enabled = false;
            txt_descripcion.Enabled = false;
            Txt_Cod.Text = "";
            Txt_nombre.Text = "";
            txt_descripcion.Text = "";
            scampo = logic.siguiente("concepto", "codigo_concepto");
            Txt_Cod.Text = scampo;
        }
        private void Btn_ingresar_Click(object sender, EventArgs e)
        {
            desbloqueartxt();
        }

        private void Btn_editar_Click(object sender, EventArgs e)
        {
            OdbcDataReader cita = logic.modificarConcepto(Txt_Cod.Text, Txt_nombre.Text, txt_descripcion.Text);
            MessageBox.Show("Datos modificados correctamente.");
        }

        private void Btn_guardar_Click(object sender, EventArgs e)
        {
            OdbcDataReader cita = logic.Insertarconcepto(Txt_Cod.Text, Txt_nombre.Text, txt_descripcion.Text);
            MessageBox.Show("Datos registrados.");
            limpiar();

        }

        private void Btn_borrar_Click(object sender, EventArgs e)
        {
            OdbcDataReader cita = logic.eliminarconcepto(Txt_Cod.Text);
            MessageBox.Show("Eliminado Correctamentee.");
        }

        private void Btn_consultar_Click(object sender, EventArgs e)
        {
            Frm_vistaConceptos concep = new Frm_vistaConceptos();
            concep.ShowDialog();

            if (concep.DialogResult == DialogResult.OK)
            {
                Txt_Cod.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                      Cells[0].Value.ToString();
                Txt_nombre.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                      Cells[1].Value.ToString();
                txt_descripcion.Text = concep.Dgv_consulta.Rows[concep.Dgv_consulta.CurrentRow.Index].
                      Cells[2].Value.ToString();
            }
        }
    }
}
