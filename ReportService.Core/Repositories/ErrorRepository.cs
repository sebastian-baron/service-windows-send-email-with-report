using ReportService.Core.Domains;
using System;
using System.Collections.Generic;

namespace ReportService.Core.Repositories
{
    public class ErrorRepository
    {
        public List<Error> GetLastErrors(int intervalInMinutes)
        {
            return new List<Error>
            {
                new Error {Message = "Error test 1", Date = DateTime.Now },
                new Error {Message = "Error test 2", Date = DateTime.Now }
            };
        }
    }
}