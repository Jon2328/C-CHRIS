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
    public partial class Report : Form
    {
        SqlConnection conn = new SqlConnection();
        SqlCommand comm = new SqlCommand();
        string connstring = @"Data Source=JON-PC\SQLEXPRESS;Initial Catalog=WP2018mayA;Integrated Security=True";
        public Report()
        {
            InitializeComponent();
            conn = new SqlConnection(connstring);
            SqlDataAdapter da = new SqlDataAdapter("select report_book.sales_id,  report_book.Order_Id , Report_book.Book_Id,report_book.sales_date " +
            " , Stock_book.Book_Author,Stock_book.Book_category,Order_book.Order_Cost,Stock_book.Book_Cost,report_book.Book_Count from" +
            " Report_book" +
            " LEFT JOIN Stock_book ON Report_book.Book_Id = Stock_book.Book_id" +
            " LEFT JOIN Order_book ON Report_book.Order_Id = Order_book.Order_Id", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            conn.Open();

            string sqlstr10 = "select report_book.sales_id,  report_book.Order_Id , Report_book.Book_Id,stock_book.book_title,report_book.sales_date "+
            ", Stock_book.Book_Author,Stock_book.Book_category,Order_book.Order_Cost,Stock_book.Book_Cost,Report_Book.book_Count,report_book.sales_profit from"+
            " Report_book"+
            " LEFT JOIN Stock_book ON Report_book.Book_Id = Stock_book.Book_id"+
            " LEFT JOIN Order_book ON Report_book.Order_Id = Order_book.Order_Id"+
            " WHERE ";
            


            if (!String.IsNullOrEmpty(textBox1.Text))
            {
                sqlstr10 = sqlstr10 + " Report_Book.Sales_Id LIKE '" + textBox1.Text + "'";

            }
            if (!String.IsNullOrEmpty(textBox2.Text))
            {
                char last = sqlstr10[sqlstr10.Length - 2];
               
                if (last != 'D' && last != 'E')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }

                sqlstr10 = sqlstr10 + " Report_Book.Order_Id LIKE '" + textBox2.Text + "'";

            }
            if (!String.IsNullOrEmpty(textBox3.Text))
            {
                char last = sqlstr10[sqlstr10.Length - 2];
                if (last != 'D' && last != 'E')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }

                sqlstr10 = sqlstr10 + " Report_Book.Book_Id LIKE '" + textBox3.Text + "'";

            }
            if (!String.IsNullOrEmpty(textBox4.Text))
            {
                char last = sqlstr10[sqlstr10.Length - 2];
                if (last != 'D' && last != 'E')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }

                sqlstr10 = sqlstr10 + " Stock_Book.Book_Title LIKE '" + textBox4.Text + "'";

            }
            if (!String.IsNullOrEmpty(textBox5.Text))
            {
                char last = sqlstr10[sqlstr10.Length - 2];
                if (last != 'D' && last != 'E')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }

                sqlstr10 = sqlstr10 + " stock_Book.Book_Author LIKE '" + textBox5.Text + "'";

            }
            if (!String.IsNullOrEmpty(textBox6.Text))
            {
                char last = sqlstr10[sqlstr10.Length - 2];
                if (last != 'D' && last != 'E')
                {
                    sqlstr10 = sqlstr10 + " AND ";
                }

                sqlstr10 = sqlstr10 + " stock_Book.Book_Category LIKE '" + textBox6.Text + "'";

            }
 
            SqlDataAdapter da = new SqlDataAdapter(sqlstr10, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;


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
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";

        }
        // MessageBox.Show(DateTime.Today.ToString("yyyy/MM/dd"));
        private void button4_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            string sqlstr = "select report_book.sales_id,  report_book.Order_Id , Report_book.Book_Id,stock_book.book_title,report_book.sales_date "+
            " , Stock_book.Book_Author,Stock_book.Book_category,Order_book.Order_Cost,Stock_book.Book_Cost,Report_Book.book_Count,report_book.sales_profit from" +
             " Report_book"+
            " LEFT JOIN Stock_book ON Report_book.Book_Id = Stock_book.Book_id"+
            " LEFT JOIN Order_book ON Report_book.Order_Id = Order_book.Order_Id WHERE Sales_date BETWEEN '";
            sqlstr = sqlstr + DateTime.Today.ToString("yyyy-MM-dd") + "' AND '" + DateTime.Today.AddYears(1).ToString("yyyy-MM-dd") +
                "' AND Stock_book.Book_category = '" + textBox6.Text + "'";

            SqlDataAdapter da = new SqlDataAdapter(sqlstr, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;



            /* MessageBox.Show(sqlstr);
             string sqlstr5 = "";
             SqlCommand comm = new SqlCommand(sqlstr, conn);
             List<DateTime> Dateyear1 = new List<DateTime>();
             SqlDataReader reader = comm.ExecuteReader();
             int sc = 0;
             if (reader.HasRows)
             {
                 while (reader.Read())
                 {
                     if (reader.HasRows)
                     {
                         Dateyear1.Add(reader.GetDateTime(0));
                     }

                 }
                 foreach (object o in Dateyear1)
                 {
                     sqlstr5 = sqlstr5 + Dateyear1.ToString();
                 }
                 MessageBox.Show(sqlstr5);
             }

             reader.Close();*/

        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            SqlDataAdapter da = new SqlDataAdapter("select report_book.sales_id,  report_book.Order_Id , Report_book.Book_Id,report_book.sales_date " +
            " , Stock_book.Book_Author,Stock_book.Book_category,Order_book.Order_Cost,Stock_book.Book_Cost,report_book.Book_Count,report_book.sales_profit from" +
            " Report_book" +
            " LEFT JOIN Stock_book ON Report_book.Book_Id = Stock_book.Book_id" +
            " LEFT JOIN Order_book ON Report_book.Order_Id = Order_book.Order_Id", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(connstring);
            conn.Open();
            SqlCommand comm = new SqlCommand("select report_book.sales_id,  report_book.Order_Id , Report_book.Book_Id,report_book.sales_date " +
            " , Stock_book.Book_Author,Stock_book.Book_category,Order_book.Order_Cost,Stock_book.Book_Cost,report_book.Book_Count,report_book.sales_profit from" +
            " Report_book" +
            " LEFT JOIN Stock_book ON Report_book.Book_Id = Stock_book.Book_id" +
            " LEFT JOIN Order_book ON Report_book.Order_Id = Order_book.Order_Id", conn);

            string sqlstr = "select Stock_book.book_stock from stock_book WHERE ";
            string sqlstr10 = " select Order_Book.Order_Count from order_book WHERE ";
            string sqlstr15 = " select book_cost from stock_book WHERE ";
            if (!String.IsNullOrEmpty(textBox6.Text))
            {
                char last = sqlstr[sqlstr.Length - 2];
                if (last != 'D' && last != 'E')
                {
                    sqlstr = sqlstr + " AND ";
                    sqlstr10 = sqlstr10 + " AND ";
                    sqlstr15 = sqlstr15 + " AND ";
                }

                sqlstr = sqlstr + " stock_Book.Book_Category LIKE '" + textBox6.Text + "' AND book_status != 'ordered'";
                sqlstr10 = sqlstr10 + " order_Book.Book_Category LIKE '" + textBox6.Text + "'";
                sqlstr15 = sqlstr15 + " stock_Book.Book_Category LIKE '" + textBox6.Text + "'";
            }
            

            SqlCommand comm1 = new SqlCommand(sqlstr, conn);
            List<int> stockCost = new List<int>();
            SqlDataReader reader = comm1.ExecuteReader();
            int sc = 0; 
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        stockCost.Add(reader.GetInt32(0));
                    }

                }
                for (var i = 0; i < stockCost.Count; i++)
                {
                     sc = sc + stockCost[i];
                }
            }

            reader.Close();
            
            SqlCommand comm3 = new SqlCommand(sqlstr10, conn);
            List<Int32> OrderCost = new List<Int32>();
            SqlDataReader reader1 = comm3.ExecuteReader();
            
            int oc = 0;
            if (reader1.HasRows)
            {
                while (reader1.Read())
                {
                    if (reader1.HasRows)
                    {
                        OrderCost.Add(reader1.GetInt32(0));
                    }

                }
                for (var i = 0; i < OrderCost.Count; i++)
                {
                    oc = oc + OrderCost[i];
                }
            }
            reader1.Close();
            SqlCommand comm4 = new SqlCommand(sqlstr15, conn);

            Int32 ordercost = Convert.ToInt32(comm4.ExecuteScalar());
            oc = oc * ordercost;
           


            reader.Close();

            string sqlstr5 = "select book_cost from stock_book WHERE ";
            if (!String.IsNullOrEmpty(textBox6.Text))
            {
                char last = sqlstr5[sqlstr5.Length - 2];
                if (last != 'D' && last != 'E')
                {
                    sqlstr5 = sqlstr5 + " AND ";
                }

                sqlstr5 = sqlstr5 + " stock_Book.Book_Category LIKE '" + textBox6.Text + "'";

            }
            SqlCommand comm2 = new SqlCommand(sqlstr5, conn);
            
            Int32 count = Convert.ToInt32(comm2.ExecuteScalar());
            sc = sc * count;
            MessageBox.Show("Total Stock invest in "+
               textBox6.Text+" is "+  sc.ToString()+" and Total Order invest is "+oc.ToString());







        }

        private void button5_Click(object sender, EventArgs e)
        {

            conn = new SqlConnection(connstring);
            conn.Open();
            string sqlstr = "select report_book.sales_id,  report_book.Order_Id , Report_book.Book_Id,stock_book.book_title,report_book.sales_date " +
            " , Stock_book.Book_Author,Stock_book.Book_category,Order_book.Order_Cost,Stock_book.Book_Cost,Report_Book.book_Count,report_book.sales_profit from" +
             " Report_book" +
            " LEFT JOIN Stock_book ON Report_book.Book_Id = Stock_book.Book_id" +
            " LEFT JOIN Order_book ON Report_book.Order_Id = Order_book.Order_Id WHERE Sales_date BETWEEN '";
            sqlstr = sqlstr + DateTime.Today.ToString("yyyy-MM-dd") + "' AND '" + DateTime.Today.AddYears(3).ToString("yyyy-MM-dd") +
                "' AND Stock_book.Book_category = '" + textBox6.Text + "'";

            SqlDataAdapter da = new SqlDataAdapter(sqlstr, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
