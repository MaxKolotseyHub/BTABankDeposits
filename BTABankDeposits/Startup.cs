using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BTABankDeposits.Startup))]
namespace BTABankDeposits
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
