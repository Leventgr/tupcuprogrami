using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TupcuProgrami
{
    class musteri
    {
        public string tc;
        public string adsoyad;
        public string bolge;
        public string adres;
        public string tel;
        SqlConnection baglanti = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|cocitup.mdf; Integrated Security = True");
        SqlCommand kmt;
        anasayfa ana = (anasayfa)Application.OpenForms["anasayfa"];
        public void musterikayit()
        {
            kmt = new SqlCommand(" select count(*) from musteri where tc=@tc", baglanti);
            kmt.Parameters.AddWithValue("@tc", tc);
            baglanti.Open();
            int sonuc = (int)kmt.ExecuteScalar();
            if (sonuc == 0)
            {
                baglanti.Close();
                DialogResult kayıt = MessageBox.Show("Müşteriyi kaydetmek istediğinizden emin misiniz ?", "Kaydetme Onayı", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == kayıt)
                {
                    musterifrm ms = (musterifrm)Application.OpenForms["musterifrm"];
                    kmt = new SqlCommand("insert into musteri(tc,adsoyad,tel,bolge,adres) values (@tc,@ad,@tel,@bolge,@adres)", baglanti);
                    kmt.Parameters.AddWithValue("@tc", tc);
                    kmt.Parameters.AddWithValue("@ad", adsoyad);
                    kmt.Parameters.AddWithValue("@tel", tel);
                    kmt.Parameters.AddWithValue("@bolge", bolge);
                    kmt.Parameters.AddWithValue("@adres", adres);
                    baglanti.Open();
                    kmt.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Müşteri kayıdı başarıyla tamamlanmıştır.");
                    ms.textBox1.Clear();
                    ms.textBox2.Clear();
                    ms.textBox3.Clear();
                    ms.maskedTextBox1.Clear();
                    ms.richTextBox1.Clear();
                    ana.gridmusteri();

                }

            }
            else
            {
                MessageBox.Show("Müşteri daha önce kayıt edilmiş");
            }
        }
        public void musterisil()
        {

            kmt = new SqlCommand(" select count(*) from musteri where tc=@tc", baglanti);
            kmt.Parameters.AddWithValue("@tc", tc);
            baglanti.Open();
            int sonuc = (int)kmt.ExecuteScalar();
            if (sonuc != 0)
            {
                baglanti.Close();
                DialogResult silme = MessageBox.Show("Müşteriyi silmek istediğinizden emin misiniz ?", "Silme Onayı", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == silme)
                {
                    musterifrm ms = (musterifrm)Application.OpenForms["musterifrm"];
                    kmt = new SqlCommand("delete from musteri where tc=@tc", baglanti);
                    kmt.Parameters.AddWithValue("@tc", tc);
                    baglanti.Open();
                    kmt.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Müşteri silme gerçekleşmiştir");
                    ms.textBox1.Clear();
                    ms.textBox2.Clear();
                    ms.textBox3.Clear();
                    ms.maskedTextBox1.Clear();
                    ms.richTextBox1.Clear();
                    ana.gridmusteri();
                }
            }
            else
            {
                baglanti.Close();
                MessageBox.Show("Tc kimlik ile kayıtlı müşteri yok");
            }
        }
        public void musteriguncelle()
        {

            kmt = new SqlCommand(" select count(*) from musteri where tc=@tc", baglanti);
            kmt.Parameters.AddWithValue("@tc", tc);
            baglanti.Open();
            int sonuc = (int)kmt.ExecuteScalar();
            if (sonuc != 0)
            {
                baglanti.Close();

                DialogResult güncelle = MessageBox.Show("Müşteriyi güncellemek istediğinizden emin misiniz ?", "Güncelleme Onayı", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == güncelle)
                {
                    musterifrm ms = (musterifrm)Application.OpenForms["musterifrm"];
                    kmt = new SqlCommand("Update musteri set adsoyad=@ad,tel=@tel,bolge=@bolge,adres=@adres where tc=@tc", baglanti);
                    kmt.Parameters.AddWithValue("@tc", tc);
                    kmt.Parameters.AddWithValue("@ad", adsoyad);
                    kmt.Parameters.AddWithValue("@tel", tel);
                    kmt.Parameters.AddWithValue("@bolge", bolge);
                    kmt.Parameters.AddWithValue("@adres", adres);
                    baglanti.Open();
                    kmt.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Müşteri güncelleme işlemi gerçekleşmiştir");
                    ms.textBox1.Clear();
                    ms.textBox2.Clear();
                    ms.textBox3.Clear();
                    ms.maskedTextBox1.Clear();
                    ms.richTextBox1.Clear();
                    ana.gridmusteri();
                }

            }

            else
            {
                baglanti.Close();
                MessageBox.Show("Tc kimlik ile kayıtlı müşteri yok");
            }

        }

}
    class urunler
    {
        SqlConnection baglanti = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|cocitup.mdf; Integrated Security = True");

        SqlCommand kmt;
        public string urun;
        public string adet;
        public string fiyat;
        public void urunekle()
        {
            kmt = new SqlCommand(" select count(*) from urunler where urun=@urun", baglanti);
            kmt.Parameters.AddWithValue("@urun", urun);
            baglanti.Open();
            int sonuc = (int)kmt.ExecuteScalar();
            if (sonuc == 0)
            {
                baglanti.Close();
                DialogResult kayıt = MessageBox.Show("Ürünü kaydetmek istediğinizden emin misiniz ?", "Kaydetme Onayı", MessageBoxButtons.YesNo);
                if (DialogResult.Yes == kayıt)
                {
                    urunfrm ms = (urunfrm)Application.OpenForms["urunfrm"];
                    kmt = new SqlCommand("insert into urunler(urun,adet,fiyat) values (@urun,@adet,@fiyat)", baglanti);
                    kmt.Parameters.AddWithValue("@urun", urun);
                    kmt.Parameters.AddWithValue("@adet", adet);
                    kmt.Parameters.AddWithValue("@fiyat", fiyat);
                    baglanti.Open();
                    kmt.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Ürün kayıdı başarıyla tamamlanmıştır.");
                    ms.textBox4.Clear();
                    ms.textBox5.Clear();
                    ms.textBox6.Clear();


                }

            }
            else
            {
                MessageBox.Show("Ürün daha önce kayıt edilmiş");
            }
        }

        public void urunadet()
        {
            DialogResult kayıt = MessageBox.Show("Ürün adedini değiştirmek istediğinizden emin misiniz ?", "Güncelleme Onayı", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == kayıt)
            {
                urunfrm ms = (urunfrm)Application.OpenForms["urunfrm"];
                kmt = new SqlCommand("update urunler set adet=@adet where urun=@urun", baglanti);
                kmt.Parameters.AddWithValue("@urun", urun);
                kmt.Parameters.AddWithValue("@adet", adet);
                baglanti.Open();
                kmt.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ürün adet değişimi başarıyla tamamlanmıştır.");
                ms.comboBox1.Items.Clear();
                ms.comboBox2.Items.Clear();
                ms.combobox();
                ms.textBox1.Clear();
                
            }
        }
        public void urunfiyat()
        {
            DialogResult kayıt = MessageBox.Show("Ürün fiyatını değiştirmek istediğinizden emin misiniz ?", "Güncelleme Onayı", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == kayıt)
            {
                urunfrm ms = (urunfrm)Application.OpenForms["urunfrm"];
                kmt = new SqlCommand("update urunler set fiyat=@fiyat where urun=@urun", baglanti);
                kmt.Parameters.AddWithValue("@urun", urun);
                kmt.Parameters.AddWithValue("@fiyat", fiyat);
                baglanti.Open();
                kmt.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ürün fiyat değişimi başarıyla tamamlanmıştır.");
                ms.textBox3.Clear();
                ms.comboBox1.Items.Clear();
                ms.comboBox2.Items.Clear();
                ms.combobox();
            }
        }
        public void urunsil()
        {
            DialogResult kayıt = MessageBox.Show("Ürünü silmek istediğinizden emin misiniz ?", "Silme Onayı", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == kayıt)
            {
                urunfrm ms = (urunfrm)Application.OpenForms["urunfrm"];
                kmt = new SqlCommand("delete from urunler where urun=@urun", baglanti);
                kmt.Parameters.AddWithValue("@urun", urun);
                baglanti.Open();
                kmt.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Ürün silinmiştir");
                ms.comboBox1.Items.Clear();
                ms.comboBox2.Items.Clear();
                ms.combobox();
            }
        }


    }
    class siparis
    {
        anasayfa ana = (anasayfa)Application.OpenForms["anasayfa"];
        SqlConnection baglanti = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|cocitup.mdf; Integrated Security = True");
        SqlCommand kmt;
        public string tc;
        public string adsoyad;
        public string bolge;
        public string adres;
        public string tel;
        public string durum;
        public string urun;
        public string fiyat;
        public string tarih;
        public int adet;
       
        public int stok;
        public void siparisekle()
        {

            SqlCommand kmt1 = new SqlCommand("select adet from urunler where urun=@urun", baglanti);
            kmt1.Parameters.AddWithValue("@urun", urun);
            baglanti.Open();
            SqlDataReader hesap = kmt1.ExecuteReader();
            if (hesap.Read()==true)
            {
                stok = Convert.ToInt32(hesap["adet"].ToString()) - adet;
                baglanti.Close();
                if (stok >= 0)
                {

                    DialogResult kayıt = MessageBox.Show("Siparişi kaydetmek istediğinizden emin misiniz ?", "Kaydetme Onayı", MessageBoxButtons.YesNo);
                    if (DialogResult.Yes == kayıt)
                    {

                        siparisfrm ms = (siparisfrm)Application.OpenForms["siparisfrm"];
                        kmt = new SqlCommand("insert into siparis(mtc,madsoyad,mtel,mbolge,madres,durum,tarih,urun,fiyat,adet) values (@tc,@ad,@tel,@bolge,@adres,@durum,@tarih,@urun,@fiyat,@adet)", baglanti);
                        kmt.Parameters.AddWithValue("@tc", tc);
                        kmt.Parameters.AddWithValue("@ad", adsoyad);
                        kmt.Parameters.AddWithValue("@tel", tel);
                        kmt.Parameters.AddWithValue("@bolge", bolge);
                        kmt.Parameters.AddWithValue("@adres", adres);
                        kmt.Parameters.AddWithValue("@durum", durum);
                        kmt.Parameters.AddWithValue("@tarih", tarih);
                        kmt.Parameters.AddWithValue("@urun", urun);
                        kmt.Parameters.AddWithValue("@fiyat", fiyat);
                        kmt.Parameters.AddWithValue("@adet", adet);
                        baglanti.Open();
                        kmt.ExecuteNonQuery();
                        baglanti.Close();
                        MessageBox.Show("Sipariş kayıdı başarıyla tamamlanmıştır.");
                        ms.textBox1.Clear();
                        ms.textBox2.Clear();
                        ms.textBox3.Clear();
                        ms.textBox4.Clear();
                        ms.textBox5.Clear();
                        ms.textBox7.Clear();
                        ms.richTextBox1.Clear();
                        SqlCommand kmt2 = new SqlCommand("update urunler set adet=@adet where urun=@urun", baglanti);
                        kmt2.Parameters.AddWithValue("@urun", urun);
                        kmt2.Parameters.AddWithValue("@adet", stok);
                        baglanti.Open();
                        kmt2.ExecuteNonQuery();
                        baglanti.Close();
                        ana.gridsiparisTedilmemis();
                        ms.comboBox1.Items.Clear();
                        ms.combobox();
                    }
                }
                else
                {
                    MessageBox.Show("Stok yetersiz");
                }
            }
            else
            {
                baglanti.Close();

                MessageBox.Show("Ürün bulunamadı");
            }
          

        }
        public int tut;
        public int yenistok;
     //   public string tarihh;
        public int id;
        public string urun2;
        public int adet2;
        public void siparisguncelle()
        {
            siparisfrm ms1 = (siparisfrm)Application.OpenForms["siparisfrm"];
            kmt = new SqlCommand(" select *from siparis where mtc=@tc and id=@id", baglanti);
            kmt.Parameters.AddWithValue("@tc", tc);
            kmt.Parameters.AddWithValue("@id", id);
            baglanti.Open();

            SqlDataReader hesap = kmt.ExecuteReader();
            if (hesap.Read())
            {
                if (urun == hesap["urun"].ToString())
                {
                    tut = Convert.ToInt32(hesap["adet"].ToString());
                    baglanti.Close();
                    baglanti.Open();
                    SqlCommand kmt3 = new SqlCommand("select adet from urunler where urun=@urun", baglanti);
                    kmt3.Parameters.AddWithValue("@urun", urun);
                    SqlDataReader hesap1 = kmt3.ExecuteReader();
                    if (hesap1.Read())
                    {
                        stok = tut + Convert.ToInt32(hesap1["adet"].ToString());
                        yenistok = stok - (Convert.ToInt16(ms1.textBox5.Text));

                    }
                    baglanti.Close();
                    if (yenistok >= 0)
                    {
                        DialogResult kayıt = MessageBox.Show("Siparişi güncellemek istediğinizden emin misiniz ?", "Güncelleme Onayı", MessageBoxButtons.YesNo);
                        if (DialogResult.Yes == kayıt)
                        {

                            siparisfrm ms = (siparisfrm)Application.OpenForms["siparisfrm"];
                            kmt = new SqlCommand("update siparis set mtc=@tc,urun=@urun,fiyat=@fiyat,adet=@adet where mtc=@tc and id=@id", baglanti);
                            kmt.Parameters.AddWithValue("@tc", tc);
                            kmt.Parameters.AddWithValue("@durum", durum);
                            kmt.Parameters.AddWithValue("@id", id);
                            kmt.Parameters.AddWithValue("@urun", urun);
                            kmt.Parameters.AddWithValue("@fiyat", fiyat);
                            kmt.Parameters.AddWithValue("@adet", adet);
                            baglanti.Open();
                            kmt.ExecuteNonQuery();
                            baglanti.Close();
                            MessageBox.Show("Sipariş kayıdı başarıyla güncellenmiştir.");
                            ms.textBox1.Clear();
                            ms.textBox2.Clear();
                            ms.textBox3.Clear();
                            ms.textBox4.Clear();
                            ms.textBox5.Clear();
                            ms.textBox7.Clear();
                            ms.richTextBox1.Clear();
                            SqlCommand kmt2 = new SqlCommand("update urunler set adet=@adet where urun=@urun", baglanti);
                            kmt2.Parameters.AddWithValue("@urun", urun);
                            kmt2.Parameters.AddWithValue("@adet", yenistok);
                            baglanti.Open();
                            kmt2.ExecuteNonQuery();
                            baglanti.Close();
                            ana.gridsiparisTedilmemis();
                            ms.comboBox1.Items.Clear();
                            ms.combobox();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Stok yetersiz");
                    }
                }
                else
                {
                    baglanti.Close();
                    

                    SqlCommand kmt1 = new SqlCommand("select adet from urunler where urun=@urun", baglanti);
                    kmt1.Parameters.AddWithValue("@urun", urun);
                    baglanti.Open();
                    SqlDataReader hesap1 = kmt1.ExecuteReader();
                    if (hesap1.Read() == true)
                    {
                        stok = Convert.ToInt32(hesap1["adet"].ToString()) - adet;
                        baglanti.Close();
                        if (stok >= 0)
                        {

                            DialogResult kayıt = MessageBox.Show("Siparişi kaydetmek istediğinizden emin misiniz ?", "Kaydetme Onayı", MessageBoxButtons.YesNo);
                            if (DialogResult.Yes == kayıt)
                            {
                                siparisfrm ms = (siparisfrm)Application.OpenForms["siparisfrm"];
                                kmt = new SqlCommand("select adet from urunler where urun=@urun", baglanti);
                                kmt.Parameters.AddWithValue("@urun", urun2);
                                baglanti.Open();
                                SqlDataReader hesap2 = kmt.ExecuteReader();
                                while (hesap2.Read())
                                {
                                    sonadet = hesap2["adet"].ToString();
                                  
                                }
                                baglanti.Close();
                                kmt = new SqlCommand("update urunler set adet=@adet where urun=@urun", baglanti);
                                kmt.Parameters.AddWithValue("@urun", urun2);
                                kmt.Parameters.AddWithValue("@adet", adet2 + Convert.ToInt16(sonadet));
                                baglanti.Open();
                                kmt.ExecuteNonQuery();
                                baglanti.Close();
                                kmt = new SqlCommand("delete from siparis where mtc=@tc and id=@id", baglanti);
                                kmt.Parameters.AddWithValue("@tc", tc);
                                kmt.Parameters.AddWithValue("@id", id);
                                baglanti.Open();
                                kmt.ExecuteNonQuery();
                                baglanti.Close();
                                kmt = new SqlCommand("insert into siparis(mtc,madsoyad,mtel,mbolge,madres,durum,tarih,urun,fiyat,adet) values (@tc,@ad,@tel,@bolge,@adres,@durum,@tarih,@urun,@fiyat,@adet)", baglanti);
                                kmt.Parameters.AddWithValue("@tc", tc);
                                kmt.Parameters.AddWithValue("@ad", adsoyad);
                                kmt.Parameters.AddWithValue("@tel", tel);
                                kmt.Parameters.AddWithValue("@bolge", bolge);
                                kmt.Parameters.AddWithValue("@adres", adres);
                                kmt.Parameters.AddWithValue("@durum", durum);
                                kmt.Parameters.AddWithValue("@tarih", tarih);
                                kmt.Parameters.AddWithValue("@urun", urun);
                                kmt.Parameters.AddWithValue("@fiyat", fiyat);
                                kmt.Parameters.AddWithValue("@adet", adet);
                                baglanti.Open();
                                kmt.ExecuteNonQuery();
                                baglanti.Close();
                                MessageBox.Show("Sipariş kayıdı başarıyla tamamlanmıştır.");
                                ms.textBox1.Clear();
                                ms.textBox2.Clear();
                                ms.textBox3.Clear();
                                ms.textBox4.Clear();
                                ms.textBox5.Clear();
                                ms.textBox7.Clear();
                                ms.richTextBox1.Clear();
                                SqlCommand kmt2 = new SqlCommand("update urunler set adet=@adet where urun=@urun", baglanti);
                                kmt2.Parameters.AddWithValue("@urun", urun);
                                kmt2.Parameters.AddWithValue("@adet", stok);
                                baglanti.Open();
                                kmt2.ExecuteNonQuery();
                                baglanti.Close();
                                ana.gridsiparisTedilmemis();
                                ms.comboBox1.Items.Clear();
                                ms.combobox();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Stok yetersiz");
                        }
                    }
                    else
                    {
                        baglanti.Close();

                        MessageBox.Show("Ürün bulunamadı");
                    }


                }
            }
            else
            {
                baglanti.Close();
                MessageBox.Show("Sipariş Kaydı bulunamadı");
            }
        }
        string sonadet;
        public void siparissil()
        {
            DialogResult kayıt = MessageBox.Show("Siparişi silmek istediğinizden emin misiniz ?", "Silme Onayı", MessageBoxButtons.YesNo);
            if (DialogResult.Yes == kayıt)
            {
                siparisfrm ms = (siparisfrm)Application.OpenForms["siparisfrm"];
                kmt = new SqlCommand("select adet from urunler where urun=@urun", baglanti);
                kmt.Parameters.AddWithValue("@urun", urun);
                baglanti.Open();
                SqlDataReader hesap = kmt.ExecuteReader();
                while (hesap.Read())
                {
                    sonadet = hesap["adet"].ToString();
                }
                baglanti.Close();
                kmt = new SqlCommand("update urunler set adet=@adet where urun=@urun", baglanti);
                kmt.Parameters.AddWithValue("@urun", urun);
                kmt.Parameters.AddWithValue("@adet",adet+Convert.ToInt16(sonadet));
                baglanti.Open();
                kmt.ExecuteNonQuery(); 
                baglanti.Close();


                kmt = new SqlCommand("delete from siparis where mtc=@tc and id=@id", baglanti);
                kmt.Parameters.AddWithValue("@tc", tc);
                kmt.Parameters.AddWithValue("@id", id);
                baglanti.Open();
                kmt.ExecuteNonQuery();
                baglanti.Close();
                ms.textBox1.Clear();
                ms.textBox2.Clear();
                ms.textBox3.Clear();
                ms.textBox4.Clear();
                ms.textBox5.Clear();
                ms.textBox7.Clear();
                ms.richTextBox1.Clear();
                ana.gridsiparisTedilmemis();
                ms.comboBox1.Items.Clear();
                ms.combobox();
            }
        }

    }
    class kasa
    {
        SqlConnection baglanti = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|cocitup.mdf; Integrated Security = True");
        SqlCommand kmt;
        double top = 0;
        double fiyat = 0;
        public string tarih;
        public void ciro()
        {
            kmt = new SqlCommand(" select count(*) from kasa where ktarih=@tarih", baglanti);
            kmt.Parameters.AddWithValue("@tarih", tarih);
            baglanti.Open();
            int sonuc = (int)kmt.ExecuteScalar();
            if (sonuc == 0)
            {
                baglanti.Close();
                kmt = new SqlCommand("select fiyat from tsiparis where tarih=@tarih", baglanti);
                kmt.Parameters.AddWithValue("@tarih", tarih);
                baglanti.Open();
                SqlDataReader hesap = kmt.ExecuteReader();
                while (hesap.Read())
                {
                    fiyat = Convert.ToDouble(hesap["fiyat"].ToString());
                    top += fiyat;

                }
                baglanti.Close();
                kmt = new SqlCommand("insert into kasa(tutar,ktarih) values (@tutar,@ktarih)", baglanti);
                kmt.Parameters.AddWithValue("@tutar", top);
                kmt.Parameters.AddWithValue("@ktarih", tarih);
                baglanti.Open();
                kmt.ExecuteNonQuery();
                baglanti.Close();
            }
            else
            {
                MessageBox.Show("Günün kazancı önceden kaydedildi");
            }

        }
        public void ciroguncelle()
        {
            kmt = new SqlCommand(" select count(*) from kasa where ktarih=@ttarih", baglanti);
            kmt.Parameters.AddWithValue("@ttarih", tarih);
            baglanti.Open();
            int sonuc = (int)kmt.ExecuteScalar();
            if (sonuc != 0)
            {
                baglanti.Close();
                kmt = new SqlCommand("select fiyat from tsiparis where tarih=@tarih", baglanti);
                kmt.Parameters.AddWithValue("@tarih", tarih);
                baglanti.Open();
                SqlDataReader hesap = kmt.ExecuteReader();
                while (hesap.Read())
                {
                    fiyat = Convert.ToDouble(hesap["fiyat"].ToString());
                    top += fiyat;

                }
                baglanti.Close();
                kmt = new SqlCommand("update kasa set tutar=@tutar where ktarih=@tarih", baglanti);
                kmt.Parameters.AddWithValue("@tutar", top);
                kmt.Parameters.AddWithValue("@tarih", tarih);
                baglanti.Open();
                kmt.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("Güncelleme tamamlandı");
            }
            else
            {
                baglanti.Close();
                MessageBox.Show("Bugünün ciro kaydını henüz yapmadınız");
            }







        }
    }










}
