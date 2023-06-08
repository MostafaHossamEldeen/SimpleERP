$('#popupModalsearchdef').on('hidden.bs.modal', function () {
    if (modalClosingMethod == "bygrid") {
        switch ($('#popupModalsearchdef').data("name")) {
            case "chartid":
                {
                    $('#hf_chartid').val(popupres["chartid"]);
                }
                break;
            default:
                break;
    }
});