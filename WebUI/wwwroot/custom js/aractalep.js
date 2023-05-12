var aracTalepListeTablo = 0;

function DataTableAracTalep() {
    debugger;
    aracTalepListeTablo = $('#AracTalepListeTablo').dataTable({
        ajax: {
            "cache": false,
            "global": false,
            "async": true,
            "url": '/AracTalep/ListeGetir',
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
            { "data": "baslangicNoktasi", "name": "baslangicNoktasi", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "bitisNoktasi", "name": "bitisNoktasi", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "toplamKilometre", "name": "toplamKilometre", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "gidisTarihSaat", "name": "gidisTarihSaat", "orderable": false, "searchable": false, "className": "text-dark", "render": function (data, type, row) { return moment(data).format('DD.MM.YYYY HH:mm:ss'); } },
            {
                "defaultContent": "<div class='text-end'><a class='btnAracTalepDuzenle btn btn-icon btn-bg-light btn-active-color-primary btn-sm me-1'><i class='bi bi-pencil fs-4'></i></a></div>",
                "className": "text-dark"
            }
        ],
        createdRow: function (row, data, index) {
        },
    });
}

$(document).on('touchstart click', '#btnAracTalepKaydet', async function (e) {
    debugger;
    var data = new FormData($('#frmAracTalepKaydet')[0]);

    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/AracTalep/Kaydet",
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
                    window.location = '/AracTalep/ListeleView';
                });
                LoadingPageHide();
            }
        },
        error: function (veri) {
            debugger;
        },
        complete: function () {
        }
    });
});

$(document).on('touchstart click', '#btnAracTalepGuncelle', async function (e) {
    debugger;
    var data = new FormData($('#frmAracTalepKaydet')[0]);

    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/AracTalep/Guncelle",
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
                    window.location = '/AracTalep/ListeleView';
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

$(document).on('touchstart click', '.btnAracTalepDuzenle', function (e) {
    debugger;
    e.preventDefault();
    var data = aracTalepListeTablo.fnGetData($(this).parents('tr'));
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: data.id
        },
        url: '/AracTalep/AracTalepPopUpDuzenleView',
        beforeSend: function () {
        },
        success: function (veri) {
            ModalOpenClose($('#modalAracTalepGuncelle'), "Araç Talep Güncelle", veri);
            ValidasyonTetikleme.init();
            MakeDropdownSelec2InModal($('#modalAracTalepGuncelle'));
        },
        error: function () {
        },
        complete: function () {
        }
    });
});


$(document).on('touchstart click', '#btnAracTalepSil', function (e) {
    e.preventDefault();
    var id = $('#frmAracTalepKaydet #Id').val();
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: id
        },
        url: '/AracTalep/Sil',
        beforeSend: function () {
        },
        success: function (veri) {
            swalInit.fire({
                title: 'Silme İşlemi Başarılı!',
                icon: "success",
            }).then(function () {
                window.location = '/AracTalep/ListeleView';
            });
            LoadingPageHide();
        },
        error: function () {
        },
        complete: function () {
        }
    });
});


$(document).on('touchstart click', '#btnAracTalepTemizle', async function (e) {
    debugger;
    $("#frmAracTalepKaydet")[0].reset();
    MakeDropdownSelec2InModal($('#frmAracTalepKaydet'));
});



function InnerPageContentLoaded() {
    ValidasyonTetikleme.init();
    DataTableAracTalep();
}

