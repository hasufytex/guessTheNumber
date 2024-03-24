using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace guessTheNumber
{
    public partial class Game : Form
    {
        public Game(string difficulty)
        {
            InitializeComponent();

            gameDifficulty = difficulty;

            this.Text = difficulty;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            if (Debugger.IsAttached)
            {
                label4.Visible = true;
            }
        }

        private string gameDifficulty = "";
        private static readonly Dictionary<string, int> difficultyTable = new Dictionary<string, int>
        {
            { "Лесно (1-10)", 10 },
            { "Нормално (1-100)", 100 },
            { "Трудно (1-1000)", 1000 }
        };
        private int randomNumber = -5;
        private int triesCount = 0;

        private void label1_MouseHover(object sender, EventArgs e)
        {
            label2.Cursor = Cursors.Hand;
        }

        private void Start_Click(object sender, EventArgs e)
        {
            triesCount = 0;
            label3.Text = $"Брой опити: {triesCount}";

            Random random = new Random();

            int upperLimit = difficultyTable[gameDifficulty];
            randomNumber = random.Next(1, upperLimit);

            label1.Text = "Генерирано e число.";
            label4.Text = $"Debug: {randomNumber}";
        }

        private void Proveri_Click(object sender, EventArgs e)
        {
            if (randomNumber == -5)
            {
                MessageBox.Show("Не си започнал играта.");
                return;
            }

            if (int.TryParse(textBox1.Text, out int userGuess))
            {
                triesCount++;
                label3.Text = $"Брой опити: {triesCount}";

                label2.Text = $"Последен опит: {userGuess.ToString()}";

                if (userGuess == randomNumber)
                {
                    rezultat.Text = "Поздравления! Уцели числото!";
                }
                else 
                {
                    rezultat.Text = "Грешен отговор. Опитай отново.";
                }
            }
            else
            {
                label2.Text = "Невалидна стойност.";
            }

            textBox1.Text = "";
        }

        private void Game_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            TopMost = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
