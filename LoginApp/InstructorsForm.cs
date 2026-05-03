using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class InstructorsForm : Form
    {
        string connectionString;

        public InstructorsForm()
        {
            InitializeComponent();

            connectionString = ConfigurationManager
                .ConnectionStrings["LoginDBConnectionString"]
                .ConnectionString;
        }

        private void InstructorsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblInstructors", connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                txtInstructorName.Text = dataGridView1.CurrentRow.Cells["InstructorName"].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO tblInstructors (InstructorName) VALUES (@name)", connection);

                cmd.Parameters.AddWithValue("@name", txtInstructorName.Text);

                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["InstructorID"].Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE tblInstructors SET InstructorName=@name WHERE InstructorID=@id", connection);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", txtInstructorName.Text);

                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["InstructorID"].Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM tblInstructors WHERE InstructorID=@id", connection);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {

        }
    }
}