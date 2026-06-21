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
    public partial class AddNoteForm : Form
    {
        public AddNoteForm()
        {
            InitializeComponent();
        }

        private OleDbConnection GetConnection()
        {
            string dbPath = Application.StartupPath + "\\notedb1.mdb";
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbPath;
            return new OleDbConnection(connectionString);
        }

        private void AddNoteForm_Load(object sender, EventArgs e)
        {

        }

        private void richTextBoxEx1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
    string content = txtContent.Text.Trim();

    if (title == "")
    {
        MessageBox.Show("Please enter a title first.");
        return;
    }

    try
    {
        using (OleDbConnection conn = GetConnection())
        {
            conn.Open();
            
            string query = $"INSERT INTO Notes (UserId, Title, Content, CreateDate) VALUES ({CurrentUser.Id}, '{title.Replace("'", "''")}', '{content.Replace("'", "''")}', #{DateTime.Now:yyyy/MM/dd HH:mm:ss}#)";
            
            // MessageBox.Show("Query: " + query);
            
            using (OleDbCommand cmd = new OleDbCommand(query, conn))
            {
                cmd.ExecuteNonQuery();
            }
        }
        MessageBox.Show("Note saved!");
        this.Close();
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error: " + ex.Message);
    }
        }

        private void btnAddNote_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
