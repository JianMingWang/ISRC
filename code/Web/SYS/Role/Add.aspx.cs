using FineUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ISRC.Web.SYS.Role
{
    public partial class Add : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnClose.OnClientClick = ActiveWindow.GetHideReference();
            }
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSave_Click(object sender, EventArgs e)
        {
            BLL.T_Sys_Role bllRole = new BLL.T_Sys_Role();
            Model.T_Sys_Role modelRole = new Model.T_Sys_Role();

            modelRole.ID = System.Guid.NewGuid().ToString();
            modelRole.RoleName = txbRoleName.Text.Trim();
            if (txbSortNo.Text.Trim() != "")
            {
                modelRole.SortNo = int.Parse(txbSortNo.Text);
            }
            else
            {
                modelRole.SortNo = 1;
            }
            modelRole.State = "0";

            if (bllRole.Add(modelRole))
            {
                Alert.ShowInTop("添加成功！", "信息", MessageBoxIcon.Information, ActiveWindow.GetHidePostBackReference("Main_Add_Success"));
            }
            else
            {
                Alert.ShowInTop("添加失败！", "错误", MessageBoxIcon.Error, ActiveWindow.GetHidePostBackReference("Main_Add_Fail"));
            }
        }
    }
}