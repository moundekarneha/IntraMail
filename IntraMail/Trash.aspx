<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Trash.aspx.cs" Inherits="IntraMail.Trash" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Trash Page</title>
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

        .auto-style6 {
            height: 457px;
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
          <div class="auto-style6">
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
                                        <asp:Button ID="btnLogout" CssClass="button" runat="server" Text="Sign Out" Height="29px" Width="168px" CausesValidation="false" OnClick="btnLogout_Click" />
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

                                <%-- Grid View to display inbox mail --%>
                                <tr>
                                    <th cssclass="mails">
                                        <asp:Label ID="lbl" runat="server" Text=""></asp:Label></th>
                                </tr>
                                <tr>

                                    <td>
                                        <asp:GridView ID="gridDispTrash" runat="server" CssClass="gridView" AutoGenerateColumns="False" ShowHeader="false" GridLines="None" Width="1000px">

                                                 <Columns>

                                                <asp:TemplateField AccessibleHeaderText="Subject">
                                                    <ItemTemplate>
                                                        <%-- <asp:HyperLink ID="linkSub" runat="server" CssClass="inbox" NavigateUrl='<%# Eval("Sub","DisplaySentMail.aspx?Sub={0}") %>' DataTextField="Sub" Text='<%# Eval("Sub") %>'></asp:HyperLink>--%>

                                                        <asp:HyperLink runat="server" CssClass="inbox" NavigateUrl='<%# string.Format("~/DispTrash.aspx?Sub={0}&TrashId={1}",
                                                         HttpUtility.UrlEncode(Eval("Sub").ToString()), 
                                                          HttpUtility.UrlEncode(Eval("TrashId").ToString())) %>'
                                                            Text='<%# Eval("Sub") %>' />

                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:BoundField DataField="DateOfTran" ItemStyle-CssClass="inbox" />

                                            <%-- delete mails--%>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                    <asp:HyperLink runat="server" NavigateUrl='<%# Eval("TrashId","Trash.aspx?TrashId={0}")%>' Text="Delete" ForeColor="Black"></asp:HyperLink>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                            </Columns>
                                         

                                        </asp:GridView>
                                    </td>

                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
              <asp:Label ID="lblDisp" runat="server" Text=""></asp:Label>
            </div>
        </form>
</body>
</html>
