const { debug } = require("console");
const { debuglog } = require("util");

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

function recalculateIncomingAmt() {
    var total = 0;
    var indicies = gvshortmenu.batchEditApi.GetRowVisibleIndices();
    for (var i = 0; i < indicies.length; i++) {
        if (e.visibleIndex != indicies[i])
            total += gvshortmenu.batchEditApi.GetCellValue(indicies[i], 'shortmenu');
    }
    IncomingAmt.SetValue(total);
} 