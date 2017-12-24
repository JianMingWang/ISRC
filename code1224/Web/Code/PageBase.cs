using System;
using System.Web;
using FineUI;
using System.Collections.Generic;
using System.Data;


namespace ISRC.Web
{
    public class PageBase : System.Web.UI.Page
    {
        #region 当请求每个页面时，判断用户是否已登录、以及登录的角色是否具备访问该页面的权限

        /// <summary>
        /// 处理请求
        /// </summary>
        /// <param name="context"></param>
        public override void ProcessRequest(HttpContext context)
        {
            if (context.Session["AccountID"] == null)
            {
                //截取URL
                string url = context.Request.ApplicationPath.ToString();
                //拼接连接字符串
                context.Response.Write("<script type='text/javascript'>window.top.location = '" + url + "Login.aspx'</script>");
                //必须有return 否则上面语句不会执行
                return;
            }
            string roleId = context.Session["RoleID"].ToString();

            BLL.vw_Sys_RoleMenuUrl bllRoleMenuUrl = new BLL.vw_Sys_RoleMenuUrl();
            DataSet ds = bllRoleMenuUrl.GetList(" RoleID='" + roleId + "'");

            bool hasAuthority = false;
            string path = context.Request.Path;//当前请求的相对路径
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                string menuUrl = row["MenuUrl"].ToString();
                menuUrl = menuUrl.Substring(1, menuUrl.Length - 1);
                if (menuUrl.Equals(path))
                {
                    hasAuthority = true;
                    break;
                }
            }
            if (!hasAuthority && !path.Contains("Default"))
            {
                //截取URL
                string url = context.Request.ApplicationPath.ToString();
                //拼接连接字符串
                context.Response.Write("<script type='text/javascript'>window.top.location = '" + url + "Login.aspx'</script>");
                //必须有return 否则上面语句不会执行
                return;
            }
            base.ProcessRequest(context);
        }

        #endregion

        #region OnInit

        protected override void OnInit(EventArgs e)
        {
            var pm = PageManager.Instance;

            // 如果不是FineUI的AJAX回发（两种情况：1.页面第一个加载 2.页面非AJAX回发）
            if (pm != null && !pm.IsFineUIAjaxPostBack)
            {
                HttpCookie themeCookie = Request.Cookies["Theme_v4"];
                if (themeCookie != null)
                {
                    try
                    {
                        string themeValue = themeCookie.Value;
                        pm.Theme = (Theme)Enum.Parse(typeof(Theme), themeValue, true);
                    }
                    catch (Exception)
                    {
                        pm.Theme = FineUI.Theme.Neptune;
                    }
                }
                HttpCookie langCookie = Request.Cookies["Language_v4"];
                if (langCookie != null)
                {
                    try
                    {
                        string langValue = langCookie.Value;
                        pm.Language = (Language)Enum.Parse(typeof(Language), langValue, true);
                    }
                    catch (Exception)
                    {
                        pm.Language = Language.ZH_CN;
                    }
                }
            }
            base.OnInit(e);
        }

        private bool IsSystemTheme(string themeName)
        {
            themeName = themeName.ToLower();
            string[] themes = Enum.GetNames(typeof(Theme));
            foreach (string theme in themes)
            {
                if (theme.ToLower() == themeName)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region 压缩ViewState

        //protected override object LoadPageStateFromPersistenceMedium()
        //{
        //    string gzippedState = Request.Form[StringUtil.GZIPPED_VIEWSTATE_ID];
        //    return StringUtil.LoadGzippedViewState(gzippedState);
        //}

        //protected override void SavePageStateToPersistenceMedium(object viewState)
        //{
        //    ClientScript.RegisterHiddenField(StringUtil.GZIPPED_VIEWSTATE_ID, StringUtil.GenerateGzippedViewState(viewState));
        //} 

        #endregion

        #region 实用函数

        /// <summary>
        /// 获取回发的参数
        /// </summary>
        /// <returns></returns>
        public string GetRequestEventArgument()
        {
            return Request.Form["__EVENTARGUMENT"];
        }

        #endregion
    }
}
