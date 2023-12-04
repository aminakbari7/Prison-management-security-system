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
   
    public partial class prisonerform : Form
    {
        prisonsystemEntities db = new prisonsystemEntities();
        public prisonerform()
        {
            InitializeComponent();
        }
        void setgrid()
        {
            var q = from a in db.prisoners
            select new {a.pid,a.pjeid,a.pcid,a.prisonid,a.pfname,a.plname,a.birthday,a.offence,a.startdate,a.freedate };
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
            comboBox3.DataSource = db.prisoncells.ToList();
            comboBox3.ValueMember = "pcid";
            comboBox3.DisplayMember = "pcid";

        }
        private void prisonerform_Load(object sender, EventArgs e)
        {
            setgrid();
            setcom();
            dataGridView1.Columns[0].HeaderText = "شناسه زندانی";
            dataGridView1.Columns[1].HeaderText = " شناسه زندان بان";
            dataGridView1.Columns[2].HeaderText = "شناسه سلول";
            dataGridView1.Columns[3].HeaderText = "شناسه زندان";
            dataGridView1.Columns[4].HeaderText = "نام";
            dataGridView1.Columns[5].HeaderText = "نام خانوادگی";
            dataGridView1.Columns[6].HeaderText = " تاریخ تولد";
            dataGridView1.Columns[7].HeaderText = "نام جرم";
            dataGridView1.Columns[8].HeaderText = "تاریخ شروع";
            dataGridView1.Columns[9].HeaderText = "تاریخ خاتمه";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prisoner s = new prisoner();
            s.prisonid = Convert.ToInt32(comboBox1.SelectedValue);
            s.pcid = Convert.ToInt32(comboBox3.SelectedValue);
            s.pjeid = Convert.ToInt32(comboBox2.SelectedValue);
            s.pfname = textBox1.Text;
            s.plname = textBox2.Text;
            s.offence = textBox4.Text;
            s.birthday = Convert.ToDateTime(textBox3.Text);
            s.startdate = Convert.ToDateTime(textBox5.Text);
            s.freedate= Convert.ToDateTime(textBox6.Text);
            db.prisoners.Add(s);
            db.SaveChanges();
            MessageBox.Show("با موفقیت ثبت شد");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            setgrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ide = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult result = MessageBox.Show("آیا مطمئن هستید؟", "system message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var s = db.prisoners.Where(b => b.pid == ide).FirstOrDefault();
                db.prisoners.Remove(s);
                db.SaveChanges();
                MessageBox.Show("با موفقیت حذف شد", "system message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                setgrid();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
           Formupdateprisoner f = new Formupdateprisoner(db);
            f.Show();
            f.valup(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            setgrid();
            this.Close();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            var q = from a in db.prisoners.ToList()
                    where a.plname.Contains(textBox7.Text) || a.pfname.Contains(textBox7.Text) || a.offence.Contains(textBox7.Text)
                    select new { a.pid, a.pjeid, a.pcid, a.prisonid, a.pfname, a.plname, a.birthday, a.offence, a.startdate, a.freedate };
            dataGridView1.DataSource = q.ToList();
        }
    }
}
