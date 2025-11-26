using AdvancedTaskPart2.AssertHelpers;
using AdvancedTaskPart2.Model;
using AdvancedTaskPart2.Pages.ProfileOverview;
using AdvancedTaskPart2.Pages.SignIn;
using AdvancedTaskPart2.Utilities;
using System;
using TechTalk.SpecFlow;
using AdvancedTaskPart2.Hooks;

namespace AdvancedTaskPart2.StepDefinitions
{
    [Binding]
    public class CertificateFeatureStepDefinitions : CommonDriver
    {
        SignIn signIn;
        LoginComponent loginComponent;
        ProfileMenuTabsComponent profileMenuTabsComponent;
        AddAndDeleteCertificationsComponent addAndDeleteCertificationsComponent;
        ProfileCertificationsOverviewComponent profileCertificationsOverviewComponent;
        public CertificateFeatureStepDefinitions()
        {
            signIn = new SignIn();
            loginComponent = new LoginComponent();
            profileMenuTabsComponent = new ProfileMenuTabsComponent();
            addAndDeleteCertificationsComponent = new AddAndDeleteCertificationsComponent();
            profileCertificationsOverviewComponent = new ProfileCertificationsOverviewComponent();
        }
        [Given(@"User logged into Mars URL with login details '([^']*)' and navigates to Certifications tab")]
        public void GivenUserLoggedIntoMarsURLWithLoginDetailsAndNavigatesToCertificationsTab(int id)
        {
            UserInformation userInformation = JsonReader.LoadData<UserInformation>(@"UserInformation.json").FirstOrDefault(x => x.Id == id);
            signIn.clickSignInButton();
            loginComponent.LoginActions(userInformation);
            profileMenuTabsComponent.clickCertificationsTab();
        }

        [Given(@"Delete all certifications in the certifications list")]
        public void GivenDeleteAllCertificationsInTheCertificationsList()
        {
            addAndDeleteCertificationsComponent.DeleteAllCertifications();
            
        }

        [When(@"User add new certification '([^']*)' and should be added succesfully")]
        public void WhenUserAddNewCertificationAndShouldBeAddedSuccesfully(int id)
        {
            CertificationData certificationData=JsonReader.LoadData<CertificationData>(@"addCertificationsData.json").FirstOrDefault(x=>x.Id==id);
            profileCertificationsOverviewComponent.clickAddNewButton();
            addAndDeleteCertificationsComponent.addCertification(certificationData);
            string actualMessage=addAndDeleteCertificationsComponent.getMessage();
            CertificationAssertHelper.assertAddCertificationMessage(certificationData.AddExpectedMessage, actualMessage);
            
        }

        [Then(@"User deletes Certification '([^']*)' and should be deleted successfully")]
        public void ThenUserDeletesCertificationAndShouldBeDeletedSuccessfully(int id)
        {
            CertificationData certificationData = JsonReader.LoadData<CertificationData>(@"addCertificationsData.json").FirstOrDefault(x => x.Id == id);
            profileCertificationsOverviewComponent.clickDeleteButton(certificationData);
            //Thread.Sleep(2000);
            string actualMessage = addAndDeleteCertificationsComponent.getMessage();
           // Thread.Sleep(2000);
            Console.WriteLine(actualMessage);
            Console.WriteLine(certificationData.DeleteExpectedMessage);
           // Thread.Sleep(2000);
            CertificationAssertHelper.assertDeleteCertificationSuccessMessage(certificationData.DeleteExpectedMessage, actualMessage);

            

        }

       

        [Given(@"User has Certification '([^']*)' in the certificate list")]
        public void GivenUserHasCertificationInTheCertificateList(int id)
        {
            CertificationData certificationData = JsonReader.LoadData<CertificationData>(@"exitsCertificationsData.json").FirstOrDefault(x => x.Id == id);
            profileCertificationsOverviewComponent.clickAddNewButton();
            addAndDeleteCertificationsComponent.addCertification(certificationData);
            addAndDeleteCertificationsComponent.getMessage();
        }

        [When(@"User tries to add certificate '([^']*)' again")]
        public void WhenUserTriesToAddCertificateAgain(int id)
        {
            CertificationData certificationData = JsonReader.LoadData<CertificationData>(@"exitsCertificationsData.json").FirstOrDefault(x => x.Id == id);
            profileCertificationsOverviewComponent.clickAddNewButton();
            addAndDeleteCertificationsComponent.addCertification(certificationData);
        }

        [Then(@"The certificate '([^']*)' should not be added again")]
        public void ThenTheCertificateShouldNotBeAddedAgain(int id)
        {
            CertificationData certificationData = JsonReader.LoadData<CertificationData>(@"exitsCertificationsData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = addAndDeleteCertificationsComponent.getMessage();
            CertificationAssertHelper.assertAddCertificationMessage(certificationData.ExpectedMessage, actualMessage);
        }

        [When(@"User tries to add empty certification '([^']*)' in the certifications list")]
        public void WhenUserTriesToAddEmptyCertificationInTheCertificationsList(int id)
        {
            CertificationData certificationData = JsonReader.LoadData<CertificationData>(@"emptyCertificationsData.json").FirstOrDefault(x => x.Id == id);
            profileCertificationsOverviewComponent.clickAddNewButton();
            addAndDeleteCertificationsComponent.addCertification(certificationData);
        }

        [Then(@"The certification '([^']*)' should not allow empty certification")]
        public void ThenTheCertificationShouldNotAllowEmptyCertification(int id)
        {
            CertificationData certificationData = JsonReader.LoadData<CertificationData>(@"emptyCertificationsData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = addAndDeleteCertificationsComponent.getMessage();
            CertificationAssertHelper.assertAddCertificationMessage(certificationData.ExpectedMessage, actualMessage);
        }

        [When(@"User tries to add special characters in the certification '([^']*)'")]
        public void WhenUserTriesToAddSpecialCharactersInTheCertification(int id)
        {
            CertificationData certificationData = JsonReader.LoadData<CertificationData>(@"specialCharsCertificationsData.json").FirstOrDefault(x => x.Id == id);
            profileCertificationsOverviewComponent.clickAddNewButton();
            addAndDeleteCertificationsComponent.addCertification(certificationData);
        }

        [Then(@"The certification '([^']*)' should not allow special characters")]
        public void ThenTheCertificationShouldNotAllowSpecialCharacters(int id)
        {
            CertificationData certificationData = JsonReader.LoadData<CertificationData>(@"specialCharsCertificationsData.json").FirstOrDefault(x => x.Id == id);
            string actualMessage = addAndDeleteCertificationsComponent.getMessage();
            CertificationAssertHelper.assertAddCertificationMessage(certificationData.ExpectedMessage, actualMessage);
        }
    }
}
