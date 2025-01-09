
// Save product Catgory

$("#saveProductCategory").on("click", function () {
    debugger;

    let prdcatcode = $("#ProductCategoryCode").val();
    let zmgrp = $("#ZMGRP").val();
    let zsgrp1 = $("#ZSGRP1").val();
    let zsgrp2 = $("#ZSGRP2").val();
    let zsgrp3 = $("#ZSGRP3").val();
    let zsgrp4 = $("#ZSGRP4").val();
    let prdtype = $("#ProductType").val();
    let packcontains = $("#PackContains").val();
    let conversionratio = $("#ConversionRatio").val();
    let isactive = $("#IsActive").is(":checked");
    let prdcatguid = $("#ProductCategoryGuid").val();

    if (prdcatcode.trim() == "") {
        WarningMsg("Please enter material code");
        return false;
    }
    else if (zmgrp.trim() == "") {
        WarningMsg("Please enter zmgrp");
        return false;
    }

    else if (prdtype.trim() == "") {
        WarningMsg("Please enter product type");
        return false;
    }

    let req = JSON.stringify({ ProductCategoryCode: prdcatcode, ZMGRP: zmgrp, ZSGRP1: zsgrp1, ZSGRP2: zsgrp2, ZSGRP3: zsgrp3, ZSGRP4: zsgrp4, ProductType: prdtype, PackContains: packcontains, ConversionRatio: conversionratio, IsActive: isactive, ProductCategoryGuid: prdcatguid });
    $.ajax({
        url: "/ProductCategory/Save",
        type: "POST",
        contentType: "application/json",
        data: req,
        success: function (response) {
            if (response != null) {
                if (response.flag == 1) {
                    SuccessMsg(response.message, "/ProductCategory/Index");
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

// Check Product Category Code
function ChkProductCategoryCode() {
    debugger;
    $.ajax({
        url: "/ProductCategory/CheckProductCategoryCode",
        data: {
            ProductCategoryCode: $("#ProductCategoryCode").val()
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
    location.href = "/ProductCategory/Index";
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
        prdcatcode: $('input[data-column="ProductCategoryCode"]').val(),
        producttype: $('input[data-column="ProductType"]').val(),
        zmgrp: $('input[data-column="ZMGRP"]').val()
    };

    $.ajax({
        url: '/ProductCategory/GetPagedProductCategory',
        data: {
            page: page,
            rowperpage: rowsPerPage,
            prdcatcode: filters.prdcatcode,
            producttype: filters.producttype,
            zmgrp: filters.zmgrp
        },
        success: function (data) {
            $('#ProductCategoryTableContainer').html(data);
            $('input[data-column="ProductCategoryCode"]').val(filters.prdcatcode);
            $('input[data-column="ProductType"]').val(filters.producttype);
            $('input[data-column="ZMGRP"]').val(filters.zmgrp);
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

