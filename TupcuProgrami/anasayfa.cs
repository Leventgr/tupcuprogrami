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
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|cocitup.mdf; Integrated Security = True");
        public void gridmusteri()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select *From musteri", baglanti);
            DataSet ds = new DataSet();
            baglanti.Open();
            adapter.Fill(ds, "musteri");
            musterigrid.DataSource = ds.Tables["musteri"];
            baglanti.Close();
            musterigrid.RowHeadersVisible = false;
            musterigrid.Columns[0].Width = 80;
            musterigrid.Columns[2].Width = 80;
            musterigrid.Columns[0].HeaderText = "Tc";
            musterigrid.Columns[1].HeaderText = "Ad Soyad";
            musterigrid.Columns[2].HeaderText = "Telefon";
            musterigrid.Columns[3].HeaderText = "Bölge";
            musterigrid.Columns[4].HeaderText = "Adres";

        }
        public void gridsiparisTedilmemis()
        {
            SqlCommand kmt = new SqlCommand("Select *From siparis", baglanti);
            baglanti.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(kmt);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "siparis");
            siparisgrid.DataSource = ds.Tables["siparis"];
            baglanti.Close();
            siparisgrid.RowHeadersVisible = false;
            siparisgrid.Columns[0].Visible = false;
            siparisgrid.Columns[6].DefaultCellStyle.BackColor = Color.Red;
            siparisgrid.Columns[1].Width = 80;
            siparisgrid.Columns[2].Width = 80;
            siparisgrid.Columns[1].HeaderText = "Tc";
            siparisgrid.Columns[2].HeaderText = "Ad Soyad";
            siparisgrid.Columns[3].HeaderText = "Telefon";
            siparisgrid.Columns[4].HeaderText = "Bölge";
            siparisgrid.Columns[5].HeaderText = "Adres";
            siparisgrid.Columns[6].HeaderText = "Durum";
            siparisgrid.Columns[7].HeaderText = "Tarih";
            siparisgrid.Columns[8].HeaderText = "Ürün";
            siparisgrid.Columns[9].HeaderText = "Fiyat";
            siparisgrid.Columns[10].HeaderText = "Adet";
         

        }
        private void gridsiparisTedilmis()
        {
            DateTime gun = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            SqlCommand kmt = new SqlCommand("select *from tsiparis where tarih=@tarih", baglanti);
            kmt.Parameters.AddWithValue("@tarih", gun.ToString("yyyy-MM-dd"));
            baglanti.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(kmt);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "tsiparis");
            siparisgrid.DataSource = ds.Tables["tsiparis"];
            baglanti.Close();
            siparisgrid.RowHeadersVisible = false;
            siparisgrid.Columns[5].DefaultCellStyle.BackColor = Color.Green;
            siparisgrid.Columns[0].Width = 80;
            siparisgrid.Columns[2].Width = 80;
            siparisgrid.Columns[0].HeaderText = "Tc";
            siparisgrid.Columns[1].HeaderText = "Ad Soyad";
            siparisgrid.Columns[2].HeaderText = "Telefon";
            siparisgrid.Columns[3].HeaderText = "Bölge";
            siparisgrid.Columns[4].HeaderText = "Adres";
            siparisgrid.Columns[5].HeaderText = "Durum";
            siparisgrid.Columns[6].HeaderText = "Tarih";
            siparisgrid.Columns[7].HeaderText = "Ürün";
            siparisgrid.Columns[8].HeaderText = "Fiyat";
            siparisgrid.Columns[9].HeaderText = "Adet";
        }
        private void button9_Click(object sender, EventArgs e)
        {
            DialogResult cikis;
            cikis = MessageBox.Show(" Programdan Çıkmak İstediğinizden Emin Misiniz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cikis == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            musterifrm f2 = new musterifrm();
            f2.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            urunfrm f3 = new urunfrm();
            f3.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            kasafrm f4 = new kasafrm();
            f4.ShowDialog();
        }

        public string tc;
        public string ad;
        public string tel;
        public string bolge;
        public string adres;
        public string urun;
        int adet;
        public string fiyat;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (musterigrid.SelectedCells.Count > 0)
                {
                    int secilensatir = musterigrid.SelectedCells[0].RowIndex;
                    if (musterigrid.Rows[secilensatir].IsNewRow == false)
                    {
                        tc = musterigrid.Rows[secilensatir].Cells[0].Value.ToString();
                        baglanti.Open();
                        SqlCommand kmt = new SqlCommand("select * from musteri where tc=@tc", baglanti);
                        kmt.Parameters.AddWithValue("@tc", tc);
                        SqlDataReader okuyucu = kmt.ExecuteReader();
                        if (okuyucu.Read())
                        {
                            tc = okuyucu["tc"].ToString();
                            ad = okuyucu["adsoyad"].ToString();
                            tel = okuyucu["tel"].ToString();
                            bolge = okuyucu["bolge"].ToString();
                            adres = okuyucu["adres"].ToString();
                            baglanti.Close();
                        }
                        siparisfrm siparis = new siparisfrm();
                        a = "ekleme";
                        siparis.button2.Visible = false;
                        siparis.label4.Visible = false;
                        siparis.dateTimePicker1.Visible = false;
                        siparis.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Müşteri Seçiniz");
                    }
                }
                else
                {

                    MessageBox.Show("Müşteri seçmeniz gerekiyor");
                }
            }
            catch { }
        }

        private void anasayfa_Load(object sender, EventArgs e)
        {
            gridmusteri();
            gridsiparisTedilmemis();

           


        }

        private void button2_Click(object sender, EventArgs e)
        {
            gridsiparisTedilmis();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            gridsiparisTedilmemis();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" || textBox2.Text != "")
            {
                SqlCommand kmt = new SqlCommand("select *from musteri where tc=@tc or adsoyad=@adsoyad", baglanti);
                kmt.Parameters.AddWithValue("@tc", textBox1.Text);
                kmt.Parameters.AddWithValue("@adsoyad", textBox2.Text);
                baglanti.Open();
                SqlDataReader oku = kmt.ExecuteReader();
                if (oku.Read())
                {
                    baglanti.Close();
                    baglanti.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(kmt);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds, "musteri");
                    musterigrid.DataSource = ds.Tables["musteri"];
                    baglanti.Close();
                    textBox1.Clear();
                    textBox2.Clear();

                }
                else
                {
                    baglanti.Close();
                    gridmusteri();
                    MessageBox.Show("Müşteri bulunamadı");
                }
            }
            else
            {
                MessageBox.Show("Müşteri Tc veya Ad soyad giriniz");
                gridmusteri();
            }
        }
        DateTime tar = Convert.ToDateTime(DateTime.Now.ToShortDateString());

        string id;
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (siparisgrid.SelectedCells.Count > 0)
                {
                    int secilensatir = siparisgrid.SelectedCells[0].RowIndex;

                    if (siparisgrid.Rows[secilensatir].IsNewRow == false)
                    {
                        id = siparisgrid.Rows[secilensatir].Cells[0].Value.ToString();
                        tc = siparisgrid.Rows[secilensatir].Cells[1].Value.ToString();
                        ad = siparisgrid.Rows[secilensatir].Cells[2].Value.ToString();
                        tel = siparisgrid.Rows[secilensatir].Cells[3].Value.ToString();
                        bolge = siparisgrid.Rows[secilensatir].Cells[4].Value.ToString();
                        adres = siparisgrid.Rows[secilensatir].Cells[5].Value.ToString();
                        urun = siparisgrid.Rows[secilensatir].Cells[8].Value.ToString();
                        fiyat = siparisgrid.Rows[secilensatir].Cells[9].Value.ToString();
                        adet = Convert.ToInt16(siparisgrid.Rows[secilensatir].Cells[10].Value.ToString());

                        DialogResult kayıt = MessageBox.Show("Siparişin teslim edildiğine emin misiniz ?", "Teslim Onayı", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == kayıt)
                        {

                            SqlCommand kmt1 = new SqlCommand(" select * from siparis where mtc=@tc and id=@id", baglanti);
                            kmt1.Parameters.AddWithValue("@tc", tc);
                            kmt1.Parameters.AddWithValue("@id", id);
                            baglanti.Open();
                            SqlDataReader dr = kmt1.ExecuteReader();
                            if (dr.Read())
                            {
                                baglanti.Close();
                                baglanti.Open();
                                SqlCommand kmt = new SqlCommand("select * from siparis where mtc=@tc and id=@id", baglanti);
                                kmt.Parameters.AddWithValue("@tc", tc);
                                kmt.Parameters.AddWithValue("@id", id);
                                SqlDataReader okuyucu = kmt.ExecuteReader();
                                if (okuyucu.Read())
                                {
                                    baglanti.Close();
                                    string durum1 = "Tamamlandı";
                                    kmt = new SqlCommand("insert into tsiparis(mtc,madsoyad,mtel,mbolge,madres,durum,tarih,urun,fiyat,adet) values (@tc,@ad,@tel,@bolge,@adres,@durum,@tarih,@urun,@fiyat,@adet)", baglanti);
                                    kmt.Parameters.AddWithValue("@durum", durum1);
                                    kmt.Parameters.AddWithValue("@tc", tc);
                                    kmt.Parameters.AddWithValue("@ad", ad);
                                    kmt.Parameters.AddWithValue("@tel", tel);
                                    kmt.Parameters.AddWithValue("@bolge", bolge);
                                    kmt.Parameters.AddWithValue("@adres", adres);
                                    kmt.Parameters.AddWithValue("@tarih", tar.ToString("yyyy-MM-dd"));
                                    kmt.Parameters.AddWithValue("@urun", urun);
                                    kmt.Parameters.AddWithValue("@fiyat", fiyat);
                                    kmt.Parameters.AddWithValue("@adet", adet);
                                    baglanti.Open();
                                    kmt.ExecuteNonQuery();
                                    baglanti.Close();
                                    kmt = new SqlCommand("delete from siparis where mtc=@tc and id=@id", baglanti);
                                    kmt.Parameters.AddWithValue("@tc", tc);
                                    kmt.Parameters.AddWithValue("@id", id);
                                    baglanti.Open();
                                    kmt.ExecuteNonQuery();
                                    baglanti.Close();
                                    gridsiparisTedilmemis();

                                }
                                else
                                {
                                    baglanti.Close();
                                    MessageBox.Show("Sipariş bulunamadı");
                                }
                            }
                            else
                            {
                                baglanti.Close();
                                MessageBox.Show("Sipariş daha önce zaten teslim edilmiş");
                            }
                        }
                    }

                    else
                    {
                        MessageBox.Show("Sipariş seçiniz");

                    }

                }
                else
                {
                    MessageBox.Show("Bir sipariş seçmeniz gerekiyor");
                }
            }
            catch { }

        }
        public string a;
        private void button10_Click(object sender, EventArgs e)
        {
            a = "guncelleme";
            siparisfrm siparis = new siparisfrm();
            siparis.button1.Visible = false;
            siparis.button2.Location= new Point(312, 102);
            siparis.ShowDialog();
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar)
                 && !char.IsSeparator(e.KeyChar);
        }

        private void siparisgrid_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(siparisgrid.Rows[0].IsNewRow == true)
            {
                siparisgrid.Rows[0].Cells[0].ToString();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)   
        {
            if (textBox1.Text == "")
            {
            gridmusteri();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                gridmusteri();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            gridmusteri();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (siparisgrid.Columns[6].DefaultCellStyle.BackColor == Color.Red)
            {
                SqlCommand kmt = new SqlCommand("select * from siparis where tarih=@tarih", baglanti);
                kmt.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                baglanti.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(kmt);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "siparis");
                siparisgrid.DataSource = ds.Tables["siparis"];
                baglanti.Close();
                siparisgrid.RowHeadersVisible = false;
                siparisgrid.Columns[0].Visible = false;
                siparisgrid.Columns[6].DefaultCellStyle.BackColor = Color.Red;
                siparisgrid.Columns[1].Width = 80;
                siparisgrid.Columns[2].Width = 80;
                siparisgrid.Columns[1].HeaderText = "Tc";
                siparisgrid.Columns[2].HeaderText = "Ad Soyad";
                siparisgrid.Columns[3].HeaderText = "Telefon";
                siparisgrid.Columns[4].HeaderText = "Bölge";
                siparisgrid.Columns[5].HeaderText = "Adres";
                siparisgrid.Columns[6].HeaderText = "Durum";
                siparisgrid.Columns[7].HeaderText = "Tarih";
                siparisgrid.Columns[8].HeaderText = "Ürün";
                siparisgrid.Columns[9].HeaderText = "Fiyat";
                siparisgrid.Columns[10].HeaderText = "Adet";
            }
            else if(siparisgrid.Columns[5].DefaultCellStyle.BackColor == Color.Green)
            {
                SqlCommand kmt = new SqlCommand("select *from tsiparis where tarih=@tarih", baglanti);
                kmt.Parameters.AddWithValue("@tarih", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                baglanti.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(kmt);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "tsiparis");
                siparisgrid.DataSource = ds.Tables["tsiparis"];
                baglanti.Close();
                siparisgrid.RowHeadersVisible = false;
                siparisgrid.Columns[5].DefaultCellStyle.BackColor = Color.Green;
                siparisgrid.Columns[0].Width = 80;
                siparisgrid.Columns[2].Width = 80;
                siparisgrid.Columns[0].HeaderText = "Tc";
                siparisgrid.Columns[1].HeaderText = "Ad Soyad";
                siparisgrid.Columns[2].HeaderText = "Telefon";
                siparisgrid.Columns[3].HeaderText = "Bölge";
                siparisgrid.Columns[4].HeaderText = "Adres";
                siparisgrid.Columns[5].HeaderText = "Durum";
                siparisgrid.Columns[6].HeaderText = "Tarih";
                siparisgrid.Columns[7].HeaderText = "Ürün";
                siparisgrid.Columns[8].HeaderText = "Fiyat";
                siparisgrid.Columns[9].HeaderText = "Adet";
            }
        }
    }
}
