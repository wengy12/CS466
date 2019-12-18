<%@ Page Language="C#" AutoEventWireup="true" CodeFile="webtime.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Current time</h1>

        </div>
        <div>

            You have visited this page
            <asp:Label id="lblvisits" Runat="server" />
            <br />
            times!

        </div>
           
        <asp:GridView ID="gvLocation" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="IPAddress" HeaderText="IP Address" />
                <asp:BoundField DataField="Timezone" HeaderText="Timezone" />
            </Columns>
        </asp:GridView>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
