namespace NoteTakingApp
{
    partial class MainApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.btnAddNote = new DevComponents.DotNetBar.ButtonX();
            this.lblWelcome = new DevComponents.DotNetBar.LabelX();
            this.flowLayoutNotes = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.buttonX1.Image = global::NoteTakingApp.Properties.Resources.close_20px;
            this.buttonX1.Location = new System.Drawing.Point(1057, 3);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Shape = new DevComponents.DotNetBar.EllipticalShapeDescriptor();
            this.buttonX1.Size = new System.Drawing.Size(25, 25);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 16;
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // btnAddNote
            // 
            this.btnAddNote.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAddNote.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(99)))), ((int)(((byte)(156)))));
            this.btnAddNote.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.btnAddNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddNote.Location = new System.Drawing.Point(475, 12);
            this.btnAddNote.Name = "btnAddNote";
            this.btnAddNote.Size = new System.Drawing.Size(158, 48);
            this.btnAddNote.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAddNote.SymbolColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.btnAddNote.TabIndex = 18;
            this.btnAddNote.Text = "+ Add New Note";
            this.btnAddNote.TextColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(212)))), ((int)(((byte)(212)))));
            this.btnAddNote.Click += new System.EventHandler(this.btnAddNote_Click_1);
            // 
            // lblWelcome
            // 
            // 
            // 
            // 
            this.lblWelcome.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblWelcome.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblWelcome.Location = new System.Drawing.Point(31, 12);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(140, 48);
            this.lblWelcome.TabIndex = 19;
            this.lblWelcome.Text = "Welcome";
            // 
            // flowLayoutNotes
            // 
            this.flowLayoutNotes.AutoScroll = true;
            this.flowLayoutNotes.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutNotes.Location = new System.Drawing.Point(0, 66);
            this.flowLayoutNotes.Name = "flowLayoutNotes";
            this.flowLayoutNotes.Size = new System.Drawing.Size(1084, 565);
            this.flowLayoutNotes.TabIndex = 20;
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(1084, 631);
            this.Controls.Add(this.flowLayoutNotes);
            this.Controls.Add(this.lblWelcome);
            this.Controls.Add(this.btnAddNote);
            this.Controls.Add(this.buttonX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainApp";
            this.Load += new System.EventHandler(this.MainApp_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX btnAddNote;
        private DevComponents.DotNetBar.LabelX lblWelcome;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutNotes;
    }
}