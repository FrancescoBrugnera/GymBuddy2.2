$(document).ready(function () {

    console.log("Hello from me");

    var theForm = $("#theForm");
    theForm.hide;

    var button = $("#buyButton");
    button.on("click", function () {
        console.log("thanks for buying!!!!");
    });

    var productInfo = $(".lesson-props li");
    productInfo.on("click", function () {
        console.log("You clicked on" + $(this).text());
    });

    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".pop-up-form");

    $loginToggle.on("click", function () {
        $popupForm.toggle();
    });
});

