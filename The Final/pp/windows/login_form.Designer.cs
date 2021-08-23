namespace pp
{
    partial class login_form
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
            this.components = new System.ComponentModel.Container();
            this.id_worker = new System.Windows.Forms.TextBox();
            this.worker_password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.start_shift = new System.Windows.Forms.Button();
            this.end_shift = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // id_worker
            // 
            this.id_worker.Location = new System.Drawing.Point(51, 22);
            this.id_worker.Name = "id_worker";
            this.id_worker.Size = new System.Drawing.Size(138, 20);
            this.id_worker.TabIndex = 0;
            // 
            // worker_password
            // 
            this.worker_password.Location = new System.Drawing.Point(51, 57);
            this.worker_password.Name = "worker_password";
            this.worker_password.Size = new System.Drawing.Size(138, 20);
            this.worker_password.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(234, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "שם משתמש";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "ססמא";
            // 
            // start_shift
            // 
            this.start_shift.Location = new System.Drawing.Point(190, 135);
            this.start_shift.Name = "start_shift";
            this.start_shift.Size = new System.Drawing.Size(109, 38);
            this.start_shift.TabIndex = 4;
            this.start_shift.Text = "כניסה";
            this.start_shift.UseVisualStyleBackColor = true;
            this.start_shift.Click += new System.EventHandler(this.button1_Click);
            // 
            // end_shift
            // 
            this.end_shift.Location = new System.Drawing.Point(51, 135);
            this.end_shift.Name = "end_shift";
            this.end_shift.Size = new System.Drawing.Size(107, 38);
            this.end_shift.TabIndex = 5;
            this.end_shift.Text = "יציאה";
            this.end_shift.UseVisualStyleBackColor = true;
            this.end_shift.Click += new System.EventHandler(this.button2_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(134, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 13);
            this.label3.TabIndex = 6;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // login_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(326, 190);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.end_shift);
            this.Controls.Add(this.start_shift);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.worker_password);
            this.Controls.Add(this.id_worker);
            this.Name = "login_form";
            this.Text = "login_form";
            this.Load += new System.EventHandler(this.login_form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox id_worker;
        private System.Windows.Forms.TextBox worker_password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button start_shift;
        private System.Windows.Forms.Button end_shift;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
    }
}