using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Shapes;

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Calculate Calculate = new Calculate();
        public MainWindow()
        {
            InitializeComponent();
        }

        public void SetNumber(string number)
        {
            Number.Text = number;
        }


        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            Calculate.Reset(true);
        }

        private void Divide_Click(object sender, RoutedEventArgs e)
        {
            Calculate.SetOperation(4);
        }

        private void Num7_Click(object sender, RoutedEventArgs e)
        {
            Calculate.SetNumber("7");
        }

        private void Num8_Click(object sender, RoutedEventArgs e)
        {
            Calculate.SetNumber("8");
        }

        private void Num9_Click(object sender, RoutedEventArgs e)
        {
            Calculate.SetNumber("9");
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            Calculate.SetOperation(3);
        }

        private void Num4_Click(object sender, RoutedEventArgs e)
        {
            Calculate.SetNumber("4");
        }

        private void Num5_Click(object sender, RoutedEventArgs e)
        {
            Calculate.SetNumber("5");
        }

        private void Num6_Click(object sender, RoutedEventArgs e)
        {
            Calculate.SetNumber("6");
        }

        private void Subtract_Click(object sender, RoutedEventArgs e)
        {
            Calculate.SetOperation(2);
        }

        private void Num1_Click(object sender, RoutedEventArgs e)
        {
            Calculate.SetNumber("1");
        }

        private void Num2_Click(object sender, RoutedEventArgs e)
        {
            Calculate.SetNumber("2");
        }

        private void Num3_Click(object sender, RoutedEventArgs e)
        {
            Calculate.SetNumber("3");
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Calculate.SetOperation(1);
        }

        private void Switch_Click(object sender, RoutedEventArgs e)
        {
            Calculate.SwitchType();
        }

        private void Num0_Click(object sender, RoutedEventArgs e)
        {
            Calculate.SetNumber("0");
        }

        private void Decimal_Click(object sender, RoutedEventArgs e)
        {
            Calculate.SetDecimal();
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            var text = Calculate.Calc();

            if (text != null)
            {
                Number.Text = text.ToString();
            }

        }

        private void Backspace_Click(object sender, RoutedEventArgs e)
        {
            Calculate.Backspace();
        }

        private void Operation_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Calculate.TestNumbers();
        }
    }
}
