using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calculator
{
    class Calculate
    {
        string num1;
        string num2;
        int operation = 0;
        bool New = true;

        Math math = new Math();
        
        public void SetNumber(string num)
        {
            MainWindow mainWin = Application.Current.Windows
            .Cast<Window>()
            .FirstOrDefault(window => window is MainWindow) as MainWindow;
            mainWin.Number.Text = mainWin.Number.Text + num;

            if (operation == 0)
            {
                num1 = num1 + num;
            }
            else
            {
                num2 = num2 + num;
            }
        }

        public void SetOperation(int op)
        {
            operation = op;

            MainWindow mainWin = Application.Current.Windows
            .Cast<Window>()
            .FirstOrDefault(window => window is MainWindow) as MainWindow;

            switch (operation)
            {
                case 1:
                    mainWin.Operation.Text = "+";
                    break;
                case 2:
                    mainWin.Operation.Text = "-";
                    break;
                case 3:
                    mainWin.Operation.Text = "*";
                    break;
                case 4:
                    mainWin.Operation.Text = "/";
                    break;

            }
        }

        public void Reset()
        {
            New = true;
        }

        public (double i, double j) Convert(string num1, string num2)
        {

            return (Double.Parse(num1), Double.Parse(num2));
        }

        public double Calc(int op)
        {
            var nums = Convert(num1, num2);
            double i = nums.i;
            double j = nums.j;

            switch (op)
            {

                case 1:
                    return math.Add(i, j);
                case 2:
                    return math.Subtract(i, j);
                case 3:
                    return math.Multiply(i, j);
                case 4:
                    return math.Divide(i, j);
                default:
                    return 0;
            }
        }

        public void TestNumbers()
        {
            System.Windows.MessageBox.Show("First Number: " + num1 + " Second Number: " + num2 + " Operation: " + operation.ToString()); ;
        }



    }
}
