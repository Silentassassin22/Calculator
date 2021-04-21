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
        bool New = false;

        Math math = new Math();
        
        public void SetNumber(string num)
        {
            MainWindow mainWin = Application.Current.Windows
                .Cast<Window>()
                .FirstOrDefault(window => window is MainWindow) as MainWindow;
            
            mainWin.Number.Text = mainWin.Number.Text + num;

            if (operation == 0)
            {
                mainWin.PreviousNumber.Text = mainWin.PreviousNumber.Text + num;
                num1 = num1 + num;
            }
            else
            {
                num2 = num2 + num;
            }
        }

        public void SwitchType()
        {
            MainWindow mainWin = Application.Current.Windows
                .Cast<Window>()
                .FirstOrDefault(window => window is MainWindow) as MainWindow;

            if (operation == 0)
            {
                if(num1 == null || num1 == "" || num1[0] != '-')
                {
                    if (num1 == null)
                    {
                        num1 = "-";
                    }
                    num1 = num1.Insert(0, "-");
                    mainWin.Number.Text = mainWin.Number.Text.Insert(0, "-");
                } else
                {
                    if (num1 == null)
                    {
                        mainWin.Number.Text = mainWin.Number.Text.Insert(0, "-");
                        num1 = "";
                        return;
                    }
                    num1 = num1.Remove(0, 1);
                    mainWin.Number.Text = mainWin.Number.Text.Remove(0, 1);
                }
            }
            else
            {
                if (num2 ==  null || num2 == "" || num2[0] != '-')
                {
                    if(num2 == null)
                    {
                        mainWin.Number.Text = mainWin.Number.Text.Insert(0, "-");
                        num2 = "-";
                        return;
                    }
                    num2 = num2.Insert(0, "-");
                    mainWin.Number.Text = mainWin.Number.Text.Insert(0, "-");
                } else
                {
                    if (num2 == null)
                    { 
                        num2 = "";
                        return;
                    }
                    num2 = num2.Remove(0, 1);
                    mainWin.Number.Text = mainWin.Number.Text.Remove(0, 1);
                }
            }
        }

        public void SetOperation(int op)
        {
            operation = op;

            MainWindow mainWin = Application.Current.Windows
            .Cast<Window>()
            .FirstOrDefault(window => window is MainWindow) as MainWindow;
            mainWin.Number.Text = "";

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

        public void SetDecimal()
        {
            MainWindow mainWin = Application.Current.Windows
            .Cast<Window>()
            .FirstOrDefault(window => window is MainWindow) as MainWindow;


            if (operation == 0)
            {
                mainWin.Number.Text = mainWin.Number.Text + ".";
                num1 = num1 + ".";
            } else
            {
                mainWin.Number.Text = mainWin.Number.Text + ".";
                num2 = num2 + ".";
            }
        }

        public void Backspace()
        {

            if (New) { return; }

            MainWindow mainWin = Application.Current.Windows
            .Cast<Window>()
            .FirstOrDefault(window => window is MainWindow) as MainWindow;

            if (mainWin.Number.Text.Count() == 0)
            {
                return;
            }


            mainWin.Number.Text = mainWin.Number.Text.Remove(mainWin.Number.Text.Count() - 1);

            if (operation == 0)
            {
                num1 = num1.Remove(num1.Count() - 1);
            }
            else
            {
                num2 = num2.Remove(num2.Count() - 1);
            }

        }

        public void Reset(bool resettext)
        {
            MainWindow mainWin = Application.Current.Windows
                .Cast<Window>()
                .FirstOrDefault(window => window is MainWindow) as MainWindow;

            if (resettext)
            {
                mainWin.Number.Text = "";
                operation = 0;
            }
            mainWin.PreviousNumber.Text = CreateEquation();
            num1 = "0";
            num2 = "0";
            New = true;

            mainWin.PreviousNumber.Text = "";

        }

        public (double i, double j) ConvertToDouble(string num1, string num2)
        {
            if (num1[0] == '0')
            {
                num1.Remove(0);
            } else if (num2[0] == '0')
            {
                num2.Remove(0);
            }
            return (Double.Parse(num1), Double.Parse(num2));
        }

        public double? Calc()
        {
            if(num1 == "" || num2 == "" || num2 == null || operation == 0) { return null; }

            var nums = ConvertToDouble(num1, num2);
            double i = nums.i;
            double j = nums.j;


            Reset(false);

            switch (operation)
            {
                case 1:
                    operation = 0;
                    return math.Add(i, j);
                case 2:
                    operation = 0;
                    return math.Subtract(i, j);
                case 3:
                    operation = 0;
                    return math.Multiply(i, j);
                case 4:
                    operation = 0;
                    return math.Divide(i, j);
                default:
                    return 0;
            }
        }
    
        public string CreateEquation()
        {
            string equation = "";

            equation = equation + num1;

            switch (operation)
            {
                case 1:
                    equation = equation + "+";
                    break;
                case 2:
                    equation = equation + "-";
                    break;
                case 3:
                    equation = equation + "*";
                    break;
                case 4:
                    equation = equation + "/";
                    break;
            }

            equation = equation + num2;

            return equation;
        }

        public void TestNumbers()
        {
            System.Windows.MessageBox.Show("First Number: " + num1 + " Second Number: " + num2 + " Operation: " + operation.ToString() + " New: "+New.ToString());
        }



    }
}
