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
    
    public partial class formprisoncell : Form
    {
        prisonsystemEntities db = new prisonsystemEntities();
        public formprisoncell()
        {
            InitializeComponent();
        }
        void setgridp()
        {
            var q = from a in db.pcs
            select new { a.pcid, a.name ,a.eid, a.prisonid,a.fname, a.lname };
            dataGridView1.DataSource = q.ToList();


        }
        void setcom()
        {
            comboBox1.DataSource = db.prisons.ToList();
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "id";
            comboBox2.DataSource = db.jailors.ToList();
            comboBox2.ValueMember = "jeid";
            comboBox2.DisplayMember = "jeid";

        }
        private void button1_Click(object sender, EventArgs e)
        {        
                prisoncell s = new prisoncell();
                s.prisonid = Convert.ToInt32(comboBox1.SelectedValue);
                s.name = textBox1.Text;
                s.jeid = Convert.ToInt32(comboBox2.SelectedValue);
                db.prisoncells.Add(s);
                db.SaveChanges();
                MessageBox.Show("با موفقیت ثبت شد");
                textBox1.Text = "";
            setgridp();
        }

        private void formprisoncell_Load(object sender, EventArgs e)
        {
            setgridp();
            setcom();
            //a.pcid, a.name ,a.eid, a.prisonid,a.fname, a.lname,a.job
            dataGridView1.Columns[0].HeaderText = "شناسه سلول";
            dataGridView1.Columns[1].HeaderText = "نام سلول ";
            dataGridView1.Columns[2].HeaderText = "شناسه زندان بان ";
            dataGridView1.Columns[3].HeaderText = "شناسه زندان";
            dataGridView1.Columns[4].HeaderText = "نام زندان بان";
            dataGridView1.Columns[5].HeaderText = "نام خانوادگی زندان بان ";

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int ide = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult result = MessageBox.Show("آیا مطمئن هستید؟?", "system message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var s = db.prisoncells.Where(a => a.pcid == ide).FirstOrDefault();

                db.prisoncells.Remove(s);
                db.SaveChanges();
                MessageBox.Show("با موفقیت حذف شد", "system message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                setgridp();
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var q = from a in db.pcs.ToList()
                    where a.name.Contains(textBox2.Text) || a.fname.Contains(textBox2.Text)|| a.lname.Contains(textBox2.Text)
                    select new { a.pcid, a.name, a.eid, a.prisonid, a.fname, a.lname };
            dataGridView1.DataSource = q.ToList();     
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
