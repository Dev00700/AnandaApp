//$(document).ready(function () {
//    $.ajax({
//        url: "/Commitment/GetPlantName",
//        type: "POST",
//        contentType: "application/json",
//        success: function (response) {
//            let str = "";
//            if (response != null) {
//                for (var i = 0; i < response.masterdata.length; i++) {
//                    str += "<tr>";
//                    str += "<td> <input type='text' value='" + response.masterdata[i].plantCode + "'  id='plant_" + i + "'   data-plantcodeid='" + response.masterdata[i].plantCodeId + "' class = 'form-control form-control-sm' disabled /></td>";
//                    str += "<td> <input type='text' value='" + response.masterdata[i].plantName + "'  id='plantName_" + i + "'    class = 'form-control form-control-sm' disabled /></td>";
//                    str += `<td> <div class="datepicker date input-group">
//                                           <input type='text'  id='Fromdate_`+ i + `'  value="${GetCurrentDate()}" class = 'form-control form-control-sm'/>
//                                            <div class="input-group-append calend-pos">
//                                                <span class="input-group-text"> <img src="../img/calendar_icon.svg" class="cal-h "></span>
//                                            </div>
//                                        </div></td>`;

//                    str += `<td> <div class="datepicker date input-group">
//                                           <input type='text'  id='Todate_`+ i + `'  value="${GetCurrentDate()}" class = 'form-control form-control-sm'/>
//                                            <div class="input-group-append calend-pos">
//                                                <span class="input-group-text"> <img src="../img/calendar_icon.svg" class="cal-h "></span>
//                                            </div>
//                                        </div></td>`;
//                    str += "<td><select class='form-control form-control-sm form-control-sm js-example-basic-single weekno' id='weeknoId_" + i + "'></select> </td> ";

//                    //str += "<td><input type='text' id='weekno_" + i + "' value='" + response.masterdata[i].weekNo + "' class='form-control form-control-sm' disabled='true'/>" +
//                    //    "<input type='hidden' id='weeknoid_" + i + "' value='" + response.masterdata[i].weeknoId + "' /></td>";

//                    str += "<td><input type='text'  id='vlccommitment_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
//                    str += "<td><input type='text'  id='amcucommitment_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
//                    str += "<td><input type='text'  id='amcurecoverd_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
//                    str += "<td><input type='text'  id='pervlcavg_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
//                    str += "</tr>"
//                }

//                let str2 = "";
//                for (var j = 0; j < response.dropdown.length; j++) {

//                    str2 += "<option value='" + response.dropdown[j].value + "'>" + response.dropdown[j].text + "</option>";
//                }


//                $("#commitmentbody").html('');
//                $("#commitmentbody").html(str);

//                $(".weekno").html(str2);
//                // Initialize Select2 for dynamically created elements
//                $(".js-example-basic-single").select2({
//                    width: '100%'
//                });
//                $(".weekno input").datepicker({
//                    format: "dd/mm/yyyy", // Update as per your format
//                    autoclose: true,
//                });
//            }
//        }
//    });

//});
$(document).ready(function () {
    $.ajax({
        url: "/Commitment/GetPlantName",
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
                                           <input type='text'  id='Fromdate_`+ i + `'  value="${GetCurrentDate()}" class = 'form-control form-control-sm from-date'/>
                                            <div class="input-group-append calend-pos">
                                                <span class="input-group-text"> <img src="../img/calendar_icon.svg" class="cal-h "></span>
                                            </div>
                                        </div></td>`;

                    str += `<td> <div class="datepicker date input-group">
                                           <input type='text'  id='Todate_`+ i + `'  value="${GetCurrentDate()}" class = 'form-control form-control-sm to-date'/>
                                            <div class="input-group-append calend-pos">
                                                <span class="input-group-text"> <img src="../img/calendar_icon.svg" class="cal-h "></span>
                                            </div>
                                        </div></td>`;
                    str += "<td><select class='form-control form-control-sm form-control-sm js-example-basic-single weekno' id='weeknoId_" + i + "'></select> </td>";

                    str += "<td><input type='text'  id='vlccommitment_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='amcucommitment_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='amcurecoverd_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "<td><input type='text'  id='pervlcavg_" + i + "' class = 'form-control form-control-sm decimalonlytwodigit'/> </td>";
                    str += "</tr>"
                }

                let str2 = "";
                for (var j = 0; j < response.dropdown.length; j++) {
                    str2 += "<option value='" + response.dropdown[j].value + "'>" + response.dropdown[j].text + "</option>";
                }

                $("#commitmentbody").html('');
                $("#commitmentbody").html(str);

                $(".weekno").html(str2);
                $(".js-example-basic-single").select2({
                    width: '100%'
                });
                $(".datepicker input").datepicker({
                    format: "dd/mm/yyyy", // Update as per your format
                    autoclose: true,
                });

                // Attach event listeners for FromDate and ToDate
                $(".from-date, .to-date").change(function () {
                    const rowId = $(this).closest("tr").index(); // Get the row index
                    const fromDate = $(`#Fromdate_${rowId}`).val();
                    const toDate = $(`#Todate_${rowId}`).val();

                    if (fromDate && toDate) {
                        // Call API to fetch week numbers based on FromDate and ToDate
                        $.ajax({
                            url: "/WeekMaster/GetWeekNumbers",
                            type: "POST",
                            contentType: "application/json",
                            data: JSON.stringify({ fromDate, toDate }),
                            success: function (weekResponse) {
                                if (weekResponse && weekResponse.weekNumbers) {
                                    let weekOptions = "";
                                    weekResponse.weekNumbers.forEach(function (week) {
                                        weekOptions += `<option value="${week.id}">${week.name}</option>`;
                                    });
                                    $(`#weeknoId_${rowId}`).html(weekOptions);
                                } else {
                                    $(`#weeknoId_${rowId}`).html("<option value=''>No Week Available</option>");
                                }
                            },
                            error: function () {
                                alert("Failed to fetch week numbers.");
                            }
                        });
                    }
                });
            }
        }
    });
});



$("#save").on("click", function () {

    let plantCode = $("#plantCode").val();
    let plantCodeId = $("#plantCodeId").val();
    let plantname = $("#plantname").val();
    let fromdate = $("#fromdate").val();
    let todate = $("#todate").val();
    let weekno = $("#weekno").val();
    let weekId = $("#weekid").val();
    let vlccommitment = $("#vlccommitment").val();
    let amcucommitment = $("#amcucommitment").val();
    let amcurecoverd = $("#amcurecoverd").val();
    let pervlcavg = $("#pervlcavg").val();
    let CommitmentGuid = $("#CommitmentGuid").val();

    if (plantCode.trim() == "0" || plantCode.trim() == "") {
        WarningMsg("Please select Plant Code");
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
        PlantCodeId: plantCodeId,
        PlantCode: plantCode,
        FromDate: fromdate,
        ToDate: ToDate,
        WeekNoId: weekId,
        VLCCommitment: vlccommitment,
        AMCUCommitment: amcucommitment,
        AMCURecoverd: amcurecoverd,
        PerVLCAvg: pervlcavg,
        CommitmentGuId: CommitmentGuid
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
    $("#commitmentbody tr").each(function () {
        // Extract values from the inputs in the current row
        const plantcodeid = $(this).find("input[id^='plant']").data("plantcodeid");
        const Fromdate = $(this).find("input[id^='Fromdate']").val();
        const Todate = $(this).find("input[id^='Todate']").val();
        const weekno = $(this).find("input[id^='weeknoId']").val();
        const weeknoId = $(this).find("input[id^='weeknoid']").val();
        const vlccommitment = $(this).find("input[id^='vlccommitment']").val();
        const amcucommitment = $(this).find("input[id^='amcucommitment']").val();
        const amcurecoverd = $(this).find("input[id^='amcurecoverd']").val();
        const pervlcavg = $(this).find("input[id^='pervlcavg']").val();

        //const tgtvalue = $(this).find("input[id^='tgtvalue']").val();

        // Create an object for the current row's data
        if (plantcodeid && Fromdate && Todate && weeknoId) { // Only add valid rows
            records.push({
                PlantCodeId: plantcodeid,
                FromDate: Fromdate,
                ToDate: Todate,
                WeekNoId: weeknoId,
                VLCCommitment: vlccommitment,
                AMCUCommitment: amcucommitment,
                AMCURecoverd: amcurecoverd,
                PerVLCAvg: pervlcavg
            });
        }
    });

    if (records.length > 0) {
        // Send the data to the server using AJAX
        $.ajax({
            url: "/Commitment/SaveList",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(records),
            success: function (response) {
                if (response != null) {
                    if (response.flag == 1) {
                        SuccessMsg(response.message, "/Commitment/Index");
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
    window.location.href = "/Commitment/Index";
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
        url: '/Commitment/GetPagedUser',
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

