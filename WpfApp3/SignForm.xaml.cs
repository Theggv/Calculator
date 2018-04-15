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
    /// Логика взаимодействия для SignForm.xaml
    /// </summary>
    public partial class SignForm : UserControl
    {
        public enum SignIndex
        {
            Null = 0,
            Plus,
            Minus,
            Multi,
            Divide,
            Equal,
            Exp
        }
        public SignForm()
        {
            InitializeComponent();
        }

        public void ChangeSign(SignIndex index)
        {
            switch (index)
            {
                case SignIndex.Plus:
                    Sign.Text = "+";
                    break;
                case SignIndex.Minus:
                    Sign.Text = "-";
                    break;
                case SignIndex.Multi:
                    Sign.Text = "*";
                    break;
                case SignIndex.Divide:
                    Sign.Text = "/";
                    break;
                case SignIndex.Equal:
                    Sign.Text = "=";
                    break;
                case SignIndex.Exp:
                    Sign.Text = "^";
                    break;
                default:
                    Sign.Text = "";
                    break;
            }
        }
    }
}
