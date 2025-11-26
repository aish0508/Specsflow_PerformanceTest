using AdvancedTaskPart2.AssertHelpers;
using AdvancedTaskPart2.Model;
using AdvancedTaskPart2.Pages.AccountMenu;
using AdvancedTaskPart2.Pages.SignIn;
using AdvancedTaskPart2.Utilities;
using System;
using TechTalk.SpecFlow;

namespace AdvancedTaskPart2.StepDefinitions
{
    [Binding]
    public class ChangePasswordStepDefinitions
    {
        SignIn signIn;
        LoginComponent loginComponent;
        UserTab userTab;
        ChangePassword changePassword;

        public ChangePasswordStepDefinitions()
        {
            signIn = new SignIn();
            loginComponent = new LoginComponent();
            userTab = new UserTab();
            changePassword = new ChangePassword();
        }


        [Given(@"User Login into Mars Url and navigate to user tab")]
        public void GivenUserLoginIntoMarsUrlAndNavigateToUserTab()
        {
            signIn.clickSignInButton();
            List<UserInformation> userInformatioList = JsonReader.LoadData<UserInformation>(@"UserInformation.json");
            foreach (var userInformation in userInformatioList)
            {
                loginComponent.LoginActions(userInformation);
            }
            userTab.clickUserTab();
        }

    

    [When(@"User Directly Click on Save Button")]
    public void WhenUserDirectlyClickOnSaveButton()
    {
        changePassword.EmptyScenarioPassword();

    }


    [Then(@"'([^']*)' should be displayed")]
        public void ThenShouldBeDisplayed(string Message)
        {
            //string expected = "Please fill all the details before Submit";
            string actualMessage=changePassword.getEmptyMessageAlert();
            ChangePasswordAssertHelper.assertEmptyScenarioMessage(Message, actualMessage);
        }
        [When(@"User write wrong  Current password and Same inputs in New Password, Confirm Password with '([^']*)' and Click on Save Button")]
        public void WhenUserWriteWrongCurrentPasswordAndSameInputsInNewPasswordConfirmPasswordWithAndClickOnSaveButton(int id)
        {
            ChangePasswordData changePasswordData1 = JsonReader.LoadData<ChangePasswordData>(@"changePassword.json").FirstOrDefault(x => x.Id == 2);
            changePassword.WrongCurrentPassword(changePasswordData1);
        }


       
        [Then (@"Password Failed Verification'([^']*)' should be displayed")]
            public void ThenPasswordFailedVerificationshouldbedisplayed(int id)
        {
            ChangePasswordData changePasswordData1 = JsonReader.LoadData<ChangePasswordData>(@"changePassword.json").FirstOrDefault(x => x.Id == 2);
            string actualMessage = changePassword.getPasswordVerificationFailedMessage();
            ChangePasswordAssertHelper.assertVerificationOfWrongPasswordMessage(changePasswordData1.ExpectedMessage, actualMessage);
           // string newPassword = changePasswordData1.NewPassword;
            //PasswordManager passwordManager = new PasswordManager();
           // passwordManager.WriteNewPasswordToJson(newPassword);
        }
        [When(@"User write Correct Current Password and different inputs in  New Password, Confirm Password with '([^']*)'and Click on Save Button")]
        public void whenUserWriteCorrectCurrentPasswordAndDifferentInputsInNewPasswordConfirmPasswordWithAndClickOnSaveButton(int id)
        {
            ChangePasswordData changePasswordData2 = JsonReader.LoadData<ChangePasswordData>(@"changePassword.json").FirstOrDefault(x => x.Id == 3);
            changePassword.DifferentPasswordScenario(changePasswordData2);
        }


        [Then(@"Password should not match'([^']*)' should be displayed")]
        public void ThenPasswordShouldNotMatchShouldBeDisplayed(int id)
        {
            ChangePasswordData changePasswordData2 = JsonReader.LoadData<ChangePasswordData>(@"changePassword.json").FirstOrDefault(x => x.Id == 3);
            string actualMessage = changePassword.getPasswordVerificationFailedMessage();
            ChangePasswordAssertHelper.assertVerificationOfPasswordDoNotMatch(changePasswordData2.ExpectedMessage, actualMessage);
           // string newPassword = changePasswordData2.NewPassword;
           // PasswordManager passwordManager = new PasswordManager();
           // passwordManager.WriteNewPasswordToJson(newPassword);
        }
        
            
        [When(@"User clicks Change Password and updates the new password with '([^']*)'")]
        public void WhenUserClicksChangePasswordAndUpdatesTheNewPasswordWith(int id)
        {
            ChangePasswordData changePasswordData = JsonReader.LoadData<ChangePasswordData>(@"changePassword.json").FirstOrDefault(x => x.Id == id);
            changePassword.changePassword(changePasswordData);
        }

        [Then(@"New Password updated with '([^']*)' successfully")]
        public void ThenNewPasswordUpdatedWithSuccessfully(int id)
        {
            ChangePasswordData changePasswordData = JsonReader.LoadData<ChangePasswordData>(@"changePassword.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = changePassword.getMessage();
            ChangePasswordAssertHelper.assertChangePasswordSuccessMessage(changePasswordData.ExpectedMessage, actualMessage);
            string newPassword = changePasswordData.NewPassword;
            PasswordManager passwordManager = new PasswordManager();
            passwordManager.WriteNewPasswordToJson(newPassword);
        }
    }
}
