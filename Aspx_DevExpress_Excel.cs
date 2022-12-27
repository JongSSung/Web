// Excel

// - 버튼만들기

그리드창에 넣는다
public override string GetGrdVwTopBtnSet()
        {
            return base.GetBtnSet(_ResMgr.GetString("Title_CstMst")
                                  , "aPxCBkPnCstMstInfo.PerformCallback('SEARCH|');"
                                  , _PopCBkCtrlID + ".PerformCallback('POPSHOW|REG|');"
                                  , string.Empty
                                  , "CstMstAct.MULTI_DELETE_ITEM(aPxGdVwCstMstInfo,aPxCBkPnCstMstInfo,'','MULTDELETE|');"
                                  , string.Empty
                                  **, "ExcelBtnClick();"
                                  , "aPxPopCtrlExcelUp.Show();"**
                                  );


// - 내용 긁어오기
//     - .cs파일에서 팝업창에서 ReesetCtrls에서 정보긁어온다
//     - 긁어온 정보를 넣는다 ex


if (i > 0)
            {
                strFB.Remove(0, strFB.Length);
                strFB.Append(@"SELECT * FROM [" + strWorksheetName.ToString().Trim() + "$]");
                try
                {
                    DataSet Dtset = new DataSet();
                    OleDbDataAdapter adapter = new OleDbDataAdapter();
                    adapter.SelectCommand = new OleDbCommand(strFB.ToString(), excel_Helper.Connection);
                    adapter.Fill(Dtset, "SHEET1");
                    for (intvar = 0; intvar < Dtset.Tables["SHEET1"].Rows.Count; intvar++)
                    {
                        if (Dtset.Tables["SHEET1"].Rows[intvar][1].ToString().Trim() == "" ||
                            Dtset.Tables["SHEET1"].Rows[intvar][4].ToString().Trim() == "")
                        {
                            break;
                        }
                        else
                        {
                            **CSTMSTINFO CstMstInfo = new CSTMSTINFO();
                            CstMstInfo.UNTCD = Dtset.Tables["SHEET1"].Rows[intvar][0].ToString().Trim();
                            CstMstInfo.CSTCD = Dtset.Tables["SHEET1"].Rows[intvar][1].ToString().Trim();

                            //거래처명 필수
                            //        CstMstInfo.CSTNM = ValidChkHelper.IsEmpty(aPxTBxCstNm.Text.Trim()) ? string.Empty : aPxTBxCstNm.Text.Trim();

                            //거래처명 정식
                            //대표자명
                            CstMstInfo.CSTCEO = aPxTBxCstCeo.Text.Trim();

                                    //사업자번호 필수
                                    CstMstInfo.BIZNO = aPxTBxBizNo.Text.Trim();

                                    //종사업자번호
                             
                                    //업태
                                    CstMstInfo.CSTKIND = aPxTBxCstKind.Text.Trim();

                                    //종목
                                    CstMstInfo.CSTITEM = aPxTBxCstItem.Text.Trim();

                                    //전화번호
                                    CstMstInfo.TELNO = aPxTBxTelNo.Text.Trim();

                                    //FAX번호
                                    CstMstInfo.FAXNO = aPxTBxFaxNo.Text.Trim();

                                    //우편번호
                                    CstMstInfo.ZIPNO = aPxBTEtZipNo.Text.Trim();

                                    //주소
                                    CstMstInfo.ADDR1 = aPxTBxAddr1.Text.Trim();

                                    //상세주소
                                    CstMstInfo.ADDR2 = aPxTBxAddr2.Text.Trim();

                                    //특이사항
                                    CstMstInfo.REMARK1 = aPxTBxRemark.Text.Trim();

                                    //사용구분 RadioButtonList
                                    CstMstInfo.USETYPE = aPxRdoBtLstUseType.Items[aPxRdoBtLstUseType.SelectedIndex].Value.ToString();

                                    //담당자
                                    CstMstInfo.CHGNAME = aPxTBxChgName.Text;

                                    //담당자전화번호
                                    CstMstInfo.CHGOFFITEL = aPxTBxChgTel.Text;

                                    //담당자 메일주소
                                    CstMstInfo.CHGMAIL = aPxTBxChgMail.Text;

                                    CstMstInfo.REGUSER = userInfo.USERID;
                                    CstMstInfo.EDTUSER = userInfo.USERID;
                                    CstMstInfo.EDTDATIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss");
                                    CstMstInfo.REGDATIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss");

                                    using (CstMstDac dac = new CstMstDac())
                                    {
                                        string result = dac.SetCstMstInfo(CstMstInfo);

                                    }**

                        }
                    }
                }
                catch (Exception ex)
                {
                    LogManager.WriteLog(userInfo.UNTCD, LogEntryType.Exception, LogSourceType.WebPage, LogUtility.GetMethodName(), ex.Message, ex.StackTrace);
                }
                finally
                {
                    excel_Helper.Connection.Close();
                }
            }


// 칼럼이 안보일때 엑셀 다운로드 함수가서 확인


aPxGdVwItmMstInfo.DataColumns[0].Visible = false;
// aPxGdVwItmMstInfo.DataColumns[1].Visible = false;


// .aspx → .cs파일에 들어가서 → 팝업창 →  우클릭 정의로 이동 → readdataitem


// Ex

_Popup3DPMTN = new **DPMTNHisPop**(aPxCBkPn3DPMTNInfoPop, aPxPopCtrl3DPMTNInfo, aPxPnl3DPMTNInfo, UNTCD);



string.Format("{0:N0}", Int32.TryParse(dr["BUYCOST"].ToString(), out int buycost) ? buycost : 0) : "0";

aPxTBxWhsQty.Text = dr["WHSQTY"] != null ? string.Format("{0:N0}", Int32.TryParse(dr["WHSQTY"].ToString(), out int whsqty) ? whsqty : 0) : "0";
