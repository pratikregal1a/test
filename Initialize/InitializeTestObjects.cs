using System.Collections.ObjectModel;
using TurnkeyNet.Client.DataObjects;
using System.Linq;
using System.Collections.Generic;

namespace TurnkeyNet.UI.UnitTest
{

    public class InitializeTestObjects
    {
        public string SelectedYard;

        public appUser Get_TestUser()
        {
            appUser user = new appUser();
            user.UserId = 1010101010;
            user.UserName = "BradC";
            user.FirstName = "Test";
            user.LastName = "Testington";
            user.Email = "Tester@test.com";

            return user;
        }

        public string Get_TestUser_PW()
        {
            return "Test";
        }

        public appUserSession Get_TestUserSession()
        {
            appUser user = Get_TestUser();
            ObservableCollection<appYard> ocay = Get_Yards(SelectedYard);

            appUserSession userSession = new appUserSession();
            userSession.UserId = user.UserId;
            userSession.UserName = user.UserName;
            userSession.Yards = ocay;

            return userSession;
        }

        public appYard Get_Yard(string YardNumber, bool IsChecked = false)
        {
            appYard yard = new appYard();

            switch (YardNumber)
            {
                case "02":
                    yard.CompanyId = 1;
                    yard.CompanyCode = "cwd";
                    yard.CompanyName = "bradly's dinosaurs";
                    yard.YardId = 2;
                    yard.YardName = "bradly farms 2";
                    yard.YardNumber = "02";
                    yard.IsChecked = IsChecked;
                    break;
                case "03":
                    yard.CompanyId = 1;
                    yard.CompanyCode = "cwd";
                    yard.CompanyName = "bradly's dairy farms";
                    yard.YardId = 3;
                    yard.YardName = "bradly farms 3";
                    yard.YardNumber = "03";
                    yard.IsChecked = IsChecked;
                    break;
                case "04":
                    yard.CompanyId = 1;
                    yard.CompanyCode = "cwd";
                    yard.CompanyName = "bradly's bean farms";
                    yard.YardId = 4;
                    yard.YardName = "bradly farms 4";
                    yard.YardNumber = "04";
                    yard.IsChecked = IsChecked;
                    break;
                default:
                    yard.CompanyId = 1;
                    yard.CompanyCode = "cwd";
                    yard.CompanyName = "bradly's merry go round";
                    yard.YardId = 1;
                    yard.YardName = "bradly farms";
                    yard.YardNumber = "01";
                    yard.IsChecked = IsChecked;
                    break;
            }

            return yard;
        }

        public ObservableCollection<appYard> Get_Yards(string SelectedYard)
        {
            ObservableCollection<appYard> ocay = new ObservableCollection<appYard>();
            appYard yard = Get_Yard("1", (SelectedYard == "01") ? true : false);
            ocay.Add(yard);
            yard = Get_Yard("02", (SelectedYard == "02") ? true : false);
            ocay.Add(yard);
            yard = Get_Yard("03", (SelectedYard == "03") ? true : false);
            ocay.Add(yard);
            yard = Get_Yard("04", (SelectedYard == "04") ? true : false);
            ocay.Add(yard);

            return ocay;
        }
    }
}
