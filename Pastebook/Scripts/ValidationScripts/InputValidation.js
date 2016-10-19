$(document).ready(function () {
    $('#txtEmailAddress').on('blur', function () {
        var data = {
            email: $('#txtEmailAddress').val()
        }
        $.ajax({
            url: CheckEmailAddressUrl,
            data: data,
            type: 'GET',
            success: function (data) {
                CheckEmailSuccess(data)
            },
            error: function () {
                alert("Oops. Something went wrong!")
            }
        })
    })

    function CheckEmailSuccess(data) {
        if (data.status == 1) {
            alert("OK")
        }
        else {
            alert("NOT OK")
        }
    }
});