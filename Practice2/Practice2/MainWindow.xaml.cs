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

namespace Practice2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPlus_Click(object sender, RoutedEventArgs e)
        {
            float number1 = float.Parse(txtInput1.Text);
            float number2 = float.Parse(txtInput2.Text);
            float result = number1 + number2;
            String Result = number1 + "+" + number2 + "=" + result;
            txtResult.Text = result.ToString();
            lstRecentCalculation.Items.Add(Result);
        }

        private void btnMinus_Click(object sender, RoutedEventArgs e)
        {
            float number1 = float.Parse(txtInput1.Text);
            float number2 = float.Parse(txtInput2.Text);
            float result = number1 - number2;
            String Result = number1 + "-" + number2 + "=" + result;
            txtResult.Text = result.ToString();
            lstRecentCalculation.Items.Add(Result);
        }

        private void btnMutiply_Click(object sender, RoutedEventArgs e)
        {
            float number1 = float.Parse(txtInput1.Text);
            float number2 = float.Parse(txtInput2.Text);
            float result = number1 * number2;
            String Result = number1 + "*" + number2 + "=" + result;
            txtResult.Text = result.ToString();
            lstRecentCalculation.Items.Add(Result);
        }

        private void btnDevide_Click(object sender, RoutedEventArgs e)
        {
            float number1 = float.Parse(txtInput1.Text);
            float number2 = float.Parse(txtInput2.Text);
            float result = number1 / number2;
            String Result = number1 + "/" + number2 + "=" + result;
            txtResult.Text = result.ToString();
            lstRecentCalculation.Items.Add(Result);
        }

        private void lstRecentCalculation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }
    }
}
