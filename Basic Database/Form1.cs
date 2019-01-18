using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace Basic_Database
{
    public partial class Form1 : Form
    {
        string connectionString;
        SqlConnection connection;
        public Form1()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["Basic_Database.Properties.Settings.Database1ConnectionString"].ConnectionString;

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'database1DataSet.TabelElevi' table. You can move, or remove it, as needed.
            //this.tabelEleviTableAdapter.Fill(this.database1DataSet.TabelElevi);
            PopulateElevi();
        }

        private void PopulateElevi()
        {
            string query = "SELECT * FROM TabelElevi";

            using (connection = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query,connection))
            {
                DataTable tabelElevi = new DataTable();
                adapter.Fill(tabelElevi);

                listElevi.DisplayMember = "Nume";
                listElevi.ValueMember = "Id";
                listElevi.DataSource = tabelElevi;
                dataGridView1.DataSource = tabelElevi;

            }
        }
    }
}
