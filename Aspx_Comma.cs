//그리드뷰에 숫자표시되면 3번째 마다 (,)표시


using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.UI;
using System.Threading;
using System.Text;
using System.Web.UI.WebControls;
using DevExpress.Web;
using eThinErp.Biz;

using eThinErp.Utilities;

namespace eThinErp.Biz.Templates
{
    public class GrdVwCommaDataItemTemplate : ITemplate
    {
        protected string _CallFunction = string.Empty; //"SetSltdCstFPop";
        public GrdVwCommaDataItemTemplate(string functionName)
        {
            _CallFunction = functionName;
        }
        public void InstantiateIn(Control container)
        {
            GridViewDataItemTemplateContainer gridContainer = (GridViewDataItemTemplateContainer)container;
            if (gridContainer.Text != null && !ValidChkHelper.IsEmpty(gridContainer.Text.Trim()) && !gridContainer.Text.Trim().Equals(@"&nbsp;"))
            {
                ASPxHyperLink link = new ASPxHyperLink();
                link.ClientSideEvents.Click = "function (s, e) { " + _CallFunction + "('" + gridContainer.KeyValue + "'); }";
                link.Text = String.Format("{0:#,##0}", Int32.TryParse(gridContainer.Text, out int txt) ? txt  : 0);
                container.Controls.Add(link);
            }
        }

        // _CtnrCtl.Text = String.Format("{0:N0}", gridContainer.Text);

    }
}
