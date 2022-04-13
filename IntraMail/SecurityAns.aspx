<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SecurityAns.aspx.cs" Inherits="IntraMail.SecurityAns" %>

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


                    <%-- Security que--%>
                    <tr>
                        <th>Security Question</th>
                        <td>
                            <br />
                            <asp:TextBox ID="txtSecQues" runat="server" Height="20px" Width="181px" ReadOnly="true"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSecQues"></asp:RequiredFieldValidator>
                        </td>

                    </tr>
                    <%-- Security ans--%>
                    <tr>
                        <th>Security Answer</th>
                        <td>
                            <br />
                            <asp:TextBox ID="txtSecAnw" runat="server" Height="20px" Width="181px" AutoCompleteType="Disabled"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSecAnw"></asp:RequiredFieldValidator>
                        </td>

                    </tr>

                    <%-- Next --%>
                    <tr>
                        <%-- Next --%>
                        <th colspan="2">
                            <br />
                            <asp:Button ID="btnGo" CssClass="button" runat="server" Text="Next" Height="29px" Width="298px" OnClick="btnGo_Click" />
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
