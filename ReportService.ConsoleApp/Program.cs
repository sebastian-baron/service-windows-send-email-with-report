using Cipher;
using EmailSender;
using ReportService.Core;
using ReportService.Core.Domains;
using System;
using System.Collections.Generic;

namespace ReportService.ConsoleApp
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var emailReceiver = "";
            var htmlEmail = new GenerateHtmlEmail();

            var email = new Email(new EmailParams
            {
                HostSmtp = "",
                Port = 587,
                EnableSsl = true,
                SenderName = "",
                SenderEmail = "",
                SenderEmailPassword = ""
            });

            var report = new Report
            {
                Id = 1,
                Title = "R/1/2022",
                Date = new DateTime(2022, 1, 1, 12, 0, 0),
                IsSend = false,
                Positions = new List<ReportPosition>
                {
                    new ReportPosition
                    {
                        Id = 1,
                        ReportId = 1,
                        Title = "Title 1",
                        Description = "Description 1",
                        Value = 43.01M
                    },
                    new ReportPosition
                    {
                        Id = 2,
                        ReportId = 2,
                        Title = "Title 2",
                        Description = "Description 2",
                        Value = 431M
                    },
                    new ReportPosition
                    {
                        Id = 3,
                        ReportId = 3,
                        Title = "Title 3",
                        Description = "Description 3",
                        Value = 13.01M
                    }
                }
            };

            var errors = new List<Error>
            {
                new Error {Message = "Error message 1", Date = DateTime.Now },
                new Error {Message = "Error message 2", Date = DateTime.Now }
            };

            Console.WriteLine("Send email (Report day");

            email.Send("Report day", htmlEmail.GenerateReport(report), emailReceiver).Wait();

            Console.WriteLine("Send email (Error application");

            email.Send("Error application", htmlEmail.GenerateErrors(errors, 10), emailReceiver).Wait();

            Console.WriteLine("Send");
        }
    }
}