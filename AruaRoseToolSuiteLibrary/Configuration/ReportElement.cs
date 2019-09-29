using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace AruaRoseToolSuiteLibrary.Configuration
{
    public class ReportElement
    {
        private const string SUBJECT_ATTRIBUTE = "subject";

        private const string TO_TAG = "To";

        private const string CC_TAG = "Cc";

        private List<string> _toList;

        private List<string> _ccList;

        private string _subject;

        public string Key { get; private set; }

        public ReportElement(string key, string subject)
        {
            Key = key;
            _subject = subject;
            _toList = new List<string>();
            _ccList = new List<string>();
        }

        public static ReportElement Parse(XElement element, string elementTag)
        {
            if (element == null)
            {
                throw new FormatException($"'{elementTag}' tag not found.");
            }

            XAttribute subjectAttribute = element.Attribute(SUBJECT_ATTRIBUTE);

            if (subjectAttribute == null)
            {
                throw new FormatException($"'{SUBJECT_ATTRIBUTE}' attribute of {elementTag} element is missing.");
            }

            ReportElement configElement = new ReportElement(
                elementTag,
                subjectAttribute.Value
            );

            foreach (XElement toElement in element.Descendants(TO_TAG))
            {
                configElement.AddToRecipient(toElement.Value);
            }

            foreach(XElement ccElement in element.Descendants(CC_TAG))
            {
                configElement.AddCcRecipient(ccElement.Value);
            }

            return configElement;
        }

        public ReportEmailConfiguration ToReportEmailConfiguration()
        {
            ReportEmailConfiguration config = new ReportEmailConfiguration(Key, _subject);

            foreach(string to in _toList)
            {
                config.AddToRecipient(to);
            }

            foreach(string cc in _ccList)
            {
                config.AddCcRecipient(cc);
            }

            return config;
        }

        private void AddToRecipient(string to)
        {
            _toList.Add(to);
        }

        private void AddCcRecipient(string cc)
        {
            _ccList.Add(cc);
        }
    }
}
