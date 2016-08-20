setInterval("settime()", 1000);

function settime()
{
    var dateTime = new Date();
    var hour = dateTime.getHours();
    var minute = dateTime.getMinutes();
    var second = dateTime.getSeconds();

    if (minute < 10)
        minute = "0" + minute;

    if (second < 10)
        second = "0" + second;

    var time = dateTime ;

    $("#clock").text(time);
}


//<script type="text/javascript">
//    setInterval("settime()", 1000);

//function settime()
//{
//    var dateTime = new Date();
//    var hour = dateTime.getHours();
//    var minute = dateTime.getMinutes();
//    var second = dateTime.getSeconds();

//    if (minute < 10)
//        minute = "0" + minute;

//    if (second < 10)
//        second = "0" + second;

//    var time = dateTime ;

//    $("#clock").text(time);
//}
//</script>