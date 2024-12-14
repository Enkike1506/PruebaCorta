<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Class.aspx.cs" Inherits="PruebaCorta.Vistas.Class" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel="stylesheet" href="css/Style.css" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <nav>
        <ul>
	        <li><a href="Home.aspx">Home</a></li>
	        <li><a href="School.aspx">Schools</a></li>
	        <li><a href="Class.aspx">Classes</a></li>
        </ul>
</nav>
    <title>Class table</title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <br />
        <br />
        <h1>
            CLASS CATALOG
        </h1>
        <br />
        <div>
            <asp:GridView ID="GridViewClass" runat="server"></asp:GridView>
        </div>
        <br />
        <br />
        <div>
            Class's ID:
            <asp:TextBox ID="tId" Type="number" runat="server"></asp:TextBox>
            <br />
            School's ID:
            <asp:TextBox ID="tSchoolId" Type="number" runat="server"></asp:TextBox>
            <br />
            Class's name:
            <asp:TextBox ID="tName" runat="server"></asp:TextBox>
            <br />
            Class's description:
            <asp:TextBox ID="tDescription" runat="server"></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Button ID="bAdd" runat="server" Text="Add" OnClick="bAdd_Click" />
            <asp:Button ID="bEdit" runat="server" Text="Edit" OnClick="bEdit_Click" />
            <asp:Button ID="bDelete" runat="server" Text="Delete" OnClick="bDelete_Click" />
        </div>
    </form>
</body>
</html>
