$(document).ready(function () {
    $.ajax({
        url: "/CattleFeedTGT/GetPlantName",
        type: "POST",
        contentType: "application/json",
        success: function (response) {
            let str = "";
            if (response != null) {
                for (var i = 0; i < response.masterdata.length; i++) {
                    str += "<tr>";
                    str += "<td><input type='text'  id='code_" + i + "' class = 'form-control form-control-sm numberonly'/></td> ";
                    str += "<td> <input type='text' value='" + response.masterdata[i].plantCode + "'  id='plant_" + i + "'   data-plantcodeid='" + response.masterdata[i].plantCodeId + "' class = 'form-control form-control-sm' disabled /></td>";
                    str += "<td> <input type='text' value='" + response.masterdata[i].plantName + "'  id='plantName_" + i + "'    class = 'form-control form-control-sm' disabled /></td>";
                    str += `<td> <div class="datepicker date input-group">
                                           <input type='text'  id='Fromdate_`+ i + `'  value="${GetCurrentDate()}" class = 'form-control form-control-sm'/>
                                            <div class="input-group-append calend-pos">
                                                <span class="input-group-text"> <img src="../img/calendar_icon.svg" class="cal-h "></span>
                                            </div>
                                        </div></td>`;

                    str += `<td> <div class="datepicker date input-group">
                                           <input type='text'  id='Todate_`+ i + `'  value="${GetCurrentDate()}" class = 'form-control form-control-sm'/>
                                            <div class="input-group-append calend-pos">
                                                <span class="input-group-text"> <img src="../img/calendar_icon.svg" class="cal-h "></span>
                                            </div>
                                        </div></td>`;

                    str += "<td><input type='text'  id='weekno_" + i + "' class = 'form-control form-control-sm' disabled='true'/> </td>";

                    str += "<td><input type='text'  id='tgtvalue_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "</tr>"

                }
                
                $("#cattlefeedvaluebody").html('');
                $("#cattlefeedvaluebody").html(str);

                $(".datepicker input").datepicker({
                    format: "dd/mm/yyyy", // Update as per your format
                    autoclose: true,
                });
            }
        }
    });

});


$("#save").on("click", function () {

    let dicid = $("#DICID").val();
    let linetype = $("#LineType").val();
    let date = $("#Date").val();
    let valuetarget = $("#ValueTargetPerDay").val();
    let isActive = $("#IsActive").is(":checked");
    let Dailyvalueguid = $("#DailyValueGuid").val();

    if (dicid.trim() == "0") {
        WarningMsg("Please select dic name");
        return false;
    }
    else if (linetype.trim() == "") {
        WarningMsg("Please enter linetype");
        return false;
    }
    else if (date.trim() == "") {
        WarningMsg("Please enter date");
        return false;
    }
    else if (valuetarget.trim() == "0") {
        WarningMsg("Please enter date");
        return false;
    }
    let req = JSON.stringify({
        DICID: dicid,
        LineType: linetype,
        Date: date,
        ValueTargetPerDay: valuetarget,
        IsActive: isActive,
        DailyValueGuid: Dailyvalueguid
    });

    $.ajax({
        url: "/DailyValueTGT/Save",
        type: "POST",
        contentType: "application/json",
        data: req,
        success: function (response) {
            if (response != null) {
                if (response.flag == 1) {
                    SuccessMsg(response.message, "/DailyValueTGT/Index");
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
    debugger;
    let records = [];
    $("#dailyvaluebody tr").each(function () {
        // Extract values from the inputs in the current row
        const dicId = $(this).find("input[id^='dic']").data("dicid");
        const lineType = $(this).find("select[id^='linetype']").val();
        const date = $(this).find("input[id^='date']").val();
        const value = $(this).find("input[id^='value']").val();

        // Create an object for the current row's data
        if (dicId && lineType && date && value) { // Only add valid rows
            records.push({
                DICID: dicId,
                LineType: lineType,
                Date: date,
                ValueTargetPerDay: value
            });
        }
    });

    if (records.length > 0) {
        // Send the data to the server using AJAX
        $.ajax({
            url: "/DailyValueTGT/SaveList",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(records),
            success: function (response) {
                if (response != null) {
                    if (response.flag == 1) {
                        SuccessMsg(response.message, "/DailyValueTGT/Index");
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
    window.location.href = "/DailyValueTGT/Index";
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
        dicname: $('input[data-column="dicname"]').val(),
        linetype: $('input[data-column="linetype"]').val(),
        date: $('input[data-column="date"]').val(),
        valuetarget: $('input[data-column="valuetarget"]').val(),
    };

    $.ajax({
        url: '/DailyValueTGT/GetPagedUser',
        data: {
            page: page,
            rowperpage: rowsPerPage,
            dicname: filters.dicname,
            linetype: filters.linetype,
            Date: filters.date,
            valuetarget: filters.valuetarget,
        },
        success: function (data) {

            $('#dailyvalueTableContainer').html(data);

            // Restore filter values and focus
            $('input[data-column="dicname"]').val(filters.dicname);
            $('input[data-column="linetype"]').val(filters.linetype);
            $('input[data-column="date"]').val(filters.date);
            $('input[data-column="valuetarget"]').val(filters.valuetarget);

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

