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
    public partial class siparisfrm : Form
    {
        public siparisfrm()
        {
            InitializeComponent();
        }
        public static string id;
        SqlConnection baglanti = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|cocitup.mdf; Integrated Security = True");
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.SelectedItem!=null && textBox5.Text != "")
            {
                if (Convert.ToInt32(textBox5.Text) > 0)
                {
                    siparis siparis = new siparis();
                    int secilensatir = dataGridView1.SelectedCells[0].RowIndex;
                    if (dataGridView1.Rows[secilensatir].IsNewRow == false)
                    {
                       
                        siparis.urun2 = dataGridView1.Rows[secilensatir].Cells[8].Value.ToString();
                        siparis.adet2 =Convert.ToInt16(dataGridView1.Rows[secilensatir].Cells[10].Value.ToString());
                      

                    }
                    
                    string[] bol;
                    string sec = comboBox1.SelectedItem.ToString();
                    bol = sec.Split('*');
                    int tutar = 0;
                    int toplam;
                    SqlCommand kmt = new SqlCommand("select fiyat from urunler where urun=@urun", baglanti);
                    kmt.Parameters.AddWithValue("@urun", bol[0]);
                    baglanti.Open();
                    SqlDataReader getir = kmt.ExecuteReader();
                    while (getir.Read())
                    {
                        tutar = Convert.ToInt32(getir["fiyat"].ToString());
                    }
                    baglanti.Close();
                    
                    SqlCommand kmt1 = new SqlCommand("select adet from siparis where mtc=@tc and id=@id", baglanti);
                    kmt1.Parameters.AddWithValue("@tc", textBox1.Text);
                    kmt1.Parameters.AddWithValue("@id", id);
                    baglanti.Open();
                    SqlDataReader hesap = kmt1.ExecuteReader();
                    if (hesap.Read())
                    {
                       siparis.tut = Convert.ToInt32(hesap["adet"].ToString());
                    }
                    baglanti.Close();
                    DateTime gun = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    toplam = tutar * Convert.ToInt32(textBox5.Text);
                    siparis.id = Convert.ToInt16(id);
                    siparis.tc = textBox1.Text;
                    siparis.adsoyad = textBox2.Text;
                    siparis.bolge = textBox4.Text;
                    siparis.tarih =gun.ToString("yyyy-MM-dd");
                    siparis.tel = textBox3.Text;
                    siparis.adres = richTextBox1.Text;
                    siparis.urun = bol[0];
                    siparis.adet = Convert.ToInt32(textBox5.Text);
                    siparis.durum = "Hazırlanıyor";
                    siparis.fiyat = toplam.ToString();
                    siparis.siparisguncelle();
                    gridview();

                }
                else
                {
                    MessageBox.Show("Adet SIFIR olamaz");
                }
            }
            else
            {
                MessageBox.Show("Tüm alanları doldurun");
            }            
        }
        public void combobox()
        {
            SqlCommand kmt = new SqlCommand("select *from urunler", baglanti);
            baglanti.Open();
            SqlDataReader doldur = kmt.ExecuteReader();
            while (doldur.Read())
            {

                comboBox1.Items.Add(doldur["urun"].ToString()+" *Kalan"+doldur["adet"].ToString());

            }
            baglanti.Close();
        }
        private void gridview()
        {

            SqlCommand kmt = new SqlCommand("Select *From siparis", baglanti);
            baglanti.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(kmt);
            DataSet ds = new DataSet();           
            adapter.Fill(ds, "siparis");
            dataGridView1.DataSource = ds.Tables["siparis"];
            baglanti.Close();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[1].HeaderText = "Tc";
            dataGridView1.Columns[2].HeaderText = "Ad Soyad";
            dataGridView1.Columns[3].HeaderText = "Telefon";
            dataGridView1.Columns[4].HeaderText = "Bölge";
            dataGridView1.Columns[5].HeaderText = "Adres";
            dataGridView1.Columns[6].HeaderText = "Durum";
            dataGridView1.Columns[7].HeaderText = "Tarih";
            dataGridView1.Columns[8].HeaderText = "Ürün";
            dataGridView1.Columns[9].HeaderText = "Fiyat";
            dataGridView1.Columns[10].HeaderText = "Adet";

        }
        private void siparisfrm_Load(object sender, EventArgs e)
        {
            anasayfa ana = (anasayfa)Application.OpenForms["anasayfa"];
            if (ana.a!= "guncelleme")
            {
                textBox1.Text = ana.tc;
                textBox2.Text = ana.ad;
                textBox3.Text = ana.tel;
                textBox4.Text = ana.bolge;
                richTextBox1.Text = ana.adres;
            }
            else
            {
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                richTextBox1.Clear();

            }
      
            combobox();
            gridview();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.SelectedItem != null && textBox5.Text != "")
            {
                if (Convert.ToInt32(textBox5.Text) > 0)
                {
                    string[] bol;
                    string sec = comboBox1.SelectedItem.ToString();
                    bol = sec.Split('*');
                    int tutar = 0;
                    int toplam;
                    SqlCommand kmt = new SqlCommand("select fiyat from urunler where urun=@urun", baglanti);
                    kmt.Parameters.AddWithValue("@urun", bol[0]);
                    baglanti.Open();
                    SqlDataReader getir = kmt.ExecuteReader();
                    while (getir.Read())
                    {
                        tutar = Convert.ToInt32(getir["fiyat"].ToString());
                    }
                    baglanti.Close();
                    toplam = tutar * Convert.ToInt32(textBox5.Text);
                    
                    siparis sipariss = new siparis();
                    DateTime gun = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    sipariss.tarih = gun.ToString("yyyy-MM-dd");
                    sipariss.tc = textBox1.Text;
                    sipariss.adsoyad = textBox2.Text;
                    sipariss.tel = textBox3.Text;
                    sipariss.bolge = textBox4.Text;
                    sipariss.adres = richTextBox1.Text;
                    sipariss.urun = bol[0];
                    sipariss.adet = Convert.ToInt32(textBox5.Text);
                    sipariss.fiyat = toplam.ToString();
                    sipariss.durum = "Hazırlanıyor";
                    sipariss.siparisekle();
                    gridview();

                }
                else
                {
                    MessageBox.Show("Adet SIFIR olamaz");
                }
            }
            else
            {
                MessageBox.Show("Tüm alanları doldurunuz");
            }
        }
       
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilensatir = dataGridView1.SelectedCells[0].RowIndex;
            if (dataGridView1.Rows[secilensatir].IsNewRow == false)
            {
                id = dataGridView1.Rows[secilensatir].Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.Rows[secilensatir].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[secilensatir].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[secilensatir].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[secilensatir].Cells[4].Value.ToString();
                richTextBox1.Text = dataGridView1.Rows[secilensatir].Cells[5].Value.ToString();
                textBox7.Text= dataGridView1.Rows[secilensatir].Cells[1].Value.ToString();

            }

        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
           
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != "")
            {
                int secilensatir = dataGridView1.SelectedCells[0].RowIndex;
                string durum = "Hazırlanıyor";
                siparis siparis = new siparis();
                siparis.tc = textBox7.Text;
                siparis.durum = durum;
                siparis.urun = dataGridView1.Rows[secilensatir].Cells[8].Value.ToString();
                siparis.adet = Convert.ToInt16(dataGridView1.Rows[secilensatir].Cells[10].Value.ToString());
                siparis.id = Convert.ToInt16(id);
                siparis.siparissil();
                gridview();

            }
            else
            {
                MessageBox.Show("Müşteri Tcsini giriniz");
            }

        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("Select *From siparis where tarih=@tarih", baglanti);
            kmt.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
            baglanti.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(kmt);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "siparis");
            dataGridView1.DataSource = ds.Tables["siparis"];
            baglanti.Close();
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 80;
            dataGridView1.Columns[2].Width = 80;
            dataGridView1.Columns[1].HeaderText = "Tc";
            dataGridView1.Columns[2].HeaderText = "Ad Soyad";
            dataGridView1.Columns[3].HeaderText = "Telefon";
            dataGridView1.Columns[4].HeaderText = "Bölge";
            dataGridView1.Columns[5].HeaderText = "Adres";
            dataGridView1.Columns[6].HeaderText = "Durum";
            dataGridView1.Columns[7].HeaderText = "Tarih";
            dataGridView1.Columns[8].HeaderText = "Ürün";
            dataGridView1.Columns[9].HeaderText = "Fiyat";
            dataGridView1.Columns[10].HeaderText = "Adet";
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
