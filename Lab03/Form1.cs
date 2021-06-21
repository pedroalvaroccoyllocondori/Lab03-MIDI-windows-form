using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;

namespace Lab03
{

    public partial class Form1 : Form
    {
        SqlConnection conn;

        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            String servidor = txtServidor.Text;
            String bd = txtBaseDatos.Text;
            String user = txtUsuario.Text;
            String pwd = txtPassword.Text;

            String str = "Server=" + servidor + ";DataBase=" + bd + ";";

            //la cadema de coneccion cambia en funcion a estado del checkbox
            if (chkAutenticacion.Checked)
            {
                str += "Integrated Security=true";

            }
            else
            {
                str += "User Id=" + user + ";Password=" + pwd + ";";

            }
            try
            {
                conn = new SqlConnection(str);
                conn.Open();
                MessageBox.Show("conectado satisfactoriamente");
                btnDesconectar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("error al desconectar el servidor : \n" + ex.ToString());
            }
        }

        private void btnEstado_Click(object sender, EventArgs e)
        {
            //intenatamos obtener el estado de la coneccion
            try
            {
                if (conn.State==ConnectionState.Open)
                {
                    MessageBox.Show("estado del servidor:" + conn.State +
                        "\n Version del servidor" + conn.ServerVersion +
                        "\n base de datos" + conn.Database);
                }
                else
                {
                    MessageBox.Show("estado del servidor" + conn.State);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("imposible determinar el estado del servidor: \n " +
                    ex.ToString());
            }
        }

        private void btnDesconectar_Click(object sender, EventArgs e)
        {
            try
            {
                if (conn.State != ConnectionState.Closed)
                {
                    conn.Close();
                    MessageBox.Show("coneccion cerrada satisfactoriamente");
                }
                else
                {
                    MessageBox.Show("la coneccion ya sta cerrada");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("ocurrio un error al cerrar la coneccion \n" +
                    ex.ToString());
                throw;
            }
        }

        private void chkAutenticacion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAutenticacion.Checked)
            {
                txtUsuario.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtUsuario.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Persona persona = new Persona(conn);
            persona.Show();
        }
    }
}
