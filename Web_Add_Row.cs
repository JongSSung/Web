// 소재사용, 입고등록 (단위 칸 추가) -> 단위있는거 참고

//자산관리번호 TextBox
ASPxButtonEdit aSPxBtnEdtMacCd = (ASPxButtonEdit)aPxPanel.FindControl("aSPxBtnEdtMacCd");
aSPxBtnEdtMacCd.Text = string.Empty;
aSPxBtnEdtMacCd.ClientIDMode = ClientIDMode.Static;
aSPxBtnEdtMacCd.MaxLength = 20;

ASPxTextBox aSPxTxtBxMacNm = (ASPxTextBox)aPxPanel.FindControl("aSPxTxtBxMacNm");
aSPxTxtBxMacNm.Text = string.Empty;
aSPxTxtBxMacNm.ClientIDMode = ClientIDMode.Static;
aSPxTxtBxMacNm.MaxLength = 50;

ASPxTextBox aSPxTxtBxMacNm = (ASPxTextBox)aSPxPanel.FindControl("aSPxTxtBxMacNm");
aSPxTxtBxMacNm.Text = dr["MACNM"] != null ? dr["MACNM"].ToString() : string.Empty;

<tr>
<th><span class="modal-th_name"><%= _ResMgr.GetString("PG_ITMNM") %></span> </th>
<td>
<dx:ASPxTextBox runat="server" ID="aPxTBxItmNm" ClientIDMode="Static" CssClass="txt_search" MaxLength="100" Style="float:left;">
</dx:ASPxTextBox>
<dx:ASPxTextBox ID="aPxTBxStdUnit" runat="server" ClientIDMode="Static" Style="float:left;" CssClass="txt_search" MaxLength="20"></dx:ASPxTextBox>
</td>
</tr>

<script>
var scpPopupCtrl = {
            OnFindItemClick: function (s, e) {
                aPxHdnFdSchItemPop.Set("pFuncName", "scpPopupCtrl.OnFindPopCallBack");
                aPxPopCtrlFItm.Show();
            },
            OnFindPopCallBack: function (p) {
                let v = p.split('|');
                if (v.length > 1) {
                    aSPxBtnEtItemCd.SetValue(v[0]);
                    aPxTBxItmNm.SetValue(v[1]);
                    aPxTBxStdUnit.SetValue(v[3]);

                }
                aPxPopCtrlFItm.Hide();
            },
        };
<script/>

ASPxTextBox aPxTBxStdUnit = (ASPxTextBox)aSPxPanel.FindControl("aPxTBxStdUnit");
ItmMstInfo.STDUNIT = ValidChkHelper.IsEmpty(aPxTBxStdUnit.Text) ? string.Empty : aPxTBxStdUnit.Text;

//소재사용 품명옆에 단위 보이게

//단위
GridViewDataTextColumn _ColStdUnit = new GridViewDataTextColumn();
_ColStdUnit.VisibleIndex = visibleIdx++;
_ColStdUnit.HeaderCaptionTemplate = new GrdVwColHeaderTemplate(_ResMgr.GetString("PG_STDUNIT"));
_ColStdUnit.FieldName = "STDUNIT";
_ColStdUnit.Width = Unit.Parse("5%");
_ColStdUnit.HeaderStyle.HorizontalAlign = HorizontalAlign.Center;
_ColStdUnit.CellStyle.HorizontalAlign = HorizontalAlign.Right;
_ColStdUnit.CellStyle.VerticalAlign = VerticalAlign.Middle;
aSPxGrdVw.Columns.Add(_ColStdUnit);


//단위
GridViewDataTextColumn _ColSTDUNIT = (GridViewDataTextColumn)aSPxGrdVw.Columns["STDUNIT"];
_ColSTDUNIT.HeaderCaptionTemplate = new GrdVwColHeaderTemplate(_ResMgr.GetString("PG_STDUNIT"));

//쿼리에서 데이터 집어넣기
//SQL
BEGIN
   
SELECT M.SEQNO, M.ITMCD, I.ITMNM,
			CAST(M.USEQTY AS DOUBLE) AS USEQTY,
			M.REMARK, M.REGUSER, M.EDTUSER, M.REGDATIME, M.EDTDATIME,E.STDUNIT
	FROM tb_macusehis M LEFT JOIN tb_itmmstinfo AS I ON I.ITMCD = M.ITMCD
	LEFT JOIN  tb_itmmstinfo AS E ON E.ITMCD = M.ITMCD
	WHERE (CASE WHEN _ITMCD != '' THEN M.ITMCD  LIKE  CONCAT('%', _ITMCD, '%') ELSE true END) 
	 AND	(CASE WHEN _ITMNM != '' THEN I.ITMNM LIKE  CONCAT('%', _ITMNM, '%') ELSE true END)
	ORDER BY M.REGDATIME DESC;
END

//ReadData쪽에 쿼리수정(STDUNIT열 추가) (‘STDUNIT’열이 없다고 오류뜸)
SELECT M.SEQNO, M.ITMCD, (SELECT I.ITMNM FROM tb_itmmstinfo I WHERE I.ITMCD = M.ITMCD) AS ITMNM,
			CAST(USEQTY AS DOUBLE) AS USEQTY,
			M.REMARK, M.REGUSER, M.EDTUSER, M.REGDATIME, M.EDTDATIME, E.STDUNIT
	FROM tb_macusehis M LEFT JOIN  tb_itmmstinfo E ON E.ITMCD = M.ITMCD
	WHERE SEQNO = SEQNO;
///SQL