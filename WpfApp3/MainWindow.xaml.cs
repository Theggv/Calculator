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
        private bool _IsExp = false;
        private bool _IsChange = false;
        private bool _IsRed = false;
        static Calculator calc = new Calculator();

        public MainWindow()
        {
            InitializeComponent();

            _SignForm.ChangeSign(SignForm.SignIndex.Plus);
            EqualForm.ChangeSign(SignForm.SignIndex.Equal);
            isBinaryOperation = true;
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

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Remove(_SecondForm);
            isBinaryOperation = false;
            _IsRed = true;
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Remove(_SecondForm);
            isBinaryOperation = false;
            _IsChange = true;

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

        }
        private void Exp_Click(object sender, RoutedEventArgs e)
        {
            if (!_IsExp)
            {
                isBinaryOperation = false;
                _ExpForm = new DigitForm();

                MainGrid.Children.Remove(_SecondForm);
                MainGrid.Children.Add(_ExpForm);

                Grid.SetRow(_ExpForm, 1);
                Grid.SetColumn(_ExpForm, 4);

                _SignForm.ChangeSign(SignForm.SignIndex.Exp);
                _IsExp = true;
            }
        }

        private void Equal_Click_1(object sender, RoutedEventArgs e)
        {
            if (isBinaryOperation)
            {
                Fraction A = new Fraction(_FirstForm.DivPart, _FirstForm.Divider, _FirstForm.Denominator);
                calc.A = A;
                Fraction B = new Fraction(_SecondForm.DivPart, _SecondForm.Divider, _SecondForm.Denominator);
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

                if (_IsExp) { calc.Tool = Calculator.Tools.Exp; calc.Exp = _ExpForm.Digit; }
                if (_IsChange) { calc.Tool = Calculator.Tools.Change; }
                if (_IsRed) { calc.Tool = Calculator.Tools.Red; }
                calc.Res = calc.Calculation();

                _ResultForm.RewriteResult(Calculator.AllocateDivPart(calc.Res), 
                    calc.Res.Numerator - Calculator.AllocateDivPart(calc.Res)*calc.Res.Divider, 
                    calc.Res.Divider );
            }
        }
    }
}
