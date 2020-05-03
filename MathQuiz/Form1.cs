using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Nate_Brown_Math_Quiz : Form
    {

        public Nate_Brown_Math_Quiz()
        {
            InitializeComponent();
        }
        //This will be a Random object called Randomizer
        //It will generate random numbers
      


        Random randomizer = new Random();

        //variables for the addition problem
        int addend1;
        int addend2;

        //Variables to use in the subtraction problem
        int minuend;
        int subtrahend;

        //Variables for multiplication problem
        int multiplicand;
        int multiplier;

        //Variables for division problem
        int dividend;
        int divisor;


        //Variable to keep track of the remaining time
        int timeLeft;

        public void StartTheQuiz()
        {
            //Generate random numbers and store them in variables addend1 and addend2
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //Convert the random numbers to strings and display them in label controls

            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();


            //Set the sum value to initially be 0
            sum.Value = 0;

            //Set up the subtraction problem
            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            difference.Value = 0;

            //Set up the multiplication problem
            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            product.Value = 0;

            //Set up the division problem
            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            divideLeftLabel.Text = dividend.ToString();
            divideRightLabel.Text = divisor.ToString();
            quotient.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                && (minuend - subtrahend == difference.Value)
                && (multiplicand * multiplier == product.Value)
                && (dividend / divisor == quotient.Value))
                return true;
            else
                return false;
        }
       

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(CheckTheAnswer())
            {
                timeLabel.ForeColor = Color.Black;
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                startButton.Enabled = true;
            }

            else if(timeLeft > 0)
            {
                timeLeft--;
                timeLabel.Text = timeLeft + " seconds";
                if(timeLeft <= 5)
                {
                    timeLabel.ForeColor = Color.Red; 
                }
                
            }
           
            else
            {
                timer1.Stop();
                timeLabel.ForeColor = Color.Black;
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry");
                sum.Value = addend1 + addend2;
                difference.Value = minuend - subtrahend;
                product.Value = multiplicand * multiplier;
                quotient.Value = dividend / divisor;
                startButton.Enabled = true;
               

            }
            
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if(answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void hint_Giver(object sender, EventArgs e)
        {



        }

        private void Nate_Brown_Math_Quiz_Load(object sender, EventArgs e)
        {

        }
    }
}
