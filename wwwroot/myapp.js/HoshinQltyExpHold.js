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

                    str += "<td><input type='text'  id='TS_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='MBRT_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='RMV_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='Protine_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='CHHANA_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='Temprature_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='Taste_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='SPC_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='SR_Shift1_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='SR_Shift2_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='CHI_EXP_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='RM_EXP_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='Sal_EXP_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='Conv_EXP_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='Cant_EXP_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='Oth_EXP_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='Trans_EXP_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='Qlty_Rate_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='AS_Hoshin_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='AKS_Hoshin_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='MA_Hoshin_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='MC_Hosin_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='Route_Hoshin_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='EKO_Hoshin_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='Aur_Bas_Hoshin_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='CO_Hoshin_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
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

$("#save").on("click", function () {

    let date = $("#Date").val();
    let ts = $("#TS").val();
    let mbrt = $("#MBRT").val();
    let rmv = $("#RMV").val();
    let protine = $("#Protine").val();
    let chhana = $("#CHHANA").val();
    let temprature = $("#Temprature").val();
    let taste = $("#Taste").val();
    let spc = $("#SPC").val();
    let sr_shift1 = $("#SR_Shift1").val();
    let sr_shift2 = $("#SR_Shift2").val();
    let chi_exp = $("#CHI_EXP").val();
    let rm_exp = $("#RM_EXP").val();
    let sal_exp = $("#Sal_EXP").val();
    let conv_exp = $("#Conv_EXP").val();
    let cant_exp = $("#Cant_EXP").val();
    let oth_exp = $("#Oth_EXP").val();
    let trans_exp = $("#Trans_EXP").val();
    let qlty_rate = $("#Qlty_Rate").val();
    let as_hoshin = $("#AS_Hoshin").val();
    let ask_hoshin = $("#AKS_Hoshin").val();
    let ma_hoshin = $("#MA_Hoshin").val();
    let mc_hoshin = $("#MC_Hosin").val();
    let route_hoshin = $("#Route_Hoshin").val();
    let eko_hoshin = $("#EKO_Hoshin").val();
    let aur_bas_hoshin = $("#Aur_Bas_Hoshin").val();
    let co_hoshin = $("#CO_Hoshin").val();
    let isActive = $("#IsActive").is(":checked");
    let HoshinQltyExpGuid = $("#HoshinQltyExpGuid").val();


    if (date.trim() == "") {
        WarningMsg("Please enter date");
        return false;
    }
    else if (ts.trim() == "0") {
        WarningMsg("Please enter ts");
        return false;
    }

    else if (mbrt.trim() == "0") {
        WarningMsg("Please enter mbrt");
        return false;
    }
    else if (rmv.trim() == "0") {
        WarningMsg("Please enter rmv");
        return false;
    }

    else if (protine.trim() == "0") {
        WarningMsg("Please enter protine");
        return false;
    }

    else if (chhana.trim() == "0") {
        WarningMsg("Please enter chhana");
        return false;
    }

    else if (temprature.trim() == "0") {
        WarningMsg("Please enter temprature");
        return false;
    }

    else if (taste.trim() == "0") {
        WarningMsg("Please enter taste");
        return false;
    }

    else if (spc.trim() == "0") {
        WarningMsg("Please enter spc");
        return false;
    }

    else if (sr_shift1.trim() == "0") {
        WarningMsg("Please enter sr_shift1");
        return false;
    }

    else if (sr_shift2.trim() == "0") {
        WarningMsg("Please enter sr_shift2");
        return false;
    }

    else if (chi_exp.trim() == "0") {
        WarningMsg("Please enter chi_exp");
        return false;
    }

    else if (rm_exp.trim() == "0") {
        WarningMsg("Please enter rm_exp");
        return false;
    }

    else if (sal_exp.trim() == "0") {
        WarningMsg("Please enter sal_exp");
        return false;
    }
    else if (conv_exp.trim() == "0") {
        WarningMsg("Please enter conv_exp");
        return false;
    }

    else if (cant_exp.trim() == "0") {
        WarningMsg("Please enter cant_exp");
        return false;
    }

    else if (oth_exp.trim() == "0") {
        WarningMsg("Please enter oth_exp");
        return false;
    }

    else if (trans_exp.trim() == "0") {
        WarningMsg("Please enter trans_exp");
        return false;
    }

    else if (qlty_rate.trim() == "0") {
        WarningMsg("Please enter qlty_rate");
        return false;
    }

    else if (ask_hoshin.trim() == "0") {
        WarningMsg("Please enter ask_hoshin");
        return false;
    }

    else if (ma_hoshin.trim() == "0") {
        WarningMsg("Please enter ma_hoshin");
        return false;
    }

    else if (mc_hoshin.trim() == "0") {
        WarningMsg("Please enter mc_hoshin");
        return false;
    }

    else if (route_hoshin.trim() == "0") {
        WarningMsg("Please enter route_hoshin");
        return false;
    }

    else if (eko_hoshin.trim() == "0") {
        WarningMsg("Please enter eko_hoshin");
        return false;
    }

    else if (aur_bas_hoshin.trim() == "0") {
        WarningMsg("Please enter aur_bas_hoshin");
        return false;
    }

    else if (co_hoshin.trim() == "0") {
        WarningMsg("Please enter co_hoshin");
        return false;
    }
    let req = JSON.stringify({
        Date: date,
        TS: ts,
        MBRT: mbrt,
        RMV: rmv,
        Protine: protine,
        CHHANA: chhana,
        Temprature: temprature,
        Taste: taste,
        SPC: spc,
        SR_Shift1: sr_shift1,
        SR_Shift2: sr_shift2,
        CHI_EXP: chi_exp,
        RM_EXP: rm_exp,
        Sal_EXP: sal_exp,
        Conv_EXP: conv_exp,
        Cant_EXP: cant_exp,
        Oth_EXP: oth_exp,
        Trans_EXP: trans_exp,
        Qlty_Rate: qlty_rate,
        AS_Hoshin: as_hoshin,
        AKS_Hoshin: ask_hoshin,
        MA_Hoshin: ma_hoshin,
        MC_Hosin: mc_hoshin,
        Route_Hoshin: route_hoshin,
        EKO_Hoshin: eko_hoshin,
        Aur_Bas_Hoshin: aur_bas_hoshin,
        CO_Hoshin: co_hoshin,
        IsActive: isActive,
        HoshinQltyExpGuid: HoshinQltyExpGuid
    });

    $.ajax({
        url: "/HoshinQltyExpHold/Save",
        type: "POST",
        contentType: "application/json",
        data: req,
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
        error: function (xhr, status, error) {
            console.error("Error occurred:", error);
        }
    });
});



$("#savelist").on("click", function () {
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
        if (plantcodeid && Date && TS > 0 && MBRT && RMV && Protine) { // Only add valid rows
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

