﻿getPagination('#table-id');
$('#maxRows').trigger('change');
function getPagination(table) {

    $('#maxRows').on('change', function () {
        $('.pagination').html('');
        var trnum = 0;
        var maxRows = parseInt($(this).val());

        var totalRows = $(table + ' tbody tr').length;
        $(table + ' tr:gt(0)').each(function () {
            trnum++;
            if (trnum > maxRows) {

                $(this).hide();
            } if (trnum <= maxRows) { $(this).show(); }
        });
        if (totalRows > maxRows) {
            var pagenum = Math.ceil(totalRows / maxRows);
            for (var i = 1; i <= pagenum;) {
                $('.pagination').append('<li data-page="' + i + '">\
								      <span>'+ i++ + '<span class="sr-only">(current)</span></span>\
								    </li>').show();
            }
        }
        $('.pagination li:first-child').addClass('active');
        getRowsCount(maxRows, 1, totalRows);

        $('.pagination li').on('click', function (e) {
            e.preventDefault();
            var pageNum = $(this).attr('data-page');
            var trIndex = 0;
            $('.pagination li').removeClass('active');
            $(this).addClass('active');

            getRowsCount(maxRows, pageNum, totalRows);

            $(table + ' tr:gt(0)').each(function () {
                trIndex++;
                if (trIndex > (maxRows * pageNum) || trIndex <= ((maxRows * pageNum) - maxRows)) {
                    $(this).hide();
                } else { $(this).show(); }
            });
        });
    });

    $(function () {
        getDefaultIndex();
    });

    function getRowsCount(maxRows, pageNum, totalRows) {
        var end_index = maxRows * pageNum;
        var start_index = ((maxRows * pageNum) - maxRows) + parseFloat(1);
        var string = 'Showing ' + start_index + ' to ' + end_index + ' of ' + totalRows + ' entries';
        $('.rows_count').html(string);
    }

    function getDefaultIndex() {
        $('table tr:eq(0)').prepend('<th scope="col">#</th>')

        var id = 0;

        $('table tr:gt(0)').each(function () {
            id++
            $(this).prepend('<td>' + id + '</td>');
        });
    }
}