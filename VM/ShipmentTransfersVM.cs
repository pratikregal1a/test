using Microsoft.VisualStudio.TestTools.UnitTesting;
using TurnkeyNet.Client.DataObjects;
using TurnkeyNet.UI.UnitTest;
using TurnkeyNet.UI.ViewModel;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace TurnkeyNet.UI.Tests
{
    [TestClass]
    public class ShipmentTransfersVM
    {
        const bool OFFLINEMODE = true;

        [TestMethod]
        public async Task ShipmentTransferVM_CalculateNetSales()
        {
            string YARD = "01";
            string COMPANY = "cwd";

            //online mode first - this gets/sets the user session
            InitializeTest init = new InitializeTest(OFFLINEMODE);

            if (OFFLINEMODE)
            {
                Shared.LocalUserSession = init.GetTestUserOffline();
            }
            else
            {
                Shared.LocalUserSession = await init.GetTestUserOnlineAsync();
            }

            ShipmentTransfersVMObjects shipmentTransfersVMObjects = new ShipmentTransfersVMObjects(OFFLINEMODE);
            FyShipObject shipObject = shipmentTransfersVMObjects.Get_FyShipObjects(YARD, COMPANY).FirstOrDefault();

            ShipmentTransferVM stvm = new ShipmentTransferVM();
            stvm.SelectedShipment = shipObject;

            stvm.CalculateNetSales();

            Assert.IsTrue(stvm.NetSales == 100);
        }

        [TestMethod]
        public async Task SetReceivings_NewReceiving_To_NewShipment()
        {
            string YARD = "01";
            string COMPANY = "cwd";

            //online mode first - this gets/sets the user session and selects a yard
            InitializeTest init = new InitializeTest(OFFLINEMODE, YARD);

            if (OFFLINEMODE)
            {
                Shared.LocalUserSession = init.GetTestUserOffline();
            }
            else
            {
                Shared.LocalUserSession = await init.GetTestUserOnlineAsync();
            }

            ShipmentTransfersVMObjects shipmentTransfersVMObjects = new ShipmentTransfersVMObjects(OFFLINEMODE, init.testObjects);
            FyRcvObject rcvObject = shipmentTransfersVMObjects.Get_FyRcvObjects(YARD, COMPANY).FirstOrDefault();

            ShipmentTransferVM stvm = new ShipmentTransferVM();

            //new receiving
            stvm.SelectedReceivings = rcvObject;
            stvm.SelectedCompanyYard = shipmentTransfersVMObjects.Get_SelectedCompanyYard(Shared.LocalUserSession);

            //new shipment
            stvm.SelectedShipment = new FyShipObject();
            stvm.IsNewReceiving = true;

            stvm.SetReceiving();

            Assert.IsTrue(stvm.SelectedReceivings.YardNumber.Equals(stvm.SelectedCompanyYard.YardNumber)
                && stvm.SelectedReceivings.Company.Equals(stvm.SelectedCompanyYard.CompanyCode)
                && stvm.SelectedReceivings.RcvCompany.Equals(stvm.SelectedCompanyYard.CompanyCode)
                && stvm.SelectedReceivings.InvoiceSwitch == 2);

        }

        [TestMethod]
        public async Task SetReceivings_NewReceiving_To_ExistingShipment()
        {
            string YARD = "01";
            string COMPANY = "cwd";

            //online mode first - this gets/sets the user session and selects a yard
            InitializeTest init = new InitializeTest(OFFLINEMODE, YARD);

            if (OFFLINEMODE)
            {
                Shared.LocalUserSession = init.GetTestUserOffline();
            }
            else
            {
                Shared.LocalUserSession = await init.GetTestUserOnlineAsync();
            }

            ShipmentTransfersVMObjects shipmentTransfersVMObjects = new ShipmentTransfersVMObjects(OFFLINEMODE, init.testObjects);
            FyRcvObject rcvObject = shipmentTransfersVMObjects.Get_FyRcvObjects(YARD, COMPANY).FirstOrDefault();

            ShipmentTransferVM stvm = new ShipmentTransferVM();

            //new receiving
            stvm.SelectedReceivings = rcvObject;
            stvm.SelectedCompanyYard = shipmentTransfersVMObjects.Get_SelectedCompanyYard(Shared.LocalUserSession);

            //existing shipment
            stvm.IsNewReceiving = false;
            stvm.SelectedShipment = shipmentTransfersVMObjects.Get_FyShipObjects(YARD, COMPANY).FirstOrDefault();

            stvm.SetReceiving();

            Assert.IsTrue(stvm.SelectedReceivings.YardNumber.Equals(stvm.SelectedCompanyYard.YardNumber)
                && stvm.SelectedReceivings.Company.Equals(stvm.SelectedCompanyYard.CompanyCode)
                && stvm.SelectedReceivings.RcvCompany.Equals(stvm.SelectedCompanyYard.CompanyCode)
                && stvm.SelectedReceivings.InvoiceSwitch == 2);

        }

    }
}
