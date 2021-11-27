using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NV_SHARED;

namespace NV_CLIENT
{
    public partial class Form1 : Form
    {
        const String url = "tcp://localhost:6969/XXX";
        INV_BUS NV_BUS = (INV_BUS)Activator.GetObject(typeof(INV_BUS), url);
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<ChitietNV> nhanviens = NV_BUS.laydanhsach();
            dataGridView1.DataSource = nhanviens;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String keyword = textBox1.Text.Trim();
            List<ChitietNV> nhanviens = NV_BUS.Search(keyword);
            dataGridView1.DataSource = nhanviens;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int manv = int.Parse(dataGridView1.SelectedRows[0].Cells["Manv"].Value.ToString());
                ChitietNV nhanvien =  NV_BUS.Getdetails(manv);
                if (nhanvien != null)
                {
                    textBox2.Text = nhanvien.Manv.ToString();
                    textBox3.Text = nhanvien.Ten;
                    textBox4.Text = nhanvien.Chucvu;
                    textBox5.Text = nhanvien.Phongban;
                    textBox6.Text = nhanvien.Chuthich;   
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChitietNV newnhanvien = new ChitietNV()
            {
                Manv = 0,
                Ten = textBox3.Text.Trim(),
                Chucvu = textBox4.Text.Trim(),
                Phongban = textBox5.Text.Trim(),
                Chuthich = textBox6.Text.Trim()
            };

            bool result = NV_BUS.Addnew(newnhanvien);
            if (result)
            {
                List<ChitietNV> nhanviens = NV_BUS.laydanhsach();
                dataGridView1.DataSource = nhanviens;
            }
            else
            {
                MessageBox.Show("SORRY HONEY");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChitietNV newnhanvien = new ChitietNV()
            {
                Manv = int.Parse(textBox2.Text.Trim()),
                Ten = textBox3.Text.Trim(),
                Chucvu = textBox4.Text.Trim(),
                Phongban = textBox5.Text.Trim(),
                Chuthich = textBox6.Text.Trim()
            };

            bool result = NV_BUS.Update(newnhanvien);
            if (result)
            {
                List<ChitietNV> nhanviens = NV_BUS.laydanhsach();
                dataGridView1.DataSource = nhanviens;
            }
            else
            {
                MessageBox.Show("SORRY HONEY");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("ARE U SURE?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int manv = int.Parse(textBox2.Text.Trim());
                bool result = NV_BUS.Delete(manv);
                if (result)
                {
                    List<ChitietNV> nhanviens = NV_BUS.laydanhsach();
                    dataGridView1.DataSource = nhanviens;
                }
                else
                {
                    MessageBox.Show("SORRY HONEY");
                }
            }

        }
    }
}
