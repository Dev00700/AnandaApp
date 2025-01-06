$("#save").on("click", function () {
    // let userCode = $("#UserCode").val();
    let custCode = $("#CustCode").val();
    let division = $("#Division").val();
    let dic = $("#DIC").val();
    let lineDET = $("#Line_DET").val();
    let lineType = $("#Line_Type").val();
    let lineType2 = $("#Line_Type2").val();
    let isActive = $("#IsActive").is(":checked");
    let exportCustGrpGuid = $("#ExportCustGrpGuid").val();

    if (dic.trim() == "0"||dic=="") {
        WarningMsg("Please enter DIC name");
        return false;
    }
    else if (lineType.trim() == "" || lineType=="") {
        WarningMsg("Please enter LineType");
        return false;
    }
    else if (custCode.trim() == "" || custCode == "") {
        WarningMsg("Please enter Customer Code");
        return false;
    }
    else if (division.trim() == "0" || division == "") {
        WarningMsg("Please enter Division");
        return false;
    }
    else if (lineDET.trim() == "0" || lineDET == "") {
        WarningMsg("Please enter Line DET");
        return false;
    }
    else if (lineType2.trim() == "0" || lineType2 == "") {
        WarningMsg("Please enter Line Type2");
        return false;
    }



    let req = JSON.stringify({
        CustCode: custCode,
        Division: division,
        DIC: dic,
        Line_DET: lineDET,
        Line_Type: lineType,
        Line_Type2: lineType2,
        IsActive: isActive,
        ExportCustGrpGuid: exportCustGrpGuid
    });

    $.ajax({
        url: "/ExportCustomerGroup/Save",
        type: "POST",
        contentType: "application/json",
        data: req,
        success: function (response) {
            if (response != null) {
                if (response.flag == 1) {
                    SuccessMsg(response.message, "/ExportCustomerGroup/Index");
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
    window.location.href = "/ExportCustomerGroup/Index";
});

$(document).on("click", ".page-link", function (e) {
    e.preventDefault();
    loadTable($(this).data("page"));
});


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

function loadTable(page, focusedColumn, focusedValue) {
    debugger;
    var filters = {
        custCode: $('input[data-column="custCode"]').val(),
        division: $('input[data-column="division"]').val(),
        dic: $('input[data-column="dic"]').val(),
        lineDET: $('input[data-column="line_DET"]').val(),
        lineType: $('input[data-column="Line_Type"]').val(),
        lineType2: $('input[data-column="Line_Type2"]').val(),
    };

    $.ajax({
        url: '/ExportCustomerGroup/GetPagedUser',
        data: {
            page: page,
            custCode: filters.custCode,
            division: filters.division,
            dic: filters.dic,
            lineDET: filters.lineDET,
            linetype: filters.lineType,
            linetype2: filters.lineType2,
        },
        success: function (data) {
            debugger;
            $('#dailyvalueTableContainer').html(data);

            // Restore filter values and focus
            $('input[data-column="custCode"]').val(filters.custCode);
            $('input[data-column="division"]').val(filters.division);
            $('input[data-column="dic"]').val(filters.dic);
            $('input[data-column="lineDET"]').val(filters.lineDET);
            $('input[data-column="lineType1"]').val(filters.lineType);
            $('input[data-column="lineType2"]').val(filters.lineType2);


            // Restore focus to the previously focused input field
            if (focusedColumn) {
                const $focusedInput = $(`input[data-column="${focusedColumn}"]`);
                $focusedInput.focus().val(focusedValue); // Restore focus and cursor position
            }
        },
        error: function (xhr, status, error) {
            console.error("Error:", error);
        }
    });
}

