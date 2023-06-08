//#region collabse logo
var movelogo = document.getElementById('crlogo');
var movebottom = document.querySelector('.logobottom');
var testbottom = document.querySelector('.simple-icon-arrow-up');
var laptopmmove = document.querySelector('.laptop')
function cirlogo() {
    if (movelogo.getAttribute('class') == 'cir') {
        movelogo.setAttribute('class', 'cirremove');
        movebottom.setAttribute('class', 'logobottomremove');
        testbottom.setAttribute('class', 'simple-icon-arrow-down');
        if (laptopmmove != null || laptopmmove != undefined) {
            laptopmmove.setAttribute('class', 'laptopup');
        }
    } else {
        movelogo.setAttribute('class', 'cir');
        movebottom.setAttribute('class', 'logobottom');
        testbottom.setAttribute('class', 'simple-icon-arrow-up');
        if (laptopmmove != null || laptopmmove !=undefined) {
            laptopmmove.setAttribute('class', 'laptop');
        }
      
    }
}
//#endregion
//#region navbar toggel
var ad = document.getElementById('test');
var movelogobottom = document.querySelector('.bto');
var index = 1
function toggleclass() {
    switch (index) {
        case 1:
            /// logo
            if (test.getAttribute('class') == 'Ellipse_1') {
                test.setAttribute('class', 'remove');
            } else {
                test.setAttribute('class', 'Ellipse_1');
            }
            /// button
            if (movelogobottom.getAttribute('class') == 'logobottom') {
                movelogobottom.setAttribute('class', 'bto');
            } else if (movelogobottom.getAttribute('class') == 'logobottomremove') {
                movelogobottom.setAttribute('class', 'btomove');
            } else if (movelogobottom.getAttribute('class') == 'btomove') {
                movelogobottom.setAttribute('class', 'logobottomremove');
            }
            else {
                movelogobottom.setAttribute('class', 'logobottom');
            }
            break;
        case 2:
            break;
        case 3:
            break;
        case 4:
            /// logo
            if (test.getAttribute('class') == 'Ellipse_1') {
                test.setAttribute('class', 'remove');
            } else {
                test.setAttribute('class', 'Ellipse_1');
            }

            /// button
            if (movelogobottom.getAttribute('class') == 'logobottom') {
                movelogobottom.setAttribute('class', 'bto');
            } else if (movelogobottom.getAttribute('class') == 'logobottomremove') {
                movelogobottom.setAttribute('class', 'btomove');
            } else if (movelogobottom.getAttribute('class') == 'btomove') {
                movelogobottom.setAttribute('class', 'logobottomremove');
            }
            else {
                movelogobottom.setAttribute('class', 'logobottom');
            }
            index = 0;
            break;
    }
    console.log(index);
    index++;
}
//#endregion
//#region labtop
var laa = document.getElementById('moduleerp');
var lapt = 1
function laptclass() {
    switch (lapt) {
        case 1:
            ///laptop
            if (laa.getAttribute('class') == 'laptop') {
                laa.setAttribute('class', 'laptopmove');
            } else if (laa.getAttribute('class') == 'laptopup') {
                laa.setAttribute('class', 'laptopupmove');
            } else if (laa.getAttribute('class') == 'laptopupmove') {
                laa.setAttribute('class', 'laptopup');
            } else {
                laa.setAttribute('class', 'laptop');
            }
            break;
        case 2:
            break;
        case 3:
            break;
        case 4:
            ///laptop
            if (laa.getAttribute('class') == 'laptop') {
                laa.setAttribute('class', 'laptopmove');
            } else if (laa.getAttribute('class') == 'laptopup') {
                laa.setAttribute('class', 'laptopupmove');

            } else if (laa.getAttribute('class') == 'laptopupmove') {
                laa.setAttribute('class', 'laptopup');
            } else {
                laa.setAttribute('class', 'laptop');
            }

            lapt = 0;
            break;
    }
    console.log(lapt);
    lapt++;
}
        //#endregion