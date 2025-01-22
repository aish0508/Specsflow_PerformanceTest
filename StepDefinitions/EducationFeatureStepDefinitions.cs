using AdvancedTaskPart2.AssertHelpers;
using AdvancedTaskPart2.Model;
using AdvancedTaskPart2.Pages.ProfileOverview;
using AdvancedTaskPart2.Pages.SignIn;
using AdvancedTaskPart2.Utilities;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskPart2.StepDefinitions
{
    [Binding]
    public class EducationFeatureStepDefinitions :CommonDriver
    {
        SignIn signIn;
        LoginComponent loginComponent;
        ProfileMenuTabsComponent profileMenuTabsComponent;
        AddAndDeleteEducationComponent addAndDeleteEducationComponent;
        ProfileEducationOverviewComponent profileEducationOverviewComponent;

        public EducationFeatureStepDefinitions()
        {
            signIn = new SignIn();
            loginComponent = new LoginComponent();
            profileMenuTabsComponent = new ProfileMenuTabsComponent();
            addAndDeleteEducationComponent = new AddAndDeleteEducationComponent();
            profileEducationOverviewComponent = new ProfileEducationOverviewComponent();
        }
        [Given(@"User logged into Mars URL with login details '([^']*)' and navigates to Education tab")]
        public void GivenUserLoggedIntoMarsURLWithLoginDetailsAndNavigatesToEducationTab(int id)
        {
            UserInformation userInformation = JsonReader.LoadData<UserInformation>(@"UserInformation.json").FirstOrDefault(x => x.Id == id);
            signIn.clickSignInButton();
            loginComponent.LoginActions(userInformation);
            profileMenuTabsComponent.clickEducationTab();
        }
    

        [Given(@"Delete all educations in the education list")]
        public void GivenDeleteAllEducationsInTheEducationList()
        {
            addAndDeleteEducationComponent.DeleteAllEducation();
        }

        [When(@"User adds a new education '([^']*)' and should be added successfully")]
        public void WhenUserAddsANewEducationAndShouldBeAddedSuccessfully(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"addEducationData.json").FirstOrDefault(x => x.Id == id);
            profileEducationOverviewComponent.clickAddNewButton();
            addAndDeleteEducationComponent.addEducation(educationData);
            Thread.Sleep(1000);
            string actualMessage = addAndDeleteEducationComponent.getMessage();
            Thread.Sleep(3000);
            EducationAssertHelper.assertAddEducationSuccessMessage(educationData.AddExpectedMessage, actualMessage);
        }

        [When(@"User deletes education '([^']*)' and should be deleted successfully")]
        public void WhenUserDeletesEducationAndShouldBeDeletedSuccessfully(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"addEducationData.json").FirstOrDefault(x => x.Id == id);
            profileEducationOverviewComponent.clickDeleteButton(educationData);
            string actualMessage = addAndDeleteEducationComponent.getMessage();
            EducationAssertHelper.assertDeleteEducationSuccessMessage(educationData.DeleteExpectedMessage, actualMessage);
        }

        [Given(@"User has education '([^']*)' in the education list")]
        public void GivenUserHasEducationInTheEducationList(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"exitsEducationData.json").FirstOrDefault(x => x.Id == id);
            profileEducationOverviewComponent.clickAddNewButton();
            addAndDeleteEducationComponent.addEducation(educationData);
            addAndDeleteEducationComponent.getMessage();
        }

        [When(@"User tries to add education '([^']*)' again")]
        public void WhenUserTriesToAddEducationAgain(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"exitsEducationData.json").FirstOrDefault(x => x.Id == id);
            profileEducationOverviewComponent.clickAddNewButton();
            addAndDeleteEducationComponent.addEducation(educationData);
        }

        [Then(@"The education '([^']*)' should not be added again")]
        public void ThenTheEducationShouldNotBeAddedAgain(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"exitsEducationData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = addAndDeleteEducationComponent.getMessage();
            EducationAssertHelper.assertExitsAlreadyAddedEducation(educationData.ExpectedMessage, actualMessage);
        }

        [When(@"User tries to add empty education '([^']*)' in the education list")]
        public void WhenUserTriesToAddEmptyEducationInTheEducationList(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"emptyEducationData.json").FirstOrDefault(x => x.Id == id);
            profileEducationOverviewComponent.clickAddNewButton();
            addAndDeleteEducationComponent.addEducation(educationData);
        }

        [Then(@"The education '([^']*)' should not allow empty education")]
        public void ThenTheEducationShouldNotAllowEmptyEducation(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"emptyEducationData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = addAndDeleteEducationComponent.getMessage();
            EducationAssertHelper.assertEmptyScenarioAlertMessage(educationData.ExpectedMessage, actualMessage);
        }

        [When(@"User tries to add special characters '([^']*)' in the education")]
        public void WhenUserTriesToAddSpecialCharactersInTheEducation(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"specialCharsEducationData.json").FirstOrDefault(x => x.Id == id);
            profileEducationOverviewComponent.clickAddNewButton();
            addAndDeleteEducationComponent.addEducation(educationData);
        }

        [Then(@"The education '([^']*)' should not allow special characters")]
        public void ThenTheEducationShouldNotAllowSpecialCharacters(int id)
        {
            EducationData educationData = JsonReader.LoadData<EducationData>(@"specialCharsEducationData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = addAndDeleteEducationComponent.getMessage();
            EducationAssertHelper.assertAddSpecialCharacters(educationData.ExpectedMessage, actualMessage);
        }
    }
}
