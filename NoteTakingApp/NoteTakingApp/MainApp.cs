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
    public partial class MainApp : Form
    {
        public MainApp()
        {
            InitializeComponent();
        }

        private OleDbConnection GetConnection()
        {
            string dbPath = Application.StartupPath + "\\notedb1.mdb";
            string connectionString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbPath;
            return new OleDbConnection(connectionString);
        }

        private void MainApp_Load(object sender, EventArgs e)
        {
            lblWelcome.Text = "Welcome," + CurrentUser.Username;
            LoadNotes();
        }

        private void LoadNotes()
        {
            flowLayoutNotes.Controls.Clear();

            try
            {
                using (OleDbConnection conn = GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Id, Title, Content FROM Notes WHERE UserId = @userId ORDER BY Id DESC";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@userId", CurrentUser.Id);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = reader.GetInt32(0);
                                string title = reader.GetString(1);
                                string content = reader.GetString(2);

                                CreateNoteCard(id, title, content);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در بارگذاری: " + ex.Message);
            }
        }

        private void CreateNoteCard(int noteId, string title, string content)
        {
            Panel card = new Panel();
            card.Width = 230;
            card.Height = 130;
            card.BackColor = Color.LightYellow;
            card.BorderStyle = BorderStyle.FixedSingle;
            card.Margin = new Padding(8);
            card.Tag = noteId;

            Label lblTitle = new Label();
            lblTitle.Text = title;
            lblTitle.Font = new Font("Tahoma", 11, FontStyle.Bold);
            lblTitle.Location = new Point(8, 8);
            lblTitle.Width = 210;
            lblTitle.Height = 28;

            Label lblContent = new Label();
            string shortContent = content.Length > 70 ? content.Substring(0, 70) + "..." : content;
            lblContent.Text = shortContent;
            lblContent.Location = new Point(8, 40);
            lblContent.Width = 210;
            lblContent.Height = 50;
            lblContent.AutoSize = false;

            Button btnDelete = new Button();
            btnDelete.Text = "Delete";
            btnDelete.Size = new Size(70, 28);
            btnDelete.Location = new Point(8, 95);
            btnDelete.BackColor = Color.IndianRed;
            btnDelete.ForeColor = Color.White;
            btnDelete.Tag = noteId;
            btnDelete.Click += BtnDelete_Click;

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblContent);
            card.Controls.Add(btnDelete);

            flowLayoutNotes.Controls.Add(card);
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int noteId = (int)btn.Tag;

            DialogResult result = MessageBox.Show("Are you sure you want to delete this note?", "Confirm", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (OleDbConnection conn = GetConnection())
                    {
                        conn.Open();
                        string query = "DELETE FROM Notes WHERE Id = @id";
                        using (OleDbCommand cmd = new OleDbCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", noteId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Note deleted!");
                    LoadNotes(); 
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            AddNoteForm addForm = new AddNoteForm();
            addForm.ShowDialog();   
            LoadNotes();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void buttonX2_Click(object sender, EventArgs e)
        {

        }

        private void btnAddNote_Click_1(object sender, EventArgs e)
        {
            AddNoteForm addForm = new AddNoteForm();
            addForm.ShowDialog();
            LoadNotes();
        }
    }
}
