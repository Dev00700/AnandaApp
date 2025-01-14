$(document).ready(function () {
    $.ajax({
        url: "/HoshinQltyExpHold/GetPlantName",
        type: "POST",
        contentType: "application/json",
        success: function (response) {
            let str = "";
            if (response != null) {
                for (var i = 0; i < response.masterdata.length; i++) {
                    str += "<tr>";
                    str += "<td> <input type='text' value='" + response.masterdata[i].plantCode + "'  id='plant_" + i + "'   data-plantcodeid='" + response.masterdata[i].plantCodeId + "' class = 'form-control form-control-sm' disabled /></td>";
                    str += "<td> <input type='text' value='" + response.masterdata[i].plantName + "'  id='plantName_" + i + "'    class = 'form-control form-control-sm' disabled /></td>";
                    str += `<td> <div class="datepicker date input-group">
                                           <input type='text'  id='Date_`+ i + `'  value="${GetCurrentDate()}" class = 'form-control form-control-sm'/>
                                            <div class="input-group-append calend-pos">
                                                <span class="input-group-text"> <img src="../img/calendar_icon.svg" class="cal-h "></span>
                                            </div>
                                        </div></td>`;

                    str += "<td><input type='text' value='0' id='TS_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='MBRT_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='RMV_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='Protine_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='CHHANA_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='Temprature_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='Taste_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='SPC_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='SR_Shift1_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='SR_Shift2_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='CHI_EXP_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='RM_EXP_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='Sal_EXP_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='Conv_EXP_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='Cant_EXP_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='Oth_EXP_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='Trans_EXP_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='Qlty_Rate_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='AS_Hoshin_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='AKS_Hoshin_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='MA_Hoshin_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='MC_Hosin_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='Route_Hoshin_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='EKO_Hoshin_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='Aur_Bas_Hoshin_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text' value='0' id='CO_Hoshin_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "</tr>"

                }

                $("#hosingqltyExpholdvaluebody").html('');
                $("#hosingqltyExpholdvaluebody").html(str);

                $(".datepicker input").datepicker({
                    format: "dd/mm/yyyy", // Update as per your format
                    autoclose: true,
                });
            }
        }
    });

});


//$("#save").on("click", function () {

//    let dicid = $("#DICID").val();
//    let linetype = $("#LineType").val();
//    let date = $("#Date").val();
//    let valuetarget = $("#ValueTargetPerDay").val();
//    let isActive = $("#IsActive").is(":checked");
//    let Dailyvalueguid = $("#DailyValueGuid").val();

//    if (dicid.trim() == "0") {
//        WarningMsg("Please select dic name");
//        return false;
//    }
//    else if (linetype.trim() == "") {
//        WarningMsg("Please enter linetype");
//        return false;
//    }
//    else if (date.trim() == "") {
//        WarningMsg("Please enter date");
//        return false;
//    }
//    else if (valuetarget.trim() == "0") {
//        WarningMsg("Please enter date");
//        return false;
//    }
//    let req = JSON.stringify({
//        DICID: dicid,
//        LineType: linetype,
//        Date: date,
//        ValueTargetPerDay: valuetarget,
//        IsActive: isActive,
//        DailyValueGuid: Dailyvalueguid
//    });

//    $.ajax({
//        url: "/DailyValueTGT/Save",
//        type: "POST",
//        contentType: "application/json",
//        data: req,
//        success: function (response) {
//            if (response != null) {
//                if (response.flag == 1) {
//                    SuccessMsg(response.message, "/DailyValueTGT/Index");
//                }
//                else if (response.flag == 2) {
//                    ErrorMsg(response.message);
//                }
//            }
//        },
//        error: function (xhr, status, error) {
//            console.error("Error occurred:", error);
//        }
//    });
//});



$("#savelist").on("click", function () {
    debugger;
    let records = [];
    $("#hosingqltyExpholdvaluebody tr").each(function () {
        // Extract values from the inputs in the current row
        const plantcodeid = $(this).find("input[id^='plant']").data("plantcodeid");
        const Date = $(this).find("input[id^='Date']").val();
        const TS = $(this).find("input[id^='TS']").val();
        const MBRT = $(this).find("input[id^='MBRT']").val();
        const RMV = $(this).find("input[id^='RMV']").val();
        const Protine = $(this).find("input[id^='Protine']").val();
        const CHHANA = $(this).find("input[id^='CHHANA']").val();
        const Temprature = $(this).find("input[id^='Temprature']").val();
        const Taste = $(this).find("input[id^='Taste']").val();
        const SPC = $(this).find("input[id^='SPC']").val();
        const SR_Shift1 = $(this).find("input[id^='SR_Shift1']").val();
        const SR_Shift2 = $(this).find("input[id^='SR_Shift2']").val();
        const CHI_EXP = $(this).find("input[id^='CHI_EXP']").val();
        const RM_EXP = $(this).find("input[id^='RM_EXP']").val();
        const Sal_EXP = $(this).find("input[id^='Sal_EXP']").val();
        const Conv_EXP = $(this).find("input[id^='Conv_EXP']").val();
        const Cant_EXP = $(this).find("input[id^='Cant_EXP']").val();
        const Oth_EXP = $(this).find("input[id^='Oth_EXP']").val();
        const Trans_EXP = $(this).find("input[id^='Trans_EXP']").val();
        const Qlty_Rate = $(this).find("input[id^='Qlty_Rate']").val();
        const AS_Hoshin = $(this).find("input[id^='AS_Hoshin']").val();
        const AKS_Hoshin = $(this).find("input[id^='AKS_Hoshin']").val();
        const MA_Hoshin = $(this).find("input[id^='MA_Hoshin']").val();
        const MC_Hosin = $(this).find("input[id^='MC_Hosin']").val();
        const Route_Hoshin = $(this).find("input[id^='Route_Hoshin']").val();
        const EKO_Hoshin = $(this).find("input[id^='EKO_Hoshin']").val();
        const Aur_Bas_Hoshin = $(this).find("input[id^='Aur_Bas_Hoshin']").val();
        const CO_Hoshin = $(this).find("input[id^='CO_Hoshin']").val();

        // Create an object for the current row's data
        if ( plantcodeid && Date && TS ) { // Only add valid rows
            records.push({
                PlantCodeId: plantcodeid,
                Date: Date,
                TS: TS,
                MBRT: MBRT,
                RMV: RMV,
                Protine: Protine,
                CHHANA: CHHANA,
                Temprature: Temprature,
                Taste: Taste,
                SPC: SPC,
                SR_Shift1: SR_Shift1,
                SR_Shift2: SR_Shift2,
                CHI_EXP: CHI_EXP,
                RM_EXP: RM_EXP,
                Sal_EXP: Sal_EXP,
                Conv_EXP: Conv_EXP,
                Cant_EXP: Cant_EXP,
                Oth_EXP: Oth_EXP,
                Trans_EXP: Trans_EXP,
                Qlty_Rate: Qlty_Rate,
                AS_Hoshin: AS_Hoshin,
                AKS_Hoshin: AKS_Hoshin,
                MA_Hoshin: MA_Hoshin,
                MC_Hosin: MC_Hosin,
                Route_Hoshin: Route_Hoshin,
                EKO_Hoshin: EKO_Hoshin,
                Aur_Bas_Hoshin: Aur_Bas_Hoshin,
                CO_Hoshin: CO_Hoshin
            });
        }
    });

    if (records.length > 0) {
        // Send the data to the server using AJAX
        $.ajax({
            url: "/HoshinQltyExpHold/SaveList",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(records),
            success: function (response) {
                if (response != null) {
                    if (response.flag == 1) {
                        SuccessMsg(response.message, "/HoshinQltyExpHold/Index");
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
    window.location.href = "/HoshinQltyExpHold/Index";
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
        PlantCode: $('input[data-column="PlantCode"]').val(),
        PlantName: $('input[data-column="PlantName"]').val(),
        Date: $('input[data-column="Date"]').val(),
    };

    $.ajax({
        url: '/HoshinQltyExpHold/GetPagedUser',
        data: {
            page: page,
            rowperpage: rowsPerPage,
            PlantCode: filters.PlantCode,
            PlantName: filters.PlantName,
            Date: filters.Date,
        },
        success: function (data) {

            $('#HoshinQltyExpTableContainer').html(data);
            // Restore filter values and focus
            $('input[data-column="PlantCode"]').val(filters.PlantCode);
            $('input[data-column="PlantName"]').val(filters.PlantName);
            $('input[data-column="Date"]').val(filters.Date);

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

