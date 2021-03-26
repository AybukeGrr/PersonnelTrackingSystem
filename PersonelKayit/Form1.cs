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

namespace PersonelKayit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-GAIF2J04\\SQLEXPRESS;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        void temizle()
        {
            TxtPersonelID.Text = "";
            TxtPersonelAd.Text = "";
            TxtPersonelSoyad.Text = "";
            TxtMeslek.Text = "";
            CmbSehir.Text = "";
            MskMaas.Text = "";
            RdbEvli.Checked = false;
            RdbBekar.Checked = false;
            TxtPersonelAd.Focus();
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
            this.table_PersonelTableAdapter2.Fill(this.personelVeriTabaniDataSet4.Table_Personel); 
        }

        private void BtnListele_Click(object sender, EventArgs e)
        {
            this.table_PersonelTableAdapter2.Fill(this.personelVeriTabaniDataSet4.Table_Personel);

        }


        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Table_Personel (PersonelAd, PersonelSoyad, PersonelSehir, PersonelMaas, PersonelMeslek, PersonelDurum) values (@p1, @p2, @p3, @p4, @p5, @p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", TxtPersonelAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtPersonelSoyad.Text);
            komut.Parameters.AddWithValue("@p3", CmbSehir.Text);
            komut.Parameters.AddWithValue("@p4", MskMaas.Text);
            komut.Parameters.AddWithValue("@p5", TxtMeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Eklendi.");
        }

        private void RdbEvli_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbEvli.Checked == true)
            {
                label8.Text = "True";
            }
        }

        private void RdbBekar_CheckedChanged(object sender, EventArgs e)
        {
            if (RdbBekar.Checked == true)
            {
                label8.Text = "False";
            }
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;

            TxtPersonelID.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            TxtPersonelAd.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            TxtPersonelSoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            CmbSehir.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            MskMaas.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text = dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            TxtMeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();
        }

        private void label8_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "true")
            {
                RdbEvli.Checked = true;
            }
            if(label8.Text=="false")
            {
                RdbBekar.Checked = true;
            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutSil = new SqlCommand("Delete From Table_Personel Where PersonelID=@k1 ", baglanti);
            komutSil.Parameters.AddWithValue("@k1", TxtPersonelID.Text);
            komutSil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kayıt Silindi.");
        }

        private void BtnGüncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutGuncelle = new SqlCommand("Update Table_Personel Set PersonelAd=@a1, PersonelSoyad=@a2, PersonelSehir=@a3, PersonelMaas=@a4, PersonelDurum=@a5, PersonelMeslek=@a6 where PersonelID=@a7", baglanti);
            komutGuncelle.Parameters.AddWithValue("@a1", TxtPersonelAd.Text);
            komutGuncelle.Parameters.AddWithValue("@a2", TxtPersonelSoyad.Text);
            komutGuncelle.Parameters.AddWithValue("@a3", CmbSehir.Text);
            komutGuncelle.Parameters.AddWithValue("@a4", MskMaas.Text);
            komutGuncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutGuncelle.Parameters.AddWithValue("@a6", TxtMeslek.Text);
            komutGuncelle.Parameters.AddWithValue("@a7", TxtPersonelID.Text);
            komutGuncelle.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Personel Bilgisi Güncellendi.");
        }

        private void Btnİstatistik_Click(object sender, EventArgs e)
        {
            Frmİstatistik fr = new Frmİstatistik();
            fr.Show();
        }

        private void BtnGrafik_Click(object sender, EventArgs e)
        {
            FrmGrafikler frg = new FrmGrafikler();
            frg.Show();
        }
    }
}
