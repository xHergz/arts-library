using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace AruaRoseToolSuiteLibrary.Configuration
{
    public class EmailReportingConfiguration
    {
        private Dictionary<string, ReportEmailConfiguration> _reportConfigurations;

        public string SenderEmail { get; private set; }

        public string Password { get; private set; }

        public string MailServer { get; private set; }

        public int Port { get; private set; }

        public int ReportCount { get { return _reportConfigurations.Count; } }

        public EmailReportingConfiguration()
        {
            DefaultConfiguration();
        }

        public EmailReportingConfiguration(string senderEmail, string password, string mailServer, int port)
        {
            SenderEmail = senderEmail;
            Password = password;
            MailServer = mailServer;
            Port = port;
            _reportConfigurations = new Dictionary<string, ReportEmailConfiguration>();
        }

        public static EmailReportingConfiguration LoadFromFile(string configFilePath, List<string> reportKeys)
        {
            if (!File.Exists(configFilePath))
            {
                throw new FileNotFoundException($"Logging configuration file at '{configFilePath}' not found.");
            }

            XDocument config = XDocument.Load(configFilePath);
            return LoadConfiguration(config, reportKeys);
        }

        public static EmailReportingConfiguration LoadFromString(string configuration, List<string> reportKeys)
        {
            if (string.IsNullOrWhiteSpace(configuration))
            {
                throw new ArgumentNullException("Configuration is null, empty, or whitespace.");
            }

            XDocument config = XDocument.Parse(configuration);
            return LoadConfiguration(config, reportKeys);
        }

        public bool AddReport(ReportEmailConfiguration report)
        {
            if (_reportConfigurations.ContainsKey(report.ReportName))
            {
                return false;
            }

            _reportConfigurations.Add(report.ReportName, report);
            return true;
        }

        public ReportEmailConfiguration GetReportEmailConfiguration(string key)
        {
            if (!_reportConfigurations.ContainsKey(key))
            {
                return null;
            }

            return _reportConfigurations[key];
        }

        private static EmailReportingConfiguration LoadConfiguration(XDocument configDoc, List<string> reportKeys)
        {
            ReportsElement reportsElement = ReportsElement.Parse(
                configDoc.Element(ReportsElement.TAG),
                reportKeys
            );
            return reportsElement.ToEmailReportingConfiguration();
        }

        private void DefaultConfiguration()
        {
            SenderEmail = null;
            Password = null;
            MailServer = null;
            Port = -1;
            _reportConfigurations = new Dictionary<string, ReportEmailConfiguration>();
        }
    }
}
