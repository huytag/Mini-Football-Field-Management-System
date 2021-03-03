using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_li_san_bong
{
    public partial class QuanLiSan : Form
    {
        public QuanLiSan()
        {
            InitializeComponent();
            nhanVien1.BringToFront();
            if (admin.ten == "admin")
            {
                ten.Text = "Admin";
            }
            else
            {
                ten.Text = "Nhân viên";
                btnQLNV.Enabled = false;
                btnQLK.Enabled = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void quanliDS1_Load(object sender, EventArgs e)
        {

        }

        private void btnDS_Click(object sender, EventArgs e)
        {
            nhanVien1.BringToFront();
        }

        private void btnDV_Click(object sender, EventArgs e)
        {
            dichVu1.BringToFront();
        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            qlnv1.BringToFront();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            thanhToanTien1.BringToFront();
        }

        private void btnQLK_Click(object sender, EventArgs e)
        {
            quanLiKho1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f = new Form1();
            f.ShowDialog();
            this.Close();
        }
    }
}
