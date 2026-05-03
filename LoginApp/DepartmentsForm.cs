using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class DepartmentsForm : Form
    {
        string connectionString;

        public DepartmentsForm()
        {
            InitializeComponent();

            connectionString = ConfigurationManager
                .ConnectionStrings["LoginDBConnectionString"]
                .ConnectionString;
        }

        private void DepartmentsForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblDepartments", connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                txtDepartmentName.Text = dataGridView1.CurrentRow.Cells["DepartmentName"].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO tblDepartments (DepartmentName) VALUES (@name)", connection);

                cmd.Parameters.AddWithValue("@name", txtDepartmentName.Text);

                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["DepartmentID"].Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE tblDepartments SET DepartmentName=@name WHERE DepartmentID=@id", connection);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", txtDepartmentName.Text);

                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["DepartmentID"].Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM tblDepartments WHERE DepartmentID=@id", connection);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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