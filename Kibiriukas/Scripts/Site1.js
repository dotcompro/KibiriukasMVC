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

$(document).ready(function () {
    $("#categoryDropDown").change(function () {
        var id = $("#categoryDropDown").val();
        getDropDown2Data(id);
    });
});