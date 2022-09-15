<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="date.aspx.cs" Inherits="Rusada_Mvc_Demo.date" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>


<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lbldate" runat="server"></asp:Label>
            <br />
            <br />
          <asp:button runat="server" text="Button" ID="btn_insert" OnClick="Unnamed1_Click" /> 
        </div>
    </form>
</body>
</html>
