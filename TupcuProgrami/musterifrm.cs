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
    public partial class musterifrm : Form
    {
        public musterifrm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|cocitup.mdf; Integrated Security = True");
        private void gridview()
        {
          
            SqlDataAdapter adapter = new SqlDataAdapter("Select *From musteri", baglanti);
            DataSet ds = new DataSet();
            baglanti.Open();
            adapter.Fill(ds, "musteri");
            dataGridView1.DataSource = ds.Tables["musteri"];
            baglanti.Close();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns[0].Width = 80;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[0].HeaderText = "Tc";
            dataGridView1.Columns[1].HeaderText = "Ad Soyad";
            dataGridView1.Columns[2].HeaderText = "Telefon";
            dataGridView1.Columns[3].HeaderText = "Bölge";
            dataGridView1.Columns[4].HeaderText = "Adres";

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && maskedTextBox1.Text != "" && richTextBox1.Text != "")
            {
                if (textBox1.Text.Length == 11)
                {
                    if (maskedTextBox1.Text.Length == 14)
                    {

                        musteri musteri = new musteri();
                        musteri.tc = textBox1.Text.ToString();
                        musteri.adsoyad = textBox2.Text.ToString();
                        musteri.tel = maskedTextBox1.Text.ToString();
                        musteri.bolge = textBox3.Text.ToString();
                        musteri.adres = richTextBox1.Text.ToString();
                        musteri.musteriguncelle();
                        gridview();
                    }
                    else
                    {
                        MessageBox.Show("Telefon numarasını eksik girdiniz");
                    }
                }
                else
                {
                    MessageBox.Show("Tc kimlik numarası 11 haneli olmalıdır");

                }

            }
            else
            {
                MessageBox.Show("Tüm alanları doldurun");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && maskedTextBox1.Text != "" && richTextBox1.Text != "")
            {
                if (textBox1.Text.Length ==11)
                {
                    if (maskedTextBox1.Text.Length == 14)
                    {

                        musteri musteri = new musteri();
                        musteri.tc = textBox1.Text.ToString();
                        musteri.adsoyad = textBox2.Text.ToString();
                        musteri.tel = maskedTextBox1.Text.ToString();
                        musteri.bolge = textBox3.Text.ToString();
                        musteri.adres = richTextBox1.Text.ToString();
                        musteri.musterikayit();
                        gridview();
                        
                    }
                    else
                    {
                        MessageBox.Show("Telefon numarasını eksik girdiniz");
                    }
                }
                else
                {
                    MessageBox.Show("Tc kimlik numarası 11 haneli olmalıdır");
                  
                }
            }
            else
            {
                MessageBox.Show("Tüm alanları doldurun");
            }
        }

        private void musterifrm_Load(object sender, EventArgs e)
        {
            gridview();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                musteri musteri = new musteri();
                musteri.tc = textBox1.Text.ToString();
                musteri.musterisil();
                gridview();
                
            }
            else
            {
                MessageBox.Show("Tc kimlik numarasını boş bırakmayın");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           SqlCommand kmt = new SqlCommand("select * from musteri where tc=@tc",baglanti);
            kmt.Parameters.AddWithValue("@tc", textBox1.Text.ToString());
            baglanti.Open();
           SqlDataReader oku = kmt.ExecuteReader();
            if (oku.Read())
            {
                textBox2.Text = oku["adsoyad"].ToString();
                maskedTextBox1.Text = oku["tel"].ToString();
                textBox3.Text = oku["bolge"].ToString();
                richTextBox1.Text = oku["adres"].ToString();
            }
            else
            {

                textBox2.Clear();
                textBox3.Clear();
                maskedTextBox1.Clear();
                richTextBox1.Clear();
            }
            baglanti.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void maskedTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }


    }
}
