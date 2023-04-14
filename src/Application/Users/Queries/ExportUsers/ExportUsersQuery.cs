using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Sat.Recruitment.Application.Common.Interfaces;

namespace Sat.Recruitment.Application.Users.Queries.ExportUsers;

public record ExportUsersQuery : IRequest<ExportUsersVm>
{}

public class ExportUsersQueryHandler : IRequestHandler<ExportUsersQuery, ExportUsersVm>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ICsvFileBuilder _fileBuilder;
    public ExportUsersQueryHandler(IApplicationDbContext context, IMapper mapper, ICsvFileBuilder fileBuilder)
    {
        _context = context;
        _mapper = mapper;
        _fileBuilder = fileBuilder;
    }
    public async Task<ExportUsersVm> Handle(ExportUsersQuery request, CancellationToken cancellationToken)
    {
        var userRecords = await _context.User
                       .ProjectTo<UserFileRecord>(_mapper.ConfigurationProvider)
                       .ToListAsync(cancellationToken);

        var vm = new ExportUsersVm(
            "UsersRecords.csv",
            "text/csv",
            _fileBuilder.BuildUserRecordsFile(userRecords));

        return vm;
    }
}