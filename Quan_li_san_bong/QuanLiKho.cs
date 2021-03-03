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
    public partial class QuanLiKho : UserControl
    {
        Connect ketNoi = new Connect();
        public QuanLiKho()
        {
            InitializeComponent();   
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void QuanLiKho_Load(object sender, EventArgs e)
        {
            tenSP.Items.Clear();
            ketNoi.DbConnection();
            string sql = "select TENDU from douong";
            DataTable table = ketNoi.getDataTable(sql);
            foreach (DataRow row in table.Rows)
            {
                tenSP.Items.Add(row["TENDU"].ToString());
            }
            string sql1 = "select * from douong";
            dataGridView1.DataSource = ketNoi.getDataTable(sql1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ketNoi.DbConnection();
            ketNoi.updateToDataBase("update douong set ton=ton+"+SL.Text+" where tendu='"+tenSP.Text+"'");
            QuanLiKho_Load(sender,e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
                ketNoi.updateToDataBase("insert into douong values('"+tenSPM.Text+"','"+gia.Text+"','"+SLM.Text+"')");
                QuanLiKho_Load(sender,e);
        }
    }
}
