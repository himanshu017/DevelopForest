$(function () {

    $('.mainnav__link').click(function () {
        var trgts = $(this).attr('trgt');
        var CategoryId = $(this).attr('data-id');
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

    });

});