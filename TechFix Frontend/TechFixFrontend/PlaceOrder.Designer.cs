namespace TechFixFrontend
{
    partial class PlaceOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlaceOrder));
            selectSupplier1 = new ComboBox();
            amount1 = new TextBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            button2 = new Button();
            submit = new Button();
            button1 = new Button();
            label1 = new Label();
            productcode1 = new TextBox();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // selectSupplier1
            // 
            selectSupplier1.Font = new Font("Courier New", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            selectSupplier1.FormattingEnabled = true;
            selectSupplier1.Location = new Point(415, 241);
            selectSupplier1.Name = "selectSupplier1";
            selectSupplier1.Size = new Size(234, 41);
            selectSupplier1.TabIndex = 114;
            // 
            // amount1
            // 
            amount1.BorderStyle = BorderStyle.FixedSingle;
            amount1.Font = new Font("Courier New", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            amount1.Location = new Point(415, 169);
            amount1.Name = "amount1";
            amount1.Size = new Size(234, 41);
            amount1.TabIndex = 113;
            amount1.Tag = "";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Courier New", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(225, 241);
            label4.Name = "label4";
            label4.Size = new Size(159, 34);
            label4.TabIndex = 118;
            label4.Text = "Supplier";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Courier New", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(261, 176);
            label3.Name = "label3";
            label3.Size = new Size(123, 34);
            label3.TabIndex = 117;
            label3.Text = "Amount";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Courier New", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(153, 101);
            label2.Name = "label2";
            label2.Size = new Size(231, 34);
            label2.TabIndex = 116;
            label2.Text = "Product Code";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(64, 64, 64);
            button2.Font = new Font("Courier New", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.White;
            button2.Location = new Point(521, 310);
            button2.Name = "button2";
            button2.Size = new Size(128, 46);
            button2.TabIndex = 115;
            button2.Text = "Add";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click_1;
            // 
            // submit
            // 
            submit.BackColor = Color.FromArgb(255, 128, 0);
            submit.Font = new Font("Courier New", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            submit.ForeColor = Color.White;
            submit.Location = new Point(400, 367);
            submit.Name = "submit";
            submit.Size = new Size(249, 54);
            submit.TabIndex = 112;
            submit.Text = "Submit Order";
            submit.UseVisualStyleBackColor = false;
            submit.Click += submit_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(64, 64, 64);
            button1.Font = new Font("Courier New", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(4, 4);
            button1.Name = "button1";
            button1.Size = new Size(114, 39);
            button1.TabIndex = 111;
            button1.Text = "Back";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Corbel", 28.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(267, 7);
            label1.Name = "label1";
            label1.Size = new Size(243, 58);
            label1.TabIndex = 110;
            label1.Text = "New Order";
            // 
            // productcode1
            // 
            productcode1.BorderStyle = BorderStyle.FixedSingle;
            productcode1.Font = new Font("Courier New", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            productcode1.Location = new Point(415, 99);
            productcode1.Name = "productcode1";
            productcode1.Size = new Size(234, 41);
            productcode1.TabIndex = 109;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(633, 7);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(161, 54);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 108;
            pictureBox1.TabStop = false;
            // 
            // PlaceOrder
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(selectSupplier1);
            Controls.Add(amount1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(submit);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(productcode1);
            Controls.Add(pictureBox1);
            Name = "PlaceOrder";
            Tag = "mount";
            Text = "PlaceOrder";
            Load += PlaceOrder_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox textBox12;
        private ComboBox selectSupplier1;
        private TextBox amount1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button button2;
        private Button submit;
        private Button button1;
        private Label label1;
        private TextBox productcode1;
        private PictureBox pictureBox1;
    }
}