var aractipiListeTablo = 0;

function DataTableAracTipi() {
    aractipiListeTablo = $('#AracTipiListeTablo').dataTable({
        ajax: {
            "cache": false,
            "global": false,
            "async": true,
            "url": '/AracTipi/ListeGetir',
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
            { "data": "adi", "name": "adi", "orderable": false, "searchable": false, "className": "text-dark" },
            {
                "defaultContent": "<div class='text-end'><a class='btnAracTipiDuzenle btn btn-icon btn-bg-light btn-active-color-primary btn-sm me-1'><i class='bi bi-pencil fs-4'></i></a></div>",
                "className":"text-dark" 
            }
        ],
    });
}

$(document).on('touchstart click', '#btnAracTipiKaydet', function (e) {
    var data = new FormData($('#frmAracTipiKaydet')[0]);
    //SendAjaxRequest('/AracTipi/Kaydet', RequestType.POST, data);
    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/AracTipi/Kaydet",
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
                    window.location = '/AracTipi/ListeleView';
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

$(document).on('touchstart click', '#btnAracTipiGuncelle', async function (e) {
    var data = new FormData($('#frmAracTipiKaydet')[0]);
    //await SendAjaxRequest('/AracTipi/Guncelle', RequestType.POST, data);
    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/AracTipi/Guncelle",
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
                    window.location = '/AracTipi/ListeleView';
                });
                LoadingPageHide();
            }
        },
        error: function () {
            debugger;
        },
        complete: function () {
        }
    });
});


$(document).on('touchstart click', '.btnAracTipiDuzenle', function (e) {
    e.preventDefault();
    var data = aractipiListeTablo.fnGetData($(this).parents('tr'));
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: data.id
        },
        url: '/AracTipi/AracTipiPopUpDuzenleView',
        beforeSend: function () {
        },
        success: function (veri) {
            ModalOpenClose($('#modalAracTipiGuncelle'), "Araç Tipi Güncelle", veri);
            ValidasyonTetikleme.init();
        },
        error: function () {
        },
        complete: function () {
        }
    });
});

$(document).on('touchstart click', '#btnAracTipiSil', function (e) {
    e.preventDefault();
    var id = $('#frmAracTipiKaydet #Id').val();
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: id
        },
        url: '/AracTipi/Sil',
        beforeSend: function () {
        },
        success: function (veri) {
            swalInit.fire({
                title: 'Silme İşlemi Başarılı!',
                icon: "success",
            }).then(function () {
                window.location = '/AracTipi/ListeleView';
            });
            LoadingPageHide();
        },
        error: function () {
        },
        complete: function () {
        }
    });
});

$(document).on('touchstart click', '#btnAracTipiTemizle', function (e) {
    $("#frmAracTipiKaydet")[0].reset();
    MakeDropdownSelec2InModal($('#frmAracTipiKaydet'));
});


function InnerPageContentLoaded() {
    DataTableAracTipi();
    ValidasyonTetikleme.init();
}