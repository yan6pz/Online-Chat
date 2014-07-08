<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Login
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% if ( ViewData["Message"] != null )
           if (ViewData["Message"].ToString().Length > 0)
           { %>
                <div style="padding: 30px; margin-top: 20px; margin-bottom: 20px; background-color: #ffaaaa;">
                    <%: ViewData["Message"] %>
                </div>
        <% } %>

    <h2>Login</h2>
    <% Html.BeginForm(); %>
	    <fieldset style="padding-top:20px">
	    <p>Username: <input type="text" id="username" name="username" value="" /></p>
	    <p>Password: <input type="password" id="password" name="password" value="" /></p>
	    <p><input type="submit" id="login" value="Login" /></p>
	    </fieldset>
    <% Html.EndForm(); %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
