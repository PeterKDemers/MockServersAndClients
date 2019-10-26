using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.ServiceModel;
using System.Reflection;
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

namespace MockNotServerServiceHost
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceHost _Host = null;
        UdpClient _UdpClient = null;
        MainWindowViewModel _ViewModel;
        Dictionary<String, String> _KvpList = new Dictionary<String, String>();


        public MainWindow()
        {
            InitializeComponent();

            //this.DataContext = (_ViewModel = new MainWindowViewModel(_Logger));
            this.DataContext = (_ViewModel = new MainWindowViewModel());

            _ViewModel.UpDownBackground = Brushes.Red;
            _ViewModel.UpDownText = "Down";
            _ViewModel.UpDownText = "Down";
            _ViewModel.TextBox1Visibility = System.Windows.Visibility.Hidden;
            _ViewModel.TextBox2Visibility = System.Windows.Visibility.Hidden;
            _ViewModel.TextBox3Visibility = System.Windows.Visibility.Hidden;
            _ViewModel.TextBox4Visibility = System.Windows.Visibility.Hidden;
            _ViewModel.TextBox5Visibility = System.Windows.Visibility.Hidden;
            _ViewModel.TextBox6Visibility = System.Windows.Visibility.Hidden;
            _ViewModel.TextBox7Visibility = System.Windows.Visibility.Hidden;
            _ViewModel.TextBox8Visibility = System.Windows.Visibility.Hidden;
            _ViewModel.TextBox9Visibility = System.Windows.Visibility.Hidden;
            _ViewModel.TextBox10Visibility = System.Windows.Visibility.Hidden;
            Task.Run(() =>
            {
                ReceiveDataTask();
            });
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
        private void StartServiceTask()
        {
            try
            {
                if (_Host != null)
                {

                }
                else
                {
                    _Host = new ServiceHost(typeof(MockNotServerService));
                    _Host.Open();
                    _ViewModel.UpDownBackground = Brushes.ForestGreen;
                    _ViewModel.UpDownText = "Up";
                    for (; ; )
                    {
                        Thread.Sleep(1000 * 10);
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayMsg(String.Format("Ex: {0}", ex.Message));
            }
        }
        private void ReceiveDataTask()
        {
            String index;
            try
            {
                _UdpClient = new UdpClient(7373);
                for (; ; )
                {
                    IPEndPoint endpoint = new IPEndPoint(IPAddress.Any, 0);
                    Byte[] data = _UdpClient.Receive(ref endpoint);
                    string message = Encoding.ASCII.GetString(data);
                    string[] pairs = message.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (String field in pairs){
                        string[] fields = field.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (_KvpList.ContainsKey(fields[0])) {
                            _KvpList[fields[0]] = fields[1];
                        } else {
                            _KvpList.Add(fields[0], fields[1]);
                        }
                    }
                    Int32 i = 0;
                    foreach (KeyValuePair<String, String> kvp in _KvpList) {
                        switch (i) {
                            case 0:
                                _ViewModel.TextBox1Text = String.Format("{0}: {1}", kvp.Key, kvp.Value);
                                _ViewModel.TextBox1Visibility = System.Windows.Visibility.Visible;
                                break;
                            case 1:
                                _ViewModel.TextBox2Text = String.Format("{0}: {1}", kvp.Key, kvp.Value);
                                _ViewModel.TextBox2Visibility = System.Windows.Visibility.Visible;
                                break;
                            case 2:
                                _ViewModel.TextBox3Text = String.Format("{0}: {1}", kvp.Key, kvp.Value);
                                _ViewModel.TextBox3Visibility = System.Windows.Visibility.Visible;
                                break;
                            case 3:
                                _ViewModel.TextBox4Text = String.Format("{0}: {1}", kvp.Key, kvp.Value);
                                _ViewModel.TextBox4Visibility = System.Windows.Visibility.Visible;
                                break;
                            case 4:
                                _ViewModel.TextBox5Text = String.Format("{0}: {1}", kvp.Key, kvp.Value);
                                _ViewModel.TextBox5Visibility = System.Windows.Visibility.Visible;
                                break;
                            case 5:
                                _ViewModel.TextBox6Text = String.Format("{0}: {1}", kvp.Key, kvp.Value);
                                _ViewModel.TextBox6Visibility = System.Windows.Visibility.Visible;
                                break;
                            case 6:
                                _ViewModel.TextBox7Text = String.Format("{0}: {1}", kvp.Key, kvp.Value);
                                _ViewModel.TextBox7Visibility = System.Windows.Visibility.Visible;
                                break;
                            case 7:
                                _ViewModel.TextBox8Text = String.Format("{0}: {1}", kvp.Key, kvp.Value);
                                _ViewModel.TextBox8Visibility = System.Windows.Visibility.Visible;
                                break;
                            case 8:
                                _ViewModel.TextBox9Text = String.Format("{0}: {1}", kvp.Key, kvp.Value);
                                _ViewModel.TextBox9Visibility = System.Windows.Visibility.Visible;
                                break;
                            case 9:
                                _ViewModel.TextBox10Text = String.Format("{0}: {1}", kvp.Key, kvp.Value);
                                _ViewModel.TextBox10Visibility = System.Windows.Visibility.Visible;
                                break;
                            default:
                                break;
                        }
                        i++;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(String.Format("ReceiveDataTask() ex:{0}", ex.Message));
            }
        }
    }
}
