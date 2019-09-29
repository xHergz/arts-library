using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using AruaRoseToolSuiteLibrary.Configuration;
using AruaRoseToolSuiteLibrary_Tests.Data;
using NUnit.Framework;

namespace AruaRoseToolSuiteLibrary_Tests
{
    public class EmailReportingConfiguration_Tests
    {
        private EmailReportingConfiguration _configuration;

        private List<string> _reportKeys;

        [SetUp]
        public void SetUp()
        {
            _reportKeys = new List<string>() { EmailReportingConfigurationData.REPORT_NAME };
        }

        [Test]
        public void Constructor_WithDefaults_ReturnsDefaultObject()
        {
            _configuration = new EmailReportingConfiguration();
            Assert.IsNull(_configuration.SenderEmail);
            Assert.IsNull(_configuration.Password);
            Assert.IsNull(_configuration.MailServer);
            Assert.AreEqual(-1, _configuration.Port);
            Assert.AreEqual(0, _configuration.ReportCount);
        }

        [Test]
        public void Constructor_WithArguments_ReturnsObject()
        {
            _configuration = new EmailReportingConfiguration(EmailReportingConfigurationData.SENDER_EMAIL, EmailReportingConfigurationData.PASSWORD,
                EmailReportingConfigurationData.MAIL_SERVER, EmailReportingConfigurationData.PORT);
            Assert.AreEqual(EmailReportingConfigurationData.SENDER_EMAIL, _configuration.SenderEmail);
            Assert.AreEqual(EmailReportingConfigurationData.PASSWORD, _configuration.Password);
            Assert.AreEqual(EmailReportingConfigurationData.MAIL_SERVER, _configuration.MailServer);
            Assert.AreEqual(EmailReportingConfigurationData.PORT, _configuration.Port);
            Assert.AreEqual(0, _configuration.ReportCount);
        }

        [Test]
        public void LoadFromFile_WithNullPath_ThrowsException()
        {
            Assert.Throws<FileNotFoundException>(() =>
            {
                _configuration = EmailReportingConfiguration.LoadFromFile(null, _reportKeys);
            });
        }

        [Test]
        public void LoadFromFile_WithMissingConfigFile_ThrowsException()
        {
            Assert.Throws<FileNotFoundException>(() =>
            {
                _configuration = EmailReportingConfiguration.LoadFromFile(
                    EmailReportingConfigurationData.MISSING_CONFIG_FILE,
                    _reportKeys
                );
            });
        }

        [Test]
        public void LoadFromString_WithNullString_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _configuration = EmailReportingConfiguration.LoadFromString(null, _reportKeys);
            });
        }

        [Test]
        public void LoadFromString_WithEmptyString_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                _configuration = EmailReportingConfiguration.LoadFromString(string.Empty, _reportKeys);
            });
        }

        [Test]
        public void LoadFromString_WithMissingRootElement_ThrowsException()
        {
            Assert.Throws<XmlException>(() =>
            {
                _configuration = EmailReportingConfiguration.LoadFromString(
                    EmailReportingConfigurationData.MISSING_ROOT_CONFIG,
                    _reportKeys
                );
            });
        }

        [Test]
        public void LoadFromString_WithMissingAttribute_ThrowsException()
        {
            Assert.Throws<FormatException>(() =>
            {
                _configuration = EmailReportingConfiguration.LoadFromString(
                    EmailReportingConfigurationData.MISSING_ATTRIBUTE_CONFIG,
                    _reportKeys
                );
            });
        }

        [Test]
        public void LoadFromString_WithMissingReport_ThrowsException()
        {
            Assert.Throws<FormatException>(() =>
            {
                _configuration = EmailReportingConfiguration.LoadFromString(
                    EmailReportingConfigurationData.MISSING_REPORT_CONFIG,
                    _reportKeys
                );
            });
        }

        [Test]
        public void LoadFromString_WithMissingSubject_ThrowsException()
        {
            Assert.Throws<FormatException>(() =>
            {
                _configuration = EmailReportingConfiguration.LoadFromString(
                    EmailReportingConfigurationData.MISSING_SUBJECT_CONFIG,
                    _reportKeys
                );
            });
        }

        [Test]
        public void LoadFromString_WithInvalidPort_ThrowsException()
        {
            Assert.Throws<FormatException>(() =>
            {
                _configuration = EmailReportingConfiguration.LoadFromString(
                    EmailReportingConfigurationData.INVALID_PORT_CONFIG,
                    _reportKeys
                );
            });
        }

        [Test]
        public void LoadFromString_WithWrongRootElement_ThrowsException()
        {
            Assert.Throws<FormatException>(() =>
            {
                _configuration = EmailReportingConfiguration.LoadFromString(
                    EmailReportingConfigurationData.MISSING_ELEMENT_CONFIG,
                    _reportKeys
                );
            });
        }

        [Test]
        public void LoadFromString_WithNoReports_ReturnsNoReports()
        {
            _configuration = EmailReportingConfiguration.LoadFromString(
                EmailReportingConfigurationData.NO_REPORTS_CONFIG,
                new List<string>()
            );
            Assert.AreEqual(EmailReportingConfigurationData.SENDER_EMAIL, _configuration.SenderEmail);
            Assert.AreEqual(EmailReportingConfigurationData.PASSWORD, _configuration.Password);
            Assert.AreEqual(EmailReportingConfigurationData.MAIL_SERVER, _configuration.MailServer);
            Assert.AreEqual(EmailReportingConfigurationData.PORT, _configuration.Port);
            Assert.AreEqual(0, _configuration.ReportCount);
        }

        [Test]
        public void LoadFromString_WithAReport_ReturnsReportInfo()
        {
            _configuration = EmailReportingConfiguration.LoadFromString(EmailReportingConfigurationData.ONE_REPORT_CONFIG, _reportKeys);
            ReportEmailConfiguration report = _configuration.GetReportEmailConfiguration(EmailReportingConfigurationData.REPORT_NAME);
            Assert.AreEqual(EmailReportingConfigurationData.SENDER_EMAIL, _configuration.SenderEmail);
            Assert.AreEqual(EmailReportingConfigurationData.PASSWORD, _configuration.Password);
            Assert.AreEqual(EmailReportingConfigurationData.MAIL_SERVER, _configuration.MailServer);
            Assert.AreEqual(EmailReportingConfigurationData.PORT, _configuration.Port);
            Assert.AreEqual(1, _configuration.ReportCount);
            Assert.AreEqual(EmailReportingConfigurationData.REPORT_NAME, report.ReportName);
            Assert.AreEqual(EmailReportingConfigurationData.RECIPIENT, report.ToList.FirstOrDefault());
            Assert.IsNull(report.CcList.FirstOrDefault());
            Assert.AreEqual(EmailReportingConfigurationData.SUBJECT, report.Subject);
        }

        [Test]
        public void AddReport_WithNonExistingReport_ReturnsTrue()
        {
            ReportEmailConfiguration report = new ReportEmailConfiguration(EmailReportingConfigurationData.REPORT_NAME, EmailReportingConfigurationData.SUBJECT);
            _configuration = new EmailReportingConfiguration();
            bool added = _configuration.AddReport(report);
            Assert.IsTrue(added);
        }

        [Test]
        public void AddReport_WithExistingReport_ReturnsFalse()
        {
            ReportEmailConfiguration report = new ReportEmailConfiguration(EmailReportingConfigurationData.REPORT_NAME, EmailReportingConfigurationData.SUBJECT);
            _configuration = new EmailReportingConfiguration();
            _configuration.AddReport(report);
            bool added = _configuration.AddReport(report);
            Assert.IsFalse(added);
        }

        [Test]
        public void GetReportEmailConfiguration_WithNonExistingReport_ReturnsNull()
        {
            _configuration = new EmailReportingConfiguration();
            ReportEmailConfiguration report = _configuration.GetReportEmailConfiguration(EmailReportingConfigurationData.REPORT_NAME);
            Assert.IsNull(report);
        }

        [Test]
        public void GetReportEmailConfiguration_WithExistingReport_ReturnsConfiguration()
        {
            ReportEmailConfiguration report = new ReportEmailConfiguration(EmailReportingConfigurationData.REPORT_NAME, EmailReportingConfigurationData.SUBJECT);
            _configuration = new EmailReportingConfiguration();
            _configuration.AddReport(report);
            ReportEmailConfiguration retrieved = _configuration.GetReportEmailConfiguration(EmailReportingConfigurationData.REPORT_NAME);
            Assert.IsNotNull(retrieved);
        }
    }
}
