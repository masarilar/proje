var gorevListeTablo = 0;
function DataTableGorev() {
    gorevListeTablo = $('#GorevListeTablo').dataTable({
        ajax: {
            "cache": false,
            "global": false,
            "async": true,
            "url": '/Gorev/ListeGetir',
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
                "defaultContent": "<div class='text-end'><a class='btnGorevDuzenle btn btn-icon btn-bg-light btn-active-color-primary btn-sm me-1'><i class='bi bi-pencil fs-4'></i></a></div>",
                "className": "text-dark"
            }
        ]
    });
}
$(document).on('touchstart click', '#btnGorevKaydet', function (e) {
    e.preventDefault();
    var data = new FormData($('#frmGorevKaydet')[0]);
    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/Gorev/Kaydet",
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
                    window.location = '/Gorev/ListeleView';
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

$(document).on('touchstart click', '#btnGorevGuncelle', async function (e) {
    e.preventDefault();
    var data = new FormData($('#frmGorevKaydet')[0]);
    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/Gorev/Guncelle",
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
                    window.location = '/Gorev/ListeleView';
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

$(document).on('touchstart click', '.btnGorevDuzenle', function (e) {
    e.preventDefault();
    var data = gorevListeTablo.fnGetData($(this).parents('tr'));
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: data.id
        },
        url: '/Gorev/GorevPopUpDuzenleView',
        beforeSend: function () {
        },
        success: function (veri) {
            ModalOpenClose($('#modalGorevGuncelle'), "Görev Güncelle", veri);
            ValidasyonTetikleme.init();
        },
        error: function () {
        },
        complete: function () {
        }
    });
});

$(document).on('touchstart click', '#btnGorevSil', function (e) {
    e.preventDefault();
    var id = $('#frmGorevKaydet #Id').val();
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: id
        },
        url: '/Gorev/Sil',
        beforeSend: function () {
        },
        success: function (veri) {
            swalInit.fire({
                title: 'Silme İşlemi Başarılı!',
                icon: "success",
            }).then(function () {
                window.location = '/Gorev/ListeleView';
            });
            LoadingPageHide();
        },
        error: function () {
        },
        complete: function () {
        }
    });
});

$(document).on('touchstart click', '#btnGorevTemizle', function (e) {
    $("#frmGorevKaydet")[0].reset();
    MakeDropdownSelec2InModal($('#frmGorevKaydet'));
});

function InnerPageContentLoaded() {
    DataTableGorev();
    ValidasyonTetikleme.init();
}