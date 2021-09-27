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

namespace IncIncPieceworkPayroll
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

        /// <summary>
        /// Calculate the Worker's Pay
        /// </summary>
        private void CalculateClick(object sender, RoutedEventArgs e)
        {
            PieceworkWorker worker = new PieceworkWorker(textBoxWorkerName.Text, 
                textBoxMessagesSent.Text) ;

            // If the worker has 0 pay. it's invalid.
            if(worker.Pay == 0)
            {
                //Set focus on Worker's name textbox
                textBoxWorkerName.Focus();
                textBoxWorkerName.SelectAll();
            }
            else
            {
                // Print various attributes of the worker.
                textBoxWorkerPay.Text = worker.Pay.ToString("c");
                textBoxTotalPay.Text = PieceworkWorker.TotalPay.ToString("c");
                textBoxTotalWorker.Text = PieceworkWorker.TotalWorkers.ToString();
                textBoxAveragePay.Text = (PieceworkWorker.TotalPay / PieceworkWorker.TotalWorkers).ToString("c");
                
                // Disable input controls.
                textBoxWorkerName.IsReadOnly = true;
                textBoxMessagesSent.IsReadOnly = true;
                buttonCalculate.IsEnabled = false;
                buttonClear.Focus();

            }
        }

        /// <summary>
        /// Clear all the fields
        /// </summary>
        private void ClearClick(object sender, RoutedEventArgs e)
        {
            //Clear all fields
            textBoxWorkerName.Clear();
            textBoxMessagesSent.Clear();
            textBoxTotalPay.Clear();
            textBoxWorkerPay.Clear();
            textBoxTotalWorker.Clear();
            textBoxAveragePay.Clear();

            // Re-enable input controls.
            textBoxWorkerName.IsReadOnly = false;
            textBoxMessagesSent.IsReadOnly = false;
            buttonCalculate.IsEnabled = true;
            textBoxWorkerName.Focus();

        }

        /// <summary>
        /// Close the program
        /// </summary>
        private void ExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
