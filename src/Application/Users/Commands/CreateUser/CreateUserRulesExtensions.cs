using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sat.Recruitment.Domain.Enums;
namespace Sat.Recruitment.Application.Users.Commands.CreateUser;
internal static class CreateUserRulesExtensions
{
    public static decimal IncreaseValue(int userType, float moneyValue)
    {
        switch (userType)
        {
            case (int)UserType.Normal:
                return handleNormalUser(moneyValue);
            case (int)UserType.SuperUser:
                return handleSuperUser(moneyValue);
            case (int)UserType.Premium:
                return handlePremiumUser(moneyValue);
            default:
                return 0;
        }
    }
    public static decimal handleNormalUser(float value)
    {
        return value > 100 ? (decimal)value * 0.12M : (decimal)value * 0.8M;
    }
    
    public static decimal handleSuperUser(float value)
    {
        return value > 100 ? (decimal)value * 0.20M : 0;
    }

    public static decimal handlePremiumUser(float value)
    {
        return value > 100 ? (decimal)value * 2M : 0;
    }
}
