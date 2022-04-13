<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="IntraMail.ForgetPassword" %>

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
        <h1>Forget Password
        </h1>
        <br />
        <br />
        <form id="form1" runat="server">
            <div>
                <table>

                    <%-- Password --%>
                    <tr>
                        <th>Password</th>
                        <td>
                            <br />
                            <asp:TextBox ID="txtPassword" runat="server" Height="20px" Width="181px" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <%-- Confirm Password --%>
                    <tr>
                        <th>Confirm Password</th>
                        <td>
                            <br />
                            <asp:TextBox ID="txtConPassword" runat="server" Height="20px" Width="181px" TextMode="Password"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtConPassword"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Mismatch" ControlToCompare="txtPassword" ForeColor="Red" ControlToValidate="txtConPassword"></asp:CompareValidator>
                        </td>
                    </tr>

                    <%-- Change Password --%>
                    <tr>
                        <th colspan="2">
                            <br />
                            <asp:Button ID="btnChangePassword" CssClass="button" runat="server" Text="Change Password" Height="29px" Width="298px" OnClick="btnChangePassword_Click" />
                        </th>
                        <%-- Back --%>
                        <td>
                            <asp:HyperLink class="hyperlink" ID="linkBack" runat="server" Text="<br/>Back" NavigateUrl="~/Login.aspx"></asp:HyperLink>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblDisp" runat="server" Text=""></asp:Label>
            </div>
        </form>
</body>
</html>
