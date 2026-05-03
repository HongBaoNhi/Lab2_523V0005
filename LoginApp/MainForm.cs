using System;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StudentsForm f = new StudentsForm();
            f.Show();
        }

        private void instuctorsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewInstructorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InstructorsForm f = new InstructorsForm();
            f.Show();
        }

        private void departmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void viewDepartmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepartmentsForm f = new DepartmentsForm();
            f.Show();
        }

        private void viewCoursesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CoursesForm f = new CoursesForm();
            f.Show();
        }
    }
}