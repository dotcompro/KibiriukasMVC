function getDropDown2Data(id) {
    $.ajax({
        url: yourApp.Urls.baseUrl +"Subcategory/GetDropDown2Data",
        data: { categoryId: id },
        dataType: "json",
        type: "POST",
        success: function (data) {
            var items = "";
            $.each(data, function (i, subcategory) {
                items += "<option value=\"" + subcategory.SubcategoryId + "\">" + subcategory.SubcategoryTitle + "</option>";
            });

            $("#subcategoryDropDown").html(items);
        }
    });
}

// function for subcategory removal

var $delete = $('.controlAction');
var $confirmAction = $('.actionConfirm');


$(function () {

    $delete.on('click', function() {
        $(this).hide();
        $confirmAction.show();
        return confirm("woot");
    });

    function cancelDelete() {
        removeEvents();
        $confirmAction.hide();
        $delete.show();
    }

    function removeEvents() {
        confirmAction.off('click', deleteItem);
        $('document').on('click', cancelDelete);
        $('document').off('keypress', onkeypress);
    }

    function onKeypress(e) {
        if (e.which == 27) {
            cancelDelete();
        }
    }

    function deleteItem() {
        alert("deleted");
        // function for delete item. maybe
    }

    $confirmAction.on('click', deleteItem);
    $('document').on('click', cancelDelete);
    $('document').on('keypress', onKeypress);
});



$(document).ready(function () {

    $('.deleteSubcategory').css({
        minWidth: "6rem",
        width: "auto"
    });
    $confirmAction.css("display", "none");




    $("#categoryDropDown").change(function () {
        var id = $("#categoryDropDown").val();
        getDropDown2Data(id);
    });
});