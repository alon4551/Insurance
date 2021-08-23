namespace final_p_
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.התחברותלמערכתToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.עובדToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.מנהלToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.סגורToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.הרשמהלמערכתToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.עובדToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.מנהלToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.LightSteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.ForeColor = System.Drawing.Color.SlateBlue;
            this.label1.Location = new System.Drawing.Point(541, 455);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "ברוכים הבאים למערכת ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.התחברותלמערכתToolStripMenuItem,
            this.הרשמהלמערכתToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(780, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // התחברותלמערכתToolStripMenuItem
            // 
            this.התחברותלמערכתToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.עובדToolStripMenuItem,
            this.מנהלToolStripMenuItem,
            this.סגורToolStripMenuItem});
            this.התחברותלמערכתToolStripMenuItem.Name = "התחברותלמערכתToolStripMenuItem";
            this.התחברותלמערכתToolStripMenuItem.Size = new System.Drawing.Size(118, 20);
            this.התחברותלמערכתToolStripMenuItem.Text = "התחברות למערכת";
            // 
            // עובדToolStripMenuItem
            // 
            this.עובדToolStripMenuItem.Name = "עובדToolStripMenuItem";
            this.עובדToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.עובדToolStripMenuItem.Text = "עובד";
            // 
            // מנהלToolStripMenuItem
            // 
            this.מנהלToolStripMenuItem.Name = "מנהלToolStripMenuItem";
            this.מנהלToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.מנהלToolStripMenuItem.Text = "מנהל";
            // 
            // סגורToolStripMenuItem
            // 
            this.סגורToolStripMenuItem.Name = "סגורToolStripMenuItem";
            this.סגורToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.סגורToolStripMenuItem.Text = "סגור חלון";
            // 
            // הרשמהלמערכתToolStripMenuItem
            // 
            this.הרשמהלמערכתToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.עובדToolStripMenuItem1,
            this.מנהלToolStripMenuItem1});
            this.הרשמהלמערכתToolStripMenuItem.Name = "הרשמהלמערכתToolStripMenuItem";
            this.הרשמהלמערכתToolStripMenuItem.Size = new System.Drawing.Size(107, 20);
            this.הרשמהלמערכתToolStripMenuItem.Text = "הרשמה למערכת";
            // 
            // עובדToolStripMenuItem1
            // 
            this.עובדToolStripMenuItem1.Name = "עובדToolStripMenuItem1";
            this.עובדToolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.עובדToolStripMenuItem1.Text = "עובד";
            // 
            // מנהלToolStripMenuItem1
            // 
            this.מנהלToolStripMenuItem1.Name = "מנהלToolStripMenuItem1";
            this.מנהלToolStripMenuItem1.Size = new System.Drawing.Size(102, 22);
            this.מנהלToolStripMenuItem1.Text = "מנהל";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(780, 514);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "מערכת \"דואגים להיות מבוטחים\"";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem התחברותלמערכתToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem עובדToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem מנהלToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem סגורToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem הרשמהלמערכתToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem עובדToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem מנהלToolStripMenuItem1;
    }
}

