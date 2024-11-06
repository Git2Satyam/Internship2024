function updateQuantity(id, total, quantity)
{
    if (id > 0 && quantity > 0) {
        $.ajax({
            type: "GET",
            contentType: "application/json",
            url: '/Cart/UpdateQuantity/' + id + "/" + quantity,
            success: function (data) {
                if (data > 0) {
                    location.reload()
                }
            },
            error: function (result) { }
        });
    }
    else if (id > 0 && quantity < 0 && total > 1) {
        $.ajax({
            type: "GET",
            contentType: "application/json",
            url: '/Cart/UpdateQuantity/' + id + "/" + quantity,
            success: function (data) {
                if (data > 0) {
                    location.reload();
                }
            },
            error: function (result) {
            },
        });
    }
}