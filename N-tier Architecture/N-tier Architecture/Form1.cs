using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccessLayer;
using EntityLayer;
using LogicLayer;

namespace N_tier_Architecture
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void btnList_Click(object sender, EventArgs e)
        {
            List<EntityPerson> people = LogicPerson.LLpersonList();
            dataGridView1.DataSource = people;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EntityPerson p = new EntityPerson();
            p.Name = tbName.Text;
            p.Surname = tbSurname.Text;
            p.City = tbCity.Text;
            p.Job = tbJob.Text;
            p.Salary = short.Parse(tbSalary.Text);
            LogicPerson.LLpersonAdd(p);
            List<EntityPerson> people = LogicPerson.LLpersonList();
            dataGridView1.DataSource = people;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EntityPerson p = new EntityPerson();
            p.Id = short.Parse(tbId.Text);
            LogicPerson.LLpersonDelete(p.Id);
            List<EntityPerson> people = LogicPerson.LLpersonList();
            dataGridView1.DataSource = people;
            tbId.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {

            EntityPerson p = new EntityPerson();
            p.Name = tbName.Text;
            p.Id = int.Parse(tbId.Text);
            p.Surname = tbSurname.Text;
            p.City = tbCity.Text;
            p.Job = tbJob.Text;
            p.Salary = short.Parse(tbSalary.Text);
            LogicPerson.LLpersonupdate(p);
            List<EntityPerson> people = LogicPerson.LLpersonList();
            dataGridView1.DataSource = people;
        }
    }
}
