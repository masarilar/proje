var kategoriListeTablo = 0;
function DataTableKategori() {
    kategoriListeTablo = $('#KategoriListeTablo').dataTable({
      
        ajax: {
            
            "cache": false,
            "global": false,
            "async": true,
            "url": '/Kategori/ListeGetir',
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
            { "data": "ad", "name": "ad", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "kategoriTip.tipAdi", "name": "kategoriTip.tipAdi", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "yetkileri", "name": "yetkileri", "orderable": false, "searchable": false, "className": "text-dark" },

            {
                "defaultContent": "<div class='text-end'><a class='btnKategoriDuzenle btn btn-icon btn-bg-light btn-active-color-primary btn-sm me-1'><i class='bi bi-pencil fs-4'></i></a></div>",
                "className": "text-dark"
            }
        ]
    });
}

$(document).on('touchstart click', '#btnKategoriKaydet', function (e) {
    e.preventDefault();
    var data = new FormData($('#frmKategoriKaydet')[0]);
    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/Kategori/Kaydet",
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
                    window.location = '/Kategori/ListeleView';
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

$(document).on('touchstart click', '#btnKategoriGuncelle', async function (e) {
    e.preventDefault();
    var data = new FormData($('#frmKategoriKaydet')[0]);
    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/Kategori/Guncelle",
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
                    window.location = '/Kategori/ListeleView';
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

$(document).on('touchstart click', '.btnKategoriDuzenle', function (e) {
    e.preventDefault();
    var data = kategoriListeTablo.fnGetData($(this).parents('tr'));
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: data.id
        },
        url: '/Kategori/KategoriPopUpDuzenleView',
        beforeSend: function () {
        },
        success: function (veri) {
            ModalOpenClose($('#modalKategoriGuncelle'), "Kategori Güncelle", veri);
            ValidasyonTetikleme.init();
            MakeDropdownSelec2InModal($('#modalKategoriGuncelle'));
        },
        error: function () {
        },
        complete: function () {
        }
    });
});
$(document).on('touchstart click', '#btnKategoriSil', function (e) {
    e.preventDefault();
    var id = $('#frmKategoriKaydet #Id').val();
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: id
        },
        url: '/Kategori/Sil',
        beforeSend: function () {
        },
        success: function (veri) {
            swalInit.fire({
                title: 'Silme İşlemi Başarılı!',
                icon: "success",
            }).then(function () {
                window.location = '/Kategori/ListeleView';
            });
            LoadingPageHide();
        },
        error: function () {
        },
        complete: function () {
        }
    });
});

$(document).on('touchstart click', '#btnKategoriTemizle', function (e) {
    $("#frmKategoriKaydet")[0].reset();
    MakeDropdownSelec2InModal($('#frmKategoriKaydet'));
});
function InnerPageContentLoaded() {
    DataTableKategori();
    ValidasyonTetikleme.init();
}