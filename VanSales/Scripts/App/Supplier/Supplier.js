$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    if (modalClosingMethod == "bygrid") {
        cmb_suppchartid.SetValue(popupres["chartid"]);
    }
})
function deldata() {
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
            gvsuppliers.PerformCallback(null);
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

function GetError(s, e) {
    if (s.cperrors != 'undefined' && s.cperrors != null && s.cperrors.length != 0) {
        Swal.fire({
            icon: s.cpicon,
            title: s.cperrors,
            //showClass: {
            //    popup: 'animate__animated animate__fadeInDown'
            //},
            //hideClass: {
            //    popup: 'animate__animated animate__fadeOutUp'
            //}
        })
        s.cperrors = "";
    }
}

function Done(values) {
    window.opener.addcus(values);
    window.close();
}

function sweetexception() {
    Swal.fire({
        icon: 'error',
        title: ("<%=hferror.Value%>"),
        //showClass: {
        //    popup: 'animate__animated animate__fadeInDown'
        //},
        //hideClass: {
        //    popup: 'animate__animated animate__fadeOutUp'
        //}
    })
}