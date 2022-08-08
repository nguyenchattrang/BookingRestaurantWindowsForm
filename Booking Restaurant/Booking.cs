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
    public partial class Booking : Form
    {
        BookingRestaurant_PRNContext context;
        public Booking()
        {
            context = new BookingRestaurant_PRNContext();
            InitializeComponent();
            string time = CreateDate.RoundUp(DateTime.Now, TimeSpan.FromMinutes(30)).ToString("HH:mm");
            int timeid = context.Times.Where(x => x.Time1 == time).Select(x => x.Id).SingleOrDefault();
            comboBox1.DataSource = context.Times.Where(x => x.Id >= timeid).ToList();
            comboBox1.DisplayMember = "time1";
            comboBox1.ValueMember = "id";


            List<string> people = new List<string>();
            for (int i = 1; i <= 10; i++)
            {
                people.Add($"{i} people");
            }
            comboBox2.DisplayMember = "string";
            comboBox2.ValueMember = "int";
            comboBox2.DataSource = people;
            comboBox2.SelectedIndex = 1;
            dateTimePicker1.Value = DateTime.Now;

            comboBox1.SelectedIndex = 0;


            for (int i = 0; i < comboBox1.SelectedIndex; i++)
            {
                comboBox1.SelectedIndex = -1;
            }


            bindGrid(false);
        }

        public void bindGrid(bool a)
        {


            int people = int.Parse(comboBox2.SelectedValue.ToString().Split(" ")[0]);

            int timeid = int.Parse(comboBox1.SelectedValue.ToString());
            var abc = context.Bookings.Where(x => x.Orderdate == (DateTime)dateTimePicker1.Value).Where(x => x.TimeId > timeid - 7 && x.TimeId < timeid + 7).Select(x => x.TableId).ToList();

            var data = context.Tables.Where(x => !abc.Contains(x.Id)).Where(x => x.Capacity >= people).ToList();
            dataGridView1.DataSource = data;
            if (a == false)
            {
                DataGridViewButtonColumn button = new DataGridViewButtonColumn();
                {
                    button.Name = "Booking";
                    button.HeaderText = "Booking";
                    button.Text = "Booking";
                    button.UseColumnTextForButtonValue = true;
                    this.dataGridView1.Columns.Add(button);
                }
            }

            dataGridView1.Columns["Bookings"].Visible = false;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            bindGrid(true);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int people = int.Parse(comboBox2.SelectedValue.ToString().Split(" ")[0]);
            if (e.ColumnIndex == dataGridView1.Columns["Booking"].Index)
            {
                int tableId;
                tableId = (int)dataGridView1.Rows[e.RowIndex].Cells["Id"].Value;
                DialogResult dr = MessageBox.Show($"Do you want to book this table at {comboBox1.Text} - {dateTimePicker1.Value.ToString("dd/MM/yyyy")} for {comboBox2.SelectedItem}?", "Booking Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
               
                if (dr == DialogResult.Yes)
                {
                    Models.Booking a = new Models.Booking();
                    a.AccountId = context.Accounts.Where(x => x.Username == Settings.UserName).Select(x=>x.Id).SingleOrDefault();
                    a.Numberofpeople = people;
                    a.Orderdate = dateTimePicker1.Value;
                    a.TimeId = int.Parse( comboBox1.SelectedValue.ToString());
                    a.TableId = tableId;

                    context.Bookings.Add(a);
                    context.SaveChanges();
                    MessageBox.Show("Add succesfully!");
                    bindGrid(true);
                }
                return;
            }
        }

        private void Booking_Load(object sender, EventArgs e)
        {

        }
    }

    public static class CreateDate
    {
        public static DateTime RoundUp(this DateTime dt, TimeSpan d)
        {
            var modTicks = dt.Ticks % d.Ticks;
            var delta = modTicks != 0 ? d.Ticks - modTicks : 0;
            return new DateTime(dt.Ticks + delta, dt.Kind);
        }
    }    
  
}
