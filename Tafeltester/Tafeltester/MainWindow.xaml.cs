using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;

namespace Tafeltester
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Random rnd = new Random();
        int number1,
        number2,
        op,
        numberOfQuestions = 1,
        number3,
        questionsCorrect = 0,
        dif;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void nameBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void hard(object sender, RoutedEventArgs e)
        {
            difficulty.Visibility = Visibility.Hidden;
            vraag.Visibility = Visibility.Visible;

            dif = 3;

            Generate();
        }

        private void medium(object sender, RoutedEventArgs e)
        {
            difficulty.Visibility = Visibility.Hidden;
            vraag.Visibility = Visibility.Visible;

            dif = 3;

            Generate();
        }

        private void easy(object sender, RoutedEventArgs e)
        {
            difficulty.Visibility = Visibility.Hidden;
            vraag.Visibility = Visibility.Visible;

            dif = 1;

            Generate();


        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            noNameError.Visibility = Visibility.Hidden;

            if (string.IsNullOrEmpty(nameBox.Text))
            {
                noNameError.Visibility = Visibility.Visible;
            }
            else
            {
                startScreen.Visibility = Visibility.Hidden;
                difficulty.Visibility = Visibility.Visible;
            }

            string name = nameBox.Text;
            namefield.Text = "Howdy, " + name;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

       



        private void Generate()
        {
            number1 = rnd.Next(1, 20);
            number2 = rnd.Next(1, 20);
            op = rnd.Next(0, dif + 1);
            progress.Text = numberOfQuestions + "/10";

            if (op == 0)
            {
                string sum = number1 + " + " + number2 + " =";
                number3 = number1 + number2;
                tbsum.Text = sum;

            }
            else if (op == 1)
            {
                string sum = (number1 + number2) + " - " + number2 + " =";
                number3 = number1;
                tbsum.Text = sum;
            }
            else if (op == 2)
            {
                string sum = number1 + " x " + number2 + " =";
                number3 = number1 * number2;
                tbsum.Text = sum;
            }
            else if (op == 3)
            {
                string sum = (number1 * number2) + " : " + number2 + " =";
                number3 = number1;
                tbsum.Text = sum;
            }
            
        }



        private void Checkbtn(object sender, RoutedEventArgs e)
        {
            if (numberOfQuestions < 10)
            {
                string input_1 = awnsertb.Text;
                if (input_1.All(char.IsDigit) && input_1.Length > 0)
                {
                    if (Convert.ToInt32(input_1) == number3)
                    {
                        questionsCorrect++;
                        numberOfQuestions++;
                        SoundPlayer correct = new SoundPlayer(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"media\correct.wav"));
                        correct.Play();
                        MessageBox.Show("Dat is GOED (~O 3 O)👌");
                        Generate();
                    }
                    else
                    {
                        numberOfQuestions++;
                        SoundPlayer incorrect = new SoundPlayer(Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName, @"media\incorrect.wav"));
                        incorrect.Play();
                        MessageBox.Show("Dat is fout ( ˘︹˘ )");
                        Generate();
                    }

                    awnsertb.Text = "";

                }

            }
            else
            {
                MessageBox.Show("Je hebt " + questionsCorrect + " van de 10 correct.");
                questionsCorrect = 0;
                numberOfQuestions = 1;

                difficulty.Visibility = Visibility.Visible;
                vraag.Visibility = Visibility.Hidden;
            }
        }
    }
}
