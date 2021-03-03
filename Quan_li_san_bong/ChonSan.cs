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
    public partial class ChonSan : Form
    {
        Connect ketNoi = new Connect();
        string a, b, c;
        string san="";
        public ChonSan()
        {
            InitializeComponent();
        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            if (san.Equals(""))
            {
                MessageBox.Show("Yêu cầu chọn sân");
            }
            else
            {
                ketNoi.DbConnection();
                string sql = "insert into HOADON values('" + KhachHang.tenKH.ToString() + "','" + KhachHang.diaChi.ToString() + "','" + KhachHang.sDT.ToString() + "','" + san + "','" + ngay.Value.Date.ToString() + "','" + gio.Text + "','" + gioMuon.Text + "','0')";
                ketNoi.updateToDataBase(sql);
                MessageBox.Show("Đã đặt sân thành công");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            san = "SAN1";
            san1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            san = "SAN2";
            san2.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            san = "SAN3";
            san3.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            san = "SAN4";
            san4.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            san = "SAN5";
            san5.Enabled = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            san = "SAN6";
            san6.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            san = "SAN7";
            san7.Enabled = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            san = "SAN8";
            san8.Enabled = false;
        }

        private void ChonSan_Load(object sender, EventArgs e)
        {
            if (ngay.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Ngày đặt sân không được bé hơn ngày hiện tại");
            }
            if (gio.Text == "" || gioMuon.Text == "")
            {
                san1.Enabled = false;
                san2.Enabled = false;
                san3.Enabled = false;
                san5.Enabled = false;
                san7.Enabled = false;
                san4.Enabled = false;
                san6.Enabled = false;
                san8.Enabled = false;
            }
            else
            {
                san1.Enabled = true;
                san2.Enabled = true;
                san3.Enabled = true;
                san5.Enabled = true;
                san7.Enabled = true;
                san4.Enabled = true;
                san6.Enabled = true;
                san8.Enabled = true;
            }
        }

        private void gio_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void gioMuon_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void gio_TextChanged(object sender, EventArgs e)
        {
            ChonSan_Load(sender, e);
            a = ngay.Value.Date.ToString();
            b = gio.Text;
            c = gioMuon.Text;
            ketNoi.DbConnection();
            string sql = "select MaSan from hoadon where NGAY='" + a + "' AND GIO='" + b + "' AND GIOMUON='" + c + "'";
            DataTable table = ketNoi.getDataTable(sql);
            foreach (DataRow row in table.Rows)
            {
                if (row["MASAN"].ToString().Equals("SAN1"))
                    san1.Enabled = false;
                if (row["MASAN"].ToString().Equals("SAN2"))
                    san2.Enabled = false;
                if (row["MASAN"].ToString().Equals("SAN3"))
                    san3.Enabled = false;
                if (row["MASAN"].ToString().Equals("SAN4"))
                    san4.Enabled = false;
                if (row["MASAN"].ToString().Equals("SAN5"))
                    san5.Enabled = false;
                if (row["MASAN"].ToString().Equals("SAN6"))
                    san6.Enabled = false;
                if (row["MASAN"].ToString().Equals("SAN7"))
                    san7.Enabled = false;
                if (row["MASAN"].ToString().Equals("SAN8"))
                    san8.Enabled = false;
            }
        }

        private void gioMuon_TextChanged(object sender, EventArgs e)
        {
            if (gio.Text == "")
            {
                ChonSan_Load(sender, e);
            }
            ChonSan_Load(sender, e);
            a = ngay.Value.Date.ToString();
            b = gio.Text;
            c = gioMuon.Text;
            ketNoi.DbConnection();
            string sql = "select MaSan from hoadon where NGAY='" + a + "' AND GIO='" + b + "' AND GIOMUON='" + c + "'";
            DataTable table = ketNoi.getDataTable(sql);
            foreach (DataRow row in table.Rows)
            {
                if (row["MASAN"].ToString().Equals("SAN1"))
                    san1.Enabled = false;
                if (row["MASAN"].ToString().Equals("SAN2"))
                    san2.Enabled = false;
                if (row["MASAN"].ToString().Equals("SAN3"))
                    san3.Enabled = false;
                if (row["MASAN"].ToString().Equals("SAN4"))
                    san4.Enabled = false;
                if (row["MASAN"].ToString().Equals("SAN5"))
                    san5.Enabled = false;
                if (row["MASAN"].ToString().Equals("SAN6"))
                    san6.Enabled = false;
                if (row["MASAN"].ToString().Equals("SAN7"))
                    san7.Enabled = false;
                if (row["MASAN"].ToString().Equals("SAN8"))
                    san8.Enabled = false;
            }
        }

        private void ngay_ValueChanged(object sender, EventArgs e)
        {
            if (gio.Text == "")
            {
                ChonSan_Load(sender, e);
            }
            ChonSan_Load(sender, e);
            a = ngay.Value.Date.ToString();
            b = gio.Text;
            c = gioMuon.Text;
            ketNoi.DbConnection();
            string sql = "select MaSan from hoadon where NGAY='" + a + "' AND GIO='" + b + "' AND GIOMUON='" + c + "'";
            DataTable table = ketNoi.getDataTable(sql);
            foreach (DataRow row in table.Rows)
            {
                if (row["MASAN"].ToString().Equals("SAN1"))
                    san1.Enabled = false;
                if (row["MASAN"].ToString().Equals("SAN2"))
                    san2.Enabled = false;
                if (row["MASAN"].ToString().Equals("SAN3"))
                    san3.Enabled = false;
                if (row["MASAN"].ToString().Equals("SAN4"))
                    san4.Enabled = false;
                if (row["MASAN"].ToString().Equals("SAN5"))
                    san5.Enabled = false;
                if (row["MASAN"].ToString().Equals("SAN6"))
                    san6.Enabled = false;
                if (row["MASAN"].ToString().Equals("SAN7"))
                    san7.Enabled = false;
                if (row["MASAN"].ToString().Equals("SAN8"))
                    san8.Enabled = false;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            QuanLiSan san = new QuanLiSan();
            san.ShowDialog();
            this.Close();
        }
    }
}
