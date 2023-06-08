/// <reference path="helperjs.js" />




var Token = function () {
    this.access_token = "";
    this.token_type = "";
    this.userName = "";
    this.expires_in = "";
    this.userId = "";
    this.fiscalYear = "";
    this.empId = "";
    this.departmentId = "";
    this.language = "";
    this.vattype = "";
    this.vat = "";
    this.branchid = "";
    this.autoitem = "";
    this.fyear = "";
    this.autoemp = "";
    this.udiscperitem = "";
};
let tokenUrl = settingobj.baseurl+ "/Token"
this.token = new Token();
    this.apiRequestHeaders = {
        withCredentials: "true",
        userid:null,
        Authorization: null
        , fyear: null
};

function getAction(url_, datamodel) {
    //new Promise(function (resolveresult, rejectresult) {
    data = datamodel != null ? datamodel : null;
    var headers = this.apiRequestHeaders;
    if (headers.Authorization == null)
    {
        token = GetToken()
    }

    if (token) {
        self.apiRequestHeaders.Authorization = "Bearer " + token.access_token;
        self.apiRequestHeaders.userid = token.userId;
        self.apiRequestHeaders.fyear = token.fyear;
    }

    let jqXHR = $.ajax({
        type: "get",
        async: false,
        cache: false,
        timeout: 3000,
        contentType: "application/json; charset=utf-8",
        url: settingobj.baseurl + url_,
        headers: headers,
        data: datamodel,
        statusCode: {
            401: function (xhr) {
                location.href = "../logout.aspx";
            }
        }
    })


    return JSON.parse(jqXHR.responseJSON.Data)


    //})
}

function postaction(url, datamodel) {

    //new Promise(function (resolveresult, rejectresult) {

    datamodel = datamodel != "" ? datamodel : null;
    var headers = this.apiRequestHeaders;     
    if (headers.Authorization == null) {
        token = GetToken()
    }
    
    if (token) {
        self.apiRequestHeaders.Authorization = "Bearer " + token.access_token;
        self.apiRequestHeaders.userid = token.userId; 
        self.apiRequestHeaders.fyear = token.fyear; 
    }
   
    let jqXHR = $.ajax({
        beforeSend: function () {
            //$('#loading_circle').show()
        },
        type: "post",
        async: false,
        cache: false,
        timeout: 3000,
        contentType: "application/json; charset=utf-8",
        url: settingobj.baseurl + url,
        headers: headers,
        dataType: "json",
        data: JSON.stringify(datamodel),
        complete: function () {
            
            $('#loading_circle').hide()
        }

    })


    return jqXHR.responseJSON.Data


 
}


function deleteAction(url, datamodel) {
    //new Promise(function (resolveresult, rejectresult) {
    datamodel = datamodel != "" ? datamodel : null;
    var headers = this.apiRequestHeaders;

    if (headers.Authorization == null) {

    token = GetToken()
        }
    if (token) {
        self.apiRequestHeaders.Authorization = "Bearer " + token.access_token;
        self.apiRequestHeaders.userid = token.userId;
        self.apiRequestHeaders.fyear = token.fyear;
    }
    let jqXHR = $.ajax({
        type: "Delete",
        async: false,
        cache: false,
        timeout: 3000,
        contentType: "application/json; charset=utf-8",
        url: settingobj.baseurl + url,
        dataType: "json",
        headers: headers,
        data: JSON.stringify(datamodel),

    })
   

    return jqXHR.responseJSON.Data


   
}
this.apiPostAction = function (url, data) {
  
 
    data = data!="" ? data : null;
    var headers = this.apiRequestHeaders;

    var deferred = $.Deferred();
    //this.clearToken();
    token = GetToken()

        if (token) {
            self.apiRequestHeaders.Authorization = "Bearer " + token.access_token;
        }

    $.ajax({
        beforeSend: function () {
            $('.loading_circle').show();
        },
            url: settingobj.baseurl+url,
            data: JSON.stringify(data),
            dataType: "json",
            contentType: "application/json;charset=utf-8",
            method: "POST",
             headers: headers,
            timeout: 0,
            
            success: function (respons) {
                $('.loading_circle').hide();
                deferred.resolve(respons);
            },
            error: function (respons) {
                deferred.reject(respons);
            }
        });


   



    return deferred.promise();

};
function buildCoikes(cockies) {
    let token = new Token();
    let cockiessplit = cockies.split("&")
    //if (cockiessplit.length == 1) {
    //    return null;
    //}
    for (var i = 0; i < cockiessplit.length; i++) {
        let orgcockies = cockiessplit[i].split("=");
        token[orgcockies[0]] = orgcockies[1];
    }
    return token;

}
function GetToken(credintal) {
    let cer = $.cookie("Token");
    if (cer==null) {
        location.href = "../logout.aspx";
    }
    var token = buildCoikes(cer);
    //new Promise(function (resolveresult, rejectresult) {
    if (token === undefined || token === null || token === "undefined" || token === "null") {
        //let jqXHR = $.ajax({
        //    type: "post",
        //    async: false,
        //    cache: false,
        //    timeout: 3000,
        //    contentType: "application/x-www-form-urlencoded",
        //    url: tokenUrl,
        //    dataType: "json",
        //    data: credintal,
        //      error: function () {
        //        console.log("error");
        //    }
        //})
       location.href="../logout.aspx" // token= jqXHR.responseJSON
    }
   
    return token;
   
    //.done(function (data) {
    //    //
    //    //return JSON.parse(data.d);
    //    //if (JSON.parse(data.d).errorid != 0) {
    //    //    alert(JSON.parse(data.d).errormsg)
    //    //}
    //    //else {

    //    //    if (redirecturl!="") {
    //    //    location.href = redirecturl
    //    //    }

    //    //}

    //    //console.log("success");
    //    // console.log(data); // This returns the whole html page's markup
    //})
    //.fail(function (jqXHR, textStatus, c) {
    //    //return false;
    //    //console.log("failure");
    //    //console.log(textStatus);
    //});

  


    //})
}
//this.getToken = function () {

//    var token = localStorage.getItem("token");
//    //var deferred = $.Deferred();
//    //if (token === undefined || token === null || token === "undefined" || token === "null") {

//        $.ajax({
//            type: 'POST',
//            url: tokenUrl,
//            dataType: "json",
//            contentType:"application/x-www-form-urlencoded",
//            data: 'username=Admin&password=Admin&grant_type=password',
//            async:false,
//            success: function (data) {
//                if (data.ok === true) {
//                    token = new Token();

//                    token.access_token = data.tokenResult.access_token;
//                    token.token_type = data.tokenResult.token_type;
//                    token.expires_in = data.tokenResult.expires_in;

//                    token.userName = data.tokenResult.username;
//                    token.userId = data.tokenResult.userid;
//                    //token.fiscalYear = data.tokenResult.user_fiscal_year;
//                    //token.language = data.tokenResult.language;

//                    //token.empId = data.userInfo.empId;
//                    //token.departmentId = data.userInfo.departmentId;

//                    localStorage.setItem("token", JSON.stringify(token));
//                   // deferred.resolve(token.access_token);


//                } else {
//                    token = null;
//                }


//            },
//            error: function () {
//                console.log("error");
//            }
//        });

//    //}
//    //else {
//    //    return token.access_token;
//    //}
//    //return deferred.promise();
//};

this.clearToken = function () {
    //localStorage.setItem("token", null);
};