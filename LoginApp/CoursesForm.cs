using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class CoursesForm : Form
    {
        string connectionString;

        public CoursesForm()
        {
            InitializeComponent();

            connectionString = ConfigurationManager
                .ConnectionStrings["LoginDBConnectionString"]
                .ConnectionString;
        }

        private void CoursesForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM tblCourses", connection);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                txtCourseName.Text = dataGridView1.CurrentRow.Cells["CourseName"].Value.ToString();
                txtCredits.Text = dataGridView1.CurrentRow.Cells["Credits"].Value.ToString();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "INSERT INTO tblCourses (CourseName, Credits) VALUES (@name, @credits)", connection);

                cmd.Parameters.AddWithValue("@name", txtCourseName.Text);
                cmd.Parameters.AddWithValue("@credits", txtCredits.Text);

                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CourseID"].Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "UPDATE tblCourses SET CourseName=@name, Credits=@credits WHERE CourseID=@id", connection);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", txtCourseName.Text);
                cmd.Parameters.AddWithValue("@credits", txtCredits.Text);

                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CourseID"].Value);

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(
                    "DELETE FROM tblCourses WHERE CourseID=@id", connection);

                cmd.Parameters.AddWithValue("@id", id);

                cmd.ExecuteNonQuery();
                LoadData();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}