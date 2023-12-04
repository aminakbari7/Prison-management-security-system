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
    public partial class mainform : Form
    {
        prisonsystemEntities db = new prisonsystemEntities();
        public mainform()
        {
            InitializeComponent();
        }

        void setgrid()
        {
            var q = from a in db.emploees
            select new { a.eid,a.pcid, a.fname, a.lname, a.birthday, a.job, a.salary };
            dataGridView1.DataSource = q.ToList();

        }
        void setcom()
        {
            comboBox1.DataSource = db.prisons.ToList();
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";

        }
        private void mainform_Load(object sender, EventArgs e)
        {
            setgrid();
            setcom();
            dataGridView1.Columns[0].HeaderText = "شناسه کارمند";
            dataGridView1.Columns[1].HeaderText = "شناسه زندان ";
            dataGridView1.Columns[2].HeaderText = "نام";
            dataGridView1.Columns[3].HeaderText = "نام خانوادگی";
            dataGridView1.Columns[4].HeaderText = "تاریخ تولد";
            dataGridView1.Columns[5].HeaderText = "نام شغل";
            dataGridView1.Columns[6].HeaderText = "میزان حقوق";

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
                emploee s = new emploee();
                s.pcid = Convert.ToInt32(comboBox1.SelectedValue);
                s.fname = textBox1.Text;
                s.lname = textBox2.Text;
                s.birthday = Convert.ToDateTime(textBox3.Text);
                s.job = textBox4.Text;
                s.salary = Convert.ToInt32(textBox5.Text);
                db.emploees.Add(s);
                db.SaveChanges();
                MessageBox.Show("با موفقیت ثبت شد");
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
           
                
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

           int ide = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult result = MessageBox.Show("آیا مطمئن هستید؟?", "system message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result==DialogResult.Yes)
            {
                var s = db.emploees.Where(a => a.eid == ide).FirstOrDefault();
            
                db.emploees.Remove(s);
                db.SaveChanges();
                MessageBox.Show("با موفقیت حذف شد", "system message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Formemploeeedit f = new Formemploeeedit(db);
            f.Show();
            f.valu(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            form1 f = new form1();
            f.Show();

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            var q = from a in db.emploees.ToList()
                    where a.lname.Contains(textBox7.Text) || a.fname.Contains(textBox7.Text) || a.job.Contains(textBox7.Text)
                    select new { a.eid, a.fname, a.lname, a.birthday, a.job, a.salary };
            dataGridView1.DataSource = q.ToList();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            formprisoncell f = new formprisoncell();
            f.Show();
        }



        private void button6_Click(object sender, EventArgs e)
        {
           prisonerform f = new prisonerform();
            f.Show();
        }
        private void button7_Click(object sender, EventArgs e)
        {
            dependentform f = new dependentform();
            f.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            jailorform f = new jailorform();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            managerform f = new managerform();
           
            f.Show();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            x f = new x();

            f.Show();
        }
    }
}
