using System.Globalization;
using CsvHelper.Configuration;
using Sat.Recruitment.Application.Users.Queries.ExportUsers;

namespace Sat.Recruitment.Infrastructure.Files.Maps;

public class UserRecordMap : ClassMap<UserFileRecord>
{
    public UserRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);
    }
}
