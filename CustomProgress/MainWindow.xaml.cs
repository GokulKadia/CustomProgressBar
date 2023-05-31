using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace CustomProgress
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BackgroundWorker backgroundWorker = new BackgroundWorker();
        string lbltext = "Loading";
        public MainWindow()
        {
            InitializeComponent();
            lbl.Content = lbltext;
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.ProgressChanged += ProgressChanged;
            backgroundWorker.DoWork += DoWork;
            // not required for this question, but is a helpful event to handle
            backgroundWorker.RunWorkerCompleted += BackgroundWorker_RunWorkerCompleted;
        }
       
        private void DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker.ReportProgress(10); 
            backgroundWorker.ReportProgress(50);
            backgroundWorker.ReportProgress(75);
            //for (int i = 0; i <= 100; i++)
            //{
            //    // Simulate long running work
            //    Thread.Sleep(1000);
            //    backgroundWorker.ReportProgress(i);
            //    i += 25;
            //    lbltext = "Copying";               
            //}
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // This is called on the UI thread when ReportProgress method is called
            prgbar.Value = e.ProgressPercentage;
            Dispatcher.BeginInvoke(new Action(() =>
            {
                lbl.Content = lbltext;
            }));
        }

        private void BackgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // This is called on the UI thread when the DoWork method completes
            // so it's a good place to hide busy indicators, or put clean up code
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            backgroundWorker.RunWorkerAsync();
        }
    }
}
