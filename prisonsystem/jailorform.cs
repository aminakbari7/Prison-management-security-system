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
    public partial class jailorform : Form
    {
        prisonsystemEntities db = new prisonsystemEntities();
        public jailorform()
        {
            InitializeComponent();
        }
        void setgrid()
        {
            var q = from a in db.jails
                    select new { a.eid,a.pcid,a.fname,a.lname,a.job}; 
            dataGridView1.DataSource = q.ToList();

        }
        void setcom()
        {
            comboBox1.DataSource = db.prisons.ToList();
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "id";
            comboBox2.DataSource = db.emploees.ToList();
            comboBox2.ValueMember = "eid";
            comboBox2.DisplayMember = "eid";

        }
        private void jailorform_Load(object sender, EventArgs e)
        {
            setgrid();
            setcom();
            dataGridView1.Columns[0].HeaderText = "شناسه زندان بان";
            dataGridView1.Columns[1].HeaderText = " شناسه زندان";
            dataGridView1.Columns[2].HeaderText = "نام";
            dataGridView1.Columns[3].HeaderText = " نام خانوادگی";
            dataGridView1.Columns[4].HeaderText = "شغل";         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            jailor s = new jailor();
            s.jprisonid = Convert.ToInt32(comboBox1.SelectedValue);
            s.jeid = Convert.ToInt32(comboBox2.SelectedValue);
            db.jailors.Add(s);
            db.SaveChanges();
            MessageBox.Show("با موفقیت ثبت شد");
            setgrid();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ide = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult result = MessageBox.Show("آیا مطمئن هستید؟", "system message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var s = db.jailors.Where(a => a.jeid == ide).FirstOrDefault();

                db.jailors.Remove(s);
                db.SaveChanges();
                MessageBox.Show("با موفقیت حذف شد", "system message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            var q = from a in db.jails.ToList()
                    where a.lname.Contains(textBox1.Text) || a.fname.Contains(textBox1.Text)
                    select new { a.eid,a.pcid, a.fname, a.lname, a.job};
            dataGridView1.DataSource = q.ToList();

           
        }
    }
}
