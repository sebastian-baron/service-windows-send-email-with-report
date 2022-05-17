using ReportService.Core.Domains;
using System;
using System.Collections.Generic;

namespace ReportService.Core.Repositories
{
    public class ReportRepository
    {
        public Report GetLastNotSentReport()
        {
            //Get the last report from the database
            return new Report
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
        }

        public void ReportSend(Report report)
        {
            report.IsSend = true;
            //here save in database
        }
    }
}