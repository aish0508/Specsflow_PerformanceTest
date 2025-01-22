using AdvancedTaskPart2.AssertHelpers;
using AdvancedTaskPart2.Model;
using AdvancedTaskPart2.Pages.NavigationMenuComponent;
using AdvancedTaskPart2.Pages.SignIn;
using AdvancedTaskPart2.Utilities;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskPart2.StepDefinitions
{
    [Binding]
    public class ManageRequestsFeatureStepDefinitions
    {
        SignIn signIn;
        LoginComponent loginComponent;
        NavigationMenuTabsComponent navigationMenuTabsComponent;
        ManageRequestsOverviewComponents manageRequestsOverviewComponents;
        SentRequestsComponent sentRequestsComponent;
        ReceivedRequestsComponent receivedRequestsComponent;
        private object id;

        public ManageRequestsFeatureStepDefinitions()
        {
            signIn = new SignIn();
            loginComponent = new LoginComponent();
            navigationMenuTabsComponent = new NavigationMenuTabsComponent();
            manageRequestsOverviewComponents = new ManageRequestsOverviewComponents();
            sentRequestsComponent = new SentRequestsComponent();
            receivedRequestsComponent = new ReceivedRequestsComponent();
        }
        [Given(@"User logged into Mars URL with login details '([^']*)' and navigates to Manage Requests tab")]
        public void GivenUserLoggedIntoMarsURLWithLoginDetailsAndNavigatesToManageRequestsTab(int id)
        {
            UserInformation userInformation = JsonReader.LoadData<UserInformation>(@"UserInformation.json").FirstOrDefault(x => x.Id == id);
            signIn.clickSignInButton();
            loginComponent.LoginActions(userInformation);
            navigationMenuTabsComponent.clickManageRequestsTab();
        }

        [When(@"User clicks received requests")]
        public void WhenUserClicksReceivedRequests()
        {
            manageRequestsOverviewComponents.clickReceivedRequests();
        }

        [When(@"User accepts the received requests with '([^']*)' in the Manage Requests")]
        public void WhenUserAcceptsTheReceivedRequestsWithInTheManageRequests(int id)
        {
            ReceivedRequestsData receivedRequestsData = JsonReader.LoadData<ReceivedRequestsData>(@"ReceivedRequestData.json").FirstOrDefault(x => x.Id == id);
            receivedRequestsComponent.clickAcceptButton(receivedRequestsData);
        }

        [Then(@"The accept requests with '([^']*)' are accepted successfully")]
        public void ThenTheAcceptRequestsWithAreAcceptedSuccessfully(int id)
        {
            ReceivedRequestsData receivedRequestsData = JsonReader.LoadData<ReceivedRequestsData>(@"ReceivedRequestData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = receivedRequestsComponent.getMessage();
            ManageRequestsAssertHelper.assertAcceptSuccessMessage(receivedRequestsData.ExpectedMessage, actualMessage);
        }

        [When(@"User declines the received requests with '([^']*)' in the Manage Requests")]
        public void WhenUserDeclinesTheReceivedRequestsWithInTheManageRequests(int id)
        {
            ReceivedRequestsData receivedRequestsData = JsonReader.LoadData<ReceivedRequestsData>(@"ReceivedRequestData.json").FirstOrDefault(x => x.Id == id);
            receivedRequestsComponent.clickDeclineButton(receivedRequestsData);
        }

        [Then(@"The decline requests with '([^']*)' are declined successfully")]
        public void ThenTheDeclineRequestsWithAreDeclinedSuccessfully(int id)
        {
            ReceivedRequestsData receivedRequestsData = JsonReader.LoadData<ReceivedRequestsData>(@"ReceivedRequestData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = receivedRequestsComponent.getMessage();
            ManageRequestsAssertHelper.assertDeclineSuccessMessage(receivedRequestsData.ExpectedMessage, actualMessage);
        }

        [When(@"User accepts and completes the received requests with '([^']*)' in the Manage Requests")]
        public void WhenUserAcceptsAndCompletesTheReceivedRequestsWithInTheManageRequests(int id)
        {
            ReceivedRequestsData receivedRequestsData = JsonReader.LoadData<ReceivedRequestsData>(@"ReceivedRequestData.json").FirstOrDefault(x => x.Id == id);
            Thread.Sleep(1000);
           // receivedRequestsComponent.clickAcceptButton(receivedRequestsData);
            receivedRequestsComponent.clickCompleteButton(receivedRequestsData);
        }

        [Then(@"The received requests with '([^']*)' are completed successfully")]
        public void ThenTheReceivedRequestsWithAreCompletedSuccessfully(int id)
        {
            ReceivedRequestsData receivedRequestsData = JsonReader.LoadData<ReceivedRequestsData>(@"ReceivedRequestData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = receivedRequestsComponent.getMessage();
            ManageRequestsAssertHelper.assertCompleteSuccessMessage(receivedRequestsData.ExpectedMessage, actualMessage);
        }

        [When(@"User clicks sent requests")]
        public void WhenUserClicksSentRequests()
        {
            manageRequestsOverviewComponents.clickSentRequests();
        }

        [When(@"User withdraw the sent requests with '([^']*)' in the Manage Requests")]
        public void WhenUserWithdrawTheSentRequestsWithInTheManageRequests(int id)
        {
            SentRequestsData sentRequestsData = JsonReader.LoadData<SentRequestsData>(@"SentRequestsData.json").FirstOrDefault(x => x.Id == id);
            sentRequestsComponent.clickWithdrawButton(sentRequestsData);
        }

        [Then(@"The withdraw requests with '([^']*)' are withdrawn successfully")]
        public void ThenTheWithdrawRequestsWithAreWithdrawnSuccessfully(int id)
        {
            SentRequestsData sentRequestsData = JsonReader.LoadData<SentRequestsData>(@"SentRequestsData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = sentRequestsComponent.getMessage();
            Console.WriteLine(actualMessage);
            ManageRequestsAssertHelper.assertWithdrawSuccessMessage(sentRequestsData.ExpectedMessage, actualMessage);
        }
    }
}
