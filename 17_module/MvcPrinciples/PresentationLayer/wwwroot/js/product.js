$(document).ready(function () {
    $('.deleteProduct').click(function () {
        var clicked = $(this);
        clicked.attr('disabled', 'disabled');

        var productId = clicked.attr('data-name');
        var url = '/Product/RemoveProduct?productId=' + productId;
        console.log(url);

        $.get(url).done(function (answer) {
            if (answer) {
                clicked.closest('.productLine').remove();
            }
        });
    });

});