

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
        zone: $('input[data-column="zone"]').val(),
        oldplantcode: $('input[data-column="oldplantcode"]').val(),
        newplantcode: $('input[data-column="newplantcode"]').val(),
        plantname: $('input[data-column="plantname"]').val(),
        zonalhead: $('input[data-column="zonalhead"]').val(),

    };

    $.ajax({
        url: '/ZoneWiseData/GetPagedUser',
        data: {
            page: page,
            rowperpage: rowsPerPage,
            zone: filters.zone,
            oldplantcode: filters.oldplantcode,
            newplantcode: filters.newplantcode,
            plantname: filters.plantname,
            zonalhead: filters.zonalhead,

        },
        success: function (data) {

            $('#zonewisedataTableContainer').html(data);

            // Restore filter values and focus
            $('input[data-column="zone"]').val(filters.zone);
            $('input[data-column="oldplantcode"]').val(filters.oldplantcode);
            $('input[data-column="newplantcode"]').val(filters.newplantcode);
            $('input[data-column="plantname"]').val(filters.plantname);
            $('input[data-column="zonalhead"]').val(filters.zonalhead);


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
