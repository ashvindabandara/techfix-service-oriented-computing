namespace TechFixFrontend
{
    partial class CheckStock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckStock));
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            label3 = new Label();
            button2 = new Button();
            labelSupplier1Name = new Label();
            labelSupplier1Price = new Label();
            labelSupplier1Stock = new Label();
            labelSupplier2Stock = new Label();
            labelSupplier2Price = new Label();
            labelSupplier2Name = new Label();
            label10 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(638, 6);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(155, 54);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Century Gothic", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(301, 100);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(288, 44);
            textBox1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Corbel", 30F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(242, 2);
            label1.Name = "label1";
            label1.Size = new Size(291, 61);
            label1.TabIndex = 2;
            label1.Text = "Check Stock";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Courier New", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(56, 106);
            label2.Name = "label2";
            label2.Size = new Size(231, 34);
            label2.TabIndex = 3;
            label2.Text = "Product Name";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(64, 64, 64);
            button1.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.Location = new Point(2, 2);
            button1.Name = "button1";
            button1.Size = new Size(114, 39);
            button1.TabIndex = 4;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.Transparent;
            label3.Font = new Font("Courier New", 12F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(64, 64, 64);
            label3.Location = new Point(61, 197);
            label3.Name = "label3";
            label3.Size = new Size(130, 23);
            label3.TabIndex = 5;
            label3.Text = "Supplier 1";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(255, 128, 0);
            button2.Font = new Font("Century Gothic", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.Location = new Point(596, 99);
            button2.Name = "button2";
            button2.Size = new Size(114, 46);
            button2.TabIndex = 6;
            button2.Text = "Check";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // labelSupplier1Name
            // 
            labelSupplier1Name.AutoSize = true;
            labelSupplier1Name.BackColor = Color.Transparent;
            labelSupplier1Name.Font = new Font("Courier New", 12F);
            labelSupplier1Name.ForeColor = Color.FromArgb(64, 64, 64);
            labelSupplier1Name.Location = new Point(93, 236);
            labelSupplier1Name.Name = "labelSupplier1Name";
            labelSupplier1Name.Size = new Size(58, 22);
            labelSupplier1Name.TabIndex = 7;
            labelSupplier1Name.Text = "Name";
            labelSupplier1Name.Click += label4_Click;
            // 
            // labelSupplier1Price
            // 
            labelSupplier1Price.AutoSize = true;
            labelSupplier1Price.BackColor = Color.Transparent;
            labelSupplier1Price.Font = new Font("Courier New", 12F);
            labelSupplier1Price.ForeColor = Color.FromArgb(64, 64, 64);
            labelSupplier1Price.Location = new Point(93, 290);
            labelSupplier1Price.Name = "labelSupplier1Price";
            labelSupplier1Price.Size = new Size(70, 22);
            labelSupplier1Price.TabIndex = 8;
            labelSupplier1Price.Text = "Price";
            // 
            // labelSupplier1Stock
            // 
            labelSupplier1Stock.AutoSize = true;
            labelSupplier1Stock.BackColor = Color.Transparent;
            labelSupplier1Stock.Font = new Font("Courier New", 12F);
            labelSupplier1Stock.ForeColor = Color.FromArgb(64, 64, 64);
            labelSupplier1Stock.Location = new Point(93, 343);
            labelSupplier1Stock.Name = "labelSupplier1Stock";
            labelSupplier1Stock.Size = new Size(70, 22);
            labelSupplier1Stock.TabIndex = 9;
            labelSupplier1Stock.Text = "Stock";
            // 
            // labelSupplier2Stock
            // 
            labelSupplier2Stock.AutoSize = true;
            labelSupplier2Stock.BackColor = Color.Transparent;
            labelSupplier2Stock.Font = new Font("Courier New", 12F);
            labelSupplier2Stock.ForeColor = Color.FromArgb(64, 64, 64);
            labelSupplier2Stock.Location = new Point(443, 343);
            labelSupplier2Stock.Name = "labelSupplier2Stock";
            labelSupplier2Stock.Size = new Size(70, 22);
            labelSupplier2Stock.TabIndex = 13;
            labelSupplier2Stock.Text = "Stock";
            labelSupplier2Stock.Click += labelSupplier2Stock_Click;
            // 
            // labelSupplier2Price
            // 
            labelSupplier2Price.AutoSize = true;
            labelSupplier2Price.BackColor = Color.Transparent;
            labelSupplier2Price.Font = new Font("Courier New", 12F);
            labelSupplier2Price.ForeColor = Color.FromArgb(64, 64, 64);
            labelSupplier2Price.Location = new Point(443, 290);
            labelSupplier2Price.Name = "labelSupplier2Price";
            labelSupplier2Price.Size = new Size(70, 22);
            labelSupplier2Price.TabIndex = 12;
            labelSupplier2Price.Text = "Price";
            // 
            // labelSupplier2Name
            // 
            labelSupplier2Name.AutoSize = true;
            labelSupplier2Name.BackColor = Color.Transparent;
            labelSupplier2Name.Font = new Font("Courier New", 12F);
            labelSupplier2Name.ForeColor = Color.FromArgb(64, 64, 64);
            labelSupplier2Name.Location = new Point(443, 236);
            labelSupplier2Name.Name = "labelSupplier2Name";
            labelSupplier2Name.Size = new Size(58, 22);
            labelSupplier2Name.TabIndex = 11;
            labelSupplier2Name.Text = "Name";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.Transparent;
            label10.Font = new Font("Courier New", 12F, FontStyle.Bold);
            label10.ForeColor = Color.FromArgb(64, 64, 64);
            label10.Location = new Point(411, 197);
            label10.Name = "label10";
            label10.Size = new Size(130, 23);
            label10.TabIndex = 10;
            label10.Text = "Supplier 2";
            // 
            // CheckStock
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(labelSupplier2Stock);
            Controls.Add(labelSupplier2Price);
            Controls.Add(labelSupplier2Name);
            Controls.Add(label10);
            Controls.Add(labelSupplier1Stock);
            Controls.Add(labelSupplier1Price);
            Controls.Add(labelSupplier1Name);
            Controls.Add(button2);
            Controls.Add(label3);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(pictureBox1);
            ForeColor = Color.White;
            Name = "CheckStock";
            Text = "CheckStock";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox textBox1;
        private Label label1;
        private Label label2;
        private Button button1;
        private Label label3;
        private Button button2;
        private Label labelSupplier1Name;
        private Label labelSupplier1Price;
        private Label labelSupplier1Stock;
        private Label labelSupplier2Stock;
        private Label labelSupplier2Price;
        private Label labelSupplier2Name;
        private Label label10;
    }
}