var adresDefteriListeTablo = 0;
function DataTableAdresDefteri() {
    adresDefteriListeTablo = $('#AdresDefteriListeTablo').dataTable({
        ajax: {
            "cache": false,
            "global": false,
            "async": true,
            "url": '/AdresDefteri/KullaniciListesiGetir',
            "data": function (d) {
            },
            "datatype": "json",
            "type": "POST",
            "beforeSend": function () {
            },
            "complete": function () {
            },
            "error": function () {
            }
        },
        columnDefs: [{
            "defaultContent": "-",
            "targets": "_all",
        }],
        columns: [
            { "data": "id", "name": "id", "visible": false, "orderable": false, "searchable": false, "className": "text-dark" },
            {
                "defaultContent": "<div class='symbol symbol-50px me-5'> <img src='' class='' alt=''></div>",
                "className": "text-dark"
            },
            { "data": "adSoyad", "name": "adSoyad", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "eposta", "name": "eposta", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "birim.adi", "name": "birim.adi", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "gorev.adi", "name": "gorev.adi", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "adres", "name": "adres", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "cepTelefon", "name": "cepTelefon", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "dahiliNo", "name": "dahiliNo", "orderable": false, "searchable": false, "className": "text-dark" }
        ],
        createdRow: function (row, data, index) {                        
            $('td', row).eq(0).closest(".text-dark").find("img").attr("src", data.resim);
        },
    });
}


//$(document).on('touchstart click', '#btnKullaniciFiltrele', async function (e) {
//    debugger;
//    var data = new FormData($('#frmListe')[0]);
//    $.ajax({
//        cache: false,
//        global: false,
//        async: true,
//        url: "/AdresDefteri/AdresDefteriDatatable",
//        data: data,
//        datatype: "json",
//        type: "POST",
//        contentType: false,
//        processData: false,
//        mimeType: "multipart/form-data",
//        beforeSend: function () {
//        },
//        success: function (veri) {
//            var sonuc = JSON.parse(veri);
//            if (sonuc.sonuc !== 0) {
//            }
//        },
//        error: function () {
//        },
//        complete: function () {
//        }
//    });
//});


function InnerPageContentLoaded() {
    DataTableAdresDefteri();
    ValidasyonTetikleme.init();
}