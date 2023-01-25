namespace emlakotomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="admin" && textBox2.Text == "123")
            {
                Form2 otomasyon = new Form2();
                otomasyon.Show();
                this.Hide();
            }

        }

    }
}