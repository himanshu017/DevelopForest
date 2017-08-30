$(function () {
    var trgts = $('.mainnav__link:eq(0)').attr('trgt');
    var CategoryId = $('.mainnav__link:eq(0)').attr('data-id');
    bindsubcategory(CategoryId);
    GetThemeLatest(0);
    GetThemeTrending(0);
    GetThemeRelated(0);
    $('.mainnav__link').click(function () {
        var trgts = $(this).attr('trgt');
        var CategoryId = $(this).attr('data-id');
        bindsubcategory(CategoryId);

    });

    function bindsubcategory(CategoryId) {
        $.ajax({
            cache: false,
            type: "POST",
            url: SubPath,
            data: { categoryid: CategoryId },
            async: false,
            success: function (data) {
                $('#subnav').html('');
                $('#subnav').html(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert('Failed to retrieve books.');
            }
        });
    }

    function GetThemeRelated(SubCategoryId) {
        $.ajax({
            cache: false,
            type: "POST",
            url: ThemeRelated,
            data: { SubCategoryId: SubCategoryId },
            async: false,
            success: function (data) {
                $('#ThemeRelated').html('');
                $('#ThemeRelated').html(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert('Failed to retrieve books.');
            }
        });
    }
});
function GetTheme(ctrl) {
    var SubCategoryId = $(ctrl).attr('data-id');
    GetThemeLatest(SubCategoryId);
    GetThemeTrending(SubCategoryId);
    GetThemeRelated(SubCategoryId);
}


function GetThemeLatest(SubCategoryId) {
    $.ajax({
        cache: false,
        type: "POST",
        url: ThemePath,
        data: { SubCategoryId: SubCategoryId },
        async: false,
        success: function (data) {
            $('#ThemeLatest').html('');
            $('#ThemeLatest').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError);
        }
    });
}

function GetThemeTrending(SubCategoryId) {
    $.ajax({
        cache: false,
        type: "POST",
        url: "/Home/GetThemeTrending",
        data: { SubCategoryId: SubCategoryId },
        async: false,
        success: function (data) {
            $('#ThemeTrending').html('');
            $('#ThemeTrending').html(data);
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert(thrownError);
        }
    });
}