using System.Collections.Generic;

namespace AruaRoseToolSuiteLibrary.Configuration
{
    public class ReportEmailConfiguration
    {
        private List<string> _toList;

        private List<string> _ccList;

        public string ReportName { get; private set; }

        public IEnumerable<string> ToList { get { return _toList; } }

        public IEnumerable<string> CcList { get { return _ccList; } }

        public string Subject { get; private set; }

        public ReportEmailConfiguration(string reportName, string subject)
        {
            ReportName = reportName;
            Subject = subject;
            _toList = new List<string>();
            _ccList = new List<string>();
        }

        public void AddToRecipient(string to)
        {
            _toList.Add(to);
        }

        public void AddCcRecipient(string cc)
        {
            _ccList.Add(cc);
        }
    }
}
