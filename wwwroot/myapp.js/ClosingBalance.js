$(document).ready(function () {
    $.ajax({
        url: "/ClosingBalance/GetPlantMaterial",
        type: "POST",
        contentType: "application/json",
        success: function (response) {
            let str = "";
            if (response != null) {
                debugger;
                for (var i = 0; i < response.masterdata.length; i++) {
                    str += "<tr>";
                    str += "<td> <input type='text' value='" + response.masterdata[i].plantCode + "'  id='plant_" + i + "'   data-plantmaterialid='" + response.masterdata[i].plantMaterialId + "' class = 'form-control form-control-sm' disabled /></td>";
                    str += "<td> <input type='text' value='" + response.masterdata[i].plantName + "'  id='plantName_" + i + "'    class = 'form-control form-control-sm' disabled /></td>";

                    str += "<td> <input type='text' value='" + response.masterdata[i].meterialCode + "'  id='materialCode_" + i + "'    class = 'form-control form-control-sm' disabled /></td>";
                    str += "<td> <input type='text' value='" + response.masterdata[i].meterialName + "'  id='materialName_" + i + "'    class = 'form-control form-control-sm' disabled /></td>";
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

                    str += "<td><input type='text'  id='openingstock_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='totalreceipt_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='totalissueqty_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='closingstock_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td> <input type='text' value='" + response.masterdata[i].bun + "'  id='plant_" + i + "'    class = 'form-control form-control-sm' disabled /></td>";

                    str += "</tr>"
                }
                $("#closingbalancevaluebody").html('');
                $("#closingbalancevaluebody").html(str);


                $(".datepicker input").datepicker({
                    format: "dd/mm/yyyy", // Update as per your format
                    autoclose: true,
                });
            }
        }
    });

});



$("#savelist").on("click", function () {
    debugger;
    let records = [];
    $("#closingbalancevaluebody tr").each(function () {
        // Extract values from the inputs in the current row
        const PlantMaterialId = $(this).find("input[id^='plant']").data("plantmaterialid");
        const Fromdate = $(this).find("input[id^='Fromdate']").val();
        const Todate = $(this).find("input[id^='Todate']").val();
        const openingstock = $(this).find("input[id^='openingstock']").val();
        const totalreceipt = $(this).find("input[id^='totalreceipt']").val();
        const totalissueqty = $(this).find("input[id^='totalissueqty']").val();
        const closingstock = $(this).find("input[id^='closingstock']").val();
        
        // Create an object for the current row's data
        if (PlantMaterialId && Fromdate && Todate && openingstock && closingstock) { // Only add valid rows
            records.push({
                PlantMaterialId: PlantMaterialId,
                FromDate: Fromdate,
                ToDate: Todate,
                OpeningStock: openingstock,
                TotalReceipt: totalreceipt,
                TotalIssueQuantities: totalissueqty,
                ClosingStock: closingstock,
            });
        }
    });

    if (records.length > 0) {
        // Send the data to the server using AJAX
        $.ajax({
            url: "/ClosingBalance/SaveList",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(records),
            success: function (response) {
                if (response != null) {
                    if (response.flag == 1) {
                        SuccessMsg(response.message, "/ClosingBalance/Index");
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
    window.location.href = "/ClosingBalance/Index";
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


