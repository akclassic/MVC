

$(function () {
    displayGrid();
});

function displayGrid() {

    $.ajax({
        type: "Get",
        url: '/Employees/EmployeeGrid',
        //data: '{customerId: "' + customerId + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (response) {
            $('#employeegrid').html(response);
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

function loadModal(id) {
    console.log('id', id);
    $.ajax({
        type: "Get",
        url: '/Employees/EmployeeModal?id=' + id,
        //data: id,
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (response) {
            console.log(response);
            $('#bodyMain').html(response);
            $('#modalHead').show();
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}

function closeModal() {
    $('#modalHead').hide();
}

function saveemployee() {
    let employee = {
        Id: document.getElementById('id').value,
        Name: document.getElementById('name').value,
        Desgination: document.getElementById('designation').value,
        Salary: document.getElementById('salary').value
    }

    //let formdata = new FormData($('#employeeform').get(0));

    $.ajax({
        type: "POST",
        url: '/Employees/UpdateEmployee',
        data: JSON.stringify(employee),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (response) {
            if (response) {
                closeModal();
                alert('Details Updated');
                displayGrid();
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


function deleteEmployee(id) {
    $.ajax({
        type: "Get",
        url: '/Employees/DeleteEmployee?id='+id,
        //data: JSON.stringify(employee),
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (response) {
            if (response) {
                alert('Employee record deleted');
                displayGrid();
            }
            
            //$('#employeegrid').html(response);
            //location.reload();
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}
//document.onload = displayGrid();

function addEmployee(id) {
    $.ajax({
        type: "Get",
        url: '/Employees/EmployeeModal?id=' + id,
        //data: id,
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (response) {
            console.log(response);
            $('#bodyMain').html(response);
            $('#modalHead').show();
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}