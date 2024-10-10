using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int n;
            if (!int.TryParse(txtSize.Text, out n) || n <= 0)
            {
                MessageBox.Show("Введите корректное значение размерности матрицы (n > 0).");
                return;
            }

            double[,] matrix = new double[n, n];

            // Считывание данных из DataGridView
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        if (!double.TryParse(dataGridView1.Rows[i].Cells[j].Value.ToString(), out matrix[i, j]))
                        {
                            MessageBox.Show("Введите корректные вещественные значения в матрице.");
                            return;
                        }
                    }
                }
            }

            // Вычисление сумм главной и побочной диагоналей
            double sumMainDiagonal = 0;
            double sumSecondaryDiagonal = 0;

            for (int i = 0; i < n; i++)
            {
                sumMainDiagonal += matrix[i, i];           // Элементы главной диагонали
                sumSecondaryDiagonal += matrix[i, n - i - 1]; // Элементы побочной диагонали
            }

            // Вывод результатов
            lblResult.Text = $"Сумма главной диагонали: {sumMainDiagonal}\n" +
                             $"Сумма побочной диагонали: {sumSecondaryDiagonal}\n";

            if (sumMainDiagonal > sumSecondaryDiagonal)
                lblResult.Text += "Сумма главной диагонали больше.";
            else if (sumMainDiagonal < sumSecondaryDiagonal)
                lblResult.Text += "Сумма побочной диагонали больше.";
            else
                lblResult.Text += "Суммы равны.";
        }

        private void txtSize_TextChanged(object sender, EventArgs e)
        {
            int n;
            if (int.TryParse(txtSize.Text, out n) && n > 0)
            {
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();

                // Создание столбцов и строк в DataGridView
                for (int i = 0; i < n; i++)
                {
                    dataGridView1.Columns.Add($"Column{i}", $"Column {i + 1}");
                }

                for (int i = 0; i < n; i++)
                {
                    dataGridView1.Rows.Add(new object[n]);
                }
            }
        }

        private void lblResult_Click(object sender, EventArgs e)
        {

        }
    }
}
    

