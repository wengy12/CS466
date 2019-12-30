<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="part_3._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div id ="First" runat="server">
    <asp:CheckBoxList ID="CheckBoxList1" AutoPostBack="True" runat="server" OnSelectedIndexChanged="CheckBoxList1_SelectedIndexChanged">
        <asp:ListItem>part1</asp:ListItem>
        <asp:ListItem>part2</asp:ListItem>
    </asp:CheckBoxList>
    <asp:Label ID="Label1" runat="server" AssociatedControlID="CheckBoxList1"></asp:Label>
        
    </div>
    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    

</asp:Content>
