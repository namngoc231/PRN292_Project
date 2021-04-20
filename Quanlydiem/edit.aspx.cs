using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Quanlydiemsv.Logic;
using Quanlydiemsv.DataAccess;

namespace Quanlydiem
{
    public partial class edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtMaSV.Enabled = false;
            txtHoTen.Enabled = false;
            txtMalop.Enabled = false;
            txtMamon.Enabled = false;
            txtdt.Enabled = false;
            txtdtk.Enabled = false;
            txtHocky.Enabled = false;
            txtGhichu.Enabled = false;
            if (!IsPostBack)
            {
                if (Request.QueryString["masv"] != null && Request.QueryString["mamon"] != null)
                {
                    string masv = Request.QueryString["masv"];
                    string mamon = Request.QueryString["mamon"];

                    List<KetQua> listKq = ListKetQua.getAllKetQua();
                    foreach (KetQua kq in listKq)
                    {
                        if (masv.Equals(kq.MaSV) && mamon.Equals(kq.MaMon))
                        {
                            txtMaSV.Text = kq.MaSV;
                            txtHoTen.Text = kq.HoTen;
                            txtMalop.Text = kq.MaLop;
                            txtMamon.Text = kq.MaMon;
                            txtdtb.Text = kq.DiemTB.ToString();
                            txtdt.Text = kq.DiemThi.ToString();
                            txtdtk.Text = kq.DiemTongKet.ToString();
                            txtHocky.Text = kq.HocKi;
                            txtGhichu.Text = kq.GhiChu;
                        }
                    }
                    // Response.Redirect("Order.aspx?page=" + Convert.ToInt32(Session["page"]));
                }
            }
            
        }

        private double diemtb, diemthi, diemtk;
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            diemtb = Convert.ToDouble(txtdtb.Text);
            diemthi = Convert.ToDouble(txtdt.Text);
            diemtk = (diemtb + diemthi) / 2;
            txtdtk.Text = diemtk.ToString();
            if (diemtk < 5)
            {
                txtGhichu.Text = "Thi lai";
            }
            else
            {
                txtGhichu.Text = "Qua mon";
            }
            
            int count = DAO.UpdateKetQua(txtMaSV.Text, txtHoTen.Text, txtMalop.Text, txtMamon.Text, diemtb, diemthi, diemtk, txtHocky.Text, txtGhichu.Text, txtMaSV.Text, txtMamon.Text);
            if (count > 0)
            {
                lbError.Text = "Update điểm thành công!";
            }
            else
            {
                lbError.Text = "Update điểm không thành công!";
            }
            
           
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            // Session["ml"] = txtMalop.Text;
            // Session["mm"] = txtMamon.Text;
            Response.Redirect("GiangVien.aspx");
        }
    }
}