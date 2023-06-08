function OnCustomButtonClick_gvhr_monthyear(s, e) {
    const swalWithBootstrapButtons = Swal.mixin({
        customClass: {
            confirmButton: 'btn btn-success',
            cancelButton: 'btn btn-danger'
        },
        buttonsStyling: true
    })
    swalWithBootstrapButtons.fire({
        title: 'تأكيد الحذف',
        text: "هل تريد حذف البيانات",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonText: ' نعم, تأكيد',
        cancelButtonText: 'لا, إلغاء ',
        reverseButtons: true
    }).then((result) => {
        if (result.isConfirmed) {

            gvhr_monthyear.DeleteRow(e.visibleIndex)
        } else if (
            result.dismiss === Swal.DismissReason.cancel
        ) {
            swalWithBootstrapButtons.fire(
                'إلغاء',
                'تم إلغاء عملية الحذف',
                'error'
            )
        }
    })
}