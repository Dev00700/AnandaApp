$(document).ready(function () {
    $.ajax({
        url: "/DistrubutorValueTGT/GetDICName",
        type: "POST",
        contentType: "application/json",
        success: function (response) {
            debugger;
            let str = '<tr>';
            if (response != null) {
                for (var i = 0; i < response.masterdata.length; i++) {
                    str += "<td> <input type='text' value='" + response.masterdata[i].dicName + "'  id='dic_" + i + "'   data-dicid='" + response.masterdata[i].dicId + "' class = 'form-control form-control-sm' disabled /></td>";
                    /* str += "<td><input type='text'  id='line_" + i + "'  class = 'form-control form-control-sm'/></td> ";*/
                    str += "<td><select class='form-control form-control-sm form-control-sm js-example-basic-single line' id='line_" + i +"'></select> </td> ";
                    /* str += "<td><input type='text'  id='linetype_" + i + "'  class = 'form-control form-control-sm'/></td> ";*/
                    str += "<td><select class='form-control form-control-sm form-control-sm js-example-basic-single linetype' id='linetype_" + i +"'></select> </td>";
                    str += `<td> <div class="datepicker date input-group">
                                           <input type='text'  id='date_`+ i + `'  value="${GetCurrentDate()}" class = 'form-control form-control-sm'/>
                                            <div class="input-group-append calend-pos">
                                                <span class="input-group-text"> <img src="../img/calendar_icon.svg" class="cal-h "></span>
                                            </div>
                                        </div></td>`;

                    str += "<td><input type='text'  id='value_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit' /> </td>";
                    str += "</tr>"

                }
                let str2 = "";
                for (var j = 0; j < response.line.length; j++) {

                    str2 += "<option value='" + response.line[j].value + "'>" + response.line[j].text + "</option>";
                }
                let str3 = "";
                for (var k = 0; k < response.linetype.length; k++) {

                    str3 += "<option value='" + response.linetype[k].value + "'>" + response.linetype[k].text + "</option>";
                }

                $("#distrubutorvaluebody").html('');
                $("#distrubutorvaluebody").html(str);
                $(".line").html(str2); 
                $(".linetype").html(str3); 

                // Initialize Select2 for dynamically created elements
                $(".js-example-basic-single").select2({
                    width: '100%'
                });
                $(".datepicker input").datepicker({
                    format: "dd/mm/yyyy", // Update as per your format
                    autoclose: true,
                });
            }
        }
    });

});

$("#save").on("click", function () {
    // let userCode = $("#UserCode").val();
    let dicid = $("#DICID").val();
    let linetype = $("#LineType").val();
    let line = $("#Line").val();
    let month = $("#Month").val();
    let distgt = $("#DisTGT").val();
    let isActive = $("#IsActive").is(":checked");
    let distrubutorvalueguid = $("#DistrubutorValueGuid").val();

    if (dicid.trim() == "0") {
        WarningMsg("Please select dic name");
        return false;
    }
    else if (linetype.trim() == "") {
        WarningMsg("Please enter linetype");
        return false;
    }
    else if (line.trim() == "") {
        WarningMsg("Please enter Line");
        return false;
    }
    else if (month.trim() == "") {
        WarningMsg("Please select month");
        return false;
    }
    else if (distgt.trim() == "0") {
        WarningMsg("Please enter DisTGT");
        return false;
    }

    let req = JSON.stringify({
        DICID: dicid,
        LineType: linetype,
        Month: month,
        Line: line,
        IsActive: isActive,
        DisTGT: distgt,
        DistrubutorValueGuid: distrubutorvalueguid
    });

    $.ajax({
        url: "/DistrubutorValueTGT/Save",
        type: "POST",
        contentType: "application/json",
        data: req,
        success: function (response) {
            if (response != null) {
                if (response.flag == 1) {
                    SuccessMsg(response.message, "/DistrubutorValueTGT/Index");
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


 

$("#savelist").on("click", function () {
    let records = [];
    $("#distrubutorvaluebody tr").each(function () {
        // Extract values from the inputs in the current row
        const dicId = $(this).find("input[id^='dic']").data("dicid");
        const line = $(this).find("select[id^='line']").val();
        const lineType = $(this).find("select[id^='linetype']").val();
        const date = $(this).find("input[id^='date']").val();
        const value = $(this).find("input[id^='value']").val();

        // Create an object for the current row's data
        if (dicId && line && lineType && date && value) { // Only add valid rows
            records.push({
                DICID: dicId,
                Line: line,
                LineType: lineType,
                Month: date,
               // DisTGT: value
            });
        }
    });

    if (records.length > 0) {
        // Send the data to the server using AJAX
        $.ajax({
            url: "/DistrubutorValueTGT/SaveList",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(records),
            success: function (response) {
                if (response != null) {
                    if (response.flag == 1) {
                        SuccessMsg(response.message, "/DistrubutorValueTGT/Index");
                    }
                    else if (response.flag == 2) {
                        ErrorMsg(response.message);
                    }
                }
            },
            error: function () {
                ErrorMsg("An error occurred while saving records.");
            }
        });
    }
    else {
        WarningMsg("No valid records to save.");
    }
});

// Cancel button
$("#cancel").click(function () {
    window.location.href = "/DistrubutorValueTGT/Index";
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
    debugger;
    var filters = {
        dicname: $('input[data-column="dicname"]').val(),
        linetype: $('input[data-column="linetype"]').val(),
        month: $('input[data-column="month"]').val(),
        distgt: $('input[data-column="distgt"]').val(),
    };

    $.ajax({
        url: '/DistrubutorValueTGT/GetPagedUser',
        data: {
            page: page,
            rowperpage: rowsPerPage,
            dicname: filters.dicname,
            linetype: filters.linetype,
            Month: filters.month,
            DisTGT: filters.distgt,
        },
        success: function (data) {
            debugger;
            $('#distrubutorTableContainer').html(data);

            // Restore filter values and focus
            $('input[data-column="dicname"]').val(filters.dicname);
            $('input[data-column="linetype"]').val(filters.linetype);
            $('input[data-column="month"]').val(filters.month);
            $('input[data-column="distgt"]').val(filters.distgt);

            // Restore focus to the previously focused input field
            if (focusedColumn) {
                const $focusedInput = $(`input[data-column="${focusedColumn}"]`);
                $focusedInput.focus().val(focusedValue); // Restore focus and cursor position
            }
            $("#rowsPerPage").val(rowsPerPage);
        },
        error: function (xhr, status, error) {
            console.error("Error:", error);
        }
    });
}

