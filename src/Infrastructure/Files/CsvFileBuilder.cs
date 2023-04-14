using System.Globalization;
using CsvHelper;
using Sat.Recruitment.Application.Common.Interfaces;
using Sat.Recruitment.Application.Users.Queries.ExportUsers;
using Sat.Recruitment.Infrastructure.Files.Maps;

namespace Sat.Recruitment.Infrastructure.Files;

public class CsvFileBuilder : ICsvFileBuilder
{
    public byte[] BuildUserRecordsFile(IEnumerable<UserFileRecord> records)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream))
        {
            using var csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);

            csvWriter.Context.RegisterClassMap<UserRecordMap>();
            csvWriter.WriteRecords(records);
        }
        return memoryStream.ToArray();
    }
}
