namespace WindowsFormsApp1
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SMIOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.SMISave = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SMIClear = new System.Windows.Forms.ToolStripMenuItem();
            this.SMISelectAll = new System.Windows.Forms.ToolStripMenuItem();
            this.SMIDateTime = new System.Windows.Forms.ToolStripMenuItem();
            this.formatToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SMIFont = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SMIZoomIn = new System.Windows.Forms.ToolStripMenuItem();
            this.SMIZoomOut = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.editToolStripMenuItem,
            this.formatToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SMIOpen,
            this.SMISave});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.openToolStripMenuItem.Text = "File";
            // 
            // SMIOpen
            // 
            this.SMIOpen.Name = "SMIOpen";
            this.SMIOpen.Size = new System.Drawing.Size(180, 22);
            this.SMIOpen.Text = "Open";
            this.SMIOpen.Click += new System.EventHandler(this.SMIOpen_Click);
            // 
            // SMISave
            // 
            this.SMISave.Name = "SMISave";
            this.SMISave.Size = new System.Drawing.Size(180, 22);
            this.SMISave.Text = "Save";
            this.SMISave.Click += new System.EventHandler(this.SMISave_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SMIClear,
            this.SMISelectAll,
            this.SMIDateTime});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // SMIClear
            // 
            this.SMIClear.Name = "SMIClear";
            this.SMIClear.Size = new System.Drawing.Size(130, 22);
            this.SMIClear.Text = "Clear";
            this.SMIClear.Click += new System.EventHandler(this.SMIClear_Click);
            // 
            // SMISelectAll
            // 
            this.SMISelectAll.Name = "SMISelectAll";
            this.SMISelectAll.Size = new System.Drawing.Size(130, 22);
            this.SMISelectAll.Text = "SelectAll";
            this.SMISelectAll.Click += new System.EventHandler(this.SMISelectAll_Click);
            // 
            // SMIDateTime
            // 
            this.SMIDateTime.Name = "SMIDateTime";
            this.SMIDateTime.Size = new System.Drawing.Size(130, 22);
            this.SMIDateTime.Text = "Time/Date";
            this.SMIDateTime.Click += new System.EventHandler(this.SMIDateTime_Click);
            // 
            // formatToolStripMenuItem
            // 
            this.formatToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SMIFont});
            this.formatToolStripMenuItem.Name = "formatToolStripMenuItem";
            this.formatToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.formatToolStripMenuItem.Text = "Format";
            // 
            // SMIFont
            // 
            this.SMIFont.Name = "SMIFont";
            this.SMIFont.Size = new System.Drawing.Size(98, 22);
            this.SMIFont.Text = "Font";
            this.SMIFont.Click += new System.EventHandler(this.SMIFont_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SMIZoomIn,
            this.SMIZoomOut});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // SMIZoomIn
            // 
            this.SMIZoomIn.Name = "SMIZoomIn";
            this.SMIZoomIn.Size = new System.Drawing.Size(129, 22);
            this.SMIZoomIn.Text = "Zoom In";
            this.SMIZoomIn.Click += new System.EventHandler(this.SMIZoomIn_Click);
            // 
            // SMIZoomOut
            // 
            this.SMIZoomOut.Name = "SMIZoomOut";
            this.SMIZoomOut.Size = new System.Drawing.Size(129, 22);
            this.SMIZoomOut.Text = "Zoom Out";
            this.SMIZoomOut.Click += new System.EventHandler(this.SMIZoomOut_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(0, 27);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(800, 423);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            this.richTextBox1.Click += new System.EventHandler(this.RichTextBox1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "Text File | *.txt";
            // 
            // fontDialog1
            // 
            this.fontDialog1.ShowColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SMIOpen;
        private System.Windows.Forms.ToolStripMenuItem SMISave;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SMIClear;
        private System.Windows.Forms.ToolStripMenuItem SMISelectAll;
        private System.Windows.Forms.ToolStripMenuItem SMIDateTime;
        private System.Windows.Forms.ToolStripMenuItem formatToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SMIFont;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SMIZoomIn;
        private System.Windows.Forms.ToolStripMenuItem SMIZoomOut;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.FontDialog fontDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

