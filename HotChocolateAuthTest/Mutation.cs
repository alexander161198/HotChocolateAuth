using HotChocolateAuthTest.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotChocolateAuthTest
{
    public class Mutation
    {
        public Task<string> GetToken(string email, string password, [Service] IIdentityService identityService) =>
            identityService.Authenticate(email, password);
    }
}
