function AddItemtoCart(ItemId) {
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: '/Cart/AddItemtoCart/' + ItemId,
        success: function (d) {
            var data = JSON.parse(d);
            if (data.CartItems.length > 0) {
                $('.noti_Counter').text(data.CartItems.length);
                var message = '<strong>' + Name + '</strong> Added to <a href="/cart">Cart</a> Successfully!'
                $('#toastCart > .toast-body').html(message)
                $('#toastCart').toast('show');
                setTimeout(function () {
                    $('#toastCart').toast('hide');
                }, 4000);
            }
        },
        error: function (result) {
        }
    });
}