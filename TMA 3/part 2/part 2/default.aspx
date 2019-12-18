<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="part_2._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick"></asp:Timer>
                    <asp:Image ID="Image1" Height="500px"  runat="server" />
                    <br />
                    <asp:TextBox ID="TextBox1" runat="server" Width="422px"></asp:TextBox>
                    <br />
                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="start" />
                    <asp:Button ID="Button1" runat="server" Text="sequence" OnClick="Button1_Click" />
                    <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="backward" />
                </ContentTemplate>
            </asp:UpdatePanel>
           
        </div>
        
        <p>
            <asp:TextBox ID="TextBox2" runat="server" Width="657px">to start, just click corresponding button, all buttuns performs the action written on it</asp:TextBox>
        </p>
    </form>
</body>
</html>
