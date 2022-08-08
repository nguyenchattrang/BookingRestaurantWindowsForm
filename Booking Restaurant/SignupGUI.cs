using Booking_Restaurant.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Booking_Restaurant
{
    public partial class SignupGUI : Form
    {
        BookingRestaurant_PRNContext context;
        public SignupGUI()
        {
            context = new BookingRestaurant_PRNContext();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username = textBox1.Text;
            string password = textBox2.Text;
            string fullname = textBox3.Text;
            string email = textBox4.Text;
            string phone = textBox5.Text;

         Account a=   context.Accounts.Where(x=>x.Username==username).SingleOrDefault();
            int count = 0;
            String message="";
            if(a!=null)
            {
                message="Username exist.\n";
                count += 1;
            }  
            if(password=="" ||fullname==""||email=="")
            {
                message+="Please fill all the field.\n";
                count += 1;
            }
            var r = new Regex(@"^\(?([0-9]{3})\)?[-.●]?([0-9]{3})[-.●]?([0-9]{4})$");
         
            if (!r.IsMatch(phone))
            {
                message += "Phone number is not valid.\n";
                count += 1;
            }    
            if(count>0)
            {
                MessageBox.Show(message,"Message");
                return;
            }    
            
            {
                Account b = new Account();
                b.Username = username;
                b.Password = password;
                b.Fullname = fullname;
                b.Email = email;
                b.Phone = phone;
                b.Status = "Active";
                b.RoleId = 3;
                context.Accounts.Add(b);
                context.SaveChanges();
                MessageBox.Show("Add new account succesfully!");
                this.Close();

            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SignupGUI_Load(object sender, EventArgs e)
        {

        }
    }
}
