<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReplySentMail.aspx.cs" Inherits="IntraMail.ReplySentMail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Reply Sent Page</title>
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
             <div>
                <h1>
                    <asp:Label ID="lblWelcome" runat="server" Text="Label"></asp:Label>
                </h1>
                <table>
                    <tr>
                        <td>
                            <table>
                                <%--Logout --%>
                                <tr>
                                    <th colspan="2">
                                        <br />
                                        <asp:Button ID="btnLogout" CssClass="button" runat="server" Text="Sign Out" Height="29px" Width="168px" OnClick="btnLogout_Click" CausesValidation="false" />
                                    </th>
                                </tr>

                                <%-- Gmail --%>
                                <tr>
                                    <td class="auto-style3">
                                        <asp:TextBox ID="TextBox1" runat="server" Text="Gmail" CssClass="gmail"></asp:TextBox>
                                    </td>
                                </tr>


                                <%-- Compose --%>
                                <tr>
                                    <td class="auto-style3">
                                        <asp:HyperLink ID="linkCompose" runat="server" Text="Compose" CssClass="inbox" NavigateUrl="~/Compose.aspx"></asp:HyperLink>
                                    </td>
                                </tr>

                                <%-- Inbox --%>
                                <tr>
                                    <td class="auto-style3">
                                        <asp:HyperLink ID="linkInbox" runat="server" Text="Inbox" CssClass="inbox" NavigateUrl="~/MainPage.aspx"></asp:HyperLink>
                                    </td>
                                </tr>

                                <%-- Sent Mail --%>
                                <tr>
                                    <td class="auto-style3">
                                        <asp:HyperLink ID="linkSentMail" runat="server" Text="Sent Mail" CssClass="inbox" NavigateUrl="~/SentMail.aspx"></asp:HyperLink>
                                    </td>
                                </tr>

                                <%-- Draft Mail --%>
                                <tr>
                                    <td class="auto-style3">
                                        <asp:HyperLink ID="linkDraftMail" runat="server" Text="Draft Mail" CssClass="inbox" NavigateUrl="~/Draft.aspx"></asp:HyperLink>
                                    </td>
                                </tr>

                                <%-- Trash Mail --%>
                                <tr>
                                    <td class="auto-style3">
                                        <asp:HyperLink ID="HyperLink1" runat="server" Text="Trash Mail" CssClass="inbox" NavigateUrl="~/Trash.aspx"></asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td class="auto-style4">
                            <table class="auto-style5">

                                <%-- Compose --%>
                                <tr>

                                    <%-- Compose Mail Heading --%>
                                    <td class="auto-style3">
                                        <asp:TextBox ID="TextBox3" runat="server" Text="Reply Mail" CssClass="gmail"></asp:TextBox>
                                        <table>
                                            <%-- back --%>
                                            <tr>
                                                <td class="auto-style6">
                                                    <asp:HyperLink ID="linkBack" runat="server" Text="Back" CssClass="inbox" NavigateUrl="~/MainPage.aspx"></asp:HyperLink>
                                                </td>
                                            </tr>

                                            <%-- Subject --%>
                                            <tr>
                                                <th>Subject</th>
                                                <td>
                                                    <br />
                                                    <asp:TextBox ID="txtSubject" runat="server" Height="20px" Width="181px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtSubject"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <%-- Body of Mail --%>
                                            <tr>
                                                <th>Body Of Mail</th>
                                                <td>
                                                    <br />
                                                    <asp:TextBox ID="txtMatter" runat="server" Height="59px" Width="181px" TextMode="MultiLine"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMatter"></asp:RequiredFieldValidator>
                                                </td>
                                            </tr>

                                            <%-- Send Mail --%>
                                            <tr>
                                                <th>
                                                    <br />
                                                    <asp:Button ID="btnDraft" CssClass="button" runat="server" Text="Draft" Height="29px" Width="298px" OnClick="btnDraft_Click" />
                                                </th>
                                                <th>
                                                    <br />
                                                    <asp:Button ID="btnSendMail" CssClass="button" runat="server" Text="Reply" Height="29px" Width="298px" OnClick="btnSendMail_Click" />
                                                </th>

                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblDisp" runat="server" Text=""></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
