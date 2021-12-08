using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace FullApplicationCrudInAsp
{
    public partial class SignUp : System.Web.UI.Page
    {
        string cs = ConfigurationManager.ConnectionStrings["CN"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtid.Text = GetRandomKey(6);
                bindCountry();
                ddlState.Items.Insert(0, "------Please Select State------");
                ddlCity.Items.Insert(0, "------Please Select City------");
            }
        }

        private string GetRandomKey(int len)
        {
            int maxSize = len;
            char[] chars = new char[30];
            string a;
            a = "1234567890";
            chars = a.ToCharArray();
            int size = maxSize;
            byte[] data = new byte[1];
            RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            size = maxSize;
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            StringBuilder result = new StringBuilder(size);
            foreach (byte b in data) { result.Append(chars[b % (chars.Length)]); }
            return result.ToString();
        }
        public void bindCountry()
        {

            SqlConnection con = new SqlConnection(cs);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from Country", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ddlCountry.DataSource = dt;
                ddlCountry.DataTextField = "County";
                ddlCountry.DataValueField = "CountryId";
                ddlCountry.DataBind();
                ddlCountry.Items.Insert(0, "------Please Select Country------");

                con.Close();
            }
            catch (Exception ex)
            {

            }

        }
        public void bindState()
        {

            SqlConnection con = new SqlConnection(cs);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select State,StateId from countryState where CountryId='" + ddlCountry.SelectedValue + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ddlState.DataSource = dt;
                ddlState.DataTextField = "State";
                ddlState.DataValueField = "StateId";
                ddlState.DataBind();
                ddlState.Items.Insert(0, "------Please Select State------");

                con.Close();
            }
            catch (Exception ex)
            {

            }

        }
        public void bindCity()
        {

            SqlConnection con = new SqlConnection(cs);
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select City,CityId from stateCity where StateId='" + ddlState.SelectedValue + "'", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                ddlCity.DataSource = dt;
                ddlCity.DataTextField = "City";
                ddlCity.DataValueField = "CityId";
                ddlCity.DataBind();
                ddlCity.Items.Insert(0, "------Please Select City------");
                con.Close();
            }
            catch (Exception ex)
            {

            }

        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindState();
        }
        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindCity();
        }
        public void userInsert()
        {
            List<string> skills = new List<string>();
            if (CheckBox1.Checked) { skills.Add(CheckBox1.Text); }
            if (CheckBox2.Checked) { skills.Add(CheckBox2.Text); }
            if (CheckBox3.Checked) { skills.Add(CheckBox3.Text); }

            string skillsadd = string.Join(", ", skills);

            SqlConnection con = new SqlConnection(cs);
            try
            {
                byte[] bytes;
                using (BinaryReader br = new BinaryReader(FileUpload1.PostedFile.InputStream))
                {
                    bytes = br.ReadBytes(FileUpload1.PostedFile.ContentLength);
                }
                con.Open();
                SqlCommand cmd = new SqlCommand("AddStudentRecord", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", txtid.Text);
                cmd.Parameters.AddWithValue("@Name", txtname.Text);
                cmd.Parameters.AddWithValue("@Class", txtclass.Text);
                cmd.Parameters.AddWithValue("@Age", txtage.Text);
                cmd.Parameters.AddWithValue("@Gender", RadioButtonList1.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@skills", skillsadd);
                cmd.Parameters.AddWithValue("@Image", bytes);
                cmd.Parameters.AddWithValue("@Country", ddlCountry.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@State", ddlState.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@City", ddlCity.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Username", txtuser.Text);
                cmd.Parameters.AddWithValue("@Password", txtpass.Text);
                cmd.Parameters.AddWithValue("@SchoolName", txtSchool.Text);
                cmd.Parameters.AddWithValue("@Address", txtAddress.Text);
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Response.Write("<script>alert('Record Saved Successfully')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Record Not saved!!')</script>");
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                con.Close();
            }
        }
        protected void btnSave_Command(object sender, System.Web.UI.WebControls.CommandEventArgs e)
        {
            userInsert();
        }
    }
}