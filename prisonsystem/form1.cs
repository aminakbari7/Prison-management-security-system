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
    public partial class form1 : Form
    {
        prisonsystemEntities db = new prisonsystemEntities();
        public form1()
        {
            InitializeComponent();
        }



        void setgrid()
        {
            var q = from a in db.prisons
                    select new { a.id, a.name, a.address, a.phone };
            dataGridView1.DataSource = q.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            prison p = new prison();
            p.name = textBox1.Text;
            p.address = textBox2.Text;
            p.phone = Convert.ToInt32(textBox3.Text);
            db.prisons.Add(p);
            db.SaveChanges();
            MessageBox.Show("با موفقیت ثبت شد");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            setgrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            setgrid();
            dataGridView1.Columns[0].HeaderText = "شناسه زندان";
            dataGridView1.Columns[1].HeaderText = " نام";
            dataGridView1.Columns[2].HeaderText = "آدرس";
            dataGridView1.Columns[3].HeaderText = "شماره تلفن";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int ide = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult result = MessageBox.Show("آیا مطمئن هستید؟?", "system message", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                var s = db.prisons.Where(a => a.id == ide).FirstOrDefault();
                db.prisons.Remove(s);
                db.SaveChanges();
                MessageBox.Show("با موفقیت حذف شد", "system message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                setgrid();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
