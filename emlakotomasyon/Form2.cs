using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace emlakotomasyon
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-C9LVD2BT\\SQLEXPRESS;Initial Catalog=otomasyon;Integrated Security=True");
        private void goster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select *From gayrimenkul", baglanti);
            SqlDataReader oku =komut.ExecuteReader();
            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["id"].ToString();
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["soyad"].ToString());
                ekle.SubItems.Add(oku["tc"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["satisveyakira"].ToString());
                ekle.SubItems.Add(oku["odasayisi"].ToString());
                ekle.SubItems.Add(oku["metrekare"].ToString());
                ekle.SubItems.Add(oku["fiyat"].ToString());
                ekle.SubItems.Add(oku["adres"].ToString());

                listView1.Items.Add(ekle);


            }
            baglanti.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into gayrimenkul(ad,soyad,tc,telefon,satisveyakira,odasayisi,metrekare,fiyat,adres) values('"+textBox1.Text.ToString ()+"','"+textBox2.Text.ToString ()+"','" + textBox9.Text.ToString() + "','" + textBox8.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + comboBox2.Text.ToString() + "','" + textBox5.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox6.Text.ToString() + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            goster();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            goster();
        }
        int id = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Delete from gayrimenkul where id=("+id+")", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            goster();
        }
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].Text);
            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text;
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox9.Text = listView1.SelectedItems[0].SubItems[3].Text;
            textBox8.Text = listView1.SelectedItems[0].SubItems[4].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[5].Text;
            comboBox2.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox5.Text = listView1.SelectedItems[0].SubItems[7].Text;
            textBox7.Text = listView1.SelectedItems[0].SubItems[8].Text;
            textBox6.Text = listView1.SelectedItems[0].SubItems[9].Text;

        }

        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update gayrimenkul set ad='"+textBox1.Text.ToString ()+"',soyad='"+textBox2.Text.ToString ()+"',tc='" + textBox9.Text.ToString() + "',telefon='" + textBox8.Text.ToString() + "',satisveyakira='" + comboBox1.Text.ToString() + "',odasayisi='" + comboBox2.Text.ToString() + "',metrekare='" + textBox5.Text.ToString() + "',fiyat='" + textBox7.Text.ToString() + "',adres='" + textBox6.Text.ToString() +"'where id ="+id+"" , baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            goster();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
