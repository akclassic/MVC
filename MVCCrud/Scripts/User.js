function login() {

    const user = {
        Username: $('#username').val(),
        Password: $('#pwd').val()
    }

    $.ajax({
        type: "POST",
        url: '/Index/AuthenticateUser',
        data: JSON.stringify(user),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (response) {
            if (response) {
                location.href = "Employees/Index"
            } else {
                alert("You are not authenticated to user this service");
            }
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}