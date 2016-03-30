<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="ConfluenceAutomator.WebClient.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="Scripts/jquery-2.2.2.min.js"></script>
    <script type="text/javascript">
        $(document).ready(
            function () {
                //console.log("NOW READY");
                $.ajax({
                    url: "http://localhost:63999/api/ConfluenceStructure/post",
                    type: "POST",
                    data: "{'Title':'TST 101','Key':'TS9','Description':'The Description','ParentKey':'BPM'}",
                    contentType: "application/json; charset=utf-8",
                    success: function (response) {
                        // you will get response from your php page (what you echo or print)                 
                        console.log(response);
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        console.log(textStatus, errorThrown);
                    }


                });
            }

            //"{"Title":"TST 101","Key":"TS9","Description":"The Description","ParentKey":"BPM"}"
        );
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Main Form</h1>
    </div>
    </form>
</body>
</html>
