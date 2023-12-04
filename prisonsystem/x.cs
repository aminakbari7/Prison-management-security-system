using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prisonsystem
{
    public partial class x : Form
    {
        prisonsystemEntities db = new prisonsystemEntities();
        public x()
        {
            InitializeComponent();
        }

        private void x_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var q = from a in db.emploees.ToList()
                    where a.lname.Contains(textBox1.Text) || a.fname.Contains(textBox2.Text) || a.job.Contains(textBox3.Text)
                    select new { a.eid, a.fname, a.lname, a.birthday, a.job, a.salary };
            dataGridView1.DataSource = q.ToList();
        }
    }
}
