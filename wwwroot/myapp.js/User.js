// Save user
$("#saveUser").on("click", function () {
   // let userCode = $("#UserCode").val();
    let userName = $("#UserName").val();
  //  let name = $("#Name").val();
    let email = $("#Email").val();
    let mobileNo = $("#MobileNo").val();
    let password = $("#Password").val();
    let role = $("#RoleId").val();
    let isActive = $("#IsActive").is(":checked");
    let userGuid = $("#UserGuid").val();

    if (userName.trim() == "") {
        WarningMsg("Please enter user name");
        return false;
    }
    else if (mobileNo.trim() == "") {
        WarningMsg("Please enter mobile no.");
        return false;
    }
    else if (password.trim() == "") {
        WarningMsg("Please enter password");
        return false;
    }
    else if (role.trim() == "0") {
        WarningMsg("Please select role");
        return false;
    }

    const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
    if (emailRegex.test(email)) {
        $("#Email").text(""); // Clear error message
    } else {
        WarningMsg("Please enter valid email");
        return false;
    }

    let req = JSON.stringify({
        UserName: userName,
        Email: email,
        MobileNo: mobileNo,
        Password: password,
        IsActive: isActive,
        UserGuid: userGuid,
        RoleId: role
    });

    $.ajax({
        url: "/User/Save",
        type: "POST",
        contentType: "application/json",
        data: req,
        success: function (response) {
            if (response != null) {
                if (response.flag == 1) {
                    SuccessMsg(response.message, "/User/Index");
                }
                else if (response.flag == 2) {
                    ErrorMsg(response.message);
                }
            }
        },
        error: function (xhr, status, error) {
            console.error("Error occurred:", error);
        }
    });
});

// Cancel button
$("#cancel").click(function () {
    window.location.href = "/User/Index";
});

//============== FOR PAGENATION=============
$(document).on("click", ".page-link", function (e) {
    e.preventDefault();
    loadTable($(this).data("page"), '', '', $("#rowsPerPage").val());
});
//==============END=============
// FOR SHOW PER PAGE DATA
$(document).on("change", "#rowsPerPage", function () {
    const rowsPerPage = $(this).val();
    const currentPage = $(".pagination .active").data("page") || 1;
    loadTable(currentPage, '', '', rowsPerPage);
});
//============================END==============================

let debounceTimeout;

$(document).on("keyup", ".filter-input", function () {
    const minLength = 3; // Minimum characters required to trigger the request

    // Clear the previous timeout
    clearTimeout(debounceTimeout);

    // Get the input value and track the focused element
    const $input = $(this);
    const value = $input.val();

    // Check if the value meets the minimum length
    if (value.length >= minLength || value.length === 0) {
        // Set a delay before making the AJAX call
        debounceTimeout = setTimeout(() => {
            const column = $input.data("column");
            loadTable(1, column, value); // Reset to page 1 when filters change
        }, 300); // Delay in milliseconds
    }
});


function loadTable(page, focusedColumn, focusedValue, rowsPerPage) {
    var filters = {
        usercode: $('input[data-column="usercode"]').val(),
        username: $('input[data-column="username"]').val(),
        email: $('input[data-column="email"]').val(),
        mobile: $('input[data-column="mobile"]').val(),
    };

    $.ajax({
        url: '/User/GetPagedUser',
        data: {
            page: page,
            rowperpage: rowsPerPage,
            userCode: filters.usercode,
            userName: filters.username,
            email: filters.email,
            mobile: filters.mobile,

        },
        success: function (data) {
            debugger;
            $('#userTableContainer').html(data);
            $('input[data-column="usercode"]').val(filters.usercode);
            $('input[data-column="username"]').val(filters.username);
            $('input[data-column="email"]').val(filters.email);
            $('input[data-column="mobile"]').val(filters.mobile);
            // Restore focus to the previously focused input field
            if (focusedColumn) {
                const $focusedInput = $(`input[data-column="${focusedColumn}"]`);
                $focusedInput.focus().val(focusedValue); // Restore focus and cursor position
            }
            $("#rowsPerPage").val(rowperpage);
        },
        error: function (xhr, status, error) {
            console.error("Error:", error);
        }
    });
}

$("#changepassword").click(function(){
    if ($("#Password").val() == "") {
        WarningMsg("Please enter password");
        return false;
    }
    let req = JSON.stringify({

        Password: $("#Password").val(),
        UserGuid: $("#UserGuid").val(),
        UserId: $("#UserId").val()
    });
    $.ajax({
        url: "/User/ChangePassword",
        type: "POST",
        contentType: "application/json",
        data: req,
        success: function (response) {
            if (response != null) {
                if (response.flag == 1) {
                    SuccessMsg(response.message, "/User/ChangePassword");
                }
                else if (response.flag == 2) {
                    ErrorMsg(response.message);
                }
            }
        },
        error: function (xhr, status, error) {
            console.error("Error occurred:", error);
        }
    });
});