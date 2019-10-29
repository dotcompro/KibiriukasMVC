//Generates an autocomplete drop down after first three letters are entered into the city textbox.
$(".locationsInput").autocomplete({
    minLength: 3,
    source: function (request, response) {
        $.ajax({
            url: Kibiriukas.Urls.baseUrl + "Profile/GetAutoCompleteGeoData",
            data: { location: $('.locationsInput').val() },
            dataType: "json",
            type: "GET",
            success: function (data) {
                response(JSON.parse(data));
            }
        });
    },
});

//Adds/removes html (language boxes) when a user checks/unchecks languages in the modal.
$(".langCheckbox").on("change", function () {
    var languageId = $(this).attr('id').split("_").pop();
    if ($(this).prop('checked')) {
        addUserLanguageRow(languageId);
    }
    else {
        $("#languageItems ." + $(this).attr('id')).remove();
        changeLangRowAttributes();
    }
});

//After language-box-html is added/removed manually, attributes corresponding with an object index need to be updated. 
function changeLangRowAttributes() {
    $('div.language').each(function (i, obj) {
        var userLangInput = $(obj).find('input:eq(0)');
        var langInput = $(obj).find('input:eq(1)');

        userLangInput.attr({
            "id": 'user_UserLanguages_' + i + '__UserLanguageId',
            "name": 'user.UserLanguages[' + i + '].UserLanguageId'
        });
        langInput.attr({
            "id": 'user_userLanguages_' + i + '__LanguageId',
            "name": 'user.UserLanguages[' + i + '].LanguageId'
        });
    });
}

//Removes html associated with a user language. 
$(document).on("click", "a.deleteLanguageRow", function () {
    $(this).parents("div.language:first").remove();
    changeLangRowAttributes();
});

//Returns an array of language ids of all languages, which are currently "selected" by the user. Selected languages don't have to already be saved in the database. 
function getCurrentlySelectedLangIds() {
    var currentlySelectedLanguageIds = [];
    $('.language').each(function (i, obj) {
        var langItemClass = obj.className.match(/langCheckbox_\d+/)[0];
        var lastChar = parseInt(langItemClass[langItemClass.length - 1]);
        currentlySelectedLanguageIds.push(lastChar);
    });
    return currentlySelectedLanguageIds;
}

//Unchecks languages in the modal which are not saved in the database as a language of the logged in user.
function uncheckLanguages() {
    var currentlySelectedLanguages = getCurrentlySelectedLangIds();
    $('.langCheckbox').each(function (i, obj) {
        var langItemId = obj.id.match(/langCheckbox_\d+/)[0];
        var lastChar = parseInt(langItemId[langItemId.length - 1]);
        if (!currentlySelectedLanguages.includes(lastChar)) {
            $('#' + langItemId).prop('checked', false);
        }
    });
}

$(".close, .finishedBtn").on("click", function () {
    $('div.languageModal').css("display", "none");
    uncheckLanguages();
});

$(".addLanguageRow").click(function () {
    uncheckLanguages();
    $('div.languageModal').css("display", "block");
});

$(".showProfile").click(function () {
    activateEditProfile();
});

$('.cancelEditProfile').click(function () {
    deactivateEditProfile();
})

//shows/hides validation error of self-introduction-textarea on focusout 
$('#selfIntroductionTextArea').focusout(function () {
    var selfIntroduction = $('#selfIntroductionTextArea').val();
    if (selfIntroduction.length > 0 && selfIntroduction.length < 30 || selfIntroduction.length > 0 && selfIntroduction.length > 200) {
        showValidationError('selfIntroValidationMsg', $('#selfIntroductionTextArea').attr('data-val-length'));
    } else if ($('.selfIntroValidationMsg').hasClass('field-validation-error')) {
        hideValidationError('selfIntroValidationMsg');
    }
});

//Checks if entered city exists and shows/hides validation error of city textbox on focusout. 
$('.locationsInput').focusout(function () {
    if ($('.locationsInput').val().length > 0) {
        $.ajax({
            url: Kibiriukas.Urls.baseUrl + "Profile/GetGeoDataByExactName",
            data: { location: $('.locationsInput').val() },
            dataType: "json",
            type: "GET",
            success: function (data) {
                if (JSON.parse(data)["totalResultsCount"] == 0) {
                    showValidationError('cityValidationMsg')
                } else {
                    hideValidationError('cityValidationMsg');
                }
            }
        })
    }
});

//Sets self introduction text area to the text that is saved in the database as self introduction of the logged in user. 
function getUserSelfIntro() {
    $.ajax({
        url: Kibiriukas.Urls.baseUrl + "Profile/GetUserSelfIntro",
        type: "GET",
        success: function (data) {
            if (jQuery.isEmptyObject(data)) {
                $('#selfIntroductionTextArea').val("");
            } else {
                $('#selfIntroductionTextArea').val(JSON.parse(data));
            }
        }
    });
}

//Sets city textbox to the text that is saved in the database as the user city. 
function getUserCity() {
    $.ajax({
        url: Kibiriukas.Urls.baseUrl + "Profile/GetUserCity",
        type: "GET",
        success: function (data) {
            $('.locationsInput').val(JSON.parse(data));
        }
    });
}

//Adjusts html associated with languages after edit profile form is canceled. Html is adjusted in a way so that language-html elements match the saved user languages in the database. 
function getUserLanguages() {
    $.ajax({
        url: Kibiriukas.Urls.baseUrl + "Profile/GetUserLanguages",
        type: "GET",
        success: function (data) {
            var dataArray = jQuery.makeArray(JSON.parse(data));
            var divsToBeDeleted = [];
            $('div.language').each(function (i, obj) {
                var langItemClass = obj.className.match(/langCheckbox_\d+/)[0];
                var lastChar = parseInt(langItemClass[langItemClass.length - 1]);
                if (!dataArray.includes(lastChar))
                    divsToBeDeleted.push(langItemClass);
            });
            $(divsToBeDeleted).each(function (i, obj) {
                $("#languageItems ." + obj).remove();
            });
            if ($('div.language').length < dataArray.length) {
                $(dataArray).each(function (i, obj) {
                    if ($(".langCheckbox_" + obj).length == 0) {
                        addUserLanguageRow(obj);
                    }
                });
            }
        }
    });
}

$(".cancelEditProfile").click(function () {
    getUserSelfIntro();
    getUserCity();
    hideValidationError('selfIntroValidationMsg');
    hideValidationError('cityValidationMsg');
    getUserLanguages();
});

//hides language modal on click away
$(window).click(function (e) {
    if (e.target.className == "languageModal") {
        unchecklanguages();
        $('div.languageModal').css("display", "none");
    }
});

//Generates html for the newly selected language and appends it
function addUserLanguageRow(langId) {
    $.ajax({
        url: Kibiriukas.Urls.baseUrl + "Profile/AddLanguageRow",
        data: { languageId: langId },
        //cache for unique ids
        cache: false,
        type: "POST",
        success: function (html) {
            var div = $(html).find('div.language');
            var UserLangIdInput = $(div).find('input:eq(0)');
            var LangIdInput = $(div).find('input:eq(1)');
            var objectPosition = $("#languageItems div").length;

            UserLangIdInput.attr({
                "id": 'user_UserLanguages_' + objectPosition + '__UserLanguageId',
                "name": 'user.UserLanguages[' + objectPosition + '].UserLanguageId'
            });
            LangIdInput.attr({
                "id": 'user_userLanguages_' + objectPosition + '__LanguageId',
                "name": 'user.UserLanguages[' + objectPosition + '].LanguageId'
            });
            $("#languageItems").append(div);
        }
    });
}

function activateEditProfile() {
    $('span.divider, a.showProfile, div #editProfileDiv').removeClass('editProfileInactive');
    $('span.divider, a.showProfile, div #editProfileDiv').addClass('editProfileActive');
}

function deactivateEditProfile() {
    $('span.divider, a.showProfile, div #editProfileDiv').removeClass('editProfileActive');
    $('span.divider, a.showProfile, div #editProfileDiv').addClass('editProfileInactive');
}

function showValidationError(elementClass, errorMessage) {
    $('.' + elementClass).removeClass('field-validation-valid');
    $('.' + elementClass).addClass('field-validation-error');
    $('.' + elementClass).text(errorMessage);
    $('.' + elementClass).css('display', 'block');
}

function hideValidationError(elementClass) {
    $('.' + elementClass).removeClass('field-validation-error');
    $('.' + elementClass).addClass('field-validation-valid');
    $('.' + elementClass).css('display', 'none');
}

function activateValidationFalseView() {
    activateEditProfile();
    $(".locationsInput").trigger("focusout");
    $("#selfIntroductionTextArea").trigger("focusout");
}

$(function () {
    if ($(".modelValidGetter").hasClass("invalid")) {
        activateValidationFalseView();
    }
});

//Shows the loading div and turns the whole background disabled-looking (grey)
function ShowProgress() {
    setTimeout(function () {
        var loadingBlock = $(".loadingWrapper");
        loadingBlock.show();
        $("body").addClass("pleaseWaitBackground");
    }, 200);
}

//Shows the loading div and turns the whole background enabled-looking
// kiekviena karta kai atliekamas kazkoks event yra perkraunamas puslapis ir aktyvuojasi window onload event
$(window).on('load', function () {
    setTimeout(function () {
        var loadingBlock = $(".loadingWrapper");
        loadingBlock.hide();
        $("body").removeClass("pleaseWaitBackground");
    }, 200);
    $('form').on("submit", null, function () {
        ShowProgress();
    });

});
