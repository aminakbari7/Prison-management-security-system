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
    public partial class Formemploeeedit : Form
    {
        prisonsystemEntities db = new prisonsystemEntities();
        public Formemploeeedit(prisonsystemEntities content)
        {
            InitializeComponent();
            db = content;
        }
        int ide;
        public void valu(int id)
        {
            ide = id;
            var s = db.emploees.Where(a => a.eid == id).FirstOrDefault();
            textBox1.Text = s.fname;
            textBox2.Text = s.lname;
            textBox3.Text = Convert.ToString(s.birthday);
            textBox4.Text = (s.job);
            textBox5.Text = Convert.ToString(s.salary);
            comboBox1.SelectedValue = (s.pcid);
        }
        private void Formemploeeedit_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = db.prisons.ToList();
            comboBox1.ValueMember = "id";
            comboBox1.DisplayMember = "name";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var s = db.emploees.Where(b => b.eid == ide).FirstOrDefault();
            s.fname= textBox1.Text;
            s.lname = textBox2.Text;
            s.birthday=Convert.ToDateTime(textBox3.Text);
            s.job=textBox4.Text ;
            s.salary= Convert.ToInt32(textBox5.Text);
            s.pcid=Convert.ToInt32(comboBox1.SelectedValue);
            db.SaveChanges();
            MessageBox.Show("با موفقیت بروزرسانی شد", "system message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
