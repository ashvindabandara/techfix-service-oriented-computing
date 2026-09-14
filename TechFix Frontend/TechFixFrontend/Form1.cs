namespace TechFixFrontend
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CheckStock checkStock = new CheckStock();
            checkStock.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PlaceOrder placeOrder = new PlaceOrder();
            placeOrder.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddQuotes addQuotes = new AddQuotes();
            addQuotes.Show();
            this.Hide();
        }
    }
}
