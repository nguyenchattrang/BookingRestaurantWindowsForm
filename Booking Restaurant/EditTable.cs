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
    public partial class EditTable : Form
    {
        int i;
        int id;
        BookingRestaurant_PRNContext context;
        public EditTable(int i,int id,BookingRestaurant_PRNContext a)
        {
            InitializeComponent();
            this.i = i;

            this.id = id;
            this.context = a;
            if(id!=0)
            {
                Table b = context.Tables.Find(id);
                textBox2.Text = b.Name;
                numericUpDown1.Value =(decimal) b.Capacity;
                textBox4.Text = b.Description;
            }    
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(i==0)
                {
                string name = textBox2.Text;
                int capacity = int.Parse( numericUpDown1.Value.ToString());
                string description = textBox4.Text;
                Table a = new Table();
                a.Name = name;
                a.Capacity = capacity;
                a.Description = description;
           
                context.Tables.Add(a);
                context.SaveChanges();
                }    
            else
            {
                
                    
                    string name = textBox2.Text;
                    int capacity = int.Parse(numericUpDown1.Value.ToString());
                    string description = textBox4.Text;
                Table a = context.Tables.Find(id);
              
                    a.Name = name;
                    a.Capacity = capacity;
                    a.Description = description;
              
                context.Tables.Update(a);
                    context.SaveChanges();
                
            }    
        }
    }
}
