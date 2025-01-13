

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
    const minLength = 2; // Minimum characters required to trigger the request

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
        fromdate: $('input[data-column="fromdate"]').val(),
        todate: $('input[data-column="todate"]').val(),
        weekno: $('input[data-column="weekno"]').val(),
       
    };

    $.ajax({
        url: '/WeekNumber/GetPagedUser',
        data: {
            page: page,
            rowperpage: rowsPerPage,
            fromdate: filters.fromdate,
            todate: filters.todate,
            weekno: filters.weekno
           
        },
        success: function (data) {

            $('#weeknumberTableContainer').html(data);

            // Restore filter values and focus
            $('input[data-column="fromdate"]').val(filters.fromdate);
            $('input[data-column="todate"]').val(filters.todate);
            $('input[data-column="weekno"]').val(filters.weekno);
          

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
