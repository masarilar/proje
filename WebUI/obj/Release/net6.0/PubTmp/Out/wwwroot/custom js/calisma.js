var calismaListeTablo = 0;
function DataTableCalisma() {
    calismaListeTablo = $('#CalismaListeTablo').dataTable({
        ajax: {
            "cache": false,
            "global": false,
            "async": true,
            "url": '/Calisma/ListeGetir',
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
                "defaultContent": "<div class='text-end'><a class='btnCalismaDuzenle btn btn-icon btn-bg-light btn-active-color-primary btn-sm me-1'><i class='bi bi-pencil fs-4'></i></a></div>",
                "className": "text-dark"
            }
        ]
    });
}
$(document).on('touchstart click', '#btnCalismaKaydet', function (e) {
    e.preventDefault();
    var data = new FormData($('#frmCalismaKaydet')[0]);
    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/Calisma/Kaydet",
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
                    window.location = '/Calisma/ListeleView';
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

$(document).on('touchstart click', '#btnCalismaGuncelle', async function (e) {
    e.preventDefault();
    var data = new FormData($('#frmCalismaKaydet')[0]);
    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/Calisma/Guncelle",
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
                    window.location = '/Calisma/ListeleView';
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

$(document).on('touchstart click', '.btnCalismaDuzenle', function (e) {
    e.preventDefault();
    var data = calismaListeTablo.fnGetData($(this).parents('tr'));
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: data.id
        },
        url: '/Calisma/CalismaPopUpDuzenleView',
        beforeSend: function () {
        },
        success: function (veri) {
            ModalOpenClose($('#modalCalismaGuncelle'), "Çalışma Güncelle", veri);
            ValidasyonTetikleme.init();
        },
        error: function () {
        },
        complete: function () {
        }
    });
});

$(document).on('touchstart click', '#btnCalismaSil', function (e) {
    e.preventDefault();
    var id = $('#frmCalismaKaydet #Id').val();
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: id
        },
        url: '/Calisma/Sil',
        beforeSend: function () {
        },
        success: function (veri) {
            swalInit.fire({
                title: 'Silme İşlemi Başarılı!',
                icon: "success",
            }).then(function () {
                window.location = '/Calisma/ListeleView';
            });
            LoadingPageHide();
        },
        error: function () {
        },
        complete: function () {
        }
    });
});

$(document).on('touchstart click', '#btnCalismaTemizle', function (e) {
    $("#frmCalismaKaydet")[0].reset();
    MakeDropdownSelec2InModal($('#frmCalismaKaydet'));
});


function InnerPageContentLoaded() {
    DataTableCalisma();
    ValidasyonTetikleme.init();
}