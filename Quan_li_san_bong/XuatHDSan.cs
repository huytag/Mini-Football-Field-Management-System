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
    public partial class XuatHDSan : Form
    {
        Connect ketNoi = new Connect();
        public XuatHDSan()
        {
            InitializeComponent();
        }

        private void XuatHDSan_Load(object sender, EventArgs e)
        {
            if (HD.form == 1)
            {
                ketNoi.DbConnection();
                DataTable da = ketNoi.getDataTable("select * from hoadon where tenkh='" + HD.tenKH + "' and ngay='" + HD.ngay + "' and gio='" + HD.gio + "' and giomuon='" + HD.gioMuon + "'");
                CrystalReport2 crys = new CrystalReport2();
                crys.SetDataSource(da);
                crystalReportViewer1.ReportSource = crys;
                crystalReportViewer1.DisplayStatusBar = false;
                crystalReportViewer1.DisplayToolbar = true;
                crystalReportViewer1.Refresh();
                HD.form = 0;
            }
            else
            {
                ketNoi.DbConnection();
                DataTable da = ketNoi.getDataTable("select * from hoadondu,douong where hoadondu.tendu=douong.tendu and hoadondu.tendu='" + DU.tenDU + "' and soluong='" + DU.sL + "'");
                CrystalReport3 crys = new CrystalReport3();
                crys.SetDataSource(da);
                crystalReportViewer1.ReportSource = crys;
                crystalReportViewer1.DisplayStatusBar = false;
                crystalReportViewer1.DisplayToolbar = true;
                crystalReportViewer1.Refresh();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            QuanLiSan ql = new QuanLiSan();
            ql.ShowDialog();
            this.Close();
        }
    }
}
