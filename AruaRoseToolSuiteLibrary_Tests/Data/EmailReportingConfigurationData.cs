using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AruaRoseToolSuiteLibrary_Tests.Data
{
    public class EmailReportingConfigurationData
    {
        public static string MISSING_CONFIG_FILE = "missingFile.config";

        public static string SENDER_EMAIL = "sender@test.com";

        public static string PASSWORD = "password";

        public static string MAIL_SERVER = "test.mail.localhost";

        public static int PORT = 200;

        public static string REPORT_NAME = "TestReport";

        public static string RECIPIENT = "recipient@test.com";

        public static string SUBJECT = "Test Subject";

        public static string NO_REPORTS_CONFIG = 
            $@"<?xml version=""1.0"" encoding=""UTF-8""?>
            <Reports
                senderEmail = ""{SENDER_EMAIL}""
                password= ""{PASSWORD}""
                mailServer= ""{MAIL_SERVER}""
                port= ""{PORT}""
            >
            </Reports>";

        public static string ONE_REPORT_CONFIG =
            $@"<?xml version=""1.0"" encoding=""UTF-8""?>
            <Reports
                senderEmail = ""{SENDER_EMAIL}""
                password= ""{PASSWORD}""
                mailServer= ""{MAIL_SERVER}""
                port= ""{PORT}""
            >
                <{REPORT_NAME}
                    subject=""{SUBJECT}""
                >
                    <ToList>
                        <To>{RECIPIENT}</To>
                    </ToList>
                    <CcList>
                    </CcList>
                </{REPORT_NAME}>
            </Reports>";

        public static string MISSING_ROOT_CONFIG = 
            $@"<?xml version=""1.0"" encoding=""UTF-8""?>";

        public static string MISSING_ELEMENT_CONFIG =
            $@"<?xml version=""1.0"" encoding=""UTF-8""?>
            <WrongElement></WrongElement>";

        public static string MISSING_ATTRIBUTE_CONFIG =
            $@"<?xml version=""1.0"" encoding=""UTF-8""?>
            <Reports
                password= ""{PASSWORD}""
                mailServer= ""{MAIL_SERVER}""
                port= ""{PORT}""
            >
            </Reports>";

        public static string MISSING_REPORT_CONFIG =
            $@"<?xml version=""1.0"" encoding=""UTF-8""?>
            <Reports
                senderEmail = ""{SENDER_EMAIL}""
                password= ""{PASSWORD}""
                mailServer= ""{MAIL_SERVER}""
                port= ""{PORT}""
            >
                <WrongReport
                    subject=""{SUBJECT}""
                >
                    <ToList>
                        <To>{RECIPIENT}</To>
                    </ToList>
                    <CcList>
                    </CcList>
                </WrongReport>
            </Reports>";

        public static string MISSING_REPORT_ELEMENT_CONFIG =
            $@"<?xml version=""1.0"" encoding=""UTF-8""?>
            <Reports
                senderEmail = ""{SENDER_EMAIL}""
                password= ""{PASSWORD}""
                mailServer= ""{MAIL_SERVER}""
                port= ""{PORT}""
            >
                <{REPORT_NAME}
                    subject=""{SUBJECT}""
                >
                    <CcList>
                    </CcList>
                </{REPORT_NAME}>
            </Reports>";

        public static string INVALID_PORT_CONFIG =
            $@"<?xml version=""1.0"" encoding=""UTF-8""?>
            <Reports
                senderEmail = ""{SENDER_EMAIL}""
                password= ""{PASSWORD}""
                mailServer= ""{MAIL_SERVER}""
                port= ""string""
            >
                <{REPORT_NAME}
                    subject=""{SUBJECT}""
                >
                    <ToList>
                        <To>{RECIPIENT}</To>
                    </ToList>
                    <CcList>
                    </CcList>
                </{REPORT_NAME}>
            </Reports>";

        public static string MISSING_SUBJECT_CONFIG =
            $@"<?xml version=""1.0"" encoding=""UTF-8""?>
            <Reports
                senderEmail = ""{SENDER_EMAIL}""
                password= ""{PASSWORD}""
                mailServer= ""{MAIL_SERVER}""
                port= ""{PORT}""
            >
                <{REPORT_NAME}>
                    <ToList>
                        <To>{RECIPIENT}</To>
                    </ToList>
                    <CcList>
                    </CcList>
                </{REPORT_NAME}>
            </Reports>";
    }
}
