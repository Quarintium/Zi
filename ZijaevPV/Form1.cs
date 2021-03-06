﻿using System;
using System.Windows.Forms;
using System.Data.Common;
using Npgsql;
using System.Data;

namespace ZijaevPV
{
    public partial class Form1 : Form
    {
        string connStr = "Server=localhost;Port=5432;User=postgres;Password=Qwertasdfum12;Database=qwertyuio;";
        bool fl = true;
        private NpgsqlDataAdapter da;

        public Form1()
        {
            InitializeComponent();

            //NpgsqlConnection conn = new NpgsqlConnection(connStr);
            //NpgsqlCommand command2;
            ReloadZn();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string q = @"select 0.8 *
(select round((fun('" + uhd_t1_1.Text + "', " + s(numericUpDown1.Value) + ") + fun('" + uhd_t1_2.Text + "', " + s(numericUpDown2.Value) + ") + " +
    "fun('" + k_t1_1.Text + "', " + s(numericUpDown3.Value) + ") + fun('" + k_t1_2.Text + "'," + s(numericUpDown4.Value) + ") + " +
    "fun('" + s_t1_1.Text + "', " + s(numericUpDown5.Value) + ") + fun('" + s_t1_2.Text + "', " + s(numericUpDown6.Value) + @")) / 6.0, 2)) as top1,
0.8 *
(select round((fun('" + comboBox5.Text + "', " + s(numericUpDown12.Value) + ") + fun('" + comboBox6.Text + "', " + s(numericUpDown11.Value) + ") + " +
    "fun('" + comboBox4.Text + "', " + s(numericUpDown10.Value) + ") + fun('" + comboBox3.Text + "'," + s(numericUpDown9.Value) + ") + " +
    "fun('" + comboBox2.Text + "', " + s(numericUpDown8.Value) + @")) / 5.0, 2)) as top2,
0.8 *
(select round((fun('" + comboBox11.Text + "', " + s(numericUpDown18.Value) + ") + fun('" + comboBox12.Text + "', " + s(numericUpDown17.Value) + ") + " +
    "fun('" + comboBox10.Text + "', " + s(numericUpDown16.Value) + ") + fun('" + comboBox8.Text + "'," + s(numericUpDown14.Value) + ") + " +
    "fun('" + comboBox7.Text + "', " + s(numericUpDown13.Value) + @")) / 5.0, 2)) as top3,
0.9 *
(select round((fun('" + comboBox2.Text + "', " + s(numericUpDown24.Value) + ") + fun('" + comboBox16.Text + "', " + s(numericUpDown22.Value) + ") + " +
    "fun('" + comboBox14.Text + "', " + s(numericUpDown21.Value) + ") + fun('" + comboBox13.Text + "'," + s(numericUpDown20.Value) + @")) / 4.0, 2)) as top4,
0.8 *
(select round((fun('" + comboBox24.Text + "', " + s(numericUpDown30.Value) + ") + fun('" + comboBox22.Text + "', " + s(numericUpDown28.Value) + ") + " +
    "fun('" + comboBox21.Text + "', " + s(numericUpDown27.Value) + ") + fun('" + comboBox22.Text + "'," + s(numericUpDown26.Value) + @")) / 4.0, 2)) as top5,
0.6 *
(select round((fun('" + comboBox30.Text + "', " + s(numericUpDown36.Value) + ") + fun('" + comboBox29.Text + "', " + s(numericUpDown35.Value) + ") + " +
    "fun('" + comboBox28.Text + "', " + s(numericUpDown34.Value) + ") + fun('" + comboBox27.Text + "'," + s(numericUpDown33.Value) + ") + " +
    "fun('" + comboBox26.Text + "', " + s(numericUpDown32.Value) + ") + fun('" + comboBox25.Text + "', " + s(numericUpDown31.Value) + @")) / 6.0, 2)) as top6";
            NpgsqlConnection conn = new NpgsqlConnection(connStr);
            NpgsqlCommand command2;
            command2 = new NpgsqlCommand(q, conn);
            conn.Open();
            using (NpgsqlDataReader qqqq = command2.ExecuteReader())
            {
                if (qqqq.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in qqqq)
                    {
                        rez_r1.Text = rez_t1.Text = Convert.ToString(dbDataRecord["top1"]);
                        rez_r2.Text = rez_t2.Text = Convert.ToString(dbDataRecord["top2"]);
                        rez_r3.Text = rez_t3.Text = Convert.ToString(dbDataRecord["top3"]);
                        rez_r4.Text = rez_t4.Text = Convert.ToString(dbDataRecord["top4"]);
                        rez_r5.Text = rez_t5.Text = Convert.ToString(dbDataRecord["top5"]);
                        rez_r6.Text = rez_t6.Text = Convert.ToString(dbDataRecord["top6"]);
                    }
                }
            }
            conn.Close();

            q = @"select 
(select round((get_price('" + uhd_t1_1.Text + "') + get_price('" + uhd_t1_2.Text + "') + " +
                "get_price('" + k_t1_1.Text + "') + get_price('" + k_t1_2.Text + "') + " +
                "get_price('" + s_t1_1.Text + "') + get_price('" + s_t1_2.Text + @"')) , 2)) as top1,

(select round((get_price('" + comboBox5.Text + "') + get_price('" + comboBox6.Text + "') + " +
                "get_price('" + comboBox4.Text + "') + get_price('" + comboBox3.Text + "') + " +
                "get_price('" + comboBox2.Text + @"')), 2)) as top2,

(select round((get_price('" + comboBox11.Text + "') + get_price('" + comboBox12.Text + "') + " +
                "get_price('" + comboBox10.Text + "') + get_price('" + comboBox8.Text + "') + " +
                "get_price('" + comboBox7.Text + @"')), 2)) as top3,

(select round((get_price('" + comboBox2.Text + "') + get_price('" + comboBox16.Text + "') + " +
                "get_price('" + comboBox14.Text + "') + get_price('" + comboBox13.Text + @"')), 2)) as top4,

(select round((get_price('" + comboBox24.Text + "') + get_price('" + comboBox22.Text + "') + " +
                "get_price('" + comboBox21.Text + "') + get_price('" + comboBox22.Text + @"')), 2)) as top5,

(select round((get_price('" + comboBox30.Text + "') + get_price('" + comboBox29.Text + "') + " +
                "get_price('" + comboBox28.Text + "') + get_price('" + comboBox27.Text + "') + " +
                "get_price('" + comboBox26.Text + "') + get_price('" + comboBox25.Text + "')), 2)) as top6";

            command2 = new NpgsqlCommand(q, conn);
            conn.Open();
            using (NpgsqlDataReader qqqq = command2.ExecuteReader())
            {
                if (qqqq.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in qqqq)
                    {
                        price1_L.Text = price1_L1.Text = Convert.ToString(dbDataRecord["top1"]);
                        price2_L.Text = price1_L2.Text = Convert.ToString(dbDataRecord["top2"]);
                        price3_L.Text = price1_L3.Text = Convert.ToString(dbDataRecord["top3"]);
                        price4_L.Text = price1_L4.Text = Convert.ToString(dbDataRecord["top4"]);
                        price5_L.Text = price1_L5.Text = Convert.ToString(dbDataRecord["top5"]);
                        price6_L.Text = price1_L6.Text = Convert.ToString(dbDataRecord["top6"]);
                    }
                }
            }
            conn.Close();
        }

        string s(decimal f)
        {
            string dd = "", buf = "";
            buf = f.ToString();
            for (int i =0; i<buf.Length;i++)
            {
                if (buf[i] == ',')
                    dd +='.';
                else
                    dd += buf[i];
            }

            return dd; 
        }

        private void label9_Click(object sender, EventArgs e)
        {
        }

        // Добавление дисковых массивов в базу данных
        private void addUXD_B_Click(object sender, EventArgs e)
        {
            // Инициализация формы добавления дисковых массивов в базу данных
            addElement f = new addElement("дисковой массив");
            f.ShowDialog();
            ReloadZn();
        }

        private void ReloadZn()
        {
            string q = "select (select count(*) from elements_storage where type_of_e = 'дисковой массив') as uhd, ";
            q += "(select count(*) from elements_storage where type_of_e = 'коммутатор') as komm, ";
            q += "(select count(*) from elements_storage where type_of_e = 'сервер SAN') as serv, ";
            q += "(select count(*) from vulnerability) as u, ";
            q += "(select count(*) from threats) as ugr ";
            NpgsqlConnection conn = new NpgsqlConnection(connStr); ;
            NpgsqlCommand command2 = new NpgsqlCommand(q, conn);
            conn.Open();
            using (NpgsqlDataReader qqqq = command2.ExecuteReader())
            {
                if (qqqq.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in qqqq)
                    {
                        countUHD_L.Text = Convert.ToString(dbDataRecord["uhd"]);
                        countComm_L.Text = Convert.ToString(dbDataRecord["komm"]);
                        countServer_L.Text = Convert.ToString(dbDataRecord["serv"]);
                        countU_L.Text = Convert.ToString(dbDataRecord["u"]);
                        countUgr_L.Text = Convert.ToString(dbDataRecord["ugr"]);
                    }
                }
            }
            conn.Close();


            comboBox2.Items.Clear();
            comboBox8.Items.Clear();
            comboBox7.Items.Clear();
            comboBox14.Items.Clear();
            comboBox13.Items.Clear();
            comboBox20.Items.Clear();
            comboBox26.Items.Clear();
            comboBox25.Items.Clear();
            uhd_t1_1.Items.Clear();
            uhd_t1_2.Items.Clear();
            comboBox5.Items.Clear();
            comboBox6.Items.Clear();
            comboBox11.Items.Clear();
            comboBox12.Items.Clear();
            comboBox18.Items.Clear();
            comboBox24.Items.Clear();
            comboBox30.Items.Clear();
            comboBox29.Items.Clear();
            k_t1_1.Items.Clear();
            k_t1_2.Items.Clear();
            comboBox4.Items.Clear();
            comboBox3.Items.Clear();
            comboBox10.Items.Clear();
            comboBox16.Items.Clear();
            comboBox15.Items.Clear();
            comboBox22.Items.Clear();
            comboBox21.Items.Clear();
            comboBox28.Items.Clear();
            comboBox27.Items.Clear();

            // Возможно где-то тут закралась ошикба
            q = "select * from elements_storage where type_of_e = 'дисковой массив'";
            command2 = new NpgsqlCommand(q, conn);
            conn.Open();
            using (NpgsqlDataReader qqqq = command2.ExecuteReader())
            {
                if (qqqq.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in qqqq)
                    {
                        uhd_t1_1.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        uhd_t1_2.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox5.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox6.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox11.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox12.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox18.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox24.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox30.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox29.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        if(fl)
                        {
                            uhd_t1_1.SelectedIndex = 0;
                            uhd_t1_2.SelectedIndex = 0;
                            comboBox5.SelectedIndex = 0;
                            comboBox6.SelectedIndex = 0;
                            comboBox11.SelectedIndex = 0;
                            comboBox12.SelectedIndex = 0;
                            comboBox18.SelectedIndex = 0;
                            comboBox24.SelectedIndex = 0;
                            comboBox30.SelectedIndex = 0;
                            comboBox29.SelectedIndex = 0;
                        }
                    }
                }
            }
            conn.Close();

            q = "select * from elements_storage where type_of_e = 'коммутатор'";
            command2 = new NpgsqlCommand(q, conn);
            conn.Open();
            using (NpgsqlDataReader qqqq = command2.ExecuteReader())
            {
                if (qqqq.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in qqqq)
                    {
                        k_t1_1.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        k_t1_2.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox4.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox3.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox10.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox16.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox15.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox22.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox21.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox28.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox27.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        if (fl)
                        {
                            k_t1_1.SelectedIndex = 0;
                            k_t1_2.SelectedIndex = 0;
                            comboBox4.SelectedIndex = 0;
                            comboBox3.SelectedIndex = 0;
                            comboBox10.SelectedIndex = 0;
                            comboBox16.SelectedIndex = 0;
                            comboBox15.SelectedIndex = 0;
                            comboBox22.SelectedIndex = 0;
                            comboBox21.SelectedIndex = 0;
                            comboBox28.SelectedIndex = 0;
                            comboBox27.SelectedIndex = 0;
                        }
                    }
                }
            }
            conn.Close();
            q = "select * from elements_storage where type_of_e = 'сервер SAN'";
            command2 = new NpgsqlCommand(q, conn);
            conn.Open();
            using (NpgsqlDataReader qqqq = command2.ExecuteReader())
            {
                if (qqqq.HasRows)
                {
                    foreach (DbDataRecord dbDataRecord in qqqq)
                    {
                        s_t1_1.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        s_t1_2.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        s_t1_1.SelectedIndex = 0;
                        s_t1_2.SelectedIndex = 0;

                        comboBox2.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox8.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox7.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox14.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox13.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox20.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox26.Items.Add(Convert.ToString(dbDataRecord["name_e"]));
                        comboBox25.Items.Add(Convert.ToString(dbDataRecord["name_e"]));


                        if (fl)
                        {
                            comboBox2.SelectedIndex = 0;
                            comboBox8.SelectedIndex = 0;
                            comboBox7.SelectedIndex = 0;
                            comboBox14.SelectedIndex = 0;
                            comboBox13.SelectedIndex = 0;
                            comboBox20.SelectedIndex = 0;
                            comboBox26.SelectedIndex = 0;
                            comboBox25.SelectedIndex = 0;
                        }
                    }
                }
            }
            conn.Close();

            fl = false;
            /*
             * 
(select round((get_price('" + uhd_t1_1.Text + "') + get_price('" + uhd_t1_2.Text + "') + " +
                "get_price('" + k_t1_1.Text + "') + get_price('" + k_t1_2.Text + "') + " +
                "get_price('" + s_t1_1.Text + "') + get_price('" + s_t1_2.Text + @"')) , 2)) as top1,
              
             */
            // Обновление списка с данными о топологии
            q = @"select  name_e, type_of_e, cost_e,  name_t, probability_of_threat, name_v, cvss_v3_rating
from elements_storage, threats, v_t_direction_threat, e_v_whose_vulnerability, vulnerability
where vulnerability.number_v = e_v_whose_vulnerability.number_v
	and elements_storage.number_e = e_v_whose_vulnerability.number_e	
	and threats.number_t = v_t_direction_threat.number_t
	and vulnerability.number_v = v_t_direction_threat.number_v
	and (name_e = '" + uhd_t1_1.Text + "' or name_e = '" + uhd_t1_2.Text + "'"+ 
    "or name_e = '" + k_t1_1.Text + "' or name_e = '" + k_t1_2.Text + "' " +
    "or name_e = '" + s_t1_1.Text + "' or name_e = '" + s_t1_2.Text + @"')
    order by name_e, type_of_e";

            da = new NpgsqlDataAdapter(q, conn);
            dsZ.Reset();
            da.Fill(dsZ);
            dtZ = dsZ.Tables[0];
            dataGridView1.DataSource = dtZ;
        }


        private DataSet dsZ = new DataSet();
        private DataTable dtZ = new DataTable();
        private void addKomm_B_Click(object sender, EventArgs e)
        {
            addElement f = new addElement("коммутатор");
            f.ShowDialog();
            ReloadZn();
        }

        private void addServer_B_Click(object sender, EventArgs e)
        {
            addElement f = new addElement("сервер SAN");
            f.ShowDialog();
            ReloadZn();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            addU f = new addU();
            f.ShowDialog();
            ReloadZn();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            addUgr f = new addUgr();
            f.ShowDialog();
            ReloadZn();
        }
    }
}


/*
 select  name_e, (sum( probability_of_threat * cvss_v3_rating)) as rez 
from elements_storage, threats, v_t_direction_threat, e_v_whose_vulnerability, vulnerability
where vulnerability.number_v = e_v_whose_vulnerability.number_v
	and elements_storage.number_e = e_v_whose_vulnerability.number_e	
	and threats.number_t = v_t_direction_threat.number_t
	and vulnerability.number_v = v_t_direction_threat.number_v
	and name_e = 'HP 1300'
	group by name_e 
     
     */
