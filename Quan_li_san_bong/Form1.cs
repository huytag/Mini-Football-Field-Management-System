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
    public partial class Form1 : Form
    {
        Connect ketNoi = new Connect();
        public Form1()
        {
            InitializeComponent();
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button_WOC1_Click(object sender, EventArgs e)
        {
            ketNoi.DbConnection();
            string sql = "select count(*) from nhanvien where tk='" + txttendn.Text + "' and pass='" + txtmatkhau.Text + "'";
            if (ketNoi.getCount(sql) == 0)
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu sai. Vui lòng nhập lại.");
            }
            else
            {
                if (txttendn.Text == "admin")
                {
                    this.Hide();
                    admin.ten = "admin";
                    QuanLiSan f2 = new QuanLiSan();
                    f2.ShowDialog();
                    this.Close();
                }
                else
                {
                    this.Hide();
                    admin.ten = "nhanvien";
                    QuanLiSan f2 = new QuanLiSan();
                    f2.ShowDialog();
                    this.Close();
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dr;
            dr = MessageBox.Show("Bạn có muốn thoát khỏi chương trình không ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox1.Checked)
            {
                txtmatkhau.UseSystemPasswordChar = true;
            } 
            else
            {
                txtmatkhau.UseSystemPasswordChar = false;
            }    
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
