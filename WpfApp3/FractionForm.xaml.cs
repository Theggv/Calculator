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
    /// Логика взаимодействия для FractionForm.xaml
    /// </summary>
    public partial class FractionForm : UserControl
    {
        private int _DivPart;
        private int _Divider;
        private int _Numerator;

        public int DivPart
        {
            get => _DivPart;
            set => _DivPart = value;
        }

        public int Divider
        {
            get => _Divider;
            set => _Divider = value;
        }

        public int Numerator
        {
            get
            {
                if (_Numerator == 0)
                    return 1;
                else
                    return _Numerator;
            }
            set
            {
                if (value == 0)
                    _Numerator = 1;
                else
                    _Numerator = value;
            }
        }
        
        public FractionForm()
        {
            InitializeComponent();
        }

        private void TextBox_InputFilter(object sender, KeyEventArgs e)
        {
            List<Key> validKeys = new List<Key>
            {
                Key.D0, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7, Key.D8, Key.D9, Key.OemMinus, Key.Back
            };
            if (validKeys.Contains(e.Key))
            {
                var curTextBox = sender as TextBox;
                if (e.Key == Key.OemMinus && (curTextBox.SelectionStart != 0 || curTextBox.Text.Contains("-")))
                    e.Handled = true;
            }
            else
                e.Handled = true;
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            var curTextBox = sender as TextBox;

            if (curTextBox.Text == "-")
                return;

            if (curTextBox.Text == "")
            {
                if (curTextBox.Name == "TextDivPart")
                    DivPart = 0;
                else if (curTextBox.Name == "TextDivPart")
                    Divider = 0;
                else if (curTextBox.Name == "TextNumerator")
                    Numerator = 0;
            }
            else
            {
                if (curTextBox.Name == "TextDivPart")
                    DivPart = int.Parse(curTextBox.Text);
                else if (curTextBox.Name == "TextDivPart")
                    Divider = int.Parse(curTextBox.Text);
                else if (curTextBox.Name == "TextNumerator")
                    Numerator = int.Parse(curTextBox.Text);
            }
        }

        public void Reset()
        {
            DivPart = 0;
            Divider = 0;
            Numerator = 0;

            TextDivPart.Text = "";
            TextDivider.Text = "";
            TextNumerator.Text = "";
        }
    }
}