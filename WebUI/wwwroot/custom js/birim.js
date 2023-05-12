var birimListeTablo = 0;
function DataTableBirim() {
    birimListeTablo = $('#BirimListeTablo').dataTable({
        ajax: {
            "cache": false,
            "global": false,
            "async": true,
            "url": '/Birim/ListeGetir',
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
            { "data": "ustBirim.adi", "name": "ustBirim.adi", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "adi", "name": "adi", "orderable": false, "searchable": false, "className": "text-dark" },
            {
                "defaultContent": "<div class='text-end'><a class='btnBirimDuzenle btn btn-icon btn-bg-light btn-active-color-primary btn-sm me-1'><i class='bi bi-pencil fs-4'></i></a></div>",
                "className": "text-dark"
            }
        ],
    });
}

$(document).on('touchstart click', '#btnBirimKaydet', function (e) {
    var data = new FormData($('#frmBirimKaydet')[0]);
    //SendAjaxRequest('/Birim/Kaydet', RequestType.POST, data);
    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/Birim/Kaydet",
        data: data,
        datatype: "json",
        type: "POST",
        contentType: false,
        processData: false,
        mimeType: "multipart/form-data",
        beforeSend: function () {
            LoadingPageShow();
        },
        success: async function (veri) {
            var sonuc = JSON.parse(veri);
            if (await ValidasyonKontrol(sonuc)) {
                swalInit.fire({
                    title: 'Kayıt İşlemi Başarılı!',
                    icon: "success",
                }).then(function () {
                    window.location = '/Birim/ListeleView';
                });
                LoadingPageHide();
            }
        },
        error: function () {
        },
        complete: function () {
        }
    });
});




$(document).on('touchstart click', '#btnBirimGuncelle', async function (e) {
    var data = new FormData($('#frmBirimKaydet')[0]);
    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/Birim/Guncelle",
        data: data,
        datatype: "json",
        type: "POST",
        contentType: false,
        processData: false,
        mimeType: "multipart/form-data",
        beforeSend: function () {
            LoadingPageShow();
        },
        success: async function (veri) {
            var sonuc = JSON.parse(veri);
            if (await ValidasyonKontrol(sonuc)) {
                swalInit.fire({
                    title: 'Güncelleme İşlemi Başarılı!',
                    icon: "success",
                }).then(function () {
                    window.location = '/Birim/ListeleView';
                });
                LoadingPageHide();
            }
        },
        error: function () {
        },
        complete: function () {
        }
    });
});


$(document).on('touchstart click', '.btnBirimDuzenle', function (e) {
    e.preventDefault();
    var data = birimListeTablo.fnGetData($(this).parents('tr'));
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: data.id
        },
        url: '/Birim/BirimPopUpDuzenleView',
        beforeSend: function () {
        },
        success: function (veri) {
            ModalOpenClose($('#modalBirimGuncelle'), "Birim Güncelle", veri);
            ValidasyonTetikleme.init();
            MakeDropdownSelec2InModal($('#modalBirimGuncelle'));
        },
        error: function () {
        },
        complete: function () {
        }
    });
});


$(document).on('touchstart click', '#btnBirimSil', function (e) {
    e.preventDefault();
    var id = $('#frmBirimKaydet #Id').val();
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: id
        },
        url: '/Birim/Sil',
        beforeSend: function () {
        },
        success: function (veri) {
            swalInit.fire({
                title: 'Silme İşlemi Başarılı!',
                icon: "success",
            }).then(function () {
                window.location = '/Birim/ListeleView';
            });
            LoadingPageHide();
        },
        error: function () {
        },
        complete: function () {
        }
    });
});

$(document).on('touchstart click', '#btnBirimTemizle', function (e) {
    $("#frmBirimKaydet")[0].reset();
    MakeDropdownSelec2InModal($('#frmBirimKaydet'));
});

function InnerPageContentLoaded() {
    DataTableBirim();
    ValidasyonTetikleme.init();
}