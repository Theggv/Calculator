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
        private FractionForm _SecondForm = new FractionForm();
        private DigitForm _ExpForm = new DigitForm();
        private FractionForm _ResultForm = new FractionForm();

        public MainWindow()
        {
            InitializeComponent();
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
                    break;
                case "-":
                    _SignForm.ChangeSign(SignForm.SignIndex.Minus);
                    break;
                case "*":
                    _SignForm.ChangeSign(SignForm.SignIndex.Multi);
                    break;
                case "/":
                    _SignForm.ChangeSign(SignForm.SignIndex.Divide);
                    break;
            }
        }
    }
}
