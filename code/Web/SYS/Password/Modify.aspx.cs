using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineUI;

namespace ISRC.Web.SYS.Password
{
    public partial class Modify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnChangePW_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.T_Sys_Account bllAccount = new BLL.T_Sys_Account();
                Model.T_Sys_Account modelAccount = bllAccount.GetModel(Session["AccountID"].ToString());
                if (txbOldPW.Text.ToString().Trim() == modelAccount.AccountPsw.ToString())
                {
                    modelAccount.AccountPsw = txbNewPW.Text.ToString().Trim();
                    if (bllAccount.Update(modelAccount))
                    {
                        Alert.ShowInTop("密码修改成功！");
                    }
                    else
                    {
                        Alert.ShowInTop("密码修改失败！", MessageBoxIcon.Error);
                    }
                }
                else
                {
                    txbOldPW.Text = "";
                    txbNewPW.Text = "";
                    txbNewPWConfirm.Text = "";
                    Alert.ShowInTop("密码错误！", MessageBoxIcon.Error);
                }
            }
            catch
            {
                Alert.ShowInTop("登陆超时，请重新登录！", MessageBoxIcon.Error);
            }
        }

        protected void txbNewPWConfirm_TextChanged(object sender, EventArgs e)
        {
            if (txbNewPWConfirm.Text.ToString().Trim() == txbNewPW.Text.ToString().Trim() && (txbNewPWConfirm.Text.ToString().Trim() != ""))
            {
                labelError.Hidden = true;
                btnChangePW.Enabled = true;
            }
            else
            {
                labelError.Hidden = false;
                btnChangePW.Enabled = false;
            }
        }
    }
}