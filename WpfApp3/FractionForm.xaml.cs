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
    /// Логика взаимодействия для FractionForm.xaml
    /// </summary>
    public partial class FractionForm : UserControl
    {
        private long _DivPart; // Целая часть
        private long _Numerator; // Числитель
        private long _Divider; // Знаменатель
        private bool _IsFocused;
        private bool _IsReadOnly;

        public bool FormFocused
        {
            get => _IsFocused;
            set => _IsFocused = value;
        }

        public long DivPart
        {
            get => _DivPart;
            set => _DivPart = value;
        }

        public long Numerator
        {
            get => _Numerator;
            set => _Numerator = value;
        }

        public long Divider
        {
            get
            {
                if (_Divider == 0)
                    return 1;
                else
                    return _Divider;
            }
            set
            {
                if (value == 0)
                    _Divider = 1;
                else
                    _Divider = value;
            }
        }

        public bool IsReadOnly
        {
            get => _IsReadOnly;
            set => _IsReadOnly = value;
        }
        
        public FractionForm()
        {
            InitializeComponent();
        }

        private void TextBox_InputFilter(object sender, KeyEventArgs e)
        {
            if (_IsReadOnly)
            {
                e.Handled = true;
                return;
            }

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
            if (_IsReadOnly)
            {
                e.Handled = true;
                return;
            }

            var curTextBox = sender as TextBox;

            if (curTextBox.Text == "-")
                return;

            if (curTextBox.Text == "")
            {
                if (curTextBox.Name == "TextDivPart")
                    DivPart = 0;
                else if (curTextBox.Name == "TextNumerator")
                    Numerator = 0;
                else if (curTextBox.Name == "TextDivider")
                    Divider = 0;
            }
            else
            {
                if (curTextBox.Name == "TextDivPart")
                    DivPart = int.Parse(curTextBox.Text);
                else if (curTextBox.Name == "TextNumerator")
                    Numerator = int.Parse(curTextBox.Text);
                else if (curTextBox.Name == "TextDivider")
                    Divider = int.Parse(curTextBox.Text);
            }
        }

        public void Reset()
        {
            DivPart = 0;
            Numerator = 0;
            Divider = 0;

            TextDivPart.Text = "";
            TextNumerator.Text = "";
            TextDivider.Text = "";
        }

        public void RewriteResult(long numerator, long divider)
        {
            if (numerator < 0 && divider < 0)
            {
                numerator *= -1;
                divider *= -1;
            }

            long divPart = numerator / divider;

            DivPart = divPart;
            Numerator = numerator % divider;
            Divider = divider;

            if (_DivPart != 0)
                TextDivPart.Text = DivPart.ToString();
            else
                TextDivPart.Text = "";

            if (Numerator == 0 || (Numerator == 1 && Divider == 1))
            {
                TextNumerator.Text = "";
                TextDivider.Text = "";

                return;
            }
            
            TextNumerator.Text = Numerator.ToString();

            if (_Divider != 1)
                TextDivider.Text = Divider.ToString();
            else
                TextDivider.Text = "";
        }

        private void TextDivider_GotFocus(object sender, RoutedEventArgs e)
        {
            FormFocused = true;
        }
    }
}
