using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Проект1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Создание 1 матрицы
        private void button1_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox1.Text);
            int y = int.Parse(textBox2.Text);

            dataGridView1.RowCount = x;
            dataGridView1.ColumnCount = y;


        }

        // Создание 2 матрицы
        private void button2_Click(object sender, EventArgs e)
        {
            int a = int.Parse(textBox3.Text);
            int b = int.Parse(textBox4.Text);

            dataGridView3.RowCount = a;
            dataGridView3.ColumnCount = b;

        }

        // Очистка всех матриц
        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Rows.Clear();
            dataGridView2.Columns.Clear();
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Clear();
        }

        // Заполнение рандомными числами 1 матрицы
        private void button4_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    dataGridView1.Rows[i].Cells[j].Value = rand.Next(0, 20);

                }
            }
        }

        // Заполнение рандомными числами 2 матрицы
        private void button5_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            for (int i = 0; i < dataGridView3.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView3.Columns.Count; j++)
                {
                    dataGridView3.Rows[i].Cells[j].Value = rand.Next(0, 20);

                }
            }
        }

        // Умножение матриц и вывод ответа
        private void button6_Click(object sender, EventArgs e)
        {

            if (dataGridView1.Rows.Count != dataGridView3.Columns.Count)
            {
                MessageBox.Show("Матрицы нельзя перемножить!");
            }
            else
            {
                int[,] r = new int[dataGridView1.Rows.Count, dataGridView3.Columns.Count];
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView3.Columns.Count; j++)
                    {
                        for (int k = 0; k < dataGridView3.Rows.Count; k++)
                        {
                            r[i, j] += int.Parse(dataGridView1.Rows[i].Cells[k].Value.ToString()) * int.Parse(dataGridView3.Rows[k].Cells[j].Value.ToString());
                        }
                    }
                }

                dataGridView2.RowCount = dataGridView1.Rows.Count;
                dataGridView2.ColumnCount = dataGridView3.Columns.Count;

                for (int i = 0; i < r.GetLength(0); ++i)
                {
                    for (int j = 0; j < r.GetLength(1); ++j)
                    {
                        dataGridView2.Rows[i].Cells[j].Value = r[i, j];
                        dataGridView2.Rows[i].Cells[j].ReadOnly = true;
                        dataGridView2.Columns[i].HeaderText = i.ToString();
                        dataGridView2.Rows[i].HeaderCell.Value = i.ToString();
                    }
                }
            }

           
        }
    }

}

