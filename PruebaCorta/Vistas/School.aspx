<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="School.aspx.cs" Inherits="PruebaCorta.Vistas.School" %>

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
    <title>School table</title>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <br />
        <br />
        <br />
        <h1>
            SCHOOL CATALOG
        </h1>
        <br />
        <div>
            <asp:GridView ID="GridViewSchool" runat="server"></asp:GridView>
        </div>
        <br />
        <br />
        <div>
            School's ID:
            <asp:TextBox ID="tId" Type="number" runat="server"></asp:TextBox>
            <br />
            School's name:
            <asp:TextBox ID="tName" runat="server"></asp:TextBox>
            <br />
            School's description:
            <asp:TextBox ID="tDescription" runat="server"></asp:TextBox>
            <br />
            School's address:
            <asp:TextBox ID="tAddress" runat="server"></asp:TextBox>
            <br />
            School's phone:
            <asp:TextBox ID="tPhone" runat="server"></asp:TextBox>
            <br />
            School's post code:
            <asp:TextBox ID="tPostCode" runat="server"></asp:TextBox>
            <br />
            School's post address:
            <asp:TextBox ID="tPostAddress" runat="server"></asp:TextBox>
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
