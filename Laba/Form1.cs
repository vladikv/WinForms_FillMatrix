using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Button = System.Windows.Forms.Button;
using TextBox = System.Windows.Forms.TextBox;

namespace Laba
{
    public partial class Form1 : Form
    {
        int[,] matrix = new int[5, 5];
        private TextBox[,] textBoxMatrix;
        public Form1()
        {
            InitializeComponent();
            InitializeMatrixTextBoxes();
        }
        private void InitializeMatrixTextBoxes()
        {
            textBoxMatrix = new TextBox[5, 5]; 

            const int textBoxWidth = 50; // Ширина текстових полів
            const int textBoxHeight = 20; // Висота текстових полів
            const int startX = 30; // Початкова позиція Х
            const int startY = 30; // Початкова позиція Y

            for (int i = 0; i < 5; i++) 
            {
                for (int j = 0; j < 5; j++) 
                {
                    TextBox textBox = new TextBox(); // Створення нового TextBox
                    textBox.Size = new System.Drawing.Size(textBoxWidth, textBoxHeight);
                    textBox.Location = new System.Drawing.Point((int)(startX + j * textBoxWidth * 1.5), (int)(startY + i * textBoxHeight * 1.5));
                    textBoxMatrix[i, j] = textBox;
                    this.Controls.Add(textBox); // Додавання TextBox на форму
                }
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Form form2 = new Form();
            form2.Name = "Form2";
            this.Hide();

            for (int i = 0; i < 5; i++) 
            {
                for (int j = 0; j < 5; j++) 
                {
                    
                    if (int.TryParse(textBoxMatrix[i, j].Text, out int value))
                    {
                        matrix[i, j] = value;
                    }
                    if (i == j || 5 == i + j + 1)
                    {
                        matrix[i, j] = 8;
                    }
                }
            }

            TextBox tBox = new TextBox();
            tBox.Multiline = true;
            tBox.ReadOnly = true;
            tBox.AppendText(MatrixToString(matrix));
            tBox.Size = new System.Drawing.Size(200, 100);
            tBox.Location = new System.Drawing.Point(15, 15);

            form2.Controls.Add(tBox);

            form2.Show();
        }
        static string MatrixToString(int[,] matrix)
        {
            StringBuilder sb = new StringBuilder();

            int rows = matrix.GetLength(0); // Кількість рядків матриці
            int cols = matrix.GetLength(1); // Кількість стовпців матриці

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    sb.Append(matrix[i, j].ToString()); // Додаємо елементи матриці до рядка
                    if (j < cols - 1)
                    {
                        sb.Append("  "); // Додаємо пробіл між елементами в межах одного рядка
                    }
                }
                if (i < rows - 1)
                {
                    sb.AppendLine(); // Додаємо рядок переходу до нового рядка матриці, крім останнього рядка
                }
            }

            return sb.ToString(); // Повертаємо отриманий рядок
        }

        
    }
}