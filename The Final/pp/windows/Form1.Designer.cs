namespace pp
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.label1 = new System.Windows.Forms.Label();
            this.EXIT = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.התחברותלמערכתToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.עובדToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.סגןמנהלToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.מנהלToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(610, 534);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ברוכים הבאים למערכת ";
            // 
            // EXIT
            // 
            this.EXIT.Location = new System.Drawing.Point(4, 529);
            this.EXIT.Name = "EXIT";
            this.EXIT.Size = new System.Drawing.Size(75, 23);
            this.EXIT.TabIndex = 1;
            this.EXIT.Text = "יציאה ";
            this.EXIT.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.התחברותלמערכתToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(764, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // התחברותלמערכתToolStripMenuItem
            // 
            this.התחברותלמערכתToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.עובדToolStripMenuItem,
            this.סגןמנהלToolStripMenuItem,
            this.מנהלToolStripMenuItem});
            this.התחברותלמערכתToolStripMenuItem.Name = "התחברותלמערכתToolStripMenuItem";
            this.התחברותלמערכתToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.התחברותלמערכתToolStripMenuItem.Text = "התחברות למערכת";
            this.התחברותלמערכתToolStripMenuItem.Click += new System.EventHandler(this.התחברותלמערכתToolStripMenuItem_Click);
            // 
            // עובדToolStripMenuItem
            // 
            this.עובדToolStripMenuItem.Name = "עובדToolStripMenuItem";
            this.עובדToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.עובדToolStripMenuItem.Text = "עובד כללי ";
            // 
            // סגןמנהלToolStripMenuItem
            // 
            this.סגןמנהלToolStripMenuItem.Name = "סגןמנהלToolStripMenuItem";
            this.סגןמנהלToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.סגןמנהלToolStripMenuItem.Text = "סגן מנהל";
            // 
            // מנהלToolStripMenuItem
            // 
            this.מנהלToolStripMenuItem.Name = "מנהלToolStripMenuItem";
            this.מנהלToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.מנהלToolStripMenuItem.Text = "מנהל ";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(764, 556);
            this.Controls.Add(this.EXIT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = " ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button EXIT;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem התחברותלמערכתToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem עובדToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem סגןמנהלToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem מנהלToolStripMenuItem;
    }
}

