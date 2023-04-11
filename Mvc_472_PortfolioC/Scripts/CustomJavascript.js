/// <reference path="jquery-3.4.1.js" />
$(function () {
    $('#btnSubmit').mouseover(function () {
        $('#btnSubmit').css("backgroundColor", "red");
    });

    $('#btnSubmit').mouseout(function () {
        $('#btnSubmit').css("backgroundColor", "blue");
    });

});