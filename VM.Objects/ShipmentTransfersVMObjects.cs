using System.Collections.ObjectModel;
using TurnkeyNet.Client.DataObjects;
using System.Linq;
using System.Collections.Generic;
using TurnkeyNet.UI.Common;
using System;
using System.Globalization;

namespace TurnkeyNet.UI.UnitTest
{
    public class ShipmentTransfersVMObjects
    {
        private bool OFFLINEMODE;
        private InitializeTestObjects TESTOBJECTS;

        public ShipmentTransfersVMObjects(bool OfflineMode = true, InitializeTestObjects testObjects = null)
        {
            OFFLINEMODE = OfflineMode;
            TESTOBJECTS = testObjects;
        }

        public enum SelectedCompanyYardEnum
        {
            [ItemCode("01")]
            [ItemDesc("Yard 1")]
            Yard = 1,
            [ItemCode("02")]
            [ItemDesc("Yard 2")]
            Yard2 = 2,
            [ItemCode("03")]
            [ItemDesc("Yard 3")]
            Yard3 = 3,
        }

        public List<FyShipObject> Get_FyShipObjectsList()
        {
            List<FyShipObject> shipObjects = new List<FyShipObject>();

            FyShipObject shipObject = new FyShipObject();
            shipObject.YardNumber = "01";
            shipObject.Company = "cwd";
            shipObject.SalesTot = 150;
            shipObject.Sp2fr = 25;
            shipObject.Sp2bc = 25;
            shipObject.Sp2Cbp = 25;
            shipObject.Sp2GridAdj = 25;

            shipObjects.Add(shipObject);

            return shipObjects;
        }

        public List<FyShipObject> Get_FyShipObjects(string yard = "01", string company = "cwd")
        {

            List<FyShipObject> shipObjects = Get_FyShipObjectsList().Where(x => x.YardNumber.Equals(yard) && x.Company.Equals(company)).ToList();

            return shipObjects;
        }

        public List<FyRcvObject> Get_FyRcvObjectsList()
        {
            var listFyRcvObject = new List<FyRcvObject>
            {
              new FyRcvObject
              {
                IsClosed = false,
                YardNumber = "01",
                LotNumber = "",
                InDate = DateTime.ParseExact("2018-10-31T00:00:00.0000000", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                Code0 = 0,
                ReferenceNumber = 0,
                Type1 = 0,
                PenNumber = "",
                HdctIn = 0,
                WeightPayTot = 0,
                WeightOfftruckTot = 0,
                CattleCostTot = 0m,
                InvoiceSwitch = 0,
                LotClassCode = "",
                AccountingDate = DateTime.ParseExact("2018-10-31T00:00:00.0000000", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                RcvTranYd = "",
                RcvTranLt = "",
                PurchaseOrderNumber = "",
                RcvInvoiceNumber = 0,
                RcvAgent = 0,
                BuyerNumber6 = 0,
                RcvMrg = 0,
                SourceId = "",
                RcvCtype = "",
                RcvLoad = "",
                RcvTime = null,
                RcvFrame = 0m,
                RcvPhenotype = "",
                RcvMoveGen = "", 
                RcvRc = 0,
                RcvRecSeq = "",
                SexCode = "",
                BreedCode = "",
                BackgroundCode = "Red",
                ConditionCode = "",
                BuyerNumber = 0,
                OriginCode = "",
                FreightIn = 0m,
                CommissionIn = 0m,
                Rc2BuyerNm = "",
                Rc2RecvPen1 = "",
                Rc2RecvPen2 = "",
                Rc2RecvPen3 = "",
                Rc2RecvPen4 = "",
                Rc2BirthMon = 0,
                RcvScaleTicket = "",
                Rc2ProjDtOut = null,
                Rc2ProjWt = 0,
                Rc2ProjBe = 0m,
                Rc2Rc = 0,
                Rc2RecSeq = "",
                LotName = "",
                LotDesc = "",
                LotStatus = "",
                LotPcntBlack = 0,
                LotIntAdjust = 0m,
                LotRation = "",
                LotFeedProgram = "",
                LotGainRate = 0m,
                LotFeedConv = 0m,
                LotProjDateOut = null,
                LotProjWtOut = 0,
                LotCostPerHead = 0m,
                RiskFcWt = 0,
                RiskLcWt = 0,
                RiskCog = 0m,
                RiskAnimalFactor = 0,
                RiskProjDtOut = null,
                RiskProjWtOut = 0,
                RiskBe = 0m,
                YardType = "",
                AgentName = "",
                RcvMessage = "",
                UseAcctDate = false,
                RcvCompany = "cwd",
                Rc2UserId = "",
                RcvUpdate = "",
                Rc2Update = "",
                HasAdjustments = false,
                Comment1 = "",
                Comment2 = "",
                Comment3 = "",
                Company = "cwd",
                Grfa = "",
                Sequence = 0L,
                BlockReverse = false,
                RowState = TurnkeyNet.Client.DataObjects.RowState.Unchanged,
                IsChecked = false,
                ProposedChanges = null
              },
              new FyRcvObject
              {
                IsClosed = false,
                YardNumber = "01",
                LotNumber = "",
                InDate = DateTime.ParseExact("2018-10-31T00:00:00.0000000", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                Code0 = 0,
                ReferenceNumber = 0,
                Type1 = 0,
                PenNumber = "",
                HdctIn = 0,
                WeightPayTot = 0,
                WeightOfftruckTot = 0,
                CattleCostTot = 0m,
                InvoiceSwitch = 0,
                LotClassCode = "",
                AccountingDate = DateTime.ParseExact("2018-10-31T00:00:00.0000000", "O", CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind),
                RcvTranYd = "",
                RcvTranLt = "",
                PurchaseOrderNumber = "",
                RcvInvoiceNumber = 0,
                RcvAgent = 0,
                BuyerNumber6 = 0,
                RcvMrg = 0,
                SourceId = "",
                RcvCtype = "",
                RcvLoad = "",
                RcvTime = null,
                RcvFrame = 0m,
                RcvPhenotype = "",
                RcvMoveGen = "",
                RcvRc = 0,
                RcvRecSeq = "",
                SexCode = "",
                BreedCode = "",
                BackgroundCode = "Pink",
                ConditionCode = "",
                BuyerNumber = 0,
                OriginCode = "",
                FreightIn = 0m,
                CommissionIn = 0m,
                Rc2BuyerNm = "",
                Rc2RecvPen1 = "",
                Rc2RecvPen2 = "",
                Rc2RecvPen3 = "",
                Rc2RecvPen4 = "",
                Rc2BirthMon = 0,
                RcvScaleTicket = "",
                Rc2ProjDtOut = null,
                Rc2ProjWt = 0,
                Rc2ProjBe = 0m,
                Rc2Rc = 0,
                Rc2RecSeq = "",
                LotName = "",
                LotDesc = "",
                LotStatus = "",
                LotPcntBlack = 0,
                LotIntAdjust = 0m,
                LotRation = "",
                LotFeedProgram = "",
                LotGainRate = 0m,
                LotFeedConv = 0m,
                LotProjDateOut = null,
                LotProjWtOut = 0,
                LotCostPerHead = 0m,
                RiskFcWt = 0,
                RiskLcWt = 0,
                RiskCog = 0m,
                RiskAnimalFactor = 0,
                RiskProjDtOut = null,
                RiskProjWtOut = 0,
                RiskBe = 0m,
                YardType = "",
                AgentName = "",
                RcvMessage = "",
                UseAcctDate = false,
                RcvCompany = "cwd",
                Rc2UserId = "",
                RcvUpdate = "",
                Rc2Update = "",
                HasAdjustments = false,
                Comment1 = "",
                Comment2 = "",
                Comment3 = "",
                Company = "cwd",
                Grfa = "",
                Sequence = 0L,
                BlockReverse = false,
                RowState = TurnkeyNet.Client.DataObjects.RowState.Unchanged,
                IsChecked = false,
                ProposedChanges = null
              }
            };

            return listFyRcvObject;
        }

        public List<FyRcvObject> Get_FyRcvObjects(string yard = "01", string company = "cwd")
        {

            List<FyRcvObject> rcvObjects = Get_FyRcvObjectsList().Where(x => x.YardNumber.Equals(yard) && x.Company.Equals(company)).ToList();

            return rcvObjects;
        }

        public ItemSelectorObject Get_SelectedCompanyYard(appUserSession userSession)
        {
            ItemSelectorObject SelectedCompanyYard = new ItemSelectorObject();
            List<ItemSelectorObject> SelectedCompanyYards = CommonLists.PopulateItemSelectorObjectList<SelectedCompanyYardEnum>();
            SelectedCompanyYards.FirstOrDefault().CompanyCode = userSession.SelectedYard.CompanyCode;
            SelectedCompanyYards.FirstOrDefault().YardNumber = userSession.SelectedYard.YardNumber;
            SelectedCompanyYards.FirstOrDefault().IsSelected = true;
            return SelectedCompanyYards.FirstOrDefault();
        }
    }
}
