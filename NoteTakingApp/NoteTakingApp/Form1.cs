using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteTakingApp
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private OleDbConnection GetConnection()
        {
            string dbPath = Application.StartupPath + "\\notedb1.mdb";
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbPath;

            return new OleDbConnection(connectionString);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void textBoxX1_TextChanged(object sender, EventArgs e)
        {

        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void SighnUpButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new SighnupForm().Show();
        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void MainLoginLable_Click(object sender, EventArgs e)
        {

        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();

            if (username.Length <= 0)
            {
                MessageBox.Show("Username is required.");
                return;
            }
            else if (password.Length <= 0)
            {
                MessageBox.Show("Password is required.");
                return;
            }

            try
            {
                using (OleDbConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Id FROM [user] WHERE username = @username AND [password] = @password";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", password);

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            CurrentUser.Id = (int)result;
                            CurrentUser.Username = username;

                            MessageBox.Show("Login successful! Welcome " + username);

                            this.Hide();
                            MainApp mainApp = new MainApp();
                            mainApp.Show();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void labelX5_Click(object sender, EventArgs e)
        {

        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
