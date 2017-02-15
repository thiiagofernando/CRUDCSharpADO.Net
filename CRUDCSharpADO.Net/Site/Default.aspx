<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Site.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Home</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="jumbotron">
        <h1>Controle de Clientes</h1>

        Selecione Operação Desejada:
       <asp:DropDownList ID="ddlMenu" runat="server">
           <asp:ListItem Value="0" Text=" - Escolha Uma Opção - "></asp:ListItem>
           <asp:ListItem Value="1" Text="Cadastrar Cliente"></asp:ListItem>
           <asp:ListItem Value="2" Text="Consultar Cliente"></asp:ListItem>
           <asp:ListItem Value="3" Text="Obter Dados do Cliente"></asp:ListItem>
           
       </asp:DropDownList>
        <asp:Button ID="btnMenu" runat="server" Text="Acessar" CssClass="btn btn-info"/>
        
        <p>
            <asp:Label ID="lblMensagem" runat="server"></asp:Label>
        </p>
    
    </div>
    </form>
</body>
<script src="Scripts/jquery-1.9.1.min.js"></script>
<script src="Scripts/bootstrap.min.js"></script>
</html>
