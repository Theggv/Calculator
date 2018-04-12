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
        private FractionForm _Fraction2;
        public FractionForm()
        {
            InitializeComponent();
        }

        private void TextBox_InputFilter(object sender, KeyEventArgs e)
        {
            List<Key> validKeys = new List<Key>
            {
                Key.D0, Key.D1, Key.D2, Key.D3, Key.D4, Key.D5, Key.D6, Key.D7, Key.D8, Key.D9, Key.OemMinus
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

        public void Reset()
        {
            DivPart.Text = "";
            Devider.Text = "";
            Denominator.Text = "";
        }
    }
}
