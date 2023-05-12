var aracTalepOnaylaListeTablo = 0;

function DataTableAracTalepOnayla() {
    debugger;
    aracTalepOnaylaListeTablo = $('#AracTalepOnaylaListeTablo').dataTable({
        ajax: {
            "cache": false,
            "global": false,
            "async": true,
            "url": '/AracTalep/TalepOnaylaListeGetir',
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
            //{ "data": "aracTipi.adi", "name": "aracTipi.adi", "orderable": false, "searchable": false, "className": "text-dark" },
            //{ "data": "kullanici.adSoyad", "name": "kullanici.adSoyad", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "aracTalepDurum", "name": "aracTalepDurum", "orderable": false, "searchable": false, "className": "text-dark" },
            {
                "defaultContent": "<div class='text-end'><a class='btnOnaylanacakAracTalepDuzenle btn btn-icon btn-bg-light btn-active-color-primary btn-sm me-1'><i class='bi bi-pencil fs-4'></i></a></div>",
                "className": "text-dark"
            }
        ],
        createdRow: function (row, data, index) {
            data.aracTalepDurum === 1 ? $('td', row).eq(4).html("Onay Bekliyor") : $('td', row).eq(5).html("Onaylandı");
        },
    });
}

$(document).on('touchstart click', '.btnOnaylanacakAracTalepDuzenle', function (e) {
    debugger;
    e.preventDefault();
    var data = aracTalepOnaylaListeTablo.fnGetData($(this).parents('tr'));
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: data.id
        },
        url: '/AracTalep/OnaylanacakAracTalepPopUpDuzenleView',
        beforeSend: function () {
        },
        success: function (veri) {
            ModalOpenClose($('#modalOnaylanacakAracTalepGuncelle'), "Onaylanacak Araç Talep Güncelle", veri);
            ValidasyonTetikleme.init();
            MakeDropdownSelec2InModal($('#modalOnaylanacakAracTalepGuncelle'));
        },
        error: function () {
        },
        complete: function () {
        }
    });
});

$(document).on('touchstart click', '#btnOnaylanacakAracTalepOnayla', async function (e) {
    debugger;
    var data = new FormData($('#frmOnaylanacakAracTalepKaydet')[0]);

    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/AracTalep/Onayla",
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
            debugger;
            var sonuc = JSON.parse(veri);
            if (sonuc.sonuc>0 && await ValidasyonKontrol(sonuc)) {
                swalInit.fire({
                    title: 'Onaylama İşlemi Başarılı!',
                    icon: "success",
                }).then(function () {
                    window.location = '/AracTalep/OnaylaView';
                });
                LoadingPageHide();
            }
            else {
                swalInit.fire({
                    title: 'Onaylama İşlemi Başarısız!',
                    icon: "error",
                }).then(function () {
                    window.location = '/AracTalep/OnaylaView';
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

$(document).on('touchstart click', '#btnOnaylanacakAracTalepReddet', async function (e) {
    debugger;
    var data = new FormData($('#frmOnaylanacakAracTalepKaydet')[0]);

    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/AracTalep/Reddet",
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
                    title: 'Reddetme İşlemi Yapıldı!',
                    icon: "success",
                }).then(function () {
                    window.location = '/AracTalep/OnaylaView';
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

function InnerPageContentLoaded() {
    ValidasyonTetikleme.init();
    DataTableAracTalepOnayla();
}