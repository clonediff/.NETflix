using DBModels.IdentityLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.TwoFAService
{
    public interface ITwoFAService
    {
        public Task SendCodeAsync(User user);
        public bool CheckCode(User user, string code);
    }
}
