namespace TechFixFrontend
{
    partial class Auth
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Auth));
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            submit = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(148, -20);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(509, 183);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Courier New", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(379, 196);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(278, 49);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Font = new Font("Courier New", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox2.Location = new Point(379, 281);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(278, 49);
            textBox2.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Courier New", 18F, FontStyle.Bold);
            label1.Location = new Point(148, 203);
            label1.Name = "label1";
            label1.Size = new Size(195, 34);
            label1.TabIndex = 7;
            label1.Text = "User  Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Courier New", 18F, FontStyle.Bold);
            label2.Location = new Point(184, 290);
            label2.Name = "label2";
            label2.Size = new Size(159, 34);
            label2.TabIndex = 8;
            label2.Text = "Password";
            // 
            // submit
            // 
            submit.BackColor = Color.FromArgb(255, 128, 0);
            submit.Font = new Font("Courier New", 22.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            submit.ForeColor = Color.White;
            submit.Location = new Point(441, 351);
            submit.Name = "submit";
            submit.Size = new Size(216, 61);
            submit.TabIndex = 9;
            submit.Text = "Login";
            submit.UseVisualStyleBackColor = false;
            submit.Click += submit_Click;
            // 
            // Auth
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(submit);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            Name = "Auth";
            Text = "Auth";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label1;
        private Label label2;
        private Button submit;
    }
}