
// Save employee

$("#saveEmployee").on("click", function () {
    debugger;
    let empcode = $("#EmployeeCode").val();
    let empname = $("#EmployeeName").val();
    let desigid = $("#DesignationId").val();
    let tableuid = $("#TableauDesignationId").val();
    let managerid = $("#ManagerId").val();
    let doj = $("#DateofJoining").val();
    let dol = $("#Dateofleaving").val();
    let isactive = $("#IsActive").is(":checked");
    let empguid = $("#EmployeeGuid").val();

    if (empcode.trim() == "") {
        WarningMsg("Please enter employee code");
        return false;
    }
    else if (empname.trim() == "") {
        WarningMsg("Please enter employee name");
        return false;
    }
    else if (desigid.trim() == 0) {
        WarningMsg("Please select designation");
        return false;
    }
    else if (tableuid.trim() == "") {
        WarningMsg("Please select tableu designation");
        return false;
    }
    else if (doj.trim() == "") {
        WarningMsg("Please select date of joining");
        return false;
    }

    let req = JSON.stringify({ EmployeeCode: empcode, EmployeeName: empname, DesignationId: desigid, TableauDesignationId: tableuid, ManagerId: managerid, DateofJoining: doj, Dateofleaving: dol, IsActive: isactive, EmployeeGuid: empguid });
    $.ajax({
        url: "/Employee/Save",
        type: "POST",
        contentType: "application/json",
        data: req,
        success: function (response) {
            if (response != null) {
                if (response.flag == 1) {
                    SuccessMsg(response.message, "/Employee/Index");
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

// Check employee code
function ChkEmpCode() {
    debugger;
    let ss = "sadasd"; // JSON.stringify( $("#EmployeeCode").val());
    $.ajax({
        url: "/Employee/CheckEmpCode",
        //type: "POST",
        //contentType: "application/json",
        //dataType: "json",
        data: {
            EmpCode: $("#EmployeeCode").val()
           
        },
        success: function (response) {
            if (response != null) {
                
                if (response.flag == 2) {
                    WarningMsg(response.message);
                }
            }
        },
        error: function (xhr, status, error) {
            console.error("Error occurred:", error);
        }
    });
}

// cancel button
$("#cancel").click(function () {
    location.href = "/Employee/Index";
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
        empCode: $('input[data-column="empCode"]').val(),
        empName: $('input[data-column="empName"]').val(),
        designation: $('input[data-column="designation"]').val()
    };

    $.ajax({
        url: '/Employee/GetPagedEmployees',
        data: {
            page: page,
            rowperpage: rowsPerPage,
            empCode: filters.empCode,
            empName: filters.empName,
            designation: filters.designation
        },
        success: function (data) {
            $('#employeeTableContainer').html(data);
            $('input[data-column="empCode"]').val(filters.empCode);
            $('input[data-column="empName"]').val(filters.empName);
            $('input[data-column="designation"]').val(filters.designation);
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

