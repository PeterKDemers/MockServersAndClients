using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
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


namespace MockNotServerClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        EndpointAddress _EndpointAddress = null;
        NOT_ServerSoap _Proxy = null;

        public MainWindow()
        {
            InitializeComponent();

            buttonPingURL.IsEnabled = false;
            buttonGetMethods.IsEnabled = false;
            buttonScadaAnalogChangedNotification.IsEnabled = false;
            buttonScadaStatusChangedNotification.IsEnabled = false;

            comboBoxServiceIpAddresses.Items.Add("127.0.0.1");
            for (int i = 1; i < 100; i++)
            {
                try
                {
                    comboBoxServiceIpAddresses.Items.Add(ConfigurationManager.AppSettings[String.Format("IpAddressOfServer{0}", i)]);
                }
                catch
                {
                    break;
                }
            }
            comboBoxServiceIpAddresses.SelectedIndex = 0;
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

                String proxyEndpoint = String.Format("http://{0}:16499/416/soap/OA_Server", comboBoxServiceIpAddresses.SelectedValue);
                _EndpointAddress = new EndpointAddress(proxyEndpoint);
                _Proxy = ChannelFactory<NOT_ServerSoap>.CreateChannel(binding, _EndpointAddress);
                textBoxProxyEndpoinbt.Text = String.Format("Proxy Established: {0}", proxyEndpoint);
                buttonPingURL.IsEnabled = true;
                buttonGetMethods.IsEnabled = true;
                buttonScadaAnalogChangedNotification.IsEnabled = true;
                buttonScadaStatusChangedNotification.IsEnabled = true;
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
                request.MultiSpeakMsgHeader.UserID = "dcs";
                request.MultiSpeakMsgHeader.Pwd = "dcs1";
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
            try
            {
                GetMethodsRequest request = new GetMethodsRequest();
                request.MultiSpeakMsgHeader = new MultiSpeakMsgHeader();
                request.MultiSpeakMsgHeader.UserID = "dcs";
                request.MultiSpeakMsgHeader.Pwd = "dcs1";
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
        private void buttonScadaAnalogChangedNotification_Click(object sender, RoutedEventArgs e)
        {
            const int MAX_NUM_ANALOGS = 21;
            Int32 numAnalogs = 0;

            try
            {
                Random rand = new Random();
                SCADAAnalogChangedNotificationRequest request = new SCADAAnalogChangedNotificationRequest();
                request.MultiSpeakMsgHeader = new MultiSpeakMsgHeader();
                request.MultiSpeakMsgHeader.UserID = "dcs";
                request.MultiSpeakMsgHeader.Pwd = "dcs1";
                //request.MultiSpeakMsgHeader.TimeStamp = DateTime.Now;
                //request.MultiSpeakMsgHeader.TimeStampSpecified = true;

                //numAnalogs = rand.Next(1, MAX_NUM_ANALOGS);
                //request.scadaAnalogs = new scadaAnalog[numAnalogs];
                //for (int i = 0; i < numAnalogs; i++) {
                //    request.scadaAnalogs[i] = new scadaAnalog();
                //    request.scadaAnalogs[i].objectID = "SCADAPoint"; ;
                //    request.scadaAnalogs[i].objectName = String.Format("Analog{0:0000}", i);
                //    request.scadaAnalogs[i].unitID = String.Format("An{0:0000}", i);
                //    request.scadaAnalogs[i].quality = new qualityDescription1();
                //    request.scadaAnalogs[i].quality = qualityDescription1.Measured;
                //    request.scadaAnalogs[i].value = new value();
                //    request.scadaAnalogs[i].value.Value = 0.1F;
                //    request.scadaAnalogs[i].value.units = uom.Amps;
                //    request.scadaAnalogs[i].value.unitsSpecified = true;
                //    request.scadaAnalogs[i].timeStamp = DateTime.Now;
                //    request.scadaAnalogs[i].timeStampSpecified = true;
                //}
                numAnalogs = 1;
                request.scadaAnalogs = new scadaAnalog[numAnalogs];
                for (int i = 0; i < numAnalogs; i++) {
                    request.scadaAnalogs[i] = new scadaAnalog();
                    request.scadaAnalogs[i].objectID = "LR1234"; ;
                    //request.scadaAnalogs[i].objectName = String.Format("Analog{0:0000}", i);
                    //request.scadaAnalogs[i].unitID = String.Format("An{0:0000}", i);
                    //request.scadaAnalogs[i].quality = new qualityDescription1();
                    //request.scadaAnalogs[i].quality = qualityDescription1.Measured;
                    request.scadaAnalogs[i].value = new value();
                    request.scadaAnalogs[i].value.Value = 0.1F;
                    request.scadaAnalogs[i].value.units = uom.Amps;
                    request.scadaAnalogs[i].value.unitsSpecified = true;
                    request.scadaAnalogs[i].timeStamp = DateTime.Now;
                    request.scadaAnalogs[i].timeStampSpecified = true;
                }
                SCADAAnalogChangedNotificationResponse response = _Proxy.SCADAAnalogChangedNotification(request);
                if (response == null)
                {
                    DisplayMsg("response is null - SUCCESS");
                    return;
                }
                if (response.SCADAAnalogChangedNotificationResult == null)
                {
                    DisplayMsg("response.SCADAAnalogChangedNotificationResult is null - SUCCESS");
                    return;
                }
                for (int i = 0; i < response.SCADAAnalogChangedNotificationResult.Length; i++)
                {
                    DisplayMsg(String.Format("{0} {1}", response.SCADAAnalogChangedNotificationResult[i].objectID, response.SCADAAnalogChangedNotificationResult[i].Value));
                }
            }
            catch (Exception ex)
            {
                DisplayMsg(String.Format("ex: {0}", ex.Message));
            }
        }
        private void buttonScadaStatusChangedNotification_Click(object sender, RoutedEventArgs e)
        {
            const int MAX_NUM_STATUS = 10;
            Random rand = new Random();
            try
            {
                SCADAStatusChangedNotificationRequest request = new SCADAStatusChangedNotificationRequest();
                request.MultiSpeakMsgHeader = new MultiSpeakMsgHeader();
                request.MultiSpeakMsgHeader.UserID = "dcs";
                request.MultiSpeakMsgHeader.Pwd = "dcs1";
                request.MultiSpeakMsgHeader.TimeStamp = DateTime.Now;
                request.MultiSpeakMsgHeader.TimeStampSpecified = true;
                request.scadaStatuses = new scadaStatus[MAX_NUM_STATUS];
                for (int i = 0; i < MAX_NUM_STATUS; i++)
                {
                    request.scadaStatuses[i] = new scadaStatus();
                    request.scadaStatuses[i].objectID = "SCADAPoint";
                    request.scadaStatuses[i].objectName = String.Format("Status{0:0000}", i);
                    request.scadaStatuses[i].quality = qualityDescription1.Measured;
                    request.scadaStatuses[i].status = new statusIdentifiers();
                    request.scadaStatuses[i].changeCounter = 0;
                }
                SCADAStatusChangedNotificationResponse response = _Proxy.SCADAStatusChangedNotification(request);
                if (response == null) {
                    DisplayMsg("response is null - SUCCESS");
                    return;
                }
                if (response.SCADAStatusChangedNotificationResult == null) {
                    DisplayMsg("response.SCADAStatusChangedNotificationResult is null - SUCCESS");
                    return;
                }
                for (int i = 0; i < response.SCADAStatusChangedNotificationResult.Length; i++)
                {
                    DisplayMsg(String.Format("{0} {1}", response.SCADAStatusChangedNotificationResult[i].objectID, response.SCADAStatusChangedNotificationResult[i].Value));
                }
            }
            catch (Exception ex)
            {
                DisplayMsg(String.Format("ex: {0}", ex.Message));
            }
        }

        private void listBox1_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            listBox1.Items.Clear();
        }
        private void buttonFlushLogs_Click(object sender, RoutedEventArgs e) {
            try {
                PingURLRequest request = new PingURLRequest();
                PingURLResponse response = _Proxy.FlushLog(request);
                DisplayMsg(response.PingURLResult[0].errorString);
            } catch (Exception ex) {
                DisplayMsg(String.Format("ex: {0}", ex.Message));
            }
        }
    }
}
