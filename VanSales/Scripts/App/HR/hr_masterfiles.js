function OnCustomButtonClick_gvhr_masterfiles_nations(s, e) {
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

            gvhr_masterfiles_nations.DeleteRow(e.visibleIndex)
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
function OnCustomButtonClick_gvhr_masterfiles_jobs(s, e) {
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

            gvhr_masterfiles_jobs.DeleteRow(e.visibleIndex)
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
function OnCustomButtonClick_gvhr_masterfiles_doctype(s, e) {
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

            gvhr_masterfiles_doctype.DeleteRow(e.visibleIndex)
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
function OnCustomButtonClick_gvhr_masterfiles_vactions(s, e) {
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

            gvhr_masterfiles_vactions.DeleteRow(e.visibleIndex)
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