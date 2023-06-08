function OnClick(s, e) {
    for (var i = 1; i < gvs_inv.GetColumnsCount(); i++) {
        var name = gvs_inv.GetColumn(i).fieldName+ "FilterTB";
        eval(name).SetText('');
    }
    gvs_inv.ClearFilter();
}
function ShowDetailPopup(sinvno) {
    debugger
    if (sinvno.startsWith("9")) {
        //popup.SetContentUrl('rtn_inv.aspx?sinvno==' + sinvno);
        //popup.Show();
        window.open('Rtn_inv.aspx?sinvno=' + sinvno)
    }
    else {
        
        //popup.SetContentUrl('inv.aspx?sinvno=' + sinvno);
        //popup.Show();
        window.open('inv.aspx?sinvno=' + sinvno)
    }
}

 
