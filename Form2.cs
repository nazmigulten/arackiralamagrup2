using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace araçkiralamagrup2
{
    public partial class Form2 : Form
    {
        Class1 vt = new Class1();
        MySqlConnection baglanti;
        MySqlCommand komut;
        string komutsatiri;
        string seciliId;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Listele();

        }
        void Listele()
        {
            baglanti = vt.baglan();
            komutsatiri = "Select *FROM araclar";
            MySqlDataAdapter dataAdapter = new MySqlDataAdapter(komutsatiri, baglanti);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (baglanti.State != ConnectionState.Open)
            {
                baglanti.Open();
            }
            komutsatiri = "INSERT INTO araclar (marka,model,yil) VALUES (@marka,@model,@yil)";
            komut = new MySqlCommand(komutsatiri, baglanti);
            komut.Parameters.AddWithValue("@marka", textBox1.Text);
            komut.Parameters.AddWithValue("@model", textBox2.Text);
            komut.Parameters.AddWithValue("@yil", textBox3.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            Listele();
            Temizle();


        }

        void Temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }
                komutsatiri = "DELETE FROM araclar WHERE arac_id=@arac_id";
                komut = new MySqlCommand(komutsatiri, baglanti);
                komut.Parameters.AddWithValue("@arac_id", dataGridView1.CurrentRow.Cells["arac_id"].Value.ToString());
                komut.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show("işlem başarılı", "mesaj", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Listele();               
       
            
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (baglanti.State != ConnectionState.Open)
                {
                    baglanti.Open();
                }
                komutsatiri = "UPDATE araclar SET marka=@marka,model=@model,yil=@yıl";
                komut = new MySqlCommand(komutsatiri, baglanti);
                komut.Parameters.AddWithValue("@marka", dataGridView1.CurrentRow.Cells["marka"].Value.ToString());
                komut.Parameters.AddWithValue("@model", textBox2.Text);
                komut.Parameters.AddWithValue("@yıl", textBox3.Text);
                komut.ExecuteNonQuery();
                baglanti.Close();
                Temizle();
                MessageBox.Show("işlem başarılı", "mesaj", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                Listele();
            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message,"hata oluştu",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }

           

            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                seciliId = dataGridView1.CurrentRow.Cells["arac_id"].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells["marka"].Value.ToString();
                textBox2.Text = dataGridView1.CurrentRow.Cells["model"].Value.ToString();
                textBox3.Text = dataGridView1.CurrentRow.Cells["YIL"].Value.ToString();
                
            }
            catch (Exception)
            {
                MessageBox.Show("hata oluştu", "mesaj",MessageBoxButtons.OK,MessageBoxIcon.Error);
                   
            }
        }
    }
}

        
   

