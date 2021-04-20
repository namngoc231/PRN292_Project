using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Quanlydiemsv.DataAccess;
using Quanlydiemsv.Logic;

namespace Quanlydiem
{
    public partial class SinhVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtMaSV.Text = Session["account"].ToString();
                txtMaSV.Enabled = false;

                // ddlKhoa.DataTextField = "TenKhoa";
                // ddlKhoa.DataValueField = "MaKhoa";
                // ddlKhoa.DataSource = ListKhoa.getAllKhoa();
                // ddlKhoa.SelectedIndex = 0;
                // ddlKhoa.DataBind();

                ddlLop.DataTextField = "MaLop";
                ddlLop.DataValueField = "MaLop";
                ddlLop.DataSource = DAO.GetDataBySQL("SELECT DISTINCT kq.MaLop FROM dbo.tblKET_QUA kq  WHERE kq.MaSV = '" + Session["account"] + "'");
                ddlLop.SelectedIndex = 0;
                ddlLop.DataBind();

                ddlMon.DataTextField = "MaMon";
                ddlMon.DataValueField = "MaMon";
                ddlMon.DataSource = DAO.GetDataBySQL("SELECT DISTINCT kq.MaMon FROM dbo.tblKET_QUA  kq  WHERE kq.MaSV ='" + Session["account"] + "'");
                ddlMon.SelectedIndex = 0;
                ddlMon.DataBind();

            }
            loadOrder();
        }
        public void loadOrder()
        {

            tblDiemSV.DataSource = DAO.GetDataBySQL("  SELECT  kq.* FROM dbo.tblKET_QUA kq  WHERE kq.MaSV ='" + Session["account"] + "'");
            tblDiemSV.DataBind();
            // string CustomerID = Session["cid"].ToString();
            // int EmployeeID = Convert.ToInt32(Session["eid"]);
            // string from = Session["from"].ToString();
            // string to = Session["to"].ToString();

            //Page = Request.QueryString["page"] != null ? Convert.ToInt32(Request.QueryString["page"]) : 1;
            // Session["page"] = Page;
            // if (Request.QueryString["page"] != null)
            //     Page = Convert.ToInt32(Request.QueryString["page"]);
            //PageSize = Convert.ToInt32(ConfigurationManager.AppSettings["OrderPageSize"]);


        }
        protected void ddlKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            // if (ddlKhoa.SelectedValue != null)
            // {
            //     ddlMon.DataTextField = "TenMon";
            //     ddlMon.DataValueField = "MaMon";
            //     ddlMon.DataSource = DAO.GetDataBySQL("SELECT * FROM dbo.tblMon WHERE MaKhoa = '" + ddlKhoa.SelectedValue.ToString() + "'");
            //     ddlMon.DataBind();
            //
            //
            //     ddlLop.DataTextField = "TenLop";
            //     ddlLop.DataValueField = "MaLop";
            //     ddlLop.DataSource = DAO.GetDataBySQL("SELECT * FROM dbo.tblLOP WHERE MaKhoa = '" + ddlKhoa.SelectedValue.ToString() + "'");
            //     ddlLop.DataBind();
            // }
        }

        protected void ddLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLop.SelectedValue != null)
            {
                ddlMon.DataTextField = "MaMon";
                ddlMon.DataValueField = "MaMon";
                ddlMon.DataSource = DAO.GetDataBySQL("SELECT DISTINCT kq.MaMon FROM dbo.tblKET_QUA  kq JOIN dbo.tblMON mon on kq.MaMon = mon.MaMon WHERE kq.MaLop = '" + ddlLop.SelectedValue + "'");
                ddlMon.DataBind();

                tblDiemSV.DataSource = DAO.GetDataBySQL("SELECT * FROM dbo.tblKET_QUA WHERE MaLop = '" + ddlLop.SelectedValue + "' and  MaMon = '" + ddlMon.SelectedValue + "'");
                tblDiemSV.DataBind();
            }
        }

        protected void ddlMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMon.SelectedValue != null)
            { 
                tblDiemSV.DataSource = DAO.GetDataBySQL("  SELECT * FROM dbo.tblKET_QUA WHERE MaMon = '" + ddlMon.SelectedValue + "' and MaLop = '" + ddlLop.SelectedValue + "'");
                tblDiemSV.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            tblDiemSV.DataSource = DAO.GetDataBySQL("SELECT kq.* FROM dbo.tblKET_QUA  kq JOIN dbo.tblMON mon on kq.MaMon = mon.MaMon WHERE kq.MaLop= '" + ddlLop.SelectedValue + "' AND kq.MaMon = '" + ddlMon.SelectedValue + "' and kq.MaSV = '" + txtMaSV.Text + "'");
            tblDiemSV.DataBind();
        }
    }
}