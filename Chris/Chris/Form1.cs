using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Chris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(connstring);
            SqlDataAdapter da = new SqlDataAdapter("Select * from Stock_book", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            label10.Hide();
            button6.Hide();

        }

        SqlConnection conn = new SqlConnection();
        SqlCommand comm = new SqlCommand();
        string connstring = @"Data Source=JON-PC\SQLEXPRESS;Initial Catalog=WP2018mayA;Integrated Security=True";

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            SqlDataAdapter da = new SqlDataAdapter("Select * from Stock_book", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
           // dateTimePicker1.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            textBox9.Text = "";
            textBox10.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            conn.Open();

            string sqlstr = "insert into Stock_book values (";
            sqlstr = sqlstr + "'" + textBox1.Text + "',";
            sqlstr = sqlstr + "'" + textBox2.Text + "',";
            sqlstr = sqlstr + "'" + textBox3.Text + "',";
            sqlstr = sqlstr + "'" + textBox4.Text + "',";
            
            sqlstr = sqlstr + "'" + dateTimePicker1.Text + "',";
            sqlstr = sqlstr + "'" + textBox6.Text + "',";
            sqlstr = sqlstr + "'" + textBox7.Text + "',";
            sqlstr = sqlstr + "'" + textBox8.Text + "',";
            sqlstr = sqlstr + "'" + textBox9.Text + "',";
            sqlstr = sqlstr + "'" + textBox5.Text + "',";
            sqlstr = sqlstr + "'" + textBox10.Text + "')";

            comm = new SqlCommand(sqlstr, conn);

            try
            {
                comm.ExecuteNonQuery();
                MessageBox.Show("Saved");
            }
            catch
            {
                MessageBox.Show("Not saved\nCheck if ID already exist ");
            }
            finally
            {
                conn.Close();
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            conn.Open();

            string sqlstr = "delete from Stock_book where Book_id like(" + "'"
                + textBox1.Text + "')";

            comm = new SqlCommand(sqlstr, conn);

            try
            {
                comm.ExecuteNonQuery();
                MessageBox.Show("Deleted");
            }
            catch
            {
                MessageBox.Show("Not Deleted");
            }
            finally
            {
                conn.Close();
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.Show();
            this.Hide();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            
            string sqlstr10 = "Select * from Stock_book WHERE ";
            //char last = StrNo[StrNo.Length - 1];


            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                sqlstr10 = sqlstr10 + "Book_Id LIKE '" + textBox1.Text + "'";

            }
            if (!String.IsNullOrEmpty(textBox2.Text))
            {
                char last = sqlstr10[sqlstr10.Length - 2];
                if (last != 'D' && last !='E')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }

                sqlstr10 = sqlstr10 + "Book_Title LIKE '" + textBox2.Text + "'";

            }
            if (!String.IsNullOrEmpty(textBox3.Text))
            {
                char last = sqlstr10[sqlstr10.Length - 2];
                
                if (last != 'D' && last != 'E')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }

                sqlstr10 = sqlstr10 + "Book_Category LIKE '" + textBox3.Text + "'";

            }
            if (!String.IsNullOrEmpty(textBox4.Text))
            {
                char last = sqlstr10[sqlstr10.Length - 2];
                if (last != 'D' && last != 'E')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }

                sqlstr10 = sqlstr10 + "Book_Author LIKE '" + textBox4.Text + "'";

            }
            if (!String.IsNullOrEmpty(textBox5.Text))
            {
                char last = sqlstr10[sqlstr10.Length - 2];
                if (last != 'D' && last != 'E')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }

                sqlstr10 = sqlstr10 + "Book_Cost LIKE '" + textBox5.Text + "'";

            }
            if (!String.IsNullOrEmpty(dateTimePicker1.Text) && dateTimePicker1.Value != dateTimePicker1.MinDate)
            {
                char last = sqlstr10[sqlstr10.Length - 2];
                if (last != 'D' && last != 'E')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }
                // var date = 
                
                sqlstr10 = sqlstr10 + "Book_Pub_Date = '" + dateTimePicker1.Value.Year +"/"+dateTimePicker1.Value.Month+"/"+dateTimePicker1.Value.Day+ "'";

            }
            if (!String.IsNullOrEmpty(textBox6.Text))
            {
                char last = sqlstr10[sqlstr10.Length - 2];
                if (last != 'D' && last != 'E')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }

                sqlstr10 = sqlstr10 + "Book_Publisher LIKE '" + textBox6.Text + "'";

            }
            if (!String.IsNullOrEmpty(textBox7.Text))
            {
                char last = sqlstr10[sqlstr10.Length - 2];
                if (last != 'D' && last != 'E')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }

                sqlstr10 = sqlstr10 + "Book_ISBN LIKE '" + textBox7.Text + "'";

            }
            if (!String.IsNullOrEmpty(textBox8.Text))
            {
                char last = sqlstr10[sqlstr10.Length - 2];
                if (last != 'D' && last != 'E')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }

                sqlstr10 = sqlstr10 + "Book_Supplier LIKE '" + textBox8.Text + "'";

            }
            if (!String.IsNullOrEmpty(textBox9.Text))
            {
                char last = sqlstr10[sqlstr10.Length - 2];
                if (last != 'D' && last != 'E')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }

                sqlstr10 = sqlstr10 + "Book_Stock LIKE '" + textBox9.Text + "'";

            }
            if (!String.IsNullOrEmpty(textBox10.Text))
            {
                char last = sqlstr10[sqlstr10.Length - 2];
                if (last != 'D' && last != 'E')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }

                sqlstr10 = sqlstr10 + "Book_Status LIKE '" + textBox10.Text + "'";

            }


            MessageBox.Show(sqlstr10);

            SqlDataAdapter da = new SqlDataAdapter(sqlstr10, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


            /* if (!String.IsNullOrEmpty(textBox1.Text))
             {
                 SqlDataAdapter da = new SqlDataAdapter("Select * from Stock_book" +
                     " where Book_Id LIKE '"+ textBox1.Text + "'", conn);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 dataGridView1.DataSource = dt;

             }
             if (!String.IsNullOrEmpty(textBox2.Text))
             {
                 SqlDataAdapter da = new SqlDataAdapter("Select * from Stock_book" +
                     " where Book_Title LIKE '" + textBox2.Text + "'", conn);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 dataGridView1.DataSource = dt;

             }
             if (!String.IsNullOrEmpty(textBox3.Text))
             {
                 SqlDataAdapter da = new SqlDataAdapter("Select * from Stock_book" +
                     " where Book_Category LIKE '" + textBox3.Text + "'", conn);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 dataGridView1.DataSource = dt;

             }
             if (!String.IsNullOrEmpty(textBox4.Text))
             {
                 SqlDataAdapter da = new SqlDataAdapter("Select * from Stock_book" +
                     " where Book_Author LIKE '" + textBox4.Text + "'", conn);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 dataGridView1.DataSource = dt;

             }
             if (!String.IsNullOrEmpty(textBox5.Text))
             {
                 SqlDataAdapter da = new SqlDataAdapter("Select * from Stock_book" +
                     " where Book_Pub_Date LIKE '" + textBox5.Text + "'", conn);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 dataGridView1.DataSource = dt;

             }
             if (!String.IsNullOrEmpty(textBox6.Text))
             {
                 SqlDataAdapter da = new SqlDataAdapter("Select * from Stock_book" +
                     " where Book_Publisher LIKE '" + textBox6.Text + "'", conn);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 dataGridView1.DataSource = dt;

             }
             if (!String.IsNullOrEmpty(textBox7.Text))
             {
                 SqlDataAdapter da = new SqlDataAdapter("Select * from Stock_book" +
                     " where Book_ISBN LIKE '" + textBox7.Text + "'", conn);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 dataGridView1.DataSource = dt;

             }
             if (!String.IsNullOrEmpty(textBox8.Text))
             {
                 SqlDataAdapter da = new SqlDataAdapter("Select * from Stock_book" +
                     " where Book_Supplier LIKE '" + textBox8.Text + "'", conn);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 dataGridView1.DataSource = dt;

             }
             if (!String.IsNullOrEmpty(textBox9.Text))
             {
                 SqlDataAdapter da = new SqlDataAdapter("Select * from Stock_book" +
                     " where Book_Stock LIKE '" + textBox9.Text + "'", conn);
                 DataTable dt = new DataTable();
                 da.Fill(dt);
                 dataGridView1.DataSource = dt;

             }*/


            try
            {
                comm.ExecuteNonQuery();


            }
            catch
            {
                //MessageBox.Show("Not Found");
            }
            finally
            {
                conn.Close();
            }



        }

        private void button6_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            
            string sqlstr10 = "UPDATE Stock_Book SET ";
  
            


            if (!String.IsNullOrEmpty(textBox2.Text))
            {

                sqlstr10 = sqlstr10 + "Book_Title = '" + textBox2.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox3.Text))
            {

                sqlstr10 = sqlstr10 + "Book_Category = '" + textBox3.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox4.Text))
            {

                sqlstr10 = sqlstr10 + "Book_Author = '" + textBox4.Text + "'";
            }
            
            if (!String.IsNullOrEmpty(dateTimePicker1.Text)&& dateTimePicker1.Value != dateTimePicker1.MinDate)
            {
                
                sqlstr10 = sqlstr10 + "Book_Pub_Date = '" + dateTimePicker1.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox6.Text))
            {

                sqlstr10 = sqlstr10 + "Book_Publisher = '" + textBox6.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox7.Text))
            {

                sqlstr10 = sqlstr10 + "Book_ISBN = '" + textBox7.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox8.Text))
            {

                sqlstr10 = sqlstr10 + "Book_Supplier = '" + textBox8.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox9.Text))
            {

                sqlstr10 = sqlstr10 + "Book_Stock = '" + textBox9.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox5.Text))
            {

                sqlstr10 = sqlstr10 + "Book_Cost = '" + textBox5.Text + "'";
            }
            if (!String.IsNullOrEmpty(textBox10.Text))
            {

                sqlstr10 = sqlstr10 + "Book_Status = '" + textBox10.Text + "'";
            }




            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                sqlstr10 = sqlstr10 + " WHERE Book_Id LIKE '" + textBox1.Text + "'";

            }
           
            comm = new SqlCommand(sqlstr10, conn);

            try
            {
                comm.ExecuteNonQuery();
                MessageBox.Show("Edited");
            }
            catch
            {
                MessageBox.Show("Not Edited");
            }
            finally
            {
                conn.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked ==true)
            {
                label10.Show();
                button6.Show();
                button2_Click(e,e);
            }else if (checkBox1.Checked == false)
            {
                label10.Hide();
                button6.Hide();
                button2_Click(e, e);
            }



        }
        
        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                dateTimePicker1.Hide();
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;
                textBox9.ReadOnly = true;
                textBox10.ReadOnly = true;
            }
            if (string.IsNullOrWhiteSpace(textBox2.Text) || checkBox1.Checked==false)
            {
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                dateTimePicker1.Show();
                textBox6.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox8.ReadOnly = false;
                textBox9.ReadOnly = false;
                textBox10.ReadOnly = false;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                dateTimePicker1.Hide();
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;
                textBox9.ReadOnly = true;
                textBox10.ReadOnly = true;
            }
            if (string.IsNullOrWhiteSpace(textBox3.Text) || checkBox1.Checked == false)
            {
                textBox2.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                dateTimePicker1.Show();
                textBox6.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox8.ReadOnly = false;
                textBox9.ReadOnly = false;
                textBox10.ReadOnly = false;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox5.ReadOnly = true;
                dateTimePicker1.Hide();
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;
                textBox9.ReadOnly = true;
                textBox10.ReadOnly = false;
            }
            if (string.IsNullOrWhiteSpace(textBox4.Text) || checkBox1.Checked == false)
            {
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox5.ReadOnly = false;
                dateTimePicker1.Show();
                textBox6.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox8.ReadOnly = false;
                textBox9.ReadOnly = false;
                textBox10.ReadOnly = false;
            }
        }

       /* private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;
                textBox9.ReadOnly = true;
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text) || checkBox1.Checked == false)
            {
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox6.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox8.ReadOnly = false;
                textBox9.ReadOnly = false;
            }
        }
        */
        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                dateTimePicker1.Hide();
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;
                textBox9.ReadOnly = true;
                textBox10.ReadOnly = true;
            }
            if (string.IsNullOrWhiteSpace(textBox6.Text) || checkBox1.Checked == false)
            {
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                dateTimePicker1.Show();
                textBox7.ReadOnly = false;
                textBox8.ReadOnly = false;
                textBox9.ReadOnly = false;
                textBox10.ReadOnly = false;
            }
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                dateTimePicker1.Hide();
                textBox6.ReadOnly = true;
                textBox8.ReadOnly = true;
                textBox9.ReadOnly = true;
                textBox10.ReadOnly = true;
            }
            if (string.IsNullOrWhiteSpace(textBox7.Text) || checkBox1.Checked == false)
            {
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                dateTimePicker1.Show();
                textBox6.ReadOnly = false;
                textBox8.ReadOnly = false;
                textBox9.ReadOnly = false;
                textBox10.ReadOnly = false;
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                dateTimePicker1.Hide();
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox9.ReadOnly = true;
                textBox10.ReadOnly = true;
            }
            if (string.IsNullOrWhiteSpace(textBox8.Text) || checkBox1.Checked == false)
            {
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                dateTimePicker1.Show();
                textBox6.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox9.ReadOnly = false;
                textBox10.ReadOnly = false;
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                dateTimePicker1.Hide();
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;
                textBox10.ReadOnly = true;
            }
            if (string.IsNullOrWhiteSpace(textBox9.Text) || checkBox1.Checked == false)
            {
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                dateTimePicker1.Show();
                textBox6.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox8.ReadOnly = false;
                textBox10.ReadOnly = false;
            }
        }

       

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                dateTimePicker1.Hide();
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;
                textBox9.ReadOnly = true;
                textBox10.ReadOnly = true;
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text) || checkBox1.Checked == false)
            {
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                dateTimePicker1.Show();
                textBox6.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox8.ReadOnly = false;
                textBox9.ReadOnly = false;
                textBox10.ReadOnly = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
             Sales sales = new Sales();
            sales.Show();
            this.Hide();
        }

        private void DateClose(object sender, EventArgs e)
        {

            if (checkBox1.Checked == true)
            {
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;
                textBox9.ReadOnly = true;
            }
            if (string.IsNullOrWhiteSpace(dateTimePicker1.Text) || checkBox1.Checked == false)
            {
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                textBox6.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox8.ReadOnly = false;
                textBox9.ReadOnly = false;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                textBox5.ReadOnly = true;
                dateTimePicker1.Hide();
                textBox6.ReadOnly = true;
                textBox7.ReadOnly = true;
                textBox8.ReadOnly = true;
                textBox9.ReadOnly = true;
               
            }
            if (string.IsNullOrWhiteSpace(textBox5.Text) || checkBox1.Checked == false)
            {
                textBox2.ReadOnly = false;
                textBox3.ReadOnly = false;
                textBox4.ReadOnly = false;
                textBox5.ReadOnly = false;
                dateTimePicker1.Show();
                textBox6.ReadOnly = false;
                textBox7.ReadOnly = false;
                textBox8.ReadOnly = false;
                textBox9.ReadOnly = false;
               
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Report report = new Report();
            report.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
    

