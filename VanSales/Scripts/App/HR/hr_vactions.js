function preventwrite1(s, e) {



    ASPxClientUtils.PreventEventAndBubble(e.htmlEvent);

}
$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    switch ($('#popupModalsearchdef').data("name")) {
        case "nav":
            debugger
            if (cmb_vapp.GetValue() != 0) {
                btn_Save.SetEnabled(false);
                btn_Save.GetMainElement().className = btn_Save.GetMainElement().className.concat(' disableclint');

                btn_delete.SetEnabled(false);
                btn_delete.GetMainElement().className = btn_delete.GetMainElement().className.concat(' disableclint');
            }
            else {
                {
                    btn_Save.SetEnabled(true);
                    btn_Save.GetMainElement().className = btn_Save.GetMainElement().className.concat(' enableclint');

                    btn_delete.SetEnabled(true);
                    btn_delete.GetMainElement().className = btn_delete.GetMainElement().className.concat(' enableclint');
                }
            }
            break;
        default:
    }
});
function validate(s, e) {
    
    if (nullToEmpty(txt_vdate.GetValue()) == "") {
        sweetinfo("برجاء ادخال تاريخ طلب الاجازه");
        txt_vdate.Focus();
        e.txt_vdate.Focus();
        return;
    }

    if (nullToEmpty(txt_empid.GetValue()) == "") {
        sweetinfo("برجاء ادخال الموظف");
        txt_empid.Focus();
        e.txt_empid.Focus();
        return;
    }
    


 
if (nullToDecimalZero(txt_vdays.GetValue()) == 0) {
        sweetinfo("لايمكن ادخال عدد ايام  صفر ");
    txt_vdays.Focus();
    e.txt_vdays.Focus();
        return;
    }
    comparedate();
}

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
        txt_empid.Focus();
    }
}

function comparedate()
{
    let fromdate = new Date(txt_vfromd.GetValue());
    let todate = new Date(txt_vtodate.GetValue());
    let vdate = new Date(txt_vdate.GetValue());


    if (vdate > fromdate)
    {
        sweetinfo("برجاء ادخال تاريخ طلب الاجازه اقل من او يساوى تاريخ البدايه");
        ASPxClientUtils.PreventEvent(event.htmlEvent);
    }

    if (fromdate > todate)
    {
        sweetinfo("برجاء ادخال تاريخ البدايه اكبر من او يساوى تاريخ النهايه");
        ASPxClientUtils.PreventEvent(event.htmlEvent);
    }
    
}

function numberofdays()
{
    //comparedate();
    // To set two dates to two variables
    let date1 = new Date(txt_vfromd.GetValue());
    let date2 = new Date(txt_vtodate.GetValue());
  
    // To calculate the time difference of two dates
    let Difference_In_Time = date2.getTime() - date1.getTime();

    // To calculate the no. of days between two dates
    let Difference_In_Days = Difference_In_Time / (1000 * 3600 * 24);
    txt_vdays.SetValue(Difference_In_Days+1);

    ////To display the final no. of days (result)
    //document.write("Total number of days between dates  <br>"
    //    + date1 + "<br> and <br>"
    //    + date2 + " is: <br> "
    //    + Difference_In_Days);
}