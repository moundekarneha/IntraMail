<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="IntraMail.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gmail Application</title>
    <link href="ProjectStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <center>
        <br />
        <br />
        <h1>Gmail Sign In
        </h1>
        <br />
        <br />
        <form id="form1" runat="server">
            <div>
                <table>
                    <%-- Email --%>
                    <tr>
                        <th>Enter Email</th>
                        <td>
                            <asp:TextBox ID="txtEmail" runat="server" Height="24px" Width="183px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid username format" ControlToValidate="txtEmail" ValidationExpression="^([\w]*[\w\.]*(?!\.)@gmail.com)" ForeColor="Red"></asp:RegularExpressionValidator>
                            
                        </td>
                    </tr>

                    <%-- Password --%>
                    <tr>
                        <th>
                            <br />
                            Enter Password</th>
                        <td>
                            <br />
                            <asp:TextBox ID="txtPass" runat="server" Height="20px" Width="181px" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPass"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <%-- Button Login --%>
                    <tr>
                        <th colspan="2">
                            <br />
                            <asp:Button ID="btnLogin" CssClass="button" runat="server" Text="Sign In" Height="29px" Width="298px" OnClick="btnLogin_Click" />
                        </th>
                    </tr>

                    <%-- Link Forget Password and Registration --%>
                    <tr>
                        <td>
                            <asp:HyperLink class="hyperlink" ID="LinkForgetPassword" runat="server" Text="<br/>Forget Password" NavigateUrl="~/SecurityQue.aspx"></asp:HyperLink>
                        </td>
                        <td>
                            <asp:HyperLink class="hyperlink" ID="LinkRegistration" runat="server" Text="<br/><center>Registration</center>" NavigateUrl="~/Registration.aspx"></asp:HyperLink>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblDisp" runat="server" Text=""></asp:Label>
            </div>
        </form>
    </center>
</body>
</html>
