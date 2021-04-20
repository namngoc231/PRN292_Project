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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string tendn = txtUserName.Text;
            string matkhau = txtPassword.Text;
            List<Quanlydiemsv.Logic.Login> listLogin = ListLogin.getAllLogin();
            foreach (Quanlydiemsv.Logic.Login account in listLogin)
            {
                if (account.TenDN.Equals(tendn) && account.MatKhau.Equals(matkhau))
                {
                    Session["account"] = account.MaSo;
                    if (account.Quyen.Equals("SV"))
                    {
                        Response.Redirect("SinhVien.aspx");
                    }
                    else
                    {
                        Response.Redirect("GiangVien.aspx");
                    }
                }
                else
                {
                    lbError.Text = "Tên đăng nhâp hoặc mật khẩu không đúng!";
                }
            }
           
        }
    }
}