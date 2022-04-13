<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecurityQue.aspx.cs" Inherits="IntraMail.SecurityQue" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gmail Application</title>
    <link href="ProjectStyle.css" rel="stylesheet" type="text/css" />
</head>
<body><center>
        <br />
        <br />
        <h1>Forget Password
        </h1>
        <br />
        <br />
    <form id="form1" runat="server">
        <div>
                <table>
                    

                    <%-- Username --%>
                    <tr>
                        <th>Username</th>
                        <td>
                            <br />
                            <asp:TextBox ID="txtUsername" runat="server" Height="20px" Width="181px"></asp:TextBox>
                        </td>
                        <td>
                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid username format" ControlToValidate="txtUsername" ValidationExpression="^([\w]*[\w\.]*(?!\.)@gmail.com)" ForeColor="Red"></asp:RegularExpressionValidator>--%>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtUsername"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <%-- Change Password --%>
                    <tr>
                        <th colspan="2">
                            <br />
                            <asp:Button ID="btnNext" CssClass="button" runat="server" Text="Next" Height="29px" Width="298px" OnClick="btnNext_Click"/>
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
