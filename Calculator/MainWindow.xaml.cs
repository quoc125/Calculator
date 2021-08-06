using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public enum OperatingMode
        {
            Normal,
            Add,
            Subtract,
            Multiply,
            Divide
        }

        protected OperatingMode currentMode;
        protected bool decimalMode = false;
        protected double currentValue;
        protected double displayValue;
        protected double operatingValue;

        public MainWindow()
        {
            InitializeComponent();
            currentMode = OperatingMode.Normal;
            currentValue = 0;
            operatingValue = 0;
            displayValue = 0;
        }

        #region Process Value
        private void Number1_Click(object sender, RoutedEventArgs e)
        {
            processValue(1);
        }

        private void Number2_Click(object sender, RoutedEventArgs e)
        {
            processValue(2);
        }
        private void Number3_Click(object sender, RoutedEventArgs e)
        {
            processValue(3);
        }

        private void Number4_Click(object sender, RoutedEventArgs e)
        {
            processValue(4);
        }

        private void Number5_Click(object sender, RoutedEventArgs e)
        {
            processValue(5);
        }

        private void Number6_Click(object sender, RoutedEventArgs e)
        {
            processValue(6);
        }
        private void Number7_Click(object sender, RoutedEventArgs e)
        {
            processValue(7);
        }

        private void Number8_Click(object sender, RoutedEventArgs e)
        {
            processValue(8);
        }

        private void Number9_Click(object sender, RoutedEventArgs e)
        {
            processValue(9);

        }

        private void Number0_Click(object sender, RoutedEventArgs e)
        {
            processValue(0);
        }
        protected void processValue(int number)
        {
            if (currentMode == OperatingMode.Normal && !decimalMode)
            {
                currentValue *= 10;
                currentValue += number;
                displayValue = currentValue;
                Output.Text = displayValue.ToString();
            }
            else if (currentMode != OperatingMode.Normal && !decimalMode)
            {
                operatingValue *= 10;
                operatingValue += number;
                displayValue = operatingValue;
                Output.Text = displayValue.ToString();
            }
        }
        #endregion

        #region Number Operations
        private void Reciprocal_Click(object sender, RoutedEventArgs e)
        {
            if (currentMode == OperatingMode.Normal)
            {
                currentValue = 1 / currentValue;
                displayValue = currentValue;
                Output.Text = displayValue.ToString();
            }
            else
            {
                operatingValue = 1 / operatingValue;
                displayValue = operatingValue;
                Output.Text = displayValue.ToString();
            }
        }
        private void Square_Click(object sender, RoutedEventArgs e)
        {
            if (currentMode == OperatingMode.Normal)
            {
                currentValue *= currentValue;
                displayValue = currentValue;
                Output.Text = displayValue.ToString();
            }
            else
            {
                operatingValue *= operatingValue;
                displayValue = operatingValue;
                Output.Text = displayValue.ToString();
            }
        }
        private void Square_Root_Click(object sender, RoutedEventArgs e)
        {
            if (currentMode == OperatingMode.Normal)
            {
                if (currentValue > 0)
                {
                    currentValue = Math.Sqrt(currentValue);
                    displayValue = currentValue;
                    Output.Text = displayValue.ToString();
                }
            }
            else
            {
                if (operatingValue > 0)
                {
                    operatingValue = Math.Sqrt(operatingValue);
                    displayValue = operatingValue;
                    Output.Text = displayValue.ToString();
                }
            }
        }
        private void Division_Click(object sender, RoutedEventArgs e)
        {
            ProcessOperation();
            currentMode = OperatingMode.Divide;
        }

        private void Multiply_Click(object sender, RoutedEventArgs e)
        {
            ProcessOperation();
            currentMode = OperatingMode.Multiply; 
        }

        private void Subtract_Click(object sender, RoutedEventArgs e)
        {
            ProcessOperation();
            currentMode = OperatingMode.Subtract;
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            ProcessOperation();
            currentMode = OperatingMode.Add;
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            ProcessOperation();
            currentMode = OperatingMode.Normal;
        }

        private void ProcessOperation()
        {
            if (currentMode != OperatingMode.Normal)
            {
                switch (currentMode)
                {
                    case OperatingMode.Add:
                        {
                            currentValue += operatingValue;
                            break;
                        }
                    case OperatingMode.Subtract:
                        {
                            currentValue -= operatingValue;
                            break;
                        }
                    case OperatingMode.Multiply:
                        {
                            currentValue *= operatingValue;
                            break;
                        }
                    case OperatingMode.Divide:
                        {
                            currentValue /= operatingValue;
                            break;
                        }
                }
                operatingValue = 0;
                displayValue = currentValue;
                Output.Text = displayValue.ToString();
            }
        }
        #endregion

        private void Inverse_Click(object sender, RoutedEventArgs e)
        {
            if (currentMode == OperatingMode.Normal)
            {
                currentValue *= -1;
                displayValue = currentValue;
                Output.Text = displayValue.ToString();
            }
            else
            {
                operatingValue *= -1;
                displayValue = operatingValue;
                Output.Text = displayValue.ToString();
            }
        }

        /// <summary>
        /// Delete the most recent input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Del_Click(object sender, RoutedEventArgs e)
        {
            if (currentMode == OperatingMode.Normal && !decimalMode)
            {
                currentValue /= 10;
                currentValue = (int)currentValue;
                displayValue = currentValue;
                Output.Text = displayValue.ToString();
            }
            if (currentMode != OperatingMode.Normal && !decimalMode)
            {
                operatingValue /= 10;
                operatingValue = (int)operatingValue;
                displayValue = operatingValue;
                Output.Text = displayValue.ToString();
            }
        }


        private void Decimal_Click(object sender, RoutedEventArgs e)
        {

        }


    }
}
