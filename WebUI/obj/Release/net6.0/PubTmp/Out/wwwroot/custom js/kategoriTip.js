var kategoriTipListeTablo = 0;
function DataTableKategoriTip() {
    kategoriTipListeTablo = $('#KategoriTipListeTablo').dataTable({
        ajax: {
            "cache": false,
            "global": false,
            "async": true,
            "url": '/KategoriTip/ListeGetir',
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
            { "data": "tipAdi", "name": "tipAdi", "orderable": false, "searchable": false, "className": "text-dark" },

            {
                "defaultContent": "<div class='text-end'><a class='btnKategoriTipDuzenle btn btn-icon btn-bg-light btn-active-color-primary btn-sm me-1'><i class='bi bi-pencil fs-4'></i></a></div>",
                "className": "text-dark"
            }
        ]
    });
}
$(document).on('touchstart click', '#btnKategoriTipKaydet', function (e) {
    e.preventDefault();
    var data = new FormData($('#frmKategoriTipKaydet')[0]);
    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/KategoriTip/Kaydet",
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
                    window.location = '/KategoriTip/ListeleView';
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

$(document).on('touchstart click', '#btnKategoriTipGuncelle', async function (e) {
    e.preventDefault();
    var data = new FormData($('#frmKategoriTipKaydet')[0]);
    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/KategoriTip/Guncelle",
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
                    window.location = '/KategoriTip/ListeleView';
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

$(document).on('touchstart click', '.btnKategoriTipDuzenle', function (e) {
    e.preventDefault();
    var data = kategoriTipListeTablo.fnGetData($(this).parents('tr'));
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: data.id
        },
        url: '/KategoriTip/KategoriTipPopUpDuzenleView',
        beforeSend: function () {
        },
        success: function (veri) {
            ModalOpenClose($('#modalKategoriTipGuncelle'), "Kategori Tip Güncelle", veri);
            ValidasyonTetikleme.init();
        },
        error: function () {
        },
        complete: function () {
        }
    });
});

$(document).on('touchstart click', '#btnKategoriTipSil', function (e) {
    e.preventDefault();
    var id = $('#frmKategoriTipKaydet #Id').val();
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: id
        },
        url: '/KategoriTip/Sil',
        beforeSend: function () {
        },
        success: function (veri) {
            swalInit.fire({
                title: 'Silme İşlemi Başarılı!',
                icon: "success",
            }).then(function () {
                window.location = '/KategoriTip/ListeleView';
            });
            LoadingPageHide();
        },
        error: function () {
        },
        complete: function () {
        }
    });
});

$(document).on('touchstart click', '#btnKategoriTipTemizle', function (e) {
    $("#frmKategoriTipKaydet")[0].reset();
    MakeDropdownSelec2InModal($('#frmKategoriTipKaydet'));
});
function InnerPageContentLoaded() {
    DataTableKategoriTip();
    ValidasyonTetikleme.init();
}