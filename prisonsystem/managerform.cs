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
    public partial class managerform : Form
    {


        prisonsystemEntities db = new prisonsystemEntities();
        public managerform()
        {
            InitializeComponent();
        }
       
        void setgrid()
        {
            var q = from a in db.mans
                    select new { a.eid, a.pcid,a.fname,a.lname,a.job,a.start};
            dataGridView1.DataSource = q.ToList();
           
        }
        void setcom()
        {
            comboBox1.DataSource = db.prisons.ToList();
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";
            comboBox2.DataSource = db.emploees.ToList();
            comboBox2.ValueMember = "eid";
            comboBox2.DisplayMember = "eid";

        }


        private void managerform_Load(object sender, EventArgs e)
        {
            setgrid();
            setcom();
            dataGridView1.Columns[0].HeaderText = "شناسه مدیر";
            dataGridView1.Columns[1].HeaderText = " شناسه زندان";
            dataGridView1.Columns[2].HeaderText = "نام ";
            dataGridView1.Columns[3].HeaderText = "نام خانوادگی";
            dataGridView1.Columns[4].HeaderText = " شغل";
            dataGridView1.Columns[5].HeaderText = "تاریخ شروع مدیریت";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ide = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult result = MessageBox.Show("آیا مطمئن هستید؟?", "system message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var s = db.managers.Where(a => a.meid == ide).FirstOrDefault();
                db.managers.Remove(s);
                db.SaveChanges();
                MessageBox.Show("با موفقیت حذف شد", "system message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                setgrid();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           manager s = new manager();
            s.pmeid = Convert.ToInt32(comboBox1.SelectedValue);
            s.meid = Convert.ToInt32(comboBox2.SelectedValue);
            s.start = Convert.ToDateTime(textBox1.Text);      
            db.managers.Add(s);
            db.SaveChanges();
            MessageBox.Show("با موفقیت ثبت شد");
            textBox1.Text = "";
            setgrid();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            var q = from a in db.mans.ToList()
                    where a.fname.Contains(textBox2.Text) || a.lname.Contains(textBox2.Text) 
                    select new { a.eid, a.pcid, a.fname, a.lname, a.job, a.start };
            dataGridView1.DataSource = q.ToList();
        }
    }
}
