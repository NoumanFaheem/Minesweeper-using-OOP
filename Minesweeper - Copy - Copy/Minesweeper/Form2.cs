using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Form2 : Form
    {
        private const string Bomb = "\U0001F4A3";
        string[ , ] buttonname;
        string[] btnName1D = new string[64];

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            buttonname = new string[ 8 , 8 ];
            var random = new Random();
            int bombnumber = 10;

            while (bombnumber > 0)

            {

                for (int i = 1; i < 9; i++)
                {


                    for (int j = 1; j < 9; j++)
                    {
                        Button btnName = Controls.Find($"btn{i}{j}", true).FirstOrDefault() as Button;
                        var randomBool = random.Next(6);

                        if (randomBool == 0 && btnName.Text != Bomb)
                        {
                            btnName.ForeColor = System.Drawing.Color.FromArgb(1,224,224,224);
                            btnName.Text = Bomb;
                            bombnumber--;

                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int tempvar, i, j;
            string a;
            a = string.Join("", btn.Name.ToCharArray().Where(Char.IsDigit));
            tempvar = Int32.Parse(a);
            i = tempvar / 10;
            j = tempvar % 10;

            int mines = 0;
            Button btnName = Controls.Find($"btn{i}{j}", true).FirstOrDefault() as Button;
            Button btnNameEast = Controls.Find($"btn{i}{j + 1}", true).FirstOrDefault() as Button;
            Button btnNameSouthEast = Controls.Find($"btn{i + 1}{j + 1}", true).FirstOrDefault() as Button;
            Button btnNameSouth = Controls.Find($"btn{i + 1}{j}", true).FirstOrDefault() as Button;
            Button btnNameSouthWest = Controls.Find($"btn{i + 1}{j - 1}", true).FirstOrDefault() as Button;
            Button btnNameWest = Controls.Find($"btn{i}{j - 1}", true).FirstOrDefault() as Button;
            Button btnNameNorthWest = Controls.Find($"btn{i - 1}{j - 1}", true).FirstOrDefault() as Button;
            Button btnNameNorth = Controls.Find($"btn{i - 1}{j}", true).FirstOrDefault() as Button;
            Button btnNameNorthEast = Controls.Find($"btn{i - 1}{j + 1}", true).FirstOrDefault() as Button;

            if (btnName.Text == Bomb)
            {
                btnName.ForeColor = System.Drawing.Color.FromArgb(1, 0, 0, 0);


                for (int k = 1; k < 9; k++)
                {

                    for (int l = 1; l < 9; l++)
                    {
                        Button btnName1 = Controls.Find($"btn{k}{l}", true).FirstOrDefault() as Button;

                        if (btnName1.Text == Bomb)
                        {
                            btnName1.ForeColor = System.Drawing.Color.FromArgb(1, 0, 0, 0);
                        }

                        if (btnName1.Text != Bomb) 
                        {
                           btnName1.Text = Convert.ToString(adjacentMinesChecker(btnName1));
                        }

                    }
                }

                Form3 f3 = new Form3();
                f3.ShowDialog();
                this.Close();

            }

            else
            {

                if (btnNameEast.Text == Bomb && btnNameEast.Text != "outofbounds")
                {
                    mines++;
                }

                if (btnNameSouthEast.Text == Bomb && btnNameSouthEast.Text != "outofbounds")
                {
                    mines++;
                }

                if (btnNameSouth.Text == Bomb && btnNameSouth.Text != "outofbounds")
                {
                    mines++;
                }

                if (btnNameSouthWest.Text == Bomb && btnNameSouthWest.Text != "outofbounds")
                {
                    mines++;
                }

                if (btnNameWest.Text == Bomb && btnNameWest.Text != "outofbounds")
                {
                    mines++;
                }

                if (btnNameNorthWest.Text == Bomb && btnNameNorthWest.Text != "outofbounds")
                {
                    mines++;
                }

                if (btnNameNorth.Text == Bomb && btnNameNorth.Text != "outofbounds")
                {
                    mines++;
                }

                if (btnNameNorthEast.Text == Bomb && btnNameNorthEast.Text != "outofbounds")
                {
                    mines++;
                }

                btnName.Text = Convert.ToString(mines);
            }
        }

        public int adjacentMinesChecker (Button btnName1)

        {
            Button btn = btnName1;
            int tempvar, i, j;
            string a;
            a = string.Join("", btn.Name.ToCharArray().Where(Char.IsDigit));
            tempvar = Int32.Parse(a);
            i = tempvar / 10;
            j = tempvar % 10;

            int mines = 0;
            Button btnName = Controls.Find($"btn{i}{j}", true).FirstOrDefault() as Button;
            Button btnNameEast = Controls.Find($"btn{i}{j + 1}", true).FirstOrDefault() as Button;
            Button btnNameSouthEast = Controls.Find($"btn{i + 1}{j + 1}", true).FirstOrDefault() as Button;
            Button btnNameSouth = Controls.Find($"btn{i + 1}{j}", true).FirstOrDefault() as Button;
            Button btnNameSouthWest = Controls.Find($"btn{i + 1}{j - 1}", true).FirstOrDefault() as Button;
            Button btnNameWest = Controls.Find($"btn{i}{j - 1}", true).FirstOrDefault() as Button;
            Button btnNameNorthWest = Controls.Find($"btn{i - 1}{j - 1}", true).FirstOrDefault() as Button;
            Button btnNameNorth = Controls.Find($"btn{i - 1}{j}", true).FirstOrDefault() as Button;
            Button btnNameNorthEast = Controls.Find($"btn{i - 1}{j + 1}", true).FirstOrDefault() as Button;

            if (btnNameEast.Text == Bomb && btnNameEast.Text != "outofbounds")
            {
                mines++;
            }

            if (btnNameSouthEast.Text == Bomb && btnNameSouthEast.Text != "outofbounds")
            {
                mines++;
            }

            if (btnNameSouth.Text == Bomb && btnNameSouth.Text != "outofbounds")
            {
                mines++;
            }

            if (btnNameSouthWest.Text == Bomb && btnNameSouthWest.Text != "outofbounds")
            {
                mines++;
            }

            if (btnNameWest.Text == Bomb && btnNameWest.Text != "outofbounds")
            {
                mines++;
            }

            if (btnNameNorthWest.Text == Bomb && btnNameNorthWest.Text != "outofbounds")
            {
                mines++;
            }

            if (btnNameNorth.Text == Bomb && btnNameNorth.Text != "outofbounds")
            {
                mines++;
            }

            if (btnNameNorthEast.Text == Bomb && btnNameNorthEast.Text != "outofbounds")
            {
                mines++;
            }

            return mines;
        }
    }
}
