using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quan_li_san_bong
{
    public partial class DichVu : UserControl
    {
        Connect ketNoi = new Connect();
        public DichVu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void DichVu_Load(object sender, EventArgs e)
        {
            ketNoi.DbConnection();
            string sql = "select TENDU from douong";
            DataTable table = ketNoi.getDataTable(sql);
            foreach (DataRow row in table.Rows)
            {
                cbbNuocUong.Items.Add(row["TENDU"].ToString());
            }
        }

        private void cbbNuocUong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbNuocUong.Text==("STING"))
            {
                this.pictureBox1.Image = global::Quan_li_san_bong.Properties.Resources.sting;
            }
            else if (cbbNuocUong.Text==("MIRINDA"))
            {
                this.pictureBox1.Image = global::Quan_li_san_bong.Properties.Resources.mirinda;
            }
            else if (cbbNuocUong.Text==("PEPSI"))
            {
                this.pictureBox1.Image = global::Quan_li_san_bong.Properties.Resources.pesi;
            }
            else if (cbbNuocUong.Text==("WATER"))
            {
                this.pictureBox1.Image = global::Quan_li_san_bong.Properties.Resources.nuocsuoi;
            }
            else if (cbbNuocUong.Text==("COCA"))
            {
                this.pictureBox1.Image = global::Quan_li_san_bong.Properties.Resources.coca;
            }
            else
            {
                this.pictureBox1.Image = global::Quan_li_san_bong.Properties.Resources.sting;
            }
        }

        private void cbbNuocUong_TextChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear(); 
            ketNoi.DbConnection();
            string ten = cbbNuocUong.SelectedItem.ToString();
            string sql2 = "select ton from douong where tendu='" + ten + "'";
            int soLuong = ketNoi.getCount(sql2);
            for (int i = 1; i <= soLuong; i++)
            {
                comboBox1.Items.Add(i.ToString());
            }
        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            DU.tenDU = cbbNuocUong.Text;
            DU.sL = comboBox1.Text;
            ketNoi.DbConnection();
            string sql = "insert INTO hoadondu(tendu,soluong) values('" + cbbNuocUong.Text + "','" + comboBox1.Text + "')";
            string sql2 = "update douong set ton=ton-" + comboBox1.Text + " where tendu='" + cbbNuocUong.Text + "'";
            ketNoi.updateToDataBase(sql);
            ketNoi.updateToDataBase(sql2);
            this.ParentForm.Hide();
            XuatHDSan hd = new XuatHDSan();
            hd.ShowDialog();
            this.ParentForm.Close();
        }
    }
}
