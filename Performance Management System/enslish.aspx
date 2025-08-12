<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="enslish.aspx.vb" Inherits="Performance_Management_System.enslish" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
        bharat
    </title>
    <script src="http://translate.google.com/translate_a/element.js?cb=googleTranslateElementInit"></script>
<script>
    function googleTranslateElementInit() {
        $.when(
                new google.translate.TranslateElement({pageLanguage: 'en', includedLanguages: 'en',
                    layout: google.translate.TranslateElement.FloatPosition.TOP_LEFT}, 'google_translate_element')
            ).done(function(){
                var select = document.getElementsByClassName('goog-te-combo')[0];
                select.selectedIndex = 1;
                select.addEventListener('click', function () {
                    select.dispatchEvent(new Event('change'));
                });
                select.click();
            });
    }
    $(window).on('load', function() {
        var select = document.getElementsByClassName('goog-te-combo')[0];
        select.click();
        var selected = document.getElementsByClassName('goog-te-gadget')[0];
        selected.hidden = true;
    });
</script>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="google_translate_element" style="border-color:black"> </div>
        </div>

        <h1>kjdfshjkhds hfkuh</h1>
    </form>
</body>
</html>
