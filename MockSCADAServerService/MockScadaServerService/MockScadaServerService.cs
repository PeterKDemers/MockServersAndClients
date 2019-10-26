using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

public class MockScadaServerService : SCADA_ServerSoap
    {
        public PingURLResponse PingURL(PingURLRequest request)
        {
            PingURLResponse response = new PingURLResponse();
            try
            {
                response.MultiSpeakMsgHeader = new MultiSpeakMsgHeader();
                response.MultiSpeakMsgHeader.MinorVersion = "4";
                response.MultiSpeakMsgHeader.MinorVersion = "1";
                response.MultiSpeakMsgHeader.Build = "73";  // 8
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
                response.PingURLResult = new errorObject[1];
                response.PingURLResult[0].objectID = "DCSystem";
                response.PingURLResult[0].errorString = ex.Message;
                return response;
            }
        }
        public GetMethodsResponse GetMethods(GetMethodsRequest request)
        {
            GetMethodsResponse response = null;
            try
            {
                response = new GetMethodsResponse();
                response.MultiSpeakMsgHeader = new MultiSpeakMsgHeader();
                response.MultiSpeakMsgHeader.TimeStampSpecified = true;
                response.MultiSpeakMsgHeader.TimeStamp = DateTime.Now;
                response.GetMethodsResult = new string[5];
                response.GetMethodsResult[0] = "GetMethods";
                response.GetMethodsResult[1] = "PingURL";
                response.GetMethodsResult[2] = "GetAllSCADAPoints";
                response.GetMethodsResult[3] = "GetSCADAAnalogBySCADAPointID";
                response.GetMethodsResult[4] = "GetSCADAStatusBySCADAPointID";
                return response;
            }
            catch (Exception ex)
            {
                response.GetMethodsResult = new string[1];
                errorObject[] eObject = new errorObject[1];
                eObject[0] = new errorObject();
                eObject[0].Value = ex.Message;
                response.GetMethodsResult[0] = ex.Message;
                return response;
            }
        }
        public GetAllSCADAPointsResponse GetAllSCADAPoints(GetAllSCADAPointsRequest request)
        {
            const int NUM_POINTS = 2048;
            GetAllSCADAPointsResponse response = new GetAllSCADAPointsResponse();
            try
            {
                response.MultiSpeakMsgHeader = new MultiSpeakMsgHeader();
                response.MultiSpeakMsgHeader.TimeStampSpecified = true;
                response.MultiSpeakMsgHeader.TimeStamp = DateTime.Now;
                response.MultiSpeakMsgHeader.ObjectsRemaining = "0";            // ???????????????????????????
                response.GetAllSCADAPointsResult = new scadaPoint[NUM_POINTS];
                bool analog = true;
                for (int i = 0; i < NUM_POINTS; i++)
                {
                    response.GetAllSCADAPointsResult[i] = new scadaPoint();
                    if (analog) {
                        response.GetAllSCADAPointsResult[i].objectName = string.Format("Analog{0:0000}", i);
                        response.GetAllSCADAPointsResult[i].scadaPointType = scadaPointType.analog;
                    } else {
                        response.GetAllSCADAPointsResult[i].objectName = string.Format("Status{0:0000}", i);
                        response.GetAllSCADAPointsResult[i].scadaPointType = scadaPointType.status;
                    }
                    response.GetAllSCADAPointsResult[i].scadaPointTypeSpecified = true;
                    analog = !analog;
                }
                return response;
            }
            catch (Exception ex)
            {
                errorObject[] eObject = new errorObject[1];
                eObject[0] = new errorObject();
                eObject[0].Value = ex.Message;
                return response;
            }
        }
        public GetSCADAAnalogBySCADAPointIDResponse GetSCADAAnalogBySCADAPointID(GetSCADAAnalogBySCADAPointIDRequest request)
        {
            Random r = new Random();
            GetSCADAAnalogBySCADAPointIDResponse response = new GetSCADAAnalogBySCADAPointIDResponse();
            try
            {
                response.MultiSpeakMsgHeader = new MultiSpeakMsgHeader();
                response.MultiSpeakMsgHeader.TimeStampSpecified = true;
                response.MultiSpeakMsgHeader.TimeStamp = DateTime.Now;
                response.GetSCADAAnalogBySCADAPointIDResult = new scadaAnalog();
                response.GetSCADAAnalogBySCADAPointIDResult.objectID = request.scadaPointID;
                response.GetSCADAAnalogBySCADAPointIDResult.value = new value();
                response.GetSCADAAnalogBySCADAPointIDResult.value.units = uom.V;
                response.GetSCADAAnalogBySCADAPointIDResult.value.unitsSpecified = true;
                response.GetSCADAAnalogBySCADAPointIDResult.value.Value = (float)r.NextDouble();
                return response;
            }
            catch (Exception ex)
            {
                errorObject[] eObject = new errorObject[1];
                eObject[0] = new errorObject();
                eObject[0].Value = ex.Message;
                return response;
            }
        }
        public GetSCADAStatusBySCADAPointIDResponse GetSCADAStatusBySCADAPointID(GetSCADAStatusBySCADAPointIDRequest request)
        {
            Random r = new Random();
            GetSCADAStatusBySCADAPointIDResponse response = new GetSCADAStatusBySCADAPointIDResponse();
            try
            {
                response.MultiSpeakMsgHeader = new MultiSpeakMsgHeader();
                response.MultiSpeakMsgHeader.TimeStampSpecified = true;
                response.MultiSpeakMsgHeader.TimeStamp = DateTime.Now;
                response.GetSCADAStatusBySCADAPointIDResult = new scadaStatus();
                response.GetSCADAStatusBySCADAPointIDResult.objectID = request.scadaPointID;
                response.GetSCADAStatusBySCADAPointIDResult.status = statusIdentifiers.Closed;
                response.GetSCADAStatusBySCADAPointIDResult.timeStamp = DateTime.Now;
                response.GetSCADAStatusBySCADAPointIDResult.timeStampSpecified = true;
                return response;
            }
            catch (Exception ex)
            {
                errorObject[] eObject = new errorObject[1];
                eObject[0] = new errorObject();
                eObject[0].Value = ex.Message;
                return response;
            }
        }
    }

