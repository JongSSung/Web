 protected void btnPrint_Click(object sender, ImageClickEventArgs e)
        {
            Response.Clear();
            Response.Charset = "UTF-8";
            stQuery = "";

            List<object> sltItem = axGridView.GetSelectedFieldValues(new string[] { "UNICD" });

            foreach (object obj in sltItem)
            {
                if (stQuery != "") stQuery += ",";

                stQuery += obj.ToString();
            }

            stQuery += "!";


            if (stQuery == "NX4!")
            {
                Response.Write("<script>window.open('../PG5000/ReportViewer.aspx?docType=XRPG05S3000:" + stQuery + "','','top=100,left=100,width=1024,height=768');</script>");


            }
            else if (stQuery == "JW!")
            {
                Response.Write("<script>window.open('../PG5000/ReportViewer.aspx?docType=XRPG05S2000:" + stQuery + "','','top=100,left=100,width=1024,height=768');</script>");

            }
            else if (stQuery == "CE!")
            {
                Response.Write("<script>window.open('../PG5000/ReportViewer.aspx?docType=XRPG05S2300:" + stQuery + "','','top=100,left=100,width=1024,height=768');</script>");

            }
            else //CV
            {
                Response.Write("<script>window.open('../PG5000/ReportViewer.aspx?docType=XRPG05I1700:" + stQuery +     "','','top=100,left=100,width=1024,height=768');</script>");

            }



        }


//stQuery 가 UNICD 가져옴