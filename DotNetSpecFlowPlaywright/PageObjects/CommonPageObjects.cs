using Microsoft.Playwright;
using System.Threading.Tasks;

namespace DotNetSpecFlowPlaywright.PageObjects
{
    public class CommonPageObjects
    {
        
        public async Task GivenUserNavigateToOnboardingFlow(IPage page)
        {
            await page.GotoAsync("https://onboard-dev.henrymeds.com/ ");
        }

    }
}
