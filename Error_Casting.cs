// 거래처정보창에 선택삭제할때 오류수정
    //예외 발생
        //'System.InvalidCastException'(eThinErp.Biz.dll)
    //오류 정보 → ‘System.String’형식 개체를 ‘Sysyem.Object[]’ 형식으로 캐스팅할 수 없습니다.


public override string DelDataItem()
        {
            using (CstMstDac dac = new CstMstDac())
            {
                List<object> list = aSPxGrdVw.GetSelectedFieldValues("CSTCD");

                string result = string.Empty;

                int sCnt = 0;
						//obejct[]
                foreach (string objs in list)
                {                             //objs[0]
                    result = dac.DelCstMstInfo(objs.ToString());

                    if (!ValidChkHelper.IsEmpty(result))
                    {
                        if (result != "EXIST")
                            sCnt++;
                    }
                }

                if (sCnt == list.Count)
                    return String.Format(_ResMgr.GetString("PG_CFM_MDELSUCCESS"), list.Count, sCnt);
                else
                    return String.Format(_ResMgr.GetString("PG_CFM_MDELFAILD"), list.Count, sCnt);

            }
        }
    }
}