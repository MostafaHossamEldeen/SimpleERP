function setEmpData(s, e) {
    let searchmodel = {
        empcode: s.GetValue()

    }
    let data = getAction("/VanSalesService/hr_vactions/GetempSingalData", searchmodel)

    if (data.length != 0) {

        searchmodel["empcode"] = data[0].empcode;
        txt_empname.SetValue(data[0].empname);

        $('#HF_empid').val(data[0].empid);


    }
    else {
        txt_empid.SetValue("");
        txt_empname.SetValue("");
        $('#HF_empid').val("");
    }
}