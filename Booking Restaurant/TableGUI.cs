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
    public partial class TableGUI : Form
    {
        BookingRestaurant_PRNContext context;
        public TableGUI()
        {
            InitializeComponent();
            context = new BookingRestaurant_PRNContext();
            comboBox1.DataSource = context.Tables.Select(x => x.Capacity).Distinct().ToList();
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Value";
            bindGrid(false, true);
        }


        public void bindGrid(bool a, bool add)
        {
            int b = int.Parse(comboBox1.SelectedValue.ToString());


            if (a == true)
                dataGridView1.DataSource = context.Tables.Where(x => x.Capacity == b).ToList();
            else
            {
                dataGridView1.DataSource = context.Tables.ToList();
                if (add == true)
                {
                    DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                    {
                        button.Name = "Edit";
                        button.HeaderText = "Edit";
                        button.Text = "Edit";
                        button.UseColumnTextForButtonValue = true;
                        this.dataGridView1.Columns.Add(button);
                    }
                    DataGridViewButtonColumn button1 = new DataGridViewButtonColumn();
                    {
                        button1.Name = "Delete";
                        button1.HeaderText = "Delete";
                        button1.Text = "Delete";
                        button1.UseColumnTextForButtonValue = true;
                        this.dataGridView1.Columns.Add(button1);
                    }
                }
            }
            dataGridView1.Columns["Bookings"].Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindGrid(true, false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bindGrid(false, false);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                int tableId;
                tableId = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;

                EditTable f = new EditTable(1, tableId, context);
                DialogResult dr = f.ShowDialog();
                if(dr==DialogResult.OK)
                {
                    MessageBox.Show("Edited sucesfully");
                    bindGrid(true,false); 
                }    

            }
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                int tableId;
                tableId = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;

                Table a = context.Tables.Find(tableId);
          DialogResult dr=      MessageBox.Show("Do you want to delete this table?", "Delete", MessageBoxButtons.YesNo);
                if(dr==DialogResult.Yes)
                { 
                context.Tables.Remove(a);
                context.SaveChanges();
                MessageBox.Show("Delete sucesfully");
                    bindGrid(true, false);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

          
                EditTable f = new EditTable(0,0,context);
          DialogResult dr=  f.ShowDialog();
            if (dr == DialogResult.OK)
            {
                MessageBox.Show("Add new table sucesfully");
                bindGrid(true,false);
            }
        }
    }
}
