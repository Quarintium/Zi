using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using Npgsql;

namespace ZijaevPV
{
    public partial class addUgr : Form
    {
        string connStr = "Server=localhost;Port=5432;User=postgres;Password=Qwertasdfum12;Database=qwertyuio;";
        public addUgr()
        {
            InitializeComponent();
            checkedListBox1.Items.Clear();
            string q = "SELECT name_v FROM public.vulnerability where object_v = '" + comboBox1.Text + "'";
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            NpgsqlCommand SqlCommand = new NpgsqlCommand(q, conn);
            conn.Open();
            using (NpgsqlDataReader qqqq = SqlCommand.ExecuteReader())
            {
                //if (qqq.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in qqqq)
                    {
                        checkedListBox1.Items.Add(Convert.ToString(dbDataRecord["name_v"]));
                    }
                }
            }
            conn.Close();
        }

        private void add_B_Click(object sender, EventArgs e)
        {
            string q = "INSERT INTO public.threats(name_t, source_of_threats, impact_object, probability_of_threat, description_t, number_t) " +
                "VALUES ('" + name_TB.Text + "', '" + cost_TB.Text + "', '" + comboBox1.Text + "', " + numericUpDown12.Value.ToString().Replace(",",".") + ", '" + textBox1.Text + "',  (select max(number_t) + 1 from threats));";
            ;
            for (int i = 0; i < checkedListBox1.SelectedItems.Count; i++)
            {
                q += "INSERT INTO public.v_t_direction_threat (number_v, number_t) VALUES (" +
                    "(select number_v from vulnerability where name_v = '" + checkedListBox1.SelectedItems[i].ToString() + "'), " +
                    "(select max(number_t) + 1 from threats));";
            }
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            NpgsqlCommand command2;
            command2 = new NpgsqlCommand(q, conn);
            conn.Open();
            // Выполнение запроса
            command2.ExecuteNonQuery();
            conn.Close();

            Close();
        }

        private void close_B_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkedListBox1.Items.Clear();
            string q = "SELECT name_v FROM public.vulnerability where object_v = '" + comboBox1.Text + "'";
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            NpgsqlCommand SqlCommand = new NpgsqlCommand(q, conn);
            conn.Open();
            using (NpgsqlDataReader qqqq = SqlCommand.ExecuteReader())
            {
                //if (qqq.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in qqqq)
                    {
                        checkedListBox1.Items.Add(Convert.ToString(dbDataRecord["name_v"]));
                    }
                }
            }
            conn.Close();
        }
    }
}
