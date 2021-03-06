﻿using System;
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

        private bool _IsExp = false;
        private bool _IsFirstFormFocused;
        private bool _IsSecondFormFocused;


        private static Calculator calc = new Calculator();

        public DigitForm ExpForm { get => _ExpForm; }

        public MainWindow()
        {
            InitializeComponent();

            _SignForm.ChangeSign(SignForm.SignIndex.Plus);
            EqualForm.ChangeSign(SignForm.SignIndex.Equal);
            _ResultForm.IsReadOnly = true;
        }

        private void Num_Click(object sender, RoutedEventArgs e)
        {
            int curNum = int.Parse((sender as Button).Content.ToString());
            TextBox curTextBox = null;
            IInputElement focusedControl = Keyboard.FocusedElement;

            if (focusedControl is TextBox textBox)
            {
                textBox.Text += curNum.ToString();
                textBox.SelectionStart = textBox.Text.Length;
            }

            try
            {
                curTextBox = (TextBox)focusedControl;
            }
            catch (Exception) { curTextBox = null; }

            if (_IsFirstFormFocused && curTextBox != null)
            {
                if (curTextBox.Text == "-")
                {
                    if (curTextBox.Name == "TextDivPart")
                        _FirstForm.Negative = true;
                    return;
                }

                if (curTextBox.Text == "")
                {
                    if (curTextBox.Name == "TextDivPart")
                    {
                        _FirstForm.DivPart = 0;
                        _FirstForm.Negative = false;
                    }
                    else if (curTextBox.Name == "TextNumerator")
                        _FirstForm.Numerator = 0;
                    else if (curTextBox.Name == "TextDivider")
                        _FirstForm.Divider = 0;
                }
                else
                {
                    if (curTextBox.Name == "TextDivPart")
                    {
                        _FirstForm.DivPart = int.Parse(curTextBox.Text);
                        _FirstForm.Negative = false;
                    }
                    else if (curTextBox.Name == "TextNumerator")
                        _FirstForm.Numerator = int.Parse(curTextBox.Text);
                    else if (curTextBox.Name == "TextDivider")
                        _FirstForm.Divider = int.Parse(curTextBox.Text);
                }
            }

            if (_IsSecondFormFocused && curTextBox != null)
            {
                if (curTextBox.Text == "-")
                {
                    if (curTextBox.Name == "TextDivPart")
                        _SecondForm.Negative = true;
                    return;
                }

                if (curTextBox.Text == "")
                {
                    if (curTextBox.Name == "TextDivPart")
                    {
                        _SecondForm.DivPart = 0;
                        _SecondForm.Negative = false;
                    }
                    else if (curTextBox.Name == "TextNumerator")
                        _SecondForm.Numerator = 0;
                    else if (curTextBox.Name == "TextDivider")
                        _SecondForm.Divider = 0;
                }
                else
                {
                    if (curTextBox.Name == "TextDivPart")
                    {
                        _SecondForm.DivPart = int.Parse(curTextBox.Text);
                        _SecondForm.Negative = false;
                    }
                    else if (curTextBox.Name == "TextNumerator")
                        _SecondForm.Numerator = int.Parse(curTextBox.Text);
                    else if (curTextBox.Name == "TextDivider")
                        _SecondForm.Divider = int.Parse(curTextBox.Text);
                }

            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            _FirstForm.Reset();
            if (_SecondForm != null)
                _SecondForm.Reset();
            if (_ResultForm != null)
                _ResultForm.Reset();
        }

        private void Red_Click(object sender, RoutedEventArgs e)
        {
            if (_IsFirstFormFocused)
            {
                Fraction A = new Fraction(_FirstForm.GetFullNumerator, _FirstForm.Divider);
                A = Calculator.Reduction(A);
                _FirstForm.RewriteResult(A.Numerator, A.Divider);
            }
            if (_IsSecondFormFocused)
            {
                Fraction A = new Fraction(_SecondForm.GetFullNumerator, _SecondForm.Divider);
                A = Calculator.Reduction(A);
                _SecondForm.RewriteResult(A.Numerator, A.Divider);
            }
            _IsExp = false;
        }

        private void Change_Click(object sender, RoutedEventArgs e)
        {
            if (_IsFirstFormFocused)
            {
                _FirstForm.RewriteResult(_FirstForm.Divider, _FirstForm.GetFullNumerator);
            }

            if (_IsSecondFormFocused)
            {
                _SecondForm.RewriteResult(_SecondForm.Divider, _SecondForm.GetFullNumerator);
            }
            _IsExp = true;
        }

        public void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Calculator.CancelOperation(this);
        }

        private void Sign_Click(object sender, RoutedEventArgs e)
        {
            var operation = (sender as Button).Content.ToString();

            Remove_ExpForm();

            switch (operation)
            {
                case "+":
                    _SignForm.ChangeSign(SignForm.SignIndex.Plus);
                    Calculator.Tool = Calculator.Tools.Plus;
                    break;
                case "-":
                    _SignForm.ChangeSign(SignForm.SignIndex.Minus);
                    Calculator.Tool = Calculator.Tools.Minus;
                    break;
                case "*":
                    _SignForm.ChangeSign(SignForm.SignIndex.Multi);
                    Calculator.Tool = Calculator.Tools.Multi;
                    break;
                case "/":
                    _SignForm.ChangeSign(SignForm.SignIndex.Divide);
                    Calculator.Tool = Calculator.Tools.Divide;
                    break;
            }

            if (!_ResultForm.IsEmpty)
            {
                long num;
                if (_ResultForm.DivPart < 0)
                    num = _ResultForm.DivPart * _ResultForm.Divider - _ResultForm.Numerator;
                else
                    num = _ResultForm.DivPart * _ResultForm.Divider + _ResultForm.Numerator;

                _FirstForm.RewriteResult(num, _ResultForm.Divider);
                _ResultForm.Reset();
            }
        }

        private void Exp_Click(object sender, RoutedEventArgs e)
        {
            Add_ExpForm();
            _IsExp = true;
        }

        public void Add_ExpForm()
        {
            if (!_IsExp)
            {
                _ExpForm = new DigitForm();

                MainGrid.Children.Remove(_SecondForm);
                MainGrid.Children.Add(_ExpForm);

                Grid.SetRow(_ExpForm, 1);
                Grid.SetColumn(_ExpForm, 4);

                _SignForm.ChangeSign(SignForm.SignIndex.Exp);
                _IsExp = true;
            }
        }

        public void Remove_ExpForm()
        {
            if (_IsExp)
            {
                _SecondForm = new FractionForm();

                MainGrid.Children.Remove(_ExpForm);
                MainGrid.Children.Add(_SecondForm);

                Grid.SetRow(_SecondForm, 1);
                Grid.SetColumn(_SecondForm, 4);

                _IsExp = false;
            }
        }

        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            MakeEqual();
        }

        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.OemPlus)
                MakeEqual();
        }

        private void MakeEqual()
        {
            calc.A = new Fraction(_FirstForm.GetFullNumerator, _FirstForm.Divider);

            if (_IsExp) { Calculator.Tool = Calculator.Tools.Exp; calc.Exp = _ExpForm.Digit; }
            else
            {
                calc.B = new Fraction(_SecondForm.GetFullNumerator, _SecondForm.Divider);
            }

            calc.Res = calc.Calculation();

            _ResultForm.RewriteResult(calc.Res.Numerator, calc.Res.Divider);

            if (_IsExp)
            {
                Calculator.SaveOperation(new Fraction(_FirstForm.DivPart, _FirstForm.Numerator, _FirstForm.Divider),
                    _SignForm.GetSign, new Fraction(),
                    new Fraction(_ResultForm.DivPart, _ResultForm.Numerator, _ResultForm.Divider), _ExpForm.Digit);
            }
            else
            {
                Calculator.SaveOperation(new Fraction(_FirstForm.DivPart, _FirstForm.Numerator, _FirstForm.Divider),
                    _SignForm.GetSign, new Fraction(_SecondForm.DivPart, _SecondForm.Numerator, _SecondForm.Divider),
                    new Fraction(_ResultForm.DivPart, _ResultForm.Numerator, _ResultForm.Divider), 0);
            }
        }

        private void ChangeSign_Click(object sender, RoutedEventArgs e)
        {
            if (_IsFirstFormFocused)
            {                
                _FirstForm.RewriteResult(_FirstForm.GetFullNumerator, _FirstForm.Divider);
            }
            if (_IsSecondFormFocused)
            {
                _SecondForm.RewriteResult(_SecondForm.GetFullNumerator, _SecondForm.Divider);
            }
        }

        private void _FirstForm_GotFocus(object sender, RoutedEventArgs e)
        {
            _IsFirstFormFocused = true;
            _IsSecondFormFocused = false;
        }

        private void _SecondForm_GotFocus(object sender, RoutedEventArgs e)
        {
            _IsFirstFormFocused = false;
            _IsSecondFormFocused = true;
        }
    }
}
