using DotNetSpecFlowPlaywright.PageObjects;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Microsoft.Playwright;
using System.Text.RegularExpressions;


namespace DotNetSpecFlowPlaywright.Steps
{
    [Binding]
    internal class AppointmentSteps

    {
     
        private IPage _page;
        private static CommonPageObjects pageobjects;

        public AppointmentSteps(IPage page , CommonPageObjects commonPageObjects)
        {
            _page = page;
            pageobjects = commonPageObjects;


        }


        [Given(@"a user navigates to onboarding flow and reserve an appointment")]
        public async Task GivenUserReserveSuccessfulAppointment()
        {
            await pageobjects.GivenUserNavigateToOnboardingFlow(_page);
            await _page.GetByTestId("california").ClickAsync();    
            await _page.Locator("[data-testid^='2024-03']").Nth(0).ClickAsync();
            await _page.GetByTestId("appointmentOverviewContinue").ClickAsync();
            await _page.GetByTestId("firstName").FillAsync("Peter");
            await _page.GetByTestId("lastName").FillAsync("Jackson");
            await _page.GetByTestId("email").FillAsync("petej@gmail.com");
            await _page.GetByTestId("verifyEmail").FillAsync("petej@gmail.com");
            await _page.GetByTestId("dob").FillAsync("01/01/2000");
            await _page.GetByTestId("phoneNumber").FillAsync("201-222-4545");
            await _page.GetByTestId("sex").SelectOptionAsync("M");
            await _page.GetByTestId("preferredPronouns").SelectOptionAsync("he/him");
            await _page.GetByTestId("tosConsent").CheckAsync();
            await _page.GetByTestId("marketingConsent").CheckAsync();
            await _page.GetByTestId("contactDetailsContinue").ClickAsync();
            await _page.GetByTestId("addressLine1").FillAsync("1 jane road");
            await _page.GetByTestId("addressLine2").FillAsync("Clock tower");
            await _page.GetByTestId("addressLine2").FillAsync("city");
            await _page.GetByTestId("zip").FillAsync("23134");
            await _page.GetByTestId("shippingAddressContinue").ClickAsync();
            await _page.GetByTestId("startTreatment").IsVisibleAsync();


        }

        [Given(@"a user navigates and choose other state to book an appointment")]
        public async Task GivenUserChoosesOtherStateToBookAnAppointment()
        {
            await pageobjects.GivenUserNavigateToOnboardingFlow(_page);
            await _page.GetByTestId("otherstate").ClickAsync();
            await _page.GetByPlaceholder("Type or select an option").ClickAsync();
            await _page.Locator("li[role='option']").Nth(5).ClickAsync();
            await _page.GetByText("Sorry, we do not support your state at this time").IsVisibleAsync();  
            await _page.GetByLabel("Enter your first name").FillAsync("Peter");
            await _page.GetByLabel("Enter your last name").FillAsync("Jackson");
            await _page.GetByLabel("Enter your phone number").FillAsync("201-222-4545");
            await _page.GetByLabel("Enter your email address").FillAsync("petej@gmail.com");
            await _page.GetByText("Submit").ClickAsync();
            
            await _page.GetByText("Thank you!").IsVisibleAsync();


        }

        [Given(@"a user navigates to onboarding flow and checks privacy practice in (.*)")]
        public async Task GivenUserChoosesToCallAndEmail(string state)
        {
            await pageobjects.GivenUserNavigateToOnboardingFlow(_page);
            await _page.GetByTestId(state).ClickAsync();
            await _page.Locator("[data-testid^='2024-03']").Nth(0).ClickAsync();

            await _page.GetByText("Privacy Practices").ClickAsync();
            await _page.GetByText("Get Started").First.IsVisibleAsync();


        }

    }
}