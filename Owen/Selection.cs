using System;
using System.Windows.Forms;

namespace Owen
{
    public partial class Selection : Form
    {
        public Selection()
        {
            InitializeComponent();
        }

        private void AddNew_Click(object sender, EventArgs e)
        {
            Import frm = new Import();
            frm.Show();
            this.Hide();
        }
        private void Converter_Click(object sender, EventArgs e)
        {
            Converter frm = new Converter();
            frm.Show();
            this.Hide();
        }

        private void ToolStripButtonBack_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены что хотите вернуться?", "Возврат на форму авторизации", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Authorization frm = new Authorization();
                frm.Show();
                this.Hide();
            }
        }
    }
}
