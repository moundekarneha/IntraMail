<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="IntraMail.Registration" %>

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
        <h1>Gmail Registration
        </h1>
        <br />
        <br />
        <form id="form1" runat="server">
            <div>
                <table>
                    <%-- First Name --%>
                    <tr>
                        <th>First Name</th>
                        <td>
                            <asp:TextBox ID="txtFirstName" runat="server" Height="24px" Width="183px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtFirstName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <%-- Last Name --%>
                    <tr>
                        <th>Last Name</th>
                        <td>
                            <br />
                            <asp:TextBox ID="txtLastName" runat="server" Height="20px" Width="181px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtLastName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>


                    <%-- Username --%>
                    <tr>
                        <th>Username</th>
                        <td>
                            <br />
                            <asp:TextBox ID="txtUserName" runat="server" Height="20px" Width="181px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Invalid username format" ControlToValidate="txtUserName" ValidationExpression="^([\w]*[\w\.]*(?!\.)@gmail.com)" ForeColor="Red"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <%-- Password --%>
                    <tr>
                        <th>Password</th>
                        <td>
                            <br />
                            <asp:TextBox ID="txtPassword" runat="server" Height="20px" Width="181px" TextMode="Password"></asp:TextBox>
                        </td>
                        <td><%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="RegularExpressionValidator" ForeColor="Red" ControlToValidate="txtPassword" ValidationExpression=" (?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[^A-Za-z0-9])(?=.{8,})"></asp:RegularExpressionValidator> --%>

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
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Password Mismatch" ControlToCompare="txtPassword" ControlToValidate="txtConPassword"></asp:CompareValidator>
                        </td>
                    </tr>

                    <%-- Date Of Birth--%>
                    <tr>
                        <th>Date Of Birth</th>
                        <td>
                            <br />
                            <asp:TextBox ID="txtDob" runat="server" Height="20px" Width="181px" TextMode="Date"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtDob"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <%-- Mobile Number--%>
                    <tr>
                        <th>Mobile Number</th>
                        <td>
                            <br />
                            <asp:TextBox ID="txtMobileNum" runat="server" Height="20px" Width="181px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Please enter 10 digit mobile number" ValidationExpression="^[0-9]{10}$" ValidateRequestMode="Enabled" ControlToValidate="txtMobileNum" ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtMobileNum"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <%-- Address--%>
                    <tr>
                        <th>Address</th>
                        <td>
                            <br />
                            <asp:TextBox ID="txtAddress" runat="server" Height="61px" Width="184px" TextMode="MultiLine"></asp:TextBox>
                        </td>
                        <td>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
                        </td>
                    </tr>

                    <%-- Security Questions--%>
                    <tr>
                        <th>
                            <br />
                            Security Questions</th>
                        <td>
                            <asp:DropDownList ID="dropDownSecQuestions" runat="server">
                                <asp:ListItem>
                                 Please select
                                </asp:ListItem>
                                <asp:ListItem>
                                 Favorite dish?
                                </asp:ListItem>
                                <asp:ListItem>
                                 Favorite pet?
                                </asp:ListItem>
                                <asp:ListItem>
                                 Favorite color?
                                </asp:ListItem>
                                <asp:ListItem>
                                 Favorite movie?
                                </asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <%-- Security Answer--%>
                    <tr>
                        <th>
                            <br />
                            Security Answer
                        </th>
                        <td>
                            <asp:TextBox ID="txtSecAnswer" runat="server" Width="181px"></asp:TextBox>
                        </td>
                    </tr>

                    <%-- Registration --%>
                    <tr>
                        <th colspan="2">
                            <br />
                            <asp:Button ID="btnRegistration" CssClass="button" runat="server" Text="Register" Height="29px" Width="298px" OnClick="btnRegistration_Click" />
                        </th>
                    </tr>

                    <%-- Link Login --%>
                    <tr>
                        <td>
                            <asp:HyperLink class="hyperlink" ID="LinkLogin" runat="server" Text="<br/>Sign In" NavigateUrl="~/Login.aspx"></asp:HyperLink>
                        </td>
                    </tr>
                </table>
                <asp:Label ID="lblDisp" runat="server" Text=""></asp:Label>
            </div>
        </form>
    </center>
</body>
</html>

