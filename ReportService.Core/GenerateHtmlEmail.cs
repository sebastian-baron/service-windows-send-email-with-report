using ReportService.Core.Domains;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReportService.Core
{
    public class GenerateHtmlEmail
    {
        public string GenerateErrors(List<Error> errors, int interval)
        {
            if (errors == null)
            {
                throw new ArgumentException(nameof(errors));
            }

            if (!errors.Any())
            {
                return string.Empty;
            }

            var html = $"Error from last {interval} minutes.<br /><br />";
            html += @"
                <table border=1 cellpadding=5 cellspacing=1>
                    <tr>
                        <td align=center bgcolor=lightgrey>Message</td>
                        <td>Data</td>
                    </tr>
            ";

            foreach (var error in errors)
            {
                html += $@"<tr><td align=center>{error.Message}</td><td align=center>{error.Date.ToString("dd-MM-yyyy HH:mm")}</td></tr>";
            }

            html += "</table><br /><br />Automatic message sent from ReportService, please do not reply.";

            return html;
        }

        public string GenerateReport(Report report)
        {
            if (report == null)
                throw new ArgumentNullException(nameof(report));

            var html = $"Raport {report.Title} from day {report.Date.ToString("dd-MM-yyyy")}<br /><br />";

            if (report.Positions != null && report.Positions.Any())
            {
                html += @"
                <table border=1 cellpadding=5 cellspacing=1>
                    <tr>
                        <td align=center bgcolor=lightgrey>Title</td>
                        <td>Description</td>
                        <td>Value</td>
                    </tr>
                ";

                foreach (var position in report.Positions)
                {
                    html += $@"<tr><td align=center>{position.Title}</td><td align=center>{position.Description}</td><td>{position.Value.ToString("0.00")} zł</td></tr>";
                }

                html += "</table>";
            }
            else
                html += "-- No data to display";

            html += "<br /><br />Automatic message sent from ReportService, please do not reply.";

            return html;
        }
    }
}