
function deleteRetreave( ReservationID,row){

    bootbox.confirm({
        message: 'تأكيد على الغاء الطلب',
        buttons: {
            confirm: {
                label: 'نعم',
                className: 'btn-danger'
            },
            cancel: {
                label: 'لا',
                className: 'btn-secondary'
            }
        },
        callback: function (result) {
            if (result) {
                $.ajax({
                    url: '/api/DeleteRetreave/?ReservationID=' + ReservationID,
                    method: 'DELETE',
                    success: function () {
                        var rowIndex = row.parentNode.parentNode.rowIndex;
                        document.getElementById("Reservers").deleteRow(rowIndex);
                        var alert = document.getElementById("alert");
                        alert.classList.remove('d-none');
                        setTimeout(function () {
                            alert.classList.add(('d-none'));
                        }, 3000);
                      
                    },
                    error: function () {
                        alert("يوجد خطأ");
                    }
                });
            }
        }
    });
}
