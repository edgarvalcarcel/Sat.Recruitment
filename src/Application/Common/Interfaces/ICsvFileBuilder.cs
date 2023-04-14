using Sat.Recruitment.Application.Users.Queries.ExportUsers;

namespace Sat.Recruitment.Application.Common.Interfaces;

public interface ICsvFileBuilder
{
    byte[] BuildUserRecordsFile(IEnumerable<UserFileRecord> records);
}
