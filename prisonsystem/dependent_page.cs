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
    public partial class dependentform : Form
    {
        prisonsystemEntities db = new prisonsystemEntities();
        public dependentform()
        {
            InitializeComponent();
        }
        void setgrid()
        {
            var q = from a in db.dependents
                    select new { a.did, a.pid, a.prisonid, a.dfname, a.dlname, a.realationship, a.phone };
            dataGridView1.DataSource = q.ToList();

        }
        void setcom()
        {
            comboBox1.DataSource = db.prisons.ToList();
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "id";
            comboBox2.DataSource = db.prisoners.ToList();
            comboBox2.ValueMember = "pid";
            comboBox2.DisplayMember = "pid";
        }
        private void dependentform_Load(object sender, EventArgs e)
        {
            setgrid();
            setcom();
            dataGridView1.Columns[0].HeaderText = "شناسه فرد وابسته";
            dataGridView1.Columns[1].HeaderText = " شناسه فرد زندانی";
            dataGridView1.Columns[2].HeaderText = "شناسه زندان";
            dataGridView1.Columns[3].HeaderText = "نام";
            dataGridView1.Columns[4].HeaderText = "نام خانوادگی";
            dataGridView1.Columns[5].HeaderText = "نوع نسبیت با زندانی ";
            dataGridView1.Columns[6].HeaderText = "شماره تلفن";
         
        }
        private void button1_Click(object sender, EventArgs e)
        {
            dependent s = new dependent();
            s.prisonid = Convert.ToInt32(comboBox1.SelectedValue);
            s.pid = Convert.ToInt32(comboBox2.SelectedValue);
            s.phone = Convert.ToInt32(textBox4.Text); ;
            s.dfname = textBox1.Text;
            s.dlname = textBox2.Text;
            s.realationship = textBox3.Text;
            db.dependents.Add(s);
            db.SaveChanges();
            MessageBox.Show("با موفقیت ثبت شد");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            setgrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            int ide = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult result = MessageBox.Show("آیا مطمئن هستید؟?", "system message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var z = db.dependents.Where(a => a.did == ide).FirstOrDefault();
                db.dependents.Remove(z);
                db.SaveChanges();
                MessageBox.Show("با موفقیت حذف شد", "system message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                setgrid();
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            var q = from a in db.dependents.ToList()
                    where a.dlname.Contains(textBox7.Text) || a.dfname.Contains(textBox7.Text) || a.realationship.Contains(textBox7.Text)
                    select new { a.pid, a.did, a.prisonid, a.dfname, a.dlname, a.realationship, a.phone };
            dataGridView1.DataSource = q.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
