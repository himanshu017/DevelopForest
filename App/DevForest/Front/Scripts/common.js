$(function () {
    var trgts = $('.mainnav__link:eq(0)').attr('trgt');
    var CategoryId = $('.mainnav__link:eq(0)').attr('data-id');
    bindsubcategory(CategoryId);
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
            success: function (data) {
                $('#subnav').html('');
                $('#subnav').html(data);
            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert('Failed to retrieve books.');
            }
        });  
    }
});