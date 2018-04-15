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

namespace WpfApp3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    { 
        private DigitForm _ExpForm = new DigitForm();
        static string operation;
        static bool isBinaryOperation;

        public MainWindow()
        {
            InitializeComponent();

            _SignForm.ChangeSign(SignForm.SignIndex.Plus);
            EqualForm.ChangeSign(SignForm.SignIndex.Equal);
            _ResultForm.IsReadOnly = true;
            
        }

        private bool CheckText() //Method should check correctness of data in textboxes 
        {
            if (isBinaryOperation)
                if (_FirstForm.Divider != 0 && _SecondForm.Divider != 0) return true;  //Fractions should exist (divider != 0)
                else return false;                                                     //There should be messagebox with error message
            else return false;                                                         //If operations are only for one fraction
        }

        private void Num_Click(object sender, RoutedEventArgs e)
        {
            int curNum = int.Parse((sender as Button).Content.ToString());
            
            IInputElement focusedControl = Keyboard.FocusedElement;

            if (focusedControl is TextBox textBox)
            {
                textBox.Text += curNum.ToString();
                textBox.SelectionStart = textBox.Text.Length;
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            _FirstForm.Reset();
            if(_SecondForm != null)
                _SecondForm.Reset();
            if(_ResultForm != null)
                _ResultForm.Reset();
        }

        private void Sign_Click(object sender, RoutedEventArgs e)
        {
            var operation = (sender as Button).Content.ToString();

            switch (operation)
            {
                case "+":
                    _SignForm.ChangeSign(SignForm.SignIndex.Plus);
                    isBinaryOperation = true;
                    break;
                case "-":
                    _SignForm.ChangeSign(SignForm.SignIndex.Minus);
                    isBinaryOperation = true;
                    break;
                case "*":
                    _SignForm.ChangeSign(SignForm.SignIndex.Multi);
                    isBinaryOperation = true;
                    break;
                case "/":
                    _SignForm.ChangeSign(SignForm.SignIndex.Divide);
                    isBinaryOperation = true;
                    break;
            }
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            Calculator calc = new Calculator();
            if (isBinaryOperation)
            {
                Fraction A = new Fraction(_FirstForm.DivPart, _FirstForm.Denominator, _FirstForm.Divider);
                calc.A = A;
                Fraction B = new Fraction(_SecondForm.DivPart, _SecondForm.Denominator, _SecondForm.Divider);
                calc.B = B;

                switch (operation)
                {
                    case "+":
                        calc.Tool = Calculator.Tools.Plus;
                        break;
                    case "-":
                        calc.Tool = Calculator.Tools.Plus;
                        break;
                    case "/":
                        calc.Tool = Calculator.Tools.Plus;
                        break;
                    case "*":
                        calc.Tool = Calculator.Tools.Plus;
                        break;
                }

                calc.Res = calc.Calculation();

                _ResultForm.TextDivPart.Text = Calculator.AllocateDivPart(calc.Res).ToString();
                _ResultForm.TextNumerator.Text = (calc.Res.Numerator - Calculator.AllocateDivPart(calc.Res) * calc.Res.Divider).ToString();
                _ResultForm.TextDivider.Text = (calc.Res.Divider).ToString();
            }

        }
    }
}
