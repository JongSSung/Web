<%@ Page Language="C#" MasterPageFile="~/main.Master" AutoEventWireup="true" CodeBehind="PG50I5100.aspx.cs" Inherits="thinPOPNG.PG5000.PG50I5100" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

//코드

</asp:Content>


////////////////////////////////////////////////////////////
//리포트 뷰어 설정해서 선택시 불러오기
protected void Page_Load(object sender, EventArgs e)
        {
            DsPrint = new DsPG5000();
            XRPG50I1600 report1 = null;
            XRPG05S2500 report2 = null;
            string docType = Request.QueryString["docType"];
            if (docType == null)
                return;
            string[] ArrdocType = docType.Split(':');
            string[] ArrViewS = ArrdocType[1].Split('!');
            switch (ArrdocType[0])
            {
                case "XRPG05S2500":
                    //DsPG5000 DsTable = new DsPG5000();
                    //report = new XRPG05S1700();
                    report2 = new XRPG05S2500();
                    ViewSearch(ArrViewS[0]);
                    report2.DataSource = DsPrint;
                    break;

                case "PG50I1600":
                    //DsPG5000 DsTable = new DsPG5000();
                    //report = new XRPG05S1700();
                    report1 = new XRPG50I1600();
                    ViewSearch(ArrViewS[0]);
                    report1.DataSource = DsPrint;                    
                    break;
                //    case "Payment":
                //        report = new XtraReport1();
                //        break;
                

            }            
            ASPxDocumentViewer1.Report = report1;
            ASPxDocumentViewer1.Report = report2;

        }