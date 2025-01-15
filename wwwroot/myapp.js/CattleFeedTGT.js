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
                    str += "<td><input type='text'  id='code_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/></td> ";
                    str += "<td> <input type='text' value='" + response.masterdata[i].plantCode + "'  id='plant_" + i + "'   data-plantcodeid='" + response.masterdata[i].plantCodeId + "' class = 'form-control form-control-sm' disabled /></td>";
                    str += "<td> <input type='text' value='" + response.masterdata[i].plantName + "'  id='plantName_" + i + "'    class = 'form-control form-control-sm' disabled /></td>";
                    str += `<td> <div class="datepicker date input-group">
                                           <input type='text'  id='Fromdate_`+ i + `'  value="${GetCurrentDate()}" class = 'form-control form-control-sm' onchange='GetWeekNoData(${i})'/>
                                            <div class="input-group-append calend-pos">
                                                <span class="input-group-text"> <img src="../img/calendar_icon.svg" class="cal-h "></span>
                                            </div>
                                        </div></td>`;

                    str += `<td> <div class="datepicker date input-group">
                                           <input type='text'  id='Todate_`+ i + `'  value="${GetCurrentDate()}" class = 'form-control form-control-sm'  onchange='GetWeekNoData(${i})'/>
                                            <div class="input-group-append calend-pos">
                                                <span class="input-group-text"> <img src="../img/calendar_icon.svg" class="cal-h "></span>
                                            </div>
                                        </div></td>`;

                    str += "<td><input type='text'  id='weekno_" + i + "'  class = 'form-control form-control-sm' disabled='true'/> </td>";
                    str += "<td><input type='text'  id='tgtvalue_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "</tr>"
                }
                $("#cattlefeedvaluebody").html('');
                $("#cattlefeedvaluebody").html(str);


                $(".datepicker input").datepicker({
                    format: "dd/mm/yyyy", // Update as per your format
                    autoclose: true,
                });
                for (var i = 0; i < response.masterdata.length; i++) {
                    GetWeekNoData(i);
                }
            }
        }
    });

});


$("#save").on("click", function () {

    let Code = $("#Code").val();
    let fromdate = $("#FromDate").val();
    let todate = $("#ToDate").val();
    let weekno = $("#WeekNo").val();
    let tgtvalue = $("#TGTValue").val();
    let isActive = $("#IsActive").is(":checked");
    let CattleFeedGuid = $("#CattleFeedGuid").val();

    if (Code.trim() == "" ) {
        WarningMsg("Please enter code");
        return false;
    }
  
    else if (fromdate.trim() == "") {
        WarningMsg("Please enter from date");
        return false;
    }

    else if (todate.trim() == "") {
        WarningMsg("Please enter to date");
        return false;
    }

    else if (weekno.trim() == "") {
        WarningMsg("Please enter week no");
        return false;
    }
    else if (tgtvalue.trim() == "0") {
        WarningMsg("Please enter target value");
        return false;
    }
    let req = JSON.stringify({
        Code: Code,
        FromDate: fromdate,
        ToDate: todate,
        WeekNo: weekno,
        TGTValue: tgtvalue,
        IsActive: isActive,
        CattleFeedGuid: CattleFeedGuid
    });

    $.ajax({
        url: "/CattleFeedTGT/Save",
        type: "POST",
        contentType: "application/json",
        data: req,
        success: function (response) {
            if (response != null) {
                if (response.flag == 1) {
                    SuccessMsg(response.message, "/CattleFeedTGT/Index");
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
    $("#cattlefeedvaluebody tr").each(function () {
        // Extract values from the inputs in the current row
        const code = $(this).find("input[id^='code']").val();
        const plantcodeid = $(this).find("input[id^='plant']").data("plantcodeid");
        const Fromdate = $(this).find("input[id^='Fromdate']").val();
        const Todate = $(this).find("input[id^='Todate']").val();
        const weekno = $(this).find("input[id^='weekno']").val();
        const tgtvalue = $(this).find("input[id^='tgtvalue']").val();

        // Create an object for the current row's data
        if (code && plantcodeid && Fromdate && Todate && weekno ) { // Only add valid rows
            records.push({
                Code: code,
                PlantCodeId: plantcodeid,
                FromDate: Fromdate,
                ToDate: Todate,
                WeekNo: weekno,
                TGTValue: tgtvalue
            });
        }
    });

    if (records.length > 0) {
        // Send the data to the server using AJAX
        $.ajax({
            url: "/CattleFeedTGT/SaveList",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(records),
            success: function (response) {
                if (response != null) {
                    if (response.flag == 1) {
                        SuccessMsg(response.message, "/CattleFeedTGT/Index");
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
    window.location.href = "/CattleFeedTGT/Index";
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
        Code: $('input[data-column="Code"]').val(),
        PlantCode: $('input[data-column="PlantCode"]').val(),
        PlantName: $('input[data-column="PlantName"]').val(),
        FromDate: $('input[data-column="FromDate"]').val(),
        ToDate: $('input[data-column="ToDate"]').val(),
        WeekNo: $('input[data-column="WeekNo"]').val(),
        TGTValue: $('input[data-column="TGTValue"]').val(),
    };

    $.ajax({
        url: '/CattleFeedTGT/GetPagedUser',
        data: {
            page: page,
            rowperpage: rowsPerPage,
            Code: filters.Code,
            PlantCode: filters.PlantCode,
            PlantName: filters.PlantName,
            FromDate: filters.FromDate,
            ToDate: filters.ToDate,
            WeekNo: filters.WeekNo,
            TGTValue: filters.TGTValue,
        },
        success: function (data) {

            $('#cattlefeedTableContainer').html(data);

            // Restore filter values and focus
            $('input[data-column="Code"]').val(filters.Code);
            $('input[data-column="PlantCode"]').val(filters.PlantCode);
            $('input[data-column="PlantName"]').val(filters.PlantName);
            $('input[data-column="FromDate"]').val(filters.FromDate);
            $('input[data-column="ToDate"]').val(filters.ToDate);
            $('input[data-column="WeekNo"]').val(filters.WeekNo);
            $('input[data-column="TGTValue"]').val(filters.TGTValue);

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


function GetWeekNoData(rowIndex) {
    let fromDate = ""; let toDate = "";
    if (rowIndex == -1) {
        fromDate = $("#FromDate").val();
        toDate = $("#ToDate").val();
    }
    else {
        fromDate = $("#Fromdate_" + rowIndex).val();
        toDate = $("#Todate_" + rowIndex).val();
    }
    $.ajax({
        url: "/CattleFeedTGT/GetWeekNo",
        type: "POST",
        data: { FromDate: fromDate, ToDate: toDate },
        success: function (response) {
            var _weekno = response;
            if (rowIndex == -1) {
                $("#WeekNo").val(_weekno);  
            }
            else {
                $("#weekno_" + rowIndex).val(_weekno);  
            }
        },
        error: function (error) {
            ErrorMsg("An error occurred while Getting records.");
        }
    });
}


