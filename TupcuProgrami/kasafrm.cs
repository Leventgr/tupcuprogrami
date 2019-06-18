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
    public partial class kasafrm : Form
    {
        public kasafrm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source = (localdb)\\MSSQLLocalDB; AttachDbFilename=|DataDirectory|cocitup.mdf; Integrated Security = True");
        private void gridview()
        {

            SqlDataAdapter adapter = new SqlDataAdapter("Select *From kasa", baglanti);
            DataSet ds = new DataSet();
            baglanti.Open();
            adapter.Fill(ds, "kasa");
            dataGridView1.DataSource = ds.Tables["kasa"];
            baglanti.Close();
            dataGridView1.Columns[0].HeaderText = "Toplam Tutar";
            dataGridView1.Columns[1].HeaderText = "Tarih";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            kasa kasa = new kasa();
            kasa.tarih = tarih.ToString("yyyy-MM-dd");
            kasa.ciro();
            gridview();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime tarih = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            kasa kasa = new kasa();
            kasa.tarih = tarih.ToString("yyyy-MM-dd");
            kasa.ciroguncelle();
            gridview();
        }

        private void kasafrm_Load(object sender, EventArgs e)
        {

            gridview();

        }
    }
}
