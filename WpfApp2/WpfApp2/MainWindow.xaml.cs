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
using lib_11;
using libmas;

namespace WpfApp2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_calculate_clk(object sender, RoutedEventArgs e)
        {
            int minVal, maxVal, size;
            int[] numbers;
            if (int.TryParse(TBminVal.Text, out minVal) && int.TryParse(TBmaxVal.Text, out maxVal) && int.TryParse(TBsize.Text, out size))
            {
                ArrayUtils.FillArrayRandom(out numbers, size, minVal, maxVal);
                
                DG.ItemsSource = ArrayUtils.ToDataTable(numbers).DefaultView;
                int difference = v11.CalculateDifference(numbers);
                MessageBox.Show($"Разница чисел: {difference}", "Результат");
            }
            else
            {
                MessageBox.Show("Введите корректный размер массива и числа от, до");
            }
        }
    }
}
