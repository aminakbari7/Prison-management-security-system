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
    public partial class Formupdateprisoner : Form
    {
        prisonsystemEntities db = new prisonsystemEntities();
        public Formupdateprisoner(prisonsystemEntities content)
        {
            InitializeComponent();
            db = content;
        }
        int ide;
        public void valup(int id)
        {
            ide = id;
            var s = db.prisoners.Where(a => a.pid == id).FirstOrDefault();
            textBox1.Text = s.pfname;
            textBox2.Text = s.plname;
            textBox3.Text = Convert.ToString(s.birthday);
            textBox4.Text = s.offence;
            textBox5.Text = Convert.ToString(s.startdate);
            textBox6.Text = Convert.ToString(s.freedate);
            comboBox1.SelectedValue = (s.prisonid);
            comboBox2.SelectedValue = (s.pjeid);
            comboBox3.SelectedValue = (s.pcid);

        }
        private void Formupdateprisoner_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            var s = db.prisoners.Where(b => b.pid == ide).FirstOrDefault();
            s.pfname = textBox1.Text;
            s.plname = textBox2.Text;
            s.birthday = Convert.ToDateTime(textBox3.Text);
            s.offence = textBox4.Text;
            s.startdate = Convert.ToDateTime(textBox5.Text);
            s.freedate = Convert.ToDateTime(textBox6.Text);
            db.SaveChanges();
            MessageBox.Show("با موفقیت بروزرسانی شد", "system message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}
