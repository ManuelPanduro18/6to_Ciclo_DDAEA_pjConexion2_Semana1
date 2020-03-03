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

namespace pjConexion2
{
    public partial class frmClientes : Form
    {
        public frmClientes()
        {
            InitializeComponent();
        }

        SqlConnection cn = new SqlConnection("Data Source=(local);Initial Catalog=Neptuno;Integrated Security=True");

        public void ListaClientes()
        {
            using (SqlDataAdapter Df = new SqlDataAdapter("Select * from Clientes", cn))
            {
                using (DataSet Da = new DataSet())
                {
                    Df.Fill(Da, "Clientes");

                    dgClientes.DataSource = Da.Tables["Clientes"];

                    lblTotal.Text = Da.Tables["Clientes"].Rows.Count.ToString();
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ListaClientes();
        }
    }
}
