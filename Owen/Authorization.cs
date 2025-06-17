using System;
using System.Data.SQLite;
using System.Windows.Forms;
using System.Configuration;

namespace Owen
{
    public partial class Authorization : Form
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["LiteConnectionString"].ConnectionString; 

        public Authorization()
        {
            InitializeComponent();
        }

        private void Authorization_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ConnectionString))
            {
                MessageBox.Show("Строка подключения к базе данных не найдена в app.config под именем 'LiteConnectionString'.", "Ошибка конфигурации", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Auth.Enabled = false;
            }
        }

        private void Auth_Click(object sender, EventArgs e)
        {
            try
            {
                using (SQLiteConnection sqlcon = new SQLiteConnection(ConnectionString))
                {
                    sqlcon.Open();

                    string query = "SELECT COUNT(1) FROM auth WHERE Login = @Login AND Password = @Password";

                    using (SQLiteCommand command = new SQLiteCommand(query, sqlcon))
                    {
                        command.Parameters.AddWithValue("@Login", Login.Text);
                        command.Parameters.AddWithValue("@Password", Password.Text);

                        int userCount = 0;
                        if (int.TryParse(command.ExecuteScalar()?.ToString(), out userCount) && userCount == 1)
                        {
                            if (Login.Text == "admin")
                            {
                                Selection frm = new Selection();
                                frm.Show();
                                this.Hide();
                            }
                            else
                            {
                                TableViewLite frm = new TableViewLite();
                                frm.Show();
                                this.Hide();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Не верно введен логин или пароль", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к базе данных или выполнения запроса: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ToolStripButtonBack_Click(object sender, EventArgs e)
        {
            Start frm = new Start();
            frm.Show();
            this.Hide();
        }
    }
}