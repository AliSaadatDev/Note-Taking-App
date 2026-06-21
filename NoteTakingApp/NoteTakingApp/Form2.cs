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
    public partial class SighnupForm : Form
    {
        public SighnupForm()
        {
            InitializeComponent();
        }

        private OleDbConnection GetConnection()
        {
            string dbPath = Application.StartupPath + "\\notedb1.mdb";
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbPath;

            return new OleDbConnection(connectionString);
        }

        private bool IsUsernameExists(string username)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM [user] WHERE username = @username";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private void RegisterUser(string username, string password)
        {
            using (OleDbConnection conn = GetConnection())
            {
                conn.Open();
                string query = "INSERT INTO [user] (username, [password]) VALUES (@username, @password)";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void SighnupForm_Load(object sender, EventArgs e)
        {

        }

        private void SighnUpButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }

        private void UsernameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string username = UsernameTextBox.Text.Trim();
            string password = PasswordTextBox.Text.Trim();

            if (username.Length <= 0)
            {
                MessageBox.Show("Username is requierd.");
                return;
            }

            else if (password.Length <= 0)
            {
                MessageBox.Show("Password is requierd.");
                return;
            }
        }

        private void labelX1_Click(object sender, EventArgs e)
        {

        }

        private void labelX3_Click(object sender, EventArgs e)
        {

        }

        private void labelX2_Click(object sender, EventArgs e)
        {

        }

        private void panelEx1_Click(object sender, EventArgs e)
        {

        }

        private void buttonX3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void labelX4_Click(object sender, EventArgs e)
        {

        }

        private void labelX5_Click(object sender, EventArgs e)
        {

        }

        private void labelX6_Click(object sender, EventArgs e)
        {

        }

        private void richTextBoxEx1_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBoxEx3_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX9_Click(object sender, EventArgs e)
        {

        }

        private void panelEx2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBoxEx2_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelX7_Click(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonX4_Click(object sender, EventArgs e)
        {
            string username = usernametext.Text.Trim();
            string password = passwordtext.Text.Trim();
            string confirm = confirmtext.Text.Trim();

            if (username.Length <= 0)
            {
                MessageBox.Show("Username is requierd.");
                return;
            }

            else if (password.Length <= 0)
            {
                MessageBox.Show("Password is requierd.");
                return;
            }

            else if (confirm.Length <= 0)
            {
                MessageBox.Show("Confirm password is requierd.");
                return;
            }

            else if (confirm != password)
            {
                MessageBox.Show("Password and confirm password dont match.");
                return;
            }

            try
            {
                if (IsUsernameExists(username))
                {
                    MessageBox.Show("this username already exists. please choose another one.");
                    return;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Database error while checking username:" + ex.Message, "Error");
                return;
            }

            try
            {
                RegisterUser(username, password);
                MessageBox.Show("Registration successful! You can now ligin.", "Success");

                this.Hide();
                new LoginForm().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error whule registering: " + ex.Message, "Database Error");
            }
        }

        private void labelX8_Click(object sender, EventArgs e)
        {

        }

        private void buttonX2_Click(object sender, EventArgs e)
        {
            this.Hide();
            new LoginForm().Show();
        }
    }
}
