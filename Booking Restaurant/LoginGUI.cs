using Booking_Restaurant.GUI;
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
    public partial class LoginGUI : Form
    {
        BookingRestaurant_PRNContext context;
        public LoginGUI()
        {
         context=   new BookingRestaurant_PRNContext();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

       Account a= context.Accounts.Where(x => x.Username == textBox1.Text).Where(x => x.Password == textBox2.Text).SingleOrDefault();

            if (a!=null)
            {
                MessageBox.Show("Loggin succesfully");
                Settings.UserName = a.Username;
                try { 
                    
                    Settings.roleid =(int) a.RoleId; 
                
                
                }
                catch
                {
                    Settings.roleid = 3;
                }
          
                this.Close();
            }
            else
                MessageBox.Show("Wrong username or password");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SignupGUI f = new SignupGUI();
          f.Show();
        }
    }
}
