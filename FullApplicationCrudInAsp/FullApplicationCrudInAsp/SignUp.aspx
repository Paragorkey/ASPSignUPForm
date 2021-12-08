<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SignUp.aspx.cs" Inherits="FullApplicationCrudInAsp.SignUp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="container">
            <div class="row">
                <center>
                    <h3 style="font-family: 'Times New Roman', Times, serif">Registration Form</h3>
                </center>
                <div class="col-md-3"></div>
                <div class="col-md-3" style="margin-top: 15px">

                    <asp:Label ID="lblid" runat="server" Text="Id"></asp:Label>
                    <asp:TextBox ID="txtid" runat="server" CssClass="form-control" placeholder="Student Id"></asp:TextBox><br />
                    <asp:Label ID="lblname" runat="server" Text="Name"></asp:Label>
                    <asp:TextBox ID="txtname" runat="server" CssClass="form-control" placeholder="Enter Your Name"></asp:TextBox><br />
                    <asp:Label ID="lblclass" runat="server" Text="Class"></asp:Label>
                    <asp:TextBox ID="txtclass" runat="server" CssClass="form-control" placeholder="Enter Your Class"></asp:TextBox><br />
                    <asp:Label ID="lblage" runat="server" Text="Age"></asp:Label>
                    <asp:TextBox ID="txtage" runat="server" CssClass="form-control" placeholder="Enter Your age"></asp:TextBox><br />
                    <asp:Label ID="lblgender" runat="server" Text="Gender"></asp:Label>
                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" DataTextField="gender" DataValueField="gender">
                        <asp:ListItem>Male</asp:ListItem>
                        <asp:ListItem>Female</asp:ListItem>
                    </asp:RadioButtonList><br />
                    <asp:Label ID="Label4" runat="server" Text="Select Image:"></asp:Label>
                    <asp:FileUpload ID="FileUpload1" runat="server" /><br />
                    <br />
                    <br />
                    <asp:Label ID="Label5" runat="server" Text="Skills:"></asp:Label><br />
                    <asp:CheckBox ID="CheckBox1" runat="server" Text="Cricket" />
                    <asp:CheckBox ID="CheckBox2" runat="server" Text="Football" />
                    <asp:CheckBox ID="CheckBox3" runat="server" Text="Music" />
                </div>
                <div class="col-md-3" style="margin-top: 15px">
                    <asp:Label ID="Label1" runat="server" Text="Country"></asp:Label><br />
                    <asp:DropDownList ID="ddlCountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList><br />
                    <%--AutoPostBack="true" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">--%><%--</asp:DropDownList><br />--%>
                    <asp:Label ID="Label2" runat="server" Text="State"></asp:Label><br />
                    <asp:DropDownList ID="ddlState" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList><br />
                    <%--AutoPostBack="true" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">--%><%--</asp:DropDownList><br />--%>
                    <asp:Label ID="Label3" runat="server" Text="City"></asp:Label><br />
                    <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="true" CssClass="form-control"></asp:DropDownList><br />


                    <asp:Label ID="lblusername" runat="server" Text="Username"></asp:Label><br />
                    <asp:TextBox ID="txtuser" runat="server" CssClass="form-control" placeholder="Enter  Username"></asp:TextBox><br />

                    <asp:Label ID="lblPass" runat="server" Text="Password"></asp:Label><br />
                    <asp:TextBox ID="txtpass" runat="server" CssClass="form-control" placeholder="Enter Your Password" TextMode="Password"></asp:TextBox><br />
                    <asp:Label ID="lblschool" runat="server" Text="SchoolName"></asp:Label><br />
                    <asp:TextBox ID="txtSchool" runat="server" CssClass="form-control" placeholder="Enter Your School Name" TextMode="MultiLine"></asp:TextBox><br />
                    <asp:Label ID="lbladdress" runat="server" Text="Address"></asp:Label><br />
                    <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" placeholder="Enter Your Address" TextMode="MultiLine"></asp:TextBox><br />
                </div>

                <center>
                    <asp:Button ID="btnSave" runat="server" Text="Register Student" CssClass="btn btn-primary" OnCommand="btnSave_Command" /><br />
                </center>
            </div>
            <div class="col-md-3"></div>
        </div>
    </form>
</body>
</html>
