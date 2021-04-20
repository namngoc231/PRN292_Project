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
    public partial class GiaoVien : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtMaGV.Text = Session["account"].ToString();
                txtMaGV.Enabled = false;

                ddlLop.DataTextField = "MaLop";
                ddlLop.DataValueField = "MaLop";
                ddlLop.DataSource = DAO.GetDataBySQL("SELECT DISTINCT kq.MaLop FROM dbo.tblKET_QUA  kq JOIN dbo.tblMON mon on kq.MaMon = mon.MaMon WHERE mon.MaGV = '"+ Session["account"]+ "'");
                ddlLop.SelectedValue = Session["ml"].ToString();
                ddlLop.DataBind();

                ddlMon.DataTextField = "MaMon";
                ddlMon.DataValueField = "MaMon";
                ddlMon.DataSource = DAO.GetDataBySQL("SELECT * FROM dbo.tblMON WHERE MaGV = '"+ Session["account"]+"'");
                ddlMon.SelectedValue = Session["mm"].ToString();
                // ddlMon.SelectedIndex = 0;
                ddlMon.DataBind();

            }
            loadOrder();
        }
        public void loadOrder()
        {

            tblDiemSV.DataSource = DAO.GetDataBySQL("SELECT kq.* FROM dbo.tblKET_QUA  kq JOIN dbo.tblMON mon on kq.MaMon = mon.MaMon WHERE kq.MaLop= '" + Session["ml"].ToString() + "' AND kq.MaMon = '" + Session["mm"].ToString() + "' and mon.MaGV = '" + txtMaGV.Text + "'");
            tblDiemSV.DataBind();
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
                Session["ml"] = ddlLop.SelectedValue.ToString();

                ddlMon.DataTextField = "MaMon";
                ddlMon.DataValueField = "MaMon";
                ddlMon.DataSource = DAO.GetDataBySQL("SELECT DISTINCT kq.MaMon FROM dbo.tblKET_QUA  kq JOIN dbo.tblMON mon on kq.MaMon = mon.MaMon WHERE kq.MaLop = '"+ddlLop.SelectedValue+"'");
                ddlMon.DataBind();


                tblDiemSV.DataSource = DAO.GetDataBySQL("SELECT * FROM dbo.tblKET_QUA WHERE MaLop = '" + ddlLop.SelectedValue + "' and  MaMon = '" + ddlMon.SelectedValue + "'");
                tblDiemSV.DataBind();
            }
        }

        protected void ddlMon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlMon.SelectedValue != null)
            {
                Session["mm"] = ddlMon.SelectedValue.ToString();

                tblDiemSV.DataSource = DAO.GetDataBySQL("  SELECT * FROM dbo.tblKET_QUA WHERE MaMon = '" + ddlMon.SelectedValue + "' and MaLop = '" + ddlLop.SelectedValue + "'");
                tblDiemSV.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            tblDiemSV.DataSource = DAO.GetDataBySQL("SELECT kq.* FROM dbo.tblKET_QUA  kq JOIN dbo.tblMON mon on kq.MaMon = mon.MaMon WHERE kq.MaLop= '"+ddlLop.SelectedValue+"' AND kq.MaMon = '"+ddlMon.SelectedValue+"' and mon.MaGV = '"+txtMaGV.Text+"'");
            tblDiemSV.DataBind();
        }
    }
}