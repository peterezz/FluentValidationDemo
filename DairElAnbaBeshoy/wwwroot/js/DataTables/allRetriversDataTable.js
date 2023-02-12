$(document).ready(function () {
    $('#Reservers').dataTable({
        "processing": true,
        "serverSide": true,
        "filter": true,
        "responsive": true,
        "scrollY": '1000px',
        "scrollCollapse": true,

        "paging": true,
        "searching": true,
        "ordering": true,
        "ajax": {
            "url": "/api/AllRetriversList",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": true,
            "searchable": false,
             "autoWidth": true,
        }],
        "columns": [
  


             { "data": "reserverFullName", "name": "ReserverFullName", "autowidth": true },
            { "data": "resrversNumber", "name": "ResrversNumber", "autowidth": true },
            { "data": "isApprovedMassage", "name": "IsApprovedMassage", "autowidth": true },
            { "data": "reserveDate", "name": "ReserveDate", "autowidth": true },
            { "data": "reserveTime", "name": "ReserveTime", "autowidth": true },
            { "data": "notes", "name": "Notes", "autowidth": true },

            {
                "render": function (data, type, row) {
                    return '<a href=/admin/UpdateReservation?ReservationID=' + row.id + ' class="btn btn-primary"  > تحديث </a>'
                },
                "orderable": false
            },
            {
                "render": function (data, type, row) { return '<a href="javascript:;" onclick="deleteRetreave(' + row.id + ',this)" class="btn btn-danger js-delete"  > الغاء </a>' },
                "orderable": false
            }

        ]
    });
});