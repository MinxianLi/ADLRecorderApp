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

    $("#weather").fadeOut(10000);
    $("#weather").fadeIn(10000);
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



//get ip
$.get("http://ipinfo.io", function (response) {
    $("#ip").html(response.ip);
    $("#address").html("Location: " + response.city + ", " + response.region);
    $("#details").html(JSON.stringify(response, null, 4));
    $("#details").html(JSON.stringify(response, null, 4));
}, "jsonp");



//setInterval("settime()", 1000);
//function settime() {
//    $("#weather").fadeOut(3000);
//    $("#weather").fadeIn(5000);
//}