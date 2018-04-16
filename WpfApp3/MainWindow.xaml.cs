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
        private DigitForm _ExpForm;
        private bool _IsExp = false;
       
        static string operation;
        static bool isBinaryOperation;
        private bool _IsChange = false;
        private bool _IsRed = false;
        static Calculator calc = new Calculator();

        public DigitForm ExpForm
        {
            get => _ExpForm;
            set => _ExpForm = value;
        }

        public MainWindow()
        {
            InitializeComponent();

            _SignForm.ChangeSign(SignForm.SignIndex.Plus);
            EqualForm.ChangeSign(SignForm.SignIndex.Equal);
            isBinaryOperation = true;
            _ResultForm.IsReadOnly = true;
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
            if (_SecondForm != null)
                _SecondForm.Reset();
            if (_ResultForm != null)
                _ResultForm.Reset();
        }

        private void Sign_Click(object sender, RoutedEventArgs e)
        {
            var operation = (sender as Button).Content.ToString();

            Remove_ExpForm();

            switch (operation)
            {
                case "+":
                    _SignForm.ChangeSign(SignForm.SignIndex.Plus);
                    calc.Tool = Calculator.Tools.Plus;
                    isBinaryOperation = true;
                    break;
                case "-":
                    _SignForm.ChangeSign(SignForm.SignIndex.Minus);
                    calc.Tool = Calculator.Tools.Minus;
                    isBinaryOperation = true;
                    break;
                case "*":
                    _SignForm.ChangeSign(SignForm.SignIndex.Multi);
                    calc.Tool = Calculator.Tools.Multi;
                    isBinaryOperation = true;
                    break;
                case "/":
                    _SignForm.ChangeSign(SignForm.SignIndex.Divide);
                    calc.Tool = Calculator.Tools.Divide;
                    isBinaryOperation = true;
                    break;
            }
        }

        private void Exp_Click(object sender, RoutedEventArgs e)
        {
            Add_ExpForm();
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
        private void Equal_Click(object sender, RoutedEventArgs e)
        {
            Fraction A = new Fraction(_FirstForm.DivPart, _FirstForm.Divider, _FirstForm.Denominator);
            calc.A = A;
            if (isBinaryOperation)
            {
                Fraction B = new Fraction(_SecondForm.DivPart, _SecondForm.Divider, _SecondForm.Denominator);
                calc.B = B;
            }
            if (_IsExp) { calc.Tool = Calculator.Tools.Exp; calc.Exp = _ExpForm.Digit; }
            if (_IsChange) { calc.Tool = Calculator.Tools.Change; }
            if (_IsRed) { calc.Tool = Calculator.Tools.Red; }
            calc.Res = calc.Calculation();

            _ResultForm.RewriteResult(Calculator.AllocateDivPart(calc.Res),
                Math.Abs(calc.Res.Numerator - Calculator.AllocateDivPart(calc.Res) * calc.Res.Divider),
                calc.Res.Divider);
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

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Calculator.CancelOperation(this);
        }
    }
}
