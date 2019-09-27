//Shows the loading div and turns the whole background disabled-looking (grey)
function ShowProgress() {
    setTimeout(function () {
        var loadingBlock = $(".loadingWrapper");
        loadingBlock.show();
        $("body").addClass("pleaseWaitBackground");
    }, 200);
}

//Shows the loading div and turns the whole background enabled-looking
$(window).on('load', function () {
    console.log('11');
    setTimeout(function () {
        var loadingBlock = $(".loadingWrapper");
        loadingBlock.hide();
        $("body").removeClass("pleaseWaitBackground");
    }, 200);
});


$('form').on("submit", null, function () {
    ShowProgress();
});

$(document).ready(function () {
    console.log("hello");
    $("#categoryDropDown").change(function () {
        console.log("changed");
        //var id = $("#dropDown2").val();
        //getDropDown2Data(id);
    });
});