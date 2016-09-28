using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;

namespace Ldme.EF.Setup
{
    //public class LdmeContextFactory: IDbContextFactory<LdmeContext>
    //{
    //    private readonly IConfigurationRoot _config;

    //    public LdmeContextFactory(IConfigurationRoot config) // the shit requires parameterless constructor, how the fuck
    //    {
    //        _config = config;
    //    }

    //    public LdmeContext Create(DbContextFactoryOptions options)
    //    {
    //        return new LdmeContext(_config);
    //    }
    //}
}
