str = grdView.GetFocusedDataRow().Field<string>("ColumnName");
 
//그리드에서 선택된 행의 데이터 가져오기
str = grdView.GetFocusedDataRow()["ColumnName"].ToString();
DataRow row = gvView.GetDataRow(gvView.FocusedRowHandle);
 
//그리드의 선택된 cell의 데이터 가져오기
string str = gvSample.GetFocusedRowCellValue("colName").ToString();
string str = gvSample.GetRowCellValue(rowHandle, columnName);
 
//특정 셀 값을 변경
gvSample.SetRowCellValue(rowHandle, columnName, value);
 
//멀티 선택인지 아닌저 설정
gridview.OptionsSelection.MultiSelect = true;
 
 
//그리드에 체크박스 넣고 체크박스로 멀티 row 선택하기
gridview.OptionsSelection.MultiSelect = true;
gridview.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
gridview.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
gridview.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
 
//그리드에서 행 선택시 row인지 cell인 설정
gv.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
 
 
//그리드 행 삭제시 주의사항 
//아래와 같이 순번으로 돌려서 삭제를 할 경우, 0번부터 올라가면서 지우면, 반정도 안지워진다. 
//이유는 row의 수가 하나씩 하나씩 증가를 한다 반대로 그리드에 있는 행수는 하나씩 줄고 있다.
// 총 10개의 행중 10개를 지운다고 했을 때 0번째 행, 1번째행 이렇게 삭제가 될 것이다. 
//행 또한 10개, 9개, 8개, 7개, 6개... 순으로 줄어들것이다. 
//6번째 행 삭제시, 그리드의 카운트는 4가될것이다. 그럼 지워지지 않는다. 
//루프문으로 지우고 싶다면 for문을 사용하여 뒤에서 카운트를 하면 지워질 것이다.
var rows = gvDetail.GetSelectedRows();
foreach (int row in rows)
        gvDetail.DeleteRow(row);
 
//일괄로 선택된 행을 지운다.
 gvDetail.DeleteSelectedRows();
 
//그리드에 Summary를 넣을 때 다음 두 코드중 하나를 사용한다.
gvMaster.OptionsView.ShowFooter = true;
colColumn.SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Count;
colColumn.SummaryItem.FieldName = "colColumn";
colColumn.SummaryItem.DisplayFormat = "Total  records";
////////////////////////////////////////
colColumn.Summary.Add(DevExpress.Data.SummaryItemType.Sum, "colColumn", "");
gv.OptionsView.ShowFooter = true;
 
//그리드 summary 공식 코드 
bvwMaster.Columns["ORG_AMT_TOT"].Summary.Add(DevExpress.Data.SummaryItemType.Sum, "ORG_AMT_TOT", "");
 
 
//멀티 선택이 가능한 그리드에서 선택된 행 정보를 가져와서 해당 행들을 변경 작업등을 한다.
var rows = gvGrid.GetSelectedRows();
foreach (int row in rows)
gvGrid.SetRowCellValue(row, "columnName", "value");
 
 
//Grid에  row가 아닌 cell을 선택 할수 있는 옵션 
grdView.OptionsSelection.MultiSelect = true;
grdView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect;
 
 
//cell merge 
//주의사항  OptionsColumn.AllowMerge을 default로 설정을 하면, 전체 cell들이 merge가 된다. 
//그러므로 merge를 안할 컬럼들은 option값을 false로 설정한다.
 GridOptionsView.AllowCellMerge 
 OptionsColumn.AllowMerge

 <code>BindingSource bindingSource = gridControlList_Mtrl_Dtl.DataSource as BindingSource;
DataTable dtSource = bindingSource.DataSource as DataTable;
//DataTable dtResult = (bindingSource.DataSource as DataTable).GetChanges(); //상태가 변경된 것만 조회
if (dtSource == null)
  return false;
 
//삭제된 행의 정보는 볼 수 없기 때문에 삭제된 행만 reject시킨다.
//if (row.RowState == DataRowState.Deleted)
//                    row.RejectChanges();
 
 
foreach (DataRow row in dtSource.Rows)
{
    if (row.RowState != DataRowState.Deleted)
    {
        if (row["MTRL_LOC_GB"].ToString().Equals("MLG_M"))
            cnt++;
    }
 
    if (row.RowState != DataRowState.Deleted)
    {
        if (dtSource.Select("MTRL_LOC_CD='" + row["MTRL_LOC_CD"] + "'").Length > 1)
        {
            MessageManager.ShowMessage(MessageType.Information, "SM0303");//자재위치가 중복되었습니다.
            return true;
        }
    }
}

private void Tab1Grid_BeforeLeaveRow(object sender, DevExpress.XtraGrid.Views.Base.RowAllowEventArgs e)
{
    if (e.RowHandle < 0)
        return;
 
    //main
    string fieldName = string.Empty;
    bool changed = false;
    if (dtBind1 != null)
    {
        var bindRow = ((AdvBandedGridView)sender).GetDataRow(e.RowHandle);
        int rowIndex = bindRow.Table.Rows.IndexOf(bindRow);
 
        if (bindRow.RowState != DataRowState.Added)
        {
            DataRow dtOriginal = dtBind1.Rows[rowIndex];
            for (int i = 0; i < ((AdvBandedGridView)sender).Columns.Count; i++)
            {
                fieldName = ((AdvBandedGridView)sender).Columns[i].FieldName;
                if (dtOriginal[fieldName].ToString() != bindRow[fieldName].ToString())
                    changed = true;
            }
        }
        else
        {
            changed = true;
        }
    }   
}