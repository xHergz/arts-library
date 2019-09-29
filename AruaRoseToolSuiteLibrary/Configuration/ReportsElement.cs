using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AruaRoseToolSuiteLibrary.Configuration
{
    public class ReportsElement
    {
        public static string TAG = "Reports";

        private const string SENDER_EMAIL_ATTRIBUTE = "senderEmail";

        private const string PASSWORD_ATTRIBUTE = "password";

        private const string MAIL_SERVER_ATTRIBUTE = "mailServer";

        private const string PORT_ATTRIBUTE = "port";

        private string _senderEmail;

        private string _password;

        private string _mailServer;

        private string _port;

        private List<ReportElement> _reportElements;

        public ReportsElement(string senderEmail, string password, string mailServer, string port)
        {
            _senderEmail = senderEmail;
            _password = password;
            _mailServer = mailServer;
            _port = port;
            _reportElements = new List<ReportElement>();
        }

        public static ReportsElement Parse(XElement element, List<string> reportKeys)
        {
            if (element == null)
            {
                throw new FormatException($"'{TAG}' tag not found.");
            }

            XAttribute senderEmailAttribute = element.Attribute(SENDER_EMAIL_ATTRIBUTE);
            XAttribute passwordAttribute = element.Attribute(PASSWORD_ATTRIBUTE);
            XAttribute mailServerAttribute = element.Attribute(MAIL_SERVER_ATTRIBUTE);
            XAttribute portAttribute = element.Attribute(PORT_ATTRIBUTE);

            if (senderEmailAttribute == null)
            {
                throw new FormatException($"'{SENDER_EMAIL_ATTRIBUTE}' attribute of {TAG} element is missing.");
            }

            if (passwordAttribute == null)
            {
                throw new FormatException($"'{PASSWORD_ATTRIBUTE}' attribute of {TAG} element is missing.");
            }

            if (mailServerAttribute == null)
            {
                throw new FormatException($"'{MAIL_SERVER_ATTRIBUTE}' attribute of {TAG} element is missing.");
            }

            if (portAttribute == null)
            {
                throw new FormatException($"'{PORT_ATTRIBUTE}' attribute of {TAG} element is missing.");
            }

            ReportsElement configElement = new ReportsElement(
                senderEmailAttribute.Value,
                passwordAttribute.Value,
                mailServerAttribute.Value,
                portAttribute.Value
            );

            foreach(string key in reportKeys)
            {
                configElement.AddReport(ReportElement.Parse(element.Element(key), key));
            }

            return configElement;
        }

        public EmailReportingConfiguration ToEmailReportingConfiguration()
        {
            if (!int.TryParse(_port, out int port))
            {
                throw new FormatException($"Port '{_port}' was unable to be parsed.");
            }

            EmailReportingConfiguration config = new EmailReportingConfiguration(_senderEmail, _password, _mailServer, port);
            foreach (ReportElement element in _reportElements)
            {
                config.AddReport(element.ToReportEmailConfiguration());
            }
            return config;
        }

        private void AddReport(ReportElement report)
        {
            _reportElements.Add(report);
        }
    }
}
