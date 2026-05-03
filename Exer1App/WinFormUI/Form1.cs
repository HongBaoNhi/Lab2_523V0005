using System;
using System.Windows.Forms;
using BLL;
using DAL;

namespace WinFormUI
{
    public partial class Form1 : Form
    {
        CustomerService service = new CustomerService();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            dataGridView1.DataSource = service.GetAll();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Customer c = new Customer();
            c.Name = txtName.Text;
            c.Email = txtEmail.Text;
            service.Add(c);
            LoadData();
            RefreshGrid();
            MessageBox.Show("Add success");
        }

        private void btnGet_Click(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(txtId.Text, out id))
            {
                var c = service.Get(id);
                if (c != null)
                {
                    txtName.Text = c.Name;
                    txtEmail.Text = c.Email;
                }
                else
                {
                    MessageBox.Show("Not found");
                }
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(txtId.Text, out id))
            {
                Customer c = new Customer();
                c.Id = id;
                c.Name = txtName.Text;
                c.Email = txtEmail.Text;

                service.Update(c);
                LoadData();
                RefreshGrid();

                MessageBox.Show("Update success");
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }
        }

        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            int id;
            if (int.TryParse(txtId.Text, out id))
            {
                service.Delete(id);
                LoadData();
                RefreshGrid();

                MessageBox.Show("Delete success");
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }
        }

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                txtId.Text = row.Cells["Id"].Value.ToString();
                txtName.Text = row.Cells["Name"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            Customer c = new Customer();
            c.Name = txtName.Text;
            c.Email = txtEmail.Text;

            service.Add(c);
            LoadData();
            RefreshGrid();

            MessageBox.Show("Add success");
        }

        void LoadData2()
        {
            dataGridView1.DataSource = service.GetAll();
        }

        private void btnGet_Click_1(object sender, EventArgs e)
        {
            int id;

            if (int.TryParse(txtId.Text, out id))
            {
                var c = service.Get(id);

                if (c != null)
                {
                    txtName.Text = c.Name;
                    txtEmail.Text = c.Email;
                }
                else
                {
                    MessageBox.Show("Not found");
                }
            }
            else
            {
                MessageBox.Show("Invalid ID");
            }
        }

        void RefreshGrid()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = service.GetAll();
        }
    }
}