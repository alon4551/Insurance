namespace pp
{
    partial class main_wimdow
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
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ראשיToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.חיפושלקוחותToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.הוספתלקוחToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.לקוחחדשToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.עובדחדשToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(410, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ברוכים הבאים למערכת ";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ראשיToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(914, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ראשיToolStripMenuItem
            // 
            this.ראשיToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.חיפושלקוחותToolStripMenuItem,
            this.הוספתלקוחToolStripMenuItem});
            this.ראשיToolStripMenuItem.Name = "ראשיToolStripMenuItem";
            this.ראשיToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.ראשיToolStripMenuItem.Text = "ראשי ";
            // 
            // חיפושלקוחותToolStripMenuItem
            // 
            this.חיפושלקוחותToolStripMenuItem.Name = "חיפושלקוחותToolStripMenuItem";
            this.חיפושלקוחותToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.חיפושלקוחותToolStripMenuItem.Text = "חיפוש לקוחות";
            this.חיפושלקוחותToolStripMenuItem.Click += new System.EventHandler(this.חיפושלקוחותToolStripMenuItem_Click);
            // 
            // הוספתלקוחToolStripMenuItem
            // 
            this.הוספתלקוחToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.לקוחחדשToolStripMenuItem,
            this.עובדחדשToolStripMenuItem});
            this.הוספתלקוחToolStripMenuItem.Name = "הוספתלקוחToolStripMenuItem";
            this.הוספתלקוחToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.הוספתלקוחToolStripMenuItem.Text = "הוספה";
            // 
            // לקוחחדשToolStripMenuItem
            // 
            this.לקוחחדשToolStripMenuItem.Name = "לקוחחדשToolStripMenuItem";
            this.לקוחחדשToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.לקוחחדשToolStripMenuItem.Text = "לקוח חדש";
            this.לקוחחדשToolStripMenuItem.Click += new System.EventHandler(this.לקוחחדשToolStripMenuItem_Click);
            // 
            // עובדחדשToolStripMenuItem
            // 
            this.עובדחדשToolStripMenuItem.Name = "עובדחדשToolStripMenuItem";
            this.עובדחדשToolStripMenuItem.Size = new System.Drawing.Size(126, 22);
            this.עובדחדשToolStripMenuItem.Text = "עובד חדש ";
            this.עובדחדשToolStripMenuItem.Click += new System.EventHandler(this.עובדחדשToolStripMenuItem_Click);
            // 
            // main_wimdow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(914, 395);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "main_wimdow";
            this.Text = "main_wimdow";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ראשיToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem חיפושלקוחותToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem הוספתלקוחToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem לקוחחדשToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem עובדחדשToolStripMenuItem;
    }
}