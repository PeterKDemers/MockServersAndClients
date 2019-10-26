using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.ServiceModel;
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
using System.Xml;

namespace MockScadaServerServiceHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceHost _Host = null;

        public MainWindow()
        {
            InitializeComponent();
            string endPoint = ConfigurationManager.AppSettings["configuration"].ToString();
        }
        void DisplayMsg(string msg)
        {
            try
            {
                listBox1.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Normal, new Action(delegate()
                {
                    listBox1.Items.Add(msg);
                }));
            }
            catch
            {
            }
        }
        private void buttonStartService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
				Task.Run(() =>
				{
					StartServiceTask();
				});
            }
            catch (Exception ex)
            {
                DisplayMsg(String.Format("Ex: {0}", ex.Message));
            }
        }
        private void StartServiceTask() {
            try {
                if (_Host != null) {

                } else {
                    _Host = new ServiceHost(typeof(MockScadaServerService));
                    _Host.Open();
                    DisplayMsg(String.Format("MockSCADAServerService has started"));
                    for (; ; ) {
                        Thread.Sleep(1000 * 10);
                    }
                }
            } catch (Exception ex) {
                DisplayMsg(String.Format("Ex: {0}", ex.Message));
            }
        }
    }
}
