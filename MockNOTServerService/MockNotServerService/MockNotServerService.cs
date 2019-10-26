using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using DCSystemsLib.Logging;
using DCSystemsLib.Utility;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "GSISService" in both code and config file together.
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class MockNotServerService : NOT_ServerSoap
    {
        UdpClient _UdpClient = null;
        static Logger _Logger = null;

        public PingURLResponse FlushLog(PingURLRequest request) {
            LogInfo("FlushLog() Entered");
            PingURLResponse response = new PingURLResponse();
            response.PingURLResult = new errorObject[1];
            response.PingURLResult[0] = new errorObject();
            try {
                if (_Logger != null) {
                    _Logger.flush();
                    response.PingURLResult[0].errorString = "OK";
                }
            } catch (Exception ex) {
                LogError(String.Format("FlushLog() ex:{0}", ex));
                response.PingURLResult[0].errorString = ex.Message;
            }
            return response;
        }
        public PingURLResponse PingURL(PingURLRequest request)
        {
            LogInfo("PingURL() Entered");
            PingURLResponse response = new PingURLResponse();
            try
            {
                if (_UdpClient == null)
                {
                    String path = @"C:\\DCSystems\Logs\";
                    ConfigurationList cl = new ConfigurationList();
                    cl.Add("Process Name", "MockNotServerService");
                    cl.Add("Log Output Directory", path);
                    _Logger = new Logger(cl);

                    LogInfo("()");

                    _UdpClient = new UdpClient();
                    _UdpClient.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7373));
                }
                Byte[] sendBytes = Encoding.ASCII.GetBytes("PingURL,OK");
                _UdpClient.Send(sendBytes, sendBytes.Length);

                response.MultiSpeakMsgHeader = new MultiSpeakMsgHeader();
                response.MultiSpeakMsgHeader.MinorVersion = "4";
                response.MultiSpeakMsgHeader.MinorVersion = "1";
                response.MultiSpeakMsgHeader.Build = "8";
                response.MultiSpeakMsgHeader.BuildString = BuildDescriptor.Release;
                response.MultiSpeakMsgHeader.AppName = "DCSystems";
                response.MultiSpeakMsgHeader.TimeStamp = DateTime.Now;
                response.MultiSpeakMsgHeader.TimeStampSpecified = true;

                //errorObject[] eObject = new errorObject[1];
                //eObject[0] = new errorObject();
                //eObject[0].eventTime = DateTime.Now;
                //eObject[0].eventTimeSpecified = true;
                //response.PingURLResult = eObject;
               return response;
            }
            catch (Exception ex)
            {
                LogError(String.Format("PingURL() ex:{0}", ex));
                response.PingURLResult = new errorObject[1];
                response.PingURLResult[0].objectID = "DCSystem";
                response.PingURLResult[0].errorString = ex.Message;
                return response;
            }
        }
        private void LogInfo(String msg) {
            if (_Logger == null) {
                return;
            }
            _Logger.write(Logger.Level.Info, msg);
        }
        private void LogError(String msg) {
            if (_Logger == null) {
                return;
            }
            _Logger.write(Logger.Level.Error, msg);
        }
        public GetMethodsResponse GetMethods(GetMethodsRequest request)
        {
            LogInfo("GetMethods() Entered");
            GetMethodsResponse response = null;
            try
            {
                if (_UdpClient == null) {
                    String path = @"C:\\DCSystems\Logs\";
                    ConfigurationList cl = new ConfigurationList();
                    cl.Add("Process Name", "MockNotServerService");
                    cl.Add("Log Output Directory", path);
                    _Logger = new Logger(cl);

                    LogInfo("()");

                    _UdpClient = new UdpClient();
                    _UdpClient.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7373));
                }
                Byte[] sendBytes = Encoding.ASCII.GetBytes("GetURL,OK");
                _UdpClient.Send(sendBytes, sendBytes.Length);

                response = new GetMethodsResponse();
                response.MultiSpeakMsgHeader = new MultiSpeakMsgHeader();
                response.MultiSpeakMsgHeader.TimeStampSpecified = true;
                response.MultiSpeakMsgHeader.TimeStamp = DateTime.Now;
                response.GetMethodsResult = new string[4];
                response.GetMethodsResult[0] = "GetMethods";
                response.GetMethodsResult[1] = "PingURL";
                response.GetMethodsResult[2] = "SCADAAnalogChangedNotification";
                response.GetMethodsResult[3] = "SCADAStatusChangedNotification";
                return response;
            }
            catch (Exception ex)
            {
                LogError(String.Format("GetMethods() ex:{0}", ex));
                response.GetMethodsResult = new string[1];
                errorObject[] eObject = new errorObject[1];
                eObject[0] = new errorObject();
                eObject[0].Value = ex.Message;
                response.GetMethodsResult[0] = ex.Message;
                return response;
            }
        }
        public SCADAAnalogChangedNotificationResponse SCADAAnalogChangedNotification(SCADAAnalogChangedNotificationRequest request)
        {
            LogInfo("SCADAAnalogChangedNotification() Entered");
            String message = String.Empty;
            SCADAAnalogChangedNotificationResponse response = new SCADAAnalogChangedNotificationResponse();
            try
            {
                if (_UdpClient == null) {
                    String path = @"C:\\DCSystems\Logs\";
                    ConfigurationList cl = new ConfigurationList();
                    cl.Add("Process Name", "MockNotServerService");
                    cl.Add("Log Output Directory", path);
                    _Logger = new Logger(cl);

                    LogInfo("()");

                    _UdpClient = new UdpClient();
                    _UdpClient.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7373));
                }
                for (int i = 0; i < request.scadaAnalogs.Length; i++)
                {
                    if (i == 0){
                        message += String.Format("{0},{1:0.000} {2}   {3} GMT", request.scadaAnalogs[i].objectID, request.scadaAnalogs[i].value.Value, request.scadaAnalogs[i].value.units, request.scadaAnalogs[i].timeStamp);
                    }
                    else
                    {
                        message += String.Format(";{0},{1:0.000} {2}   {3} GMT", request.scadaAnalogs[i].objectID, request.scadaAnalogs[i].value.Value, request.scadaAnalogs[i].value.units, request.scadaAnalogs[i].timeStamp);

                    }
                }
                Byte[] sendBytes = Encoding.ASCII.GetBytes(message);
                _UdpClient.Send(sendBytes, sendBytes.Length);

                response.MultiSpeakMsgHeader = new MultiSpeakMsgHeader();
                response.MultiSpeakMsgHeader.TimeStampSpecified = true;
                response.MultiSpeakMsgHeader.TimeStamp = DateTime.Now;
                response.SCADAAnalogChangedNotificationResult = null;
                return response;
            }
            catch (Exception ex)
            {
                LogError(String.Format("SCADAAnalogChangedNotification() ex:{0}", ex));
                response.SCADAAnalogChangedNotificationResult = new errorObject[1];
                response.SCADAAnalogChangedNotificationResult[0] = new errorObject();
                response.SCADAAnalogChangedNotificationResult[0].Value = ex.Message;
                return response;
            }
        }
        public SCADAStatusChangedNotificationResponse SCADAStatusChangedNotification(SCADAStatusChangedNotificationRequest request)
        {
            LogInfo("SCADAStatusChangedNotification() Entered");
            SCADAStatusChangedNotificationResponse response = null;
            String message = String.Empty;
            try
            {
                if (_UdpClient == null) {
                    String path = @"C:\\DCSystems\Logs\";
                    ConfigurationList cl = new ConfigurationList();
                    cl.Add("Process Name", "MockNotServerService");
                    cl.Add("Log Output Directory", path);
                    _Logger = new Logger(cl);

                    LogInfo("()");

                    _UdpClient = new UdpClient();
                    _UdpClient.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7373));
                }
                response = new SCADAStatusChangedNotificationResponse();
                response.MultiSpeakMsgHeader = new MultiSpeakMsgHeader();
                response.MultiSpeakMsgHeader.TimeStampSpecified = true;
                response.MultiSpeakMsgHeader.TimeStamp = DateTime.Now;
                response.SCADAStatusChangedNotificationResult = null;

                Byte[] sendBytes = Encoding.ASCII.GetBytes(message);
                _UdpClient.Send(sendBytes, sendBytes.Length);

                return response;
            }
            catch (Exception ex)
            {
                LogError(String.Format("SCADAStatusChangedNotification() ex:{0}", ex));
                response.SCADAStatusChangedNotificationResult = new errorObject[1];
                response.SCADAStatusChangedNotificationResult[0] = new errorObject();
                response.SCADAStatusChangedNotificationResult[0].Value = ex.Message;
                return response;
            }
        }
    }

