using FineUI;
using System;
using System.Data;
using System.Text;

namespace ISRC.Web.JC.DeptIndex
{
    public partial class List : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btnAdd.OnClientClick = windowPop.GetShowReference("Add.aspx", "新增填报单位填报指标");
                BindDept();
                LoadData();
            }
        }

        private void LoadData()
        {
            //定义DataKeys集合
            gridDeptIndex.DataKeyNames = new string[] { "Dept_ID", "Index_Id" };

            DataSet ds = new DataSet();
            BLL.vw_Dept_Index bllDeptIndex = new BLL.vw_Dept_Index();
            StringBuilder sqlString = new StringBuilder();
            sqlString.Clear();
            if (ddlDept.SelectedValue.ToString() == "-1")
            {
                sqlString.Append(" 1=1");
            }
            else
            {
                sqlString.Append(" Dept_ID = '" + ddlDept.SelectedValue.ToString() + "'");
            }
            ds = bllDeptIndex.GetList(sqlString.ToString());
            DataTable dtSource = ds.Tables[0];
            gridDeptIndex.DataSource = dtSource;
            gridDeptIndex.DataBind();
        }

        private void BindDept()
        {
            BLL.T_Dept bllDept = new BLL.T_Dept();
            DataSet dsDept = bllDept.GetList("1=1");
            DataTable dtSource = dsDept.Tables[0];

            //添加首行
            DataRow dr = dtSource.NewRow();
            dr["Name"] = "请选择填报单位！";
            dr["ID"] = "-1";
            dtSource.Rows.InsertAt(dr, 0);

            ddlDept.DataSource = dtSource;
            ddlDept.DataTextField = "Name";
            ddlDept.DataValueField = "ID";
            ddlDept.DataBind();
            ddlDept.SelectedValue = "-1";
        }

        protected void ddlDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlDept.SelectedValue.ToString() != "-1")
            {
                Session["deptName"] = ddlDept.SelectedText.ToString();
                Session["deptId"] = ddlDept.SelectedValue.ToString();
                LoadData();
                btnAdd.Enabled = true;
            }
            else
            {
                LoadData();
                btnAdd.Enabled = false;
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            BLL.T_DeptIndex bllDeptIndex = new BLL.T_DeptIndex();

            //注意此处：多页删除时，默认为第一页，需根据页码计算行数
            //string id = gridDeptIndex.DataKeys[gridDeptIndex.PageIndex * gridDeptIndex.PageSize + gridDeptIndex.SelectedRowIndex][0].ToString();

            string DeptID = gridDeptIndex.DataKeys[gridDeptIndex.SelectedRowIndex][0].ToString();
            string IndexID = gridDeptIndex.DataKeys[gridDeptIndex.SelectedRowIndex][1].ToString();
            bool result = bllDeptIndex.Delete(DeptID,IndexID);
            if (result)
            {
                Alert.ShowInTop("删除成功", "信息", MessageBoxIcon.Information);
                LoadData();
            }
            else
            {
                Alert.ShowInTop("删除失败", "错误", MessageBoxIcon.Error);
                LoadData();
            }
        }

        protected void windowPop_Close(object sender, WindowCloseEventArgs e)
        {
            LoadData();
        }


        




    }
}