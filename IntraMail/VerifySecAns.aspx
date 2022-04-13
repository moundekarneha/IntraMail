<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VerifySecAns.aspx.cs" Inherits="IntraMail.VerifySecAns" %>

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

                    <%-- sec ans --%>
                    <tr>
                        <th>Security Answer</th>
                        <td>
                            <br />
                            <asp:TextBox ID="txtSecAns" runat="server" Height="20px" Width="181px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSecAns"></asp:RequiredFieldValidator>
                        </td>
                    </tr>



                    <%-- Next --%>
                    <tr>
                        <th colspan="2">
                            <br />
                            <asp:Button ID="btnNext" CssClass="button" runat="server" Text="Next" Height="29px" Width="298px" />
                        </th>
                    </tr>
                </table>
                <asp:Label ID="lblDisp" runat="server" Text=""></asp:Label>
            </div>
        </form>
</body>
</html>
