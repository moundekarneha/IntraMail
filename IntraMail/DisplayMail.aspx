<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DisplayMail.aspx.cs" Inherits="IntraMail.DisplayMail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gmails</title>
    <link href="ProjectStyle.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .auto-style5 {
            width: 323px;
        }

        .auto-style6 {
            width: 716px;
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
                <table class="auto-style5">
                    <%-- sign out--%>
                    <tr>
                        <th colspan="2" class="auto-style6">
                            <br />
                            <asp:Button ID="btnLogout" CssClass="button" runat="server" Text="Sign Out" Height="29px" Width="168px" CausesValidation="false" OnClick="btnLogout_Click" />
                        </th>
                    </tr>
                    <%-- back --%>
                    <tr>
                        <td class="auto-style6">
                            <asp:HyperLink ID="linkBack" runat="server" Text="Back" CssClass="inbox" NavigateUrl="~/MainPage.aspx"></asp:HyperLink>
                        </td>
                    </tr>

                    <%-- Grid View to display inbox mail --%>
                    <tr>
                        <th cssclass="mails" class="auto-style6">
                            <asp:Label ID="lbl" runat="server" Text=""></asp:Label></th>
                    </tr>

                    <tr>


                        <td class="auto-style6">
                            <asp:GridView ID="gridDispInbox" runat="server" CssClass="gridView" AutoGenerateColumns="False" ShowHeader="false" GridLines="None">

                                <Columns>

                                    <%--                                                 <asp:BoundField DataField="MailFrom" HeaderText="<br />Mail From" ItemStyle-CssClass="inbox" />
                                                 <asp:BoundField DataField="DateOfTran" ItemStyle-CssClass="inbox" />
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:HyperLink ID="linkSub" runat="server" CssClass="inbox" NavigateUrl='<%# Eval("Sub","DisplayMail.aspx?Sub={0}") %>' DataTextField="Sub" Text='<%# Eval("Sub") %>'></asp:HyperLink>

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:BoundField DataField="Matter" ItemStyle-CssClass="inbox" />--%>

                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <table>
                                                <tr>
                                                    <td style="font-weight: bold">Mail From:<br />
                                                    </td>
                                                    <td><%# Eval("MailFrom")%><br />
                                                    </td>

                                                </tr>
                                                <tr>
                                                    <td style="font-weight: bold">Date:<br />
                                                    </td>
                                                    <td><%# Eval("DateOfTran")%><br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="font-weight: bold">Subject:<br />
                                                    </td>
                                                    <td><%# Eval("Sub")%><br />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="font-weight: bold">Body:<br />
                                                    </td>
                                                    <td><%# Eval("Matter")%><br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>

                                    </asp:TemplateField>

                                </Columns>

                            </asp:GridView>
                        </td>

                    </tr>
                    <%-- Forward --%>
                    <tr>
                        <td class="auto-style6">
                            <asp:HyperLink ID="HyperLink1" runat="server" Text="Forward" CssClass="inbox" NavigateUrl="~/Forward.aspx"></asp:HyperLink>
                        </td>
                    </tr>

                    <tr>
                        <td class="auto-style6">
                           <asp:HyperLink ID="HyperLink2" runat="server" Text="Reply" CssClass="inbox" NavigateUrl="~/Reply.aspx"></asp:HyperLink>
                        </td>
                    </tr>
                     
                </table>
            </div>
        </form>
    </center>
</body>
</html>
