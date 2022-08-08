using Booking_Restaurant.GUI;
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
    public partial class MainGUI : Form
    {
        public MainGUI()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
           

            if (loginToolStripMenuItem.Text.StartsWith("Login"))
            {
               LoginGUI login = new LoginGUI();
            DialogResult dr = login.ShowDialog();
             
            }
            else
            {
                Settings.UserName = "";
                MessageBox.Show("You are logged out");
                toolStripContainer2.ContentPanel.Controls.Clear();
            }
        }

        private void MainGUI_Activated(object sender, EventArgs e)
        {
            if (Settings.UserName == "")
            {  
                loginToolStripMenuItem.Text = "Login";
                registrationToolStripMenuItem.Visible = false;
                manageTableToolStripMenuItem.Visible = false;
                manageAccountToolStripMenuItem.Visible = false;
            }
            else
            {   
                loginToolStripMenuItem.Text = $"Logout ({Settings.UserName})";
                if(Settings.roleid==1)
                {
                    registrationToolStripMenuItem.Visible = true;
                    manageTableToolStripMenuItem.Visible = true;
                    manageAccountToolStripMenuItem.Visible = true;
                }    
                else if(Settings.roleid == 2)
                {
                    registrationToolStripMenuItem.Visible = true;
                   
                }    
                else
                {
                    registrationToolStripMenuItem.Visible = true;
                   
                }    

            }
        }

        private void bookingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Settings.UserName == "")
            {
                MessageBox.Show("Please login first!");
                return;
            }    
            Booking f = new Booking();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();

            toolStripContainer2.ContentPanel.Controls.Clear();
            toolStripContainer2.ContentPanel.Controls.Add(f);
        }

        private void registrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RegistrationGUI f = new RegistrationGUI();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();

            toolStripContainer2.ContentPanel.Controls.Clear();
            toolStripContainer2.ContentPanel.Controls.Add(f);
        }

        private void manageTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TableGUI f = new TableGUI();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();

            toolStripContainer2.ContentPanel.Controls.Clear();
            toolStripContainer2.ContentPanel.Controls.Add(f);
        }

        private void manageAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountGUI f = new AccountGUI();
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Show();

            toolStripContainer2.ContentPanel.Controls.Clear();
            toolStripContainer2.ContentPanel.Controls.Add(f);
        }
    }
}
