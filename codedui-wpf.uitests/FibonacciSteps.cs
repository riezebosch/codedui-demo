using Microsoft.VisualStudio.TestTools.UITesting;
using Shouldly;
using System;
using TechTalk.SpecFlow;

namespace codedui_wpf.uitests
{
    [Binding]
    public class FibonacciSteps
    {
        [Given(@"I have the application open")]
        public void GivenIHaveTheApplicationOpen()
        {
            var sut = ApplicationUnderTest.Launch("codedui-wpf.exe");
            var page = new MainPage(sut);

            ScenarioContext.Current.Set(page);
        }


        [Given(@"I have entered (.*) in the WPF application")]
        public void GivenIHaveEnteredInTheWPFApplication(int invoer)
        {
            var page = ScenarioContext.Current.Get<MainPage>();
            page.GetalOpVeld1Invoeren(invoer);
        }
        
        [When(@"I press the big bad button")]
        public void WhenIPressTheBigBadButton()
        {
            var page = ScenarioContext.Current.Get<MainPage>();
            page.DrukOpKnop();
        }
        
        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(string verwacht)
        {
            var page = ScenarioContext.Current.Get<MainPage>();
            page.LeesResultaatUit().ShouldBe(verwacht);
        }
    }
}
