//Client-Side에 추가
//필터정렬,필터검색,날짜조회후 검색하고 여러개 삭제시 오류발생
// 사유 : SEQNO의 Value값이 전달이 안된다.

//alert 메세지값
        var pFuncName = '';
        var MSG_MstDeleteWarning = '<%= _ResMgr.GetString("PG_CFM_MacPln_DelWarning") %>';
        var MSG_MultiDeleteWarning = '<%= _ResMgr.GetString("PG_CFM_MDELWARNING") %>';

        var MacPlnAct = {
            // 삭제
            DELETE_ITEM: function (GdvCtrl, CbPnlPopupCtrl, DParam, DType) {
                var datas = DParam.split('|');
                var rowCnt = GdvCtrl.GetSelectedRowCount();

                if (DType == 'DELETE|') {
                    if (confirm(MSG_MstDeleteWarning.replace('{0}', datas[0])))
                        CbPnlPopupCtrl.PerformCallback(DType + DParam);
                    else
                        return false;
                }
            },
            MULTI_DELETE_ITEM: function (GdvCtrl, CbPnlPopupCtrl, DParam ,   DType) {
                
                var rowCnt = GdvCtrl.GetSelectedRowCount();

                if (rowCnt > 0) {
                    if (DType == 'MULTDELETE|') {
                        if (confirm(MSG_MultiDeleteWarning.replace('{0}', rowCnt))){

                            //수정
                            CbPnlPopupCtrl.PerformCallback(DType) = GdvCtrl.GetSelectedFieldValues("SEQNO",GetSelectedFieldValuesCallback);

                            }
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else {
                    alert('선택된 항목이 없습니다!');
                    return false;
                }
            },

        }


        //추가
         function GetSelectedFieldValuesCallback(values) {

                return values;
        }