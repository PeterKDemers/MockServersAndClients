using System;
using System.Configuration;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
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


namespace MockScadaServerClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        String _LastReceived = String.Empty;

        MainWindowViewModel _ViewModel;
        EndpointAddress _EndpointAddress = null;
       SCADA_ServerSoap _Proxy = null;

        public MainWindow()
        {
            try
            {
                InitializeComponent();

                this.DataContext = (_ViewModel = new MainWindowViewModel());

                buttonPingURL.IsEnabled = false;
                buttonGetMethods.IsEnabled = false;
                buttonGetAllScadaPoints.IsEnabled = false;
                buttonGetScadaAnalogByScadaPointId.IsEnabled = false;
                buttonGetScadaStatusByScadaPointId.IsEnabled = false;

                DateTime n = DateTime.Now;
                String nn = n.ToString();

                for (int i = 1; i < 100; i++)
                {
                    try
                    {
                        String address = ConfigurationManager.AppSettings[String.Format("IpAddressOfServer{0}", i)];
                        if (address == null) {
                            break;
                        }
                        comboBoxServiceIpAddresses.Items.Add(address);
                    } catch {
                        break;
                    }
                }
                comboBoxServiceIpAddresses.Items.Add("127.0.0.1");
                comboBoxServiceIpAddresses.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                DisplayMsg(String.Format("ex: {0}", ex.Message));
            }
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
        private void buttonGenerateProxy_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                BasicHttpBinding binding = new BasicHttpBinding();
                binding.MaxReceivedMessageSize = Int32.MaxValue;
                binding.ReaderQuotas.MaxDepth = Int32.MaxValue;
                binding.ReaderQuotas.MaxStringContentLength = Int32.MaxValue;
                binding.ReaderQuotas.MaxBytesPerRead = Int32.MaxValue;
                binding.ReaderQuotas.MaxArrayLength = Int32.MaxValue;
                binding.ReaderQuotas.MaxNameTableCharCount = Int32.MaxValue;

                String proxyEndpoint;
                if ((bool)rbMultispeakServer.IsChecked) {
                    // http://12.218.155.155:16499/416/soap/OA_Server
                    proxyEndpoint = String.Format("http://{0}:16499/416/soap/OA_Server", comboBoxServiceIpAddresses.SelectedValue);
                } else {
                    proxyEndpoint = String.Format("http://{0}:8081/MockScadaServerService", comboBoxServiceIpAddresses.SelectedValue);
                }
                _EndpointAddress = new EndpointAddress(proxyEndpoint);
                _Proxy = ChannelFactory<SCADA_ServerSoap>.CreateChannel(binding, _EndpointAddress);
                textBoxProxyEndpoinbt.Text = String.Format("Proxy Established: {0}", proxyEndpoint);
                buttonPingURL.IsEnabled = true;
                buttonGetMethods.IsEnabled = true;
                buttonGetAllScadaPoints.IsEnabled = true;
                buttonGetScadaAnalogByScadaPointId.IsEnabled = true;
                buttonGetScadaStatusByScadaPointId.IsEnabled = true;

                buttonGetAllScadaPoints_Click(null, null);
            }
            catch (Exception ex)
            {
                DisplayMsg(String.Format("ex: {0}", ex.Message));
            }
        }
        private void buttonPingURL_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                PingURLRequest request = new PingURLRequest();
                request.MultiSpeakMsgHeader = new MultiSpeakMsgHeader();
                request.MultiSpeakMsgHeader.UserID = textBoxUserName.Text;
                request.MultiSpeakMsgHeader.Pwd = passwordBoxPassword.Password;
                PingURLResponse response = _Proxy.PingURL(request);
                if (response == null)
                {
                    DisplayMsg("MockSCADAServerService IS RUNNING BUT RESPONSE IS NULL");
                    return;
                }
                if (response.MultiSpeakMsgHeader == null)
                {
                    DisplayMsg("MockSCADAServerService IS RUNNING BUT RESPONSE IS MISSIMG MSGHEADER");
                    return;
                }
                if ((response.PingURLResult != null) && (response.PingURLResult.Length > 0))
                {
                    DisplayMsg(String.Format("MockSCADAServerService ERROR:{0}", response.PingURLResult[0].errorString));
                    return;
                }
                DisplayMsg(String.Format("MockSCADAServerService BUILD:{0} IS RUNNING", response.MultiSpeakMsgHeader.Build));
                return;
            }
            catch (Exception ex)
            {
                DisplayMsg(String.Format("ex: {0}", ex.Message));
            }
        }
        private void buttonGetMethods_Click(object sender, RoutedEventArgs e)
        {
            //ServiceReference1.MultiSpeakMsgHeader header = new ServiceReference1.MultiSpeakMsgHeader();
            try
            {
                GetMethodsRequest request = new GetMethodsRequest();
                request.MultiSpeakMsgHeader = new MultiSpeakMsgHeader();
                request.MultiSpeakMsgHeader.UserID = textBoxUserName.Text;
                request.MultiSpeakMsgHeader.Pwd = passwordBoxPassword.Password;
                GetMethodsResponse response = _Proxy.GetMethods(request);
                if (response == null)
                {
                    DisplayMsg("MockSCADAServerService RESPONSE IS NULL");
                    return;
                }
                if (response.MultiSpeakMsgHeader == null)
                {
                    DisplayMsg("MockSCADAServerService RESPONSE IS MISSIMG MSGHEADER");
                    return;
                }
                if (response.GetMethodsResult == null)
                {
                    DisplayMsg("MockSCADAServerService GetMethodsResult IS NULL");
                    return;
                }
                for (int i = 0; i < response.GetMethodsResult.Length; i++)
                {
                    DisplayMsg(String.Format("MockSCADAServerService Method: {0} IS SUPPORTED", response.GetMethodsResult[i]));
                }
            }
            catch (Exception ex)
            {
                DisplayMsg(String.Format("ex: {0}", ex.Message));
            }
        }
        private void buttonGetAllScadaPoints_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetAllSCADAPointsRequest request = new GetAllSCADAPointsRequest();
                request.MultiSpeakMsgHeader = new MultiSpeakMsgHeader();
                request.MultiSpeakMsgHeader.UserID = textBoxUserName.Text;
                request.MultiSpeakMsgHeader.Pwd = passwordBoxPassword.Password;
                request.lastReceived = _LastReceived;
                GetAllSCADAPointsResponse response = _Proxy.GetAllSCADAPoints(request);
                if (response == null)
                {
                    DisplayMsg("MockSCADAServerService RESPONSE IS NULL");
                    return;
                }
                if (response.MultiSpeakMsgHeader == null)
                {
                    DisplayMsg("MockSCADAServerService RESPONSE IS MISSIMG MSGHEADER");
                    return;
                }
                if (response.GetAllSCADAPointsResult == null)
                {
                    DisplayMsg("MockSCADAServerService GetMethodsResult IS NULL");
                    return;
                }
                if (_LastReceived == String.Empty) {
                    comboBoxAnalogPointIDs.Items.Clear();
                    comboBoxStatusPointIDs.Items.Clear();
                 }
                for (int i = 0; i < response.GetAllSCADAPointsResult.Length; i++)
                {
                    scadaPoint point = response.GetAllSCADAPointsResult[i];
                    if (point.scadaPointType == scadaPointType.analog) {
                        comboBoxAnalogPointIDs.Items.Add(point.objectName);
                    } else {
                        comboBoxStatusPointIDs.Items.Add(point.objectName);
                    }
                }
                comboBoxAnalogPointIDs.SelectedIndex = 0;
                comboBoxStatusPointIDs.SelectedIndex = 0;
                if (Int32.Parse(response.MultiSpeakMsgHeader.ObjectsRemaining) == 0) {
                    _LastReceived = String.Empty;
                } else {
                    _LastReceived = response.MultiSpeakMsgHeader.LastSent;
                }
            }
            catch (Exception ex)
            {
                DisplayMsg(String.Format("ex: {0}", ex.Message));
            }
        }
        private void buttonGetScadaAnalogByScadaPointId_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetSCADAAnalogBySCADAPointIDRequest request = new GetSCADAAnalogBySCADAPointIDRequest();
                request.scadaPointID = (String)comboBoxAnalogPointIDs.SelectedValue;
                request.MultiSpeakMsgHeader = new MultiSpeakMsgHeader();
                request.MultiSpeakMsgHeader.UserID = textBoxUserName.Text;
                request.MultiSpeakMsgHeader.Pwd = passwordBoxPassword.Password;
                GetSCADAAnalogBySCADAPointIDResponse response = _Proxy.GetSCADAAnalogBySCADAPointID(request);
                if (response == null)
                {
                    DisplayMsg("MockSCADAServerService RESPONSE IS NULL");
                    return;
                }
                if (response.MultiSpeakMsgHeader == null)
                {
                    DisplayMsg("MockSCADAServerService RESPONSE IS MISSIMG MSGHEADER");
                    return;
                }
                if (response.GetSCADAAnalogBySCADAPointIDResult == null)
                {
                    DisplayMsg("MockSCADAServerService GetMethodsResult IS NULL");
                    return;
                }
                scadaAnalog analog = response.GetSCADAAnalogBySCADAPointIDResult;
                if (analog.objectID == (String)comboBoxAnalogPointIDs.SelectedValue) {
                    textBoxAnalogValue.Text = String.Format("{0:0.00000} {1}", analog.value.Value, analog.value.units);
                } else {
                    DisplayMsg(String.Format("objectID: {0} does not match {1}", analog.objectID, (String)comboBoxStatusPointIDs.SelectedValue));
                }
            }
            catch (Exception ex)
            {
                DisplayMsg(String.Format("ex: {0}", ex.Message));
            }
        }
        private void buttonGetScadaStatusByScadaPointId_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                GetSCADAStatusBySCADAPointIDRequest request = new GetSCADAStatusBySCADAPointIDRequest();
                request.scadaPointID = (String)comboBoxStatusPointIDs.SelectedValue;
                request.MultiSpeakMsgHeader = new MultiSpeakMsgHeader();
                request.MultiSpeakMsgHeader.UserID = textBoxUserName.Text;
                request.MultiSpeakMsgHeader.Pwd = passwordBoxPassword.Password;
                GetSCADAStatusBySCADAPointIDResponse response = _Proxy.GetSCADAStatusBySCADAPointID(request);
                if (response == null)
                {
                    DisplayMsg("MockSCADAServerService RESPONSE IS NULL");
                    return;
                }
                if (response.MultiSpeakMsgHeader == null)
                {
                    DisplayMsg("MockSCADAServerService RESPONSE IS MISSIMG MSGHEADER");
                    return;
                }
                if (response.GetSCADAStatusBySCADAPointIDResult == null)
                {
                    DisplayMsg("MockSCADAServerService GetMethodsResult IS NULL");
                    return;
                }
                scadaStatus status = response.GetSCADAStatusBySCADAPointIDResult;
                if (status.objectID == (String)comboBoxStatusPointIDs.SelectedValue) {
                    textBoxStatusValue.Text = String.Format("{0}", status.status);
                } else {
                    DisplayMsg(String.Format("objectID: {0} does not match {1}", status.objectID, (String)comboBoxStatusPointIDs.SelectedValue));
                }
            }
            catch (Exception ex)
            {
                DisplayMsg(String.Format("ex: {0}", ex.Message));
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
