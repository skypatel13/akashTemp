using CaseManagement.Models.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Net.Mail;
using System.Xml.Serialization;

namespace CaseManagement.UtilityLibrary
{
    public static class Utility
    {
        public static string GetIPAddress(HttpRequest httpRequest)
        {
            return httpRequest.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        public static string GetUserAgent(HttpRequest httpRequest)
        {
            return httpRequest.Headers["User-Agent"].ToString();
        }

        public static string GetXMLString(Object obj)
        {
            XmlSerializer x = new XmlSerializer(obj.GetType());
            var stringWriter = new StringWriter();
            x.Serialize(stringWriter, obj);
            var xmlStringContent = stringWriter.ToString();
            return xmlStringContent;
        }
        public static DataUpdateResponseDTO SendEmail(string mailTo, string mailSubject, string mailContent)
        {
            DataUpdateResponseDTO dataUpdateResponseDTO = new DataUpdateResponseDTO();
            try
            {
                MyAppSettingsOptions myAppSettingsOptions = GetAppSettings();

                //var AppName = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection(MyAppSettingsOptions.MyAppSettings).Get<MyAppSettingsOptions>();
                //MailMessage mail = new MailMessage();
                //SmtpClient smtpServer = new SmtpClient("smtp.gmail.com");
                //mail.From = new MailAddress("contactkrishnasoftech@gmail.com");
                //mail.To.Add(mailTo);
                //mail.Subject = mailSubject;
                //mail.Body = mailContent;
                //smtpServer.Port = 587;
                //smtpServer.UseDefaultCredentials = false;
                //smtpServer.Credentials = new System.Net.NetworkCredential("contactkrishnasoftech@gmail.com", "vtpxdrktqfjfhzyd");
                //smtpServer.EnableSsl = true;
                //smtpServer.Send(mail);
                //return true;
                MailMessage mail = new MailMessage();
                SmtpClient smtpServer = new SmtpClient(myAppSettingsOptions.MailSMTPServer);
                mail.From = new MailAddress(myAppSettingsOptions.MailId);
                mail.To.Add(mailTo);
                mail.Subject = mailSubject;
                mail.Body = mailContent;
                smtpServer.Port = Convert.ToInt32(myAppSettingsOptions.MailPort);
                smtpServer.UseDefaultCredentials = false;
                smtpServer.Credentials = new System.Net.NetworkCredential(myAppSettingsOptions.MailId, myAppSettingsOptions.MailPW);
                smtpServer.EnableSsl = false;
                smtpServer.Send(mail);
                dataUpdateResponseDTO.Description = "Mail has been sent successfuly";
                dataUpdateResponseDTO.RecordCount = 1;
                dataUpdateResponseDTO.Status = true;
                return dataUpdateResponseDTO;
            }
            catch (Exception ex)
            {
                dataUpdateResponseDTO.Description = ex.ToString();
                dataUpdateResponseDTO.RecordCount = 0;
                dataUpdateResponseDTO.Status = false;
                return dataUpdateResponseDTO;
            }
        }

        private static MyAppSettingsOptions GetAppSettings()
        {
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var envResult = config.GetSection("Env").GetSection("Env").Value;
            var AppName = new MyAppSettingsOptions();
            if (envResult == ".Development")
            {
                AppName = new ConfigurationBuilder().AddJsonFile("appsettings.Development.json").Build().GetSection(MyAppSettingsOptions.MyAppSettings).Get<MyAppSettingsOptions>();
            }
            else
            {
                AppName = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection(MyAppSettingsOptions.MyAppSettings).Get<MyAppSettingsOptions>();
            }
            return AppName;
        }
        public static void CreateSurvivorDocFolders(string SurvivorCode)
        {
            MyAppSettingsOptions myAppSettingsOptions = GetAppSettings();
            var specificSurvivorFolderPath = Path.Combine(myAppSettingsOptions.BasePath, myAppSettingsOptions.Survivor, SurvivorCode);
            System.IO.Directory.CreateDirectory(specificSurvivorFolderPath);
            System.IO.Directory.CreateDirectory(Path.Combine(specificSurvivorFolderPath, myAppSettingsOptions.ConsentForm));
            System.IO.Directory.CreateDirectory(Path.Combine(specificSurvivorFolderPath, myAppSettingsOptions.FIR));
            System.IO.Directory.CreateDirectory(Path.Combine(specificSurvivorFolderPath, myAppSettingsOptions.GD));
            System.IO.Directory.CreateDirectory(Path.Combine(specificSurvivorFolderPath, myAppSettingsOptions.Loan));
            System.IO.Directory.CreateDirectory(Path.Combine(specificSurvivorFolderPath, myAppSettingsOptions.PC));
            System.IO.Directory.CreateDirectory(Path.Combine(specificSurvivorFolderPath, myAppSettingsOptions.PC, myAppSettingsOptions.PCApplication));
            System.IO.Directory.CreateDirectory(Path.Combine(specificSurvivorFolderPath, myAppSettingsOptions.PC, myAppSettingsOptions.PCOrder));
            System.IO.Directory.CreateDirectory(Path.Combine(specificSurvivorFolderPath, myAppSettingsOptions.Photo));
            System.IO.Directory.CreateDirectory(Path.Combine(specificSurvivorFolderPath, myAppSettingsOptions.SpecificDoc));
            System.IO.Directory.CreateDirectory(Path.Combine(specificSurvivorFolderPath, myAppSettingsOptions.VC));
            System.IO.Directory.CreateDirectory(Path.Combine(specificSurvivorFolderPath, myAppSettingsOptions.VC, myAppSettingsOptions.VCApplication));
            System.IO.Directory.CreateDirectory(Path.Combine(specificSurvivorFolderPath, myAppSettingsOptions.VC, myAppSettingsOptions.VCOrder));
            System.IO.Directory.CreateDirectory(Path.Combine(specificSurvivorFolderPath, myAppSettingsOptions.ChargeSheet));
        }
        public static void CreateDocumnetFolder()
        {
            MyAppSettingsOptions myAppSettingsOptions = GetAppSettings();
            System.IO.Directory.CreateDirectory(Path.Combine(myAppSettingsOptions.BasePath, myAppSettingsOptions.Act));
            System.IO.Directory.CreateDirectory(Path.Combine(myAppSettingsOptions.BasePath, myAppSettingsOptions.Section));
            System.IO.Directory.CreateDirectory(Path.Combine(myAppSettingsOptions.BasePath, myAppSettingsOptions.Survivor));
        }
    }
}