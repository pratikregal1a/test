using System.Collections.ObjectModel;
using System.Linq;
using TurnkeyNet.UI.ViewModel;
using System.Threading.Tasks;
using TurnkeyNet.Client.DataObjects;
using TurnkeyNet.UI.UnitTest;
using TurnkeyNet.UI.Common;

namespace TurnkeyNet.UI.Tests
{
    public class InitializeTest
    {
        private bool OFFLINEMODE;
        public InitializeTestObjects testObjects = new InitializeTestObjects();

        public InitializeTest(bool OfflineMode = true, string SelectedYard = "01")
        {
            OFFLINEMODE = OfflineMode;
            //need to create a new instance of LocalizationHelper
            LocalizationHelper lh = new LocalizationHelper();
            testObjects.SelectedYard = SelectedYard;
        }

        public appUserSession GetTestUserOffline()
        {
            appUser user = new appUser();
            appUserSession userSession = new appUserSession();
            user = testObjects.Get_TestUser();
            userSession = testObjects.Get_TestUserSession();

            userSession.SelectedYard = userSession.Yards.Where(x => x.YardNumber.Equals(testObjects.SelectedYard)).FirstOrDefault();
            userSession.DefaultTransName = userSession.SelectedYard.CompanyCode;

            return userSession;
        }

        public async Task<appUserSession> GetTestUserOnlineAsync()
        {
            appUser user = new appUser();
            appUserSession userSession = new appUserSession();
            //login
            userSession = await LoginTestUserAsync();

            userSession.SelectedYard = userSession.Yards.Where(x => x.YardNumber.Equals(testObjects.SelectedYard)).FirstOrDefault();
            userSession.DefaultTransName = userSession.SelectedYard.CompanyCode;

            return userSession;
        }

        public async Task<appUserSession> LoginTestUserAsync()
        {
            //making sure it comes back as good
            appUser user = testObjects.Get_TestUser();
            string pw = testObjects.Get_TestUser_PW();

            LoginVM lvm = new LoginVM();
            lvm.Username = user.UserName;
            lvm.Password = pw;

            return await lvm.GetTestLoginAsync();
        }

    }
}
