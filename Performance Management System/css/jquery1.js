function MutExChkList(chk) {
    var chkList = chk.parentNode.parentNode.parentNode;
    var chks = chkList.getElementsByTagName("input");
    for (var i = 0; i < chks.length; i++) {
        if (chks[i] != chk && chk.checked) {
            chks[i].checked = false;
        }
    }
}



function PrintPanel() {
    var panel = document.getElementById('.pnl');
    var printWindow = window.open('', '', 'height=400,width=800,toolbar=0');
    printWindow.document.write('<html><head><title</title>');
    printWindow.document.write('</head><body >');
    printWindow.document.write(panel.innerHTML);
    printWindow.document.write('</body></html>');
    printWindow.document.close();

    setTimeout(function () {
        printWindow.print();
    }, 500);
    return false;
}


function ValidateCheckBoxList(sender, args) {
    var checkBoxList = document.getElementById('.ch1');
    var checkboxes = checkBoxList.getElementsByTagName("input");
    var isValid = false;
    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i].checked) {
            isValid = true;
            break;
        }
    }
    args.IsValid = isValid;
}
function ValidateCheckBoxList1(sender, args) {
    var checkBoxList = document.getElementById('.ch2');
    var checkboxes = checkBoxList.getElementsByTagName("input");
    var isValid = false;
    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i].checked) {
            isValid = true;
            break;
        }
    }
    args.IsValid = isValid;
}
function ValidateCheckBoxList2(sender, args) {
    var checkBoxList = document.getElementById('.ch3');
    var checkboxes = checkBoxList.getElementsByTagName("input");
    var isValid = false;
    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i].checked) {
            isValid = true;
            break;
        }
    }
    args.IsValid = isValid;
}
function ValidateCheckBoxList3(sender, args) {
    var checkBoxList = document.getElementById('.ch4');
    var checkboxes = checkBoxList.getElementsByTagName("input");
    var isValid = false;
    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i].checked) {
            isValid = true;
            break;
        }
    }
    args.IsValid = isValid;
}
function ValidateCheckBoxList4(sender, args) {
    var checkBoxList = document.getElementById('.ch5');
    var checkboxes = checkBoxList.getElementsByTagName("input");
    var isValid = false;
    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i].checked) {
            isValid = true;
            break;
        }
    }
    args.IsValid = isValid;
}
function ValidateCheckBoxList5(sender, args) {
    var checkBoxList = document.getElementById('.ch6');
    var checkboxes = checkBoxList.getElementsByTagName("input");
    var isValid = false;
    for (var i = 0; i < checkboxes.length; i++) {
        if (checkboxes[i].checked) {
            isValid = true;
            break;
        }
    }
    args.IsValid = isValid;
}

////for back///////////
function preventBack() { window.history.forward(); }
setTimeout("preventBack()", 0);
window.onunload = function () { null };

/////////for navbar li/////////////////////

$(document).ready(function () {
    var url = window.location;
    $('.navbar .nav').find('.active').removeClass('active');
    $('.navbar .nav li a').each(function () {
        if (this.href == url) {
            $(this).parent().addClass('active');
        }
    });
});

///////////////////////////////////

// <script type = "text/javascript" src = "http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js" ></script >
//    <script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
//    <link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
//        rel="stylesheet" type="text/css" />
//    <script type="text/javascript">
//        $(function () {
//            $("#dialog").dialog({
//                autoOpen: false,
//                modal: true,
//                title: "Session Expiring",
//                buttons: {
//                    Ok: function () {
//                        ResetSession();
//                    },
//                    Close: function () {
//                        $(this).dialog('close');
//                    }
//                }
//            });
//        });
//    function SessionExpireAlert(timeout) {
//        var seconds = timeout / 1000;
//        $("#secondsIdle").html(seconds);
//        $("#seconds").html(seconds);
//        setInterval(function () {
//            seconds--;
//        $("#secondsIdle").html(seconds);
//        $("#seconds").html(seconds);
//    }, 1000);
//        setTimeout(function () {
//            //Show Popup before 20 seconds of timeout.
//            $('#dialog').dialog('open');
//        }, timeout - 20 * 1000);
//        setTimeout(function () {
//            //window.location = "login.aspx";


//        }, timeout);
//    };
//    function ResetSession() {
//            //Redirect to refresh Session.
//            window.location = window.location.href;
//        };
//</script>