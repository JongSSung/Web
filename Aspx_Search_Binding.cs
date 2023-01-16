// 검색 할수있게 파라미터설정

public override void GridData_Bind(params string[] srhTexts)
        {
            try
            {
                using (MacMstDac dac = new MacMstDac())
                {
                    DataTable dt = dac.GetMacMstInfo(srhTexts[0]);

                    if (dt != null)
                    {
                        aSPxGrdVw.DataSource = dt;
                        aSPxGrdVw.DataBind();
                    }
                }
            }
            catch(Exception ex)
            {
                LogManager.WriteLog(userInfo.UNTCD, LogEntryType.Exception, LogSourceType.WebPage, LogUtility.GetMethodName(), ex.Message, ex.StackTrace);
            }

            //return dt;
        }

protected void Load_MacMstInfo()
        {
            _PgGrdVwMac.GridViewColumns_Init();
            aSpLtrMstBtnSet.Text = _PgGrdVwMac.GetGrdVwTopBtnSet();

            _PgGrdVwMac.GridData_Bind(ValidChkHelper.IsEmpty(apxTbxCstNm_Sch.Text.Trim()) ? string.Empty : apxTbxCstNm_Sch.Text.Trim());
            //_PgGrdVwMac.GridData_Bind();
        }



//검색할때 바인딩시켜서 컬럼명 제대로 표시

public override void GridViewColumns_Init()
{
//품명
GridViewDataTextColumn _ColItmNm = (GridViewDataTextColumn)aSPxGrdVw.Columns["ITMNM"];
_ColItmNm.HeaderCaptionTemplate = new GrdVwColHeaderTemplate(_ResMgr.GetString("PG_ITMNM"));
}