<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<dynamic>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    

    <% if (Request.IsAuthenticated)
       { %>

    <form id="newmessage" action="" method="post">
        <input type="hidden" id="newmessage_username" value="<%: HttpContext.Current.User.Identity.Name %>" />
        <p>Message<br /><input type="text" id="newmessage_messagebody" size="70" />
        <input type="button" value="Send" id="newmessage_sendbutton" onclick="sendNewMessage()" /></p>
    </form>

    <% } %>

    <h2>Chat</h2>
    <h4 id="message"></h4>
    <div id="chatarea" style="border-top: 1px solid #DDD;">
    </div>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#message").html("Waiting for update...");
            var refreshId = setInterval(
                "updateChatArea()",
                5000);
        });

        function updateChatArea() {
            $.getJSON(
                "/Home/GetMessages/",
                null,
                function (data) {
                    debugger;
                    $("#message").html += "Fetching...";
                    $("#chatarea").html("");
                    var x;
                    if (data.length > 0) {
                        for (x in data) {
                            $("#chatarea").html(
                            $("#chatarea").html() +
                            "<p><b>" +
                            data[x].Username + "</b> <i>(" +
                            data[x].PostDate + ")</i> - " +
                            data[x].MessageBody + "</p>");
                        }
                    }
                    else {
                        $("#chatarea").html("<p>No Messages</p>");
                    }
                });
            $("#message").html("Messages loaded.");
        }
    </script>

    <% if (Request.IsAuthenticated)
       { %>
        
    <script type="text/javascript">
        function sendNewMessage() {
            $.post(
                "/Home/AddMessage",
                {
                    Username: $("#newmessage_username").val(),
                    MessageBody: $("#newmessage_messagebody").val()
                });
            $("#newmessage_messagebody").val("");
            updateChatArea();
        }
    </script>

    <% } %>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
