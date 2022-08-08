using Booking_Restaurant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Booking_Restaurant
{
    public partial class AccountDetails : Form
    {
        int id;
        BookingRestaurant_PRNContext Context;
        public AccountDetails(BookingRestaurant_PRNContext  context,int id)
        {
            InitializeComponent();
        
          
            this.Context = context;
            this.id = id;
            Account a = Context.Accounts.Find(id);
         

  
            textBox2.Text = a.Fullname;
            textBox4.Text= a.Email;
             textBox5.Text= a.Phone;
        }

        private void AccountDetails_Load(object sender, EventArgs e)
        {
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = Context.Roles.ToList() ;

            Account a = Context.Accounts.Find(id);
            try {
                int roleid = (int)a.RoleId - 1;
                comboBox1.SelectedIndex = roleid;
                    }
            catch {
                comboBox1.SelectedIndex = 0;
            }
          

            List<string> status = new List<string>();
            status.Add("Active");
            status.Add("Inactive");
            comboBox2.DisplayMember = "string";
            comboBox2.ValueMember = "string";
            comboBox2.DataSource = status;

        }

        private void button1_Click(object sender, EventArgs e)
        {
         Account a=   Context.Accounts.Find(id);
            a.RoleId = int.Parse(comboBox1.SelectedValue.ToString());
            a.Fullname = textBox2.Text;
            a.Status = comboBox2.SelectedValue.ToString();
            a.Email = textBox4.Text;
            a.Phone = textBox5.Text;

            Context.Accounts.Update(a);
            Context.SaveChanges();
        }
    }
}
