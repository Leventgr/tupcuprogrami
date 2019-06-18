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

namespace TupcuProgrami
{
    public partial class urunfrm : Form
    {
        public urunfrm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|cocitup.mdf; Integrated Security = True");
        private void gridview()
        {

            SqlDataAdapter adapter = new SqlDataAdapter("Select *From urunler", baglanti);
            DataSet ds = new DataSet();
            baglanti.Open();
            adapter.Fill(ds, "urunler");
            dataGridView1.DataSource = ds.Tables["urunler"];
            baglanti.Close();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns[0].HeaderText = "Ürün";
            dataGridView1.Columns[1].HeaderText = "Adet";
            dataGridView1.Columns[2].HeaderText = "Fiyat";

        }
        public void combobox()
        {
            SqlCommand kmt = new SqlCommand("select *from urunler", baglanti);
            baglanti.Open();
            SqlDataReader doldur = kmt.ExecuteReader();
            while (doldur.Read())
            {

                comboBox1.Items.Add(doldur["urun"].ToString());
                comboBox2.Items.Add(doldur["urun"].ToString());

            }
            baglanti.Close();
        }
        private void urunfrm_Load(object sender, EventArgs e)
        {
            gridview();
            combobox();
        }


        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                urunler urun = new urunler();
                urun.urun = textBox4.Text;
                urun.fiyat = textBox5.Text;
                urun.adet = textBox6.Text;
                urun.urunekle();
                gridview();
                comboBox1.Items.Clear();
                comboBox2.Items.Clear();
                combobox();
            }
            else
            {
                MessageBox.Show("Tüm alanları doldurun");
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.SelectedItem !=null)
            {
                string[] bol;
                string sec = comboBox1.SelectedItem.ToString();
                bol = sec.Split('*');
                urunler urun = new urunler();
                urun.urun = bol[0];
                urun.adet = textBox1.Text;
                urun.urunadet();
                gridview();
                           }
            else
            {
                MessageBox.Show("Tüm alanları doldurun");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem!= null)
            {
                string[] bol;
                string sec = comboBox1.SelectedItem.ToString();
                bol = sec.Split('*');
                urunler urun = new urunler();
                urun.urun =bol[0];
                urun.urunsil();
                gridview();
     
            }
            else
            {
                MessageBox.Show("Ürünü Seçiniz");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "" && comboBox2.SelectedItem!= null)
            {
                string[] bol;
                string sec = comboBox2.SelectedItem.ToString();
                bol = sec.Split('*');
                urunler urun = new urunler();
                urun.urun = bol[0];
                urun.fiyat = textBox3.Text;
                urun.urunfiyat();
                gridview();
            }
            else
            {
                MessageBox.Show("Tüm alanları doldurun");
            }
        }

    }
}
