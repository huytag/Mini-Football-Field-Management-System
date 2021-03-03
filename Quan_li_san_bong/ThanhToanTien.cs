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
    public partial class ThanhToanTien : UserControl
    {
        Connect ketNoi = new Connect();
        public ThanhToanTien()
        {
            InitializeComponent();
            ketNoi.DbConnection();
            string sql = "select * from hoadon where thanhtoan=0 order by (ngay) ";
            dataGridView1.DataSource = ketNoi.getDataTable(sql);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int numrow;
            numrow = e.RowIndex;
            HD.tenKH = dataGridView1.Rows[numrow].Cells[0].Value.ToString();
            HD.ngay = dataGridView1.Rows[numrow].Cells[4].Value.ToString();
            HD.gio = dataGridView1.Rows[numrow].Cells[5].Value.ToString();
            HD.gioMuon = dataGridView1.Rows[numrow].Cells[6].Value.ToString();
            HD.form = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ketNoi.DbConnection();
            ketNoi.updateToDataBase("update hoadon set thanhtoan='1' where tenkh='" + HD.tenKH + "' and ngay='" + HD.ngay + "' and gio='" + HD.gio + "' and giomuon='" + HD.gioMuon + "'");
            this.ParentForm.Hide();
            XuatHDSan hd = new XuatHDSan();
            hd.ShowDialog();
            this.ParentForm.Close();
        }
    }
}
