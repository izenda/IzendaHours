$("#timeTable").each(function () {
    $(this).dataTable({
        "aaSorting": [[0, 'desc']],
        "stateSave": true,
        "stateDuration": -1,
        "footerCallback": function (row, data, start, end, display) {
            var api = this.api(), data;

            // Remove the formatting to get integer data for summation
            var intVal = function (i) {
               return typeof i === 'string' ?
                    i.replace(/[\$,]/g, '') * 1 :
                    typeof i === 'number' ?
                    i : 0;
            };

            // Total over all pages
            total = api
                .column(4)
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                });

            // Total over this page
            pageTotal = api
               .column(4, { page: 'current' })
               .data()
               .reduce(function (a, b) {
                   return intVal(a) + intVal(b);
                }, 0);

            // Update footer
            $(api.column(4).footer()).html(
               pageTotal + ' hours'
            );
        }
    })
    .columnFilter({
       //sPlaceHolder: "head:before",
       "bLengthChange": true,
       "sDom": "lrtip",
       "bAutoWidth": true, "sScrollY": "400px", "bPaginate": true, "bUseColVis": true, "bScrollCollapse": true, aoColumns: [{
           type: "date-range"
                 
        },
                   {
                       type: "select"
                              
                   },
                   {
                       type: "select"

                   }
        ]

    });

});

$(document).ready(function () {
   $('#projectTable').DataTable();
});

var jumboHeight = $('.jumbotron').outerHeight();
function parallax() {
    var scrolled = $(window).scrollTop();
    $('.bg').css('height', (jumboHeight - scrolled) + 'px');
}

$(window).scroll(function (e) {
    parallax();
});

$(document).ready(function () {
    $("#ProjectId").select2();
    $("#TaskId").select2();
});

$("#createTable").each(function () {
    $(this).dataTable({
        "aoColumns": [{ "bSortable": false }, null],
        "bFilter": false,
        "bInfo": false,
        "bPaginate": false
    })
});




