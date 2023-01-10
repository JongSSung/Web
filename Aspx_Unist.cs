//엑셀 날짜 수정해서 업로드시 데이터타입변경되어서 업로드가 안될시

var vStaDate = Dtset.Tables["SHEET1"].Rows[intvar][5].ToString().Trim();
//사용 시작일
vMacPlnHis.STADATE = !string.IsNullOrEmpty(vStaDate) && vStaDate.Length >= 10 ? vStaDate.Substring(0, 10) : "";//추가

var vFshDate = Dtset.Tables["SHEET1"].Rows[intvar][6].ToString().Trim();
//사용 종료일
vMacPlnHis.FSHDATE = !string.IsNullOrEmpty(vFshDate) && vFshDate.Length >= 10 ? vFshDate.Substring(0, 10) : "";//추가


//수정버튼 누를시 날짜 그대로 읽어와서 적용
<%--<ClientSideEvents Init="function(s,e){ s.SetDate(new Date());}" />--%>