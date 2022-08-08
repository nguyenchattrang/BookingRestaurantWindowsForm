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
    public partial class AccountGUI : Form
    {
        BookingRestaurant_PRNContext context;
        public AccountGUI()
        {
            InitializeComponent();
            context = new BookingRestaurant_PRNContext();
        }
        public void bindGrid(bool a)
        {
            int role = int.Parse(comboBox1.SelectedValue.ToString());

            dataGridView1.DataSource = context.Accounts.Where(x=>x.RoleId==(role==-1?x.Id:role)).ToList();
            if(a==true)
            {     
            DataGridViewButtonColumn button = new DataGridViewButtonColumn();
            {
                button.Name = "Edit";
                button.HeaderText = "Edit";
                button.Text = "Edit";
                button.UseColumnTextForButtonValue = true;
                this.dataGridView1.Columns.Add(button);
            }
            }
        }
        private void AccountGUI_Load(object sender, EventArgs e)
        {
            var list = context.Roles.ToList();
            Role a = new Role();
            a.Id = -1;
            a.Name = "All Role";
            list.Insert(0,a);
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "id";
            comboBox1.DataSource = list;
            dataGridView1.DataSource = context.Accounts.ToList();
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
            dataGridView1.Columns["Bookings"].Visible = false;
            dataGridView1.Columns["Role"].Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            bindGrid(false);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Edit"].Index)
            {
                int aId;
                aId = (int)dataGridView1.Rows[e.RowIndex].Cells["id"].Value;
                AccountDetails f = new AccountDetails(context,aId);
          DialogResult dr=      f.ShowDialog();
                if (dr == DialogResult.OK)
                {

                    MessageBox.Show("Edited succesfully!");
                    bindGrid(false);
                }
                return;

            }
            if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                int rId;
                rId = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
                DialogResult dr = MessageBox.Show($"Do you want to delete this Account ", "Delete", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    Models.Account a = context.Accounts.Find(rId);
                    context.Accounts.Remove(a);


                    context.SaveChanges();
                    MessageBox.Show("Delete succesfully!");
                    bindGrid(false);
                }

            }
        }
    }
}
