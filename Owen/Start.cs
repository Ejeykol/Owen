using System;
using System.Windows.Forms;

namespace Owen
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы уверены что хотите выйти","Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
         }

        private void Enter_Click(object sender, EventArgs e)
        {
            Authorization frm = new Authorization();
            frm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Converter frm = new Converter();
            frm.Show();
            this.Hide();
        }
        private void Start_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TableViewLite frm = new TableViewLite();
            frm.Show();
            this.Hide();
        }
    }
}
