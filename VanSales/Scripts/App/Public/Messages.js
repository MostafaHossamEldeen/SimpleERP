 
function sweetinfo(x) {
    Swal.fire({
        icon: 'info',
        title: x,

        //showClass: {
        //    popup: 'animate__animated animate__fadeInDown'
        //},
        //hideClass: {
        //    popup: 'animate__animated animate__fadeOutUp'
        //}
    })
}


function sweetsuccess(x) {
    Swal.fire({
        icon: 'success',
        title: x,
        showConfirmButton: false,
        timer: 1500,
        //showClass: {
        //    popup: 'animate__animated animate__fadeInDown'
        //},
        //hideClass: {
        //    popup: 'animate__animated animate__fadeOutUp'
        //}
    })
}
function sweetexception(x) {
    Swal.fire({
        icon: 'error',
        title: x,
        //showClass: {
        //    popup: 'animate__animated animate__fadeInDown'
        //},
        //hideClass: {
        //    popup: 'animate__animated animate__fadeOutUp'
        //}
    })
}
function deldata(url, id, hf) {
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
            if ($("#" + hf + "").val() == "")
            {
                $("#" + hf + "").val(0)
                var hf_val = 0;
            }
            else
            {
                hf_val = $("#" + hf + "").val();
            }
            let res = postaction_webservice(url, '{ ' + id + ':' + hf_val + '}')
            if (res.errorid == 0) {
                swalWithBootstrapButtons.fire(
                    'الحذف',
                    'تم الحذف بنجاح',
                    'success'
                )
                window.setTimeout(function () { window.location.reload() }, 1500); 
            }
            else
            {
                sweetexception(res.errormsg);
            };            
        }
        else if (result.dismiss === Swal.DismissReason.cancel)
        {
            swalWithBootstrapButtons.fire(
                'إلغاء',
                'تم إلغاء عملية الحذف',
                'error'
            )
        }
    })
}
function GetError(s, e) {
    if (s.cperrors != null && s.cperrors!= undefined && s.cperrors.length != 0) {
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
//function deldata() {
//    const swalWithBootstrapButtons = Swal.mixin({
//        customClass: {
//            confirmButton: 'btn btn-success',
//            cancelButton: 'btn btn-danger'
//        },
//        buttonsStyling: true
//    })

//    swalWithBootstrapButtons.fire({
//        title: 'تأكيد الحذف',
//        text: "هل تريد حذف البيانات",
//        icon: 'warning',
//        showCancelButton: true,
//        confirmButtonText: 'نعم',
//        cancelButtonText: 'لا',
//        reverseButtons: true
//    }).then((result) => {
//        if (result.isConfirmed) {
//            gvitems.GetSelectedFieldValues("itempic", onvaluechanged);
//        } else if (
//            result.dismiss === Swal.DismissReason.cancel
//        ) {
//            swalWithBootstrapButtons.fire(
//                'إلغاء',
//                'تم إلغاء عملية الحذف',
//                'error'
//            )
//        }
//    })
//}