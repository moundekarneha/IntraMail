<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Forward.aspx.cs" Inherits="IntraMail.Forward" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forward</title>
    <link href="ProjectStyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style3 {
            width: 281px;
        }

        .auto-style4 {
            width: 789px;
        }

        .auto-style5 {
            width: 323px;
        }
    </style>
</head>
<body>
    <center>
        <br />
        <br />
        <br />
        <br />
        <form id="form1" runat="server">
            <div>
                <h1>
                    <asp:Label ID="lblWelcome" runat="server" Text="Label"></asp:Label>
                </h1>
                <table>
                    <%--Logout --%>
                    <tr>
                        <th colspan="2">
                            <br />
                            <asp:Button ID="btnLogout" CssClass="button" runat="server" Text="Sign Out" Height="29px" Width="168px" OnClick="btnLogout_Click" CausesValidation="false" />
                        </th>
                    </tr>

                     <%-- back --%>
                    <tr>
                        <td class="auto-style6">
                            <asp:HyperLink ID="linkBack" runat="server" Text="Back" CssClass="inbox" NavigateUrl="~/MainPage.aspx"></asp:HyperLink>
                        </td>
                    </tr>

                    <%-- Compose Mail Heading --%>
                    <td class="auto-style3">
                        <asp:TextBox ID="TextBox3" runat="server" Text="Forward" CssClass="gmail" ReadOnly="true"></asp:TextBox>
                        <table>

                            <%-- Mail To --%>
                            <tr>
                                <th>Mail To</th>
                                <td>
                                    <br />
                                    <asp:TextBox ID="txtMailTo" runat="server" Height="20px" Width="181px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMailTo"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                            <%--                             <%-- Subject --%>
                            <%--  <tr>
                    <th>Subject</th>
                    <td><br />
                        <asp:TextBox ID="txtSubject" runat="server" Height="20px" Width="181px"></asp:TextBox>
                    </td>
                    <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSubject"></asp:RequiredFieldValidator>
                    </td>
                </tr>

                             <%-- Body of Mail --%>
                            <%--          <tr>
                    <th>Body Of Mail</th>
                    <td><br />
                        <asp:TextBox ID="txtMatter" runat="server" Height="59px" Width="181px" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMatter"></asp:RequiredFieldValidator>
                    </td>
                </tr>--%>

                            <%-- Send Mail --%>
                            <tr>
                                <th colspan="2">
                                    <br />
                                    <asp:Button ID="btnForwardMail" CssClass="button" runat="server" Text="Forward" Height="29px" Width="298px" OnClick="btnForwardMail_Click" />
                                </th>
                            </tr>
                        </table>
                    </td>
                    </tr>
                </table>
                <asp:Label ID="lblDisp" runat="server" Text=""></asp:Label>
            </div>
        </form>
    </center>
</body>
</html>
