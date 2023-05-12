var aracBeklemeDurumListeTablo = 0;
function DataTableAracBeklemeDurum() {
    aracBeklemeDurumListeTablo = $('#AracBeklemeDurumListeTablo').dataTable({
        ajax: {
            "cache": false,
            "global": false,
            "async": true,
            "url": '/AracBeklemeDurum/ListeGetir',
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
            { "data": "beklemeDurum", "name": "beklemeDurum", "orderable": false, "searchable": false, "className": "text-dark" },
            {
                "defaultContent": "<div class='text-end'><a class='btnAracBeklemeDurumDuzenle btn btn-icon btn-bg-light btn-active-color-primary btn-sm me-1'><i class='bi bi-pencil fs-4'></i></a></div>",
                "className": "text-dark"
            }
        ],
    });
}
$(document).on('touchstart click', '#btnAracBeklemeDurumKaydet', function (e) {
    var data = new FormData($('#frmAracBeklemeDurumKaydet')[0]);

    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/AracBeklemeDurum/Kaydet",
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
                    window.location = '/AracBeklemeDurum/ListeleView';
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
$(document).on('touchstart click', '#btnAracBeklemeDurumGuncelle', async function (e) {
    var data = new FormData($('#frmAracBeklemeDurumKaydet')[0]);
    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/AracBeklemeDurum/Guncelle",
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
                    window.location = '/AracBeklemeDurum/ListeleView';
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

$(document).on('touchstart click', '.btnAracBeklemeDurumDuzenle', function (e) {
    e.preventDefault();
    var data = aracBeklemeDurumListeTablo.fnGetData($(this).parents('tr'));
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: data.id
        },
        url: '/AracBeklemeDurum/AracBeklemeDurumPopUpDuzenleView',
        beforeSend: function () {
        },
        success: function (veri) {
            ModalOpenClose($('#modalAracBeklemeDurumGuncelle'), "Araç Bekleme Durum Güncelle", veri);
            ValidasyonTetikleme.init();
            MakeDropdownSelec2InModal($('#modalAracBeklemeDurumGuncelle'));
        },
        error: function () {
        },
        complete: function () {
        }
    });
});

$(document).on('touchstart click', '#btnAracBeklemeDurumSil', function (e) {
    e.preventDefault();
    var id = $('#frmAracBeklemeDurumKaydet #Id').val();
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: id
        },
        url: '/AracBeklemeDurum/Sil',
        beforeSend: function () {
        },
        success: function (veri) {
            swalInit.fire({
                title: 'Silme İşlemi Başarılı!',
                icon: "success",
            }).then(function () {
                window.location = '/AracBeklemeDurum/ListeleView';
            });
            LoadingPageHide();
        },
        error: function () {
        },
        complete: function () {
        }
    });
});

$(document).on('touchstart click', '#btnAracBeklemeDurumTemizle', function (e) {
    $("#frmAracBeklemeDurumKaydet")[0].reset();
    MakeDropdownSelec2InModal($('#frmAracBeklemeDurumKaydet'));
});

function InnerPageContentLoaded() {
    DataTableAracBeklemeDurum();
    ValidasyonTetikleme.init();
}