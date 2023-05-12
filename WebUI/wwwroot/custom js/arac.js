var aracListeTablo = 0;
function DataTableArac() {
    aracListeTablo = $('#AracListeTablo').dataTable({
        ajax: {
            "cache": false,
            "global": false,
            "async": true,
            "url": '/Arac/ListeGetir',
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
            { "data": "aracTipi.adi", "name": "aracTipi.adi", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "marka", "name": "marka", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "modelYili", "name": "modelYili", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "rengi", "name": "rengi", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "plakasi", "name": "plakasi", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "ruhsatNo", "name": "ruhsatNo", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "baslangicKilometresi", "name": "baslangicKilometresi", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "demirbasDurumu", "name": "demirbasDurumu", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "kilometredeBakimaGider", "name": "kilometredeBakimaGider", "orderable": false, "searchable": false, "className": "text-dark" },
            {
                "defaultContent": "<div class='text-end'><a class='btnAracDuzenle btn btn-icon btn-bg-light btn-active-color-primary btn-sm me-1'><i class='bi bi-pencil fs-4'></i></a></div>",
                "className": "text-dark"
            }
        ],
        createdRow: function (row, data, index) {            
            data.demirbasDurumu === 1 ? $('td', row).eq(7).html("Kiralık") : $('td', row).eq(7).html("Firma Aracı");
            data.kilometredeBakimaGider === 1 ? $('td', row).eq(8).html("On Beş Bin Km") : $('td', row).eq(8).html("Bir Yılda");
        },
    });
}
$(document).on('touchstart click', '#btnAracKaydet', async function (e) {
    var data = new FormData($('#frmAracKaydet')[0]);
    data = await DosyaYuklemeIslemi('#frmAracKaydet',data);

    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/Arac/Kaydet",
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
                    window.location = '/Arac/ListeleView';
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
$(document).on('touchstart click', '#btnAracGuncelle', async function (e) {
    var data = new FormData($('#frmAracKaydet')[0]);

    if ($('#frmAracKaydet').find('input[type=file]')[0].files.length > 0) {
    var dosyaBase64 = await FileToBase64($('#frmAracKaydet').find('input[type=file]')[0].files[0]);
    var dosyaAdi = $('#frmAracKaydet').find('input[type=file]')[0].files[0].name;
    var dosyaUzantisi = $('#frmAracKaydet').find('input[type=file]')[0].files[0].type;

    data.append("dosyaYukle.dosya", dosyaBase64);
    data.append("dosyaYukle.dosyaAdi", dosyaAdi);
    data.append("dosyaYukle.dosyaUzantisi", dosyaUzantisi);
    }

    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/Arac/Guncelle",
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
                    window.location = '/Arac/ListeleView';
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
$(document).on('touchstart click', '.btnAracDuzenle', function (e) {
    e.preventDefault();
    var data = aracListeTablo.fnGetData($(this).parents('tr'));
    AracDuzenlePenceresi(data.id)
});
$(document).on('touchstart click', '#btnAracSil', function (e) {
    e.preventDefault();
    var id = $('#frmAracKaydet #Id').val();
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: id
        },
        url: '/Arac/Sil',
        beforeSend: function () {
        },
        success: function (veri) {
            swalInit.fire({
                title: 'Silme İşlemi Başarılı!',
                icon: "success",
            }).then(function () {
                window.location = '/Arac/ListeleView';
            });
            LoadingPageHide();
        },
        error: function () {
        },
        complete: function () {
        }
    });
});
function AracDuzenlePenceresi(id) {
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: id
        },
        url: '/Arac/AracPopUpDuzenleView',
        beforeSend: function () {
        },
        success: function (veri) {
            ModalOpenClose($('#modalAracGuncelle'), "Araç Güncelle", veri);
            $('#aracDemirbasDurumuSelect').val($('#DemirbasDurumu').html()).change();
            $('#aracKilometredeBakimaGiderSelect').val($('#KilometredeBakimaGider').html()).change();
            ValidasyonTetikleme.init();
            MakeDropdownSelec2InModal($('#modalAracGuncelle'));
            FileUpload.init();
        },
        error: function () {
        },
        complete: function () {
        }
    });
}   
$(document).on('touchstart click', '#btnAracYuklenmisDosya', function (e) {
    $element = $(this);
    LoadingPageShow();
    var veri = JSON.parse($element.next().html());
    var str = "";
    str += '<div class="row mb-3">';
    $.each(veri, function (i, item) {
        str += '<div class="col-md-6" id="byd_' + item.Id + '">';
        str += '<div class="card card-dashed mt-3">';
        str += '<div class="card-header alert alert-dismissible bg-light-success">';
        str += '<div class="row mt-3">';
        str += '<div class="fs-6 fw-bolder">' + item.Adi + '</div>';
        str += '<div class="fs-7 fw-bold text-muted mt-1">' + moment(item.KayitTarih).format('DD.MM.YYYY HH:mm:ss') + '</div>';
        str += '</div>';
        str += '<div class="col-md-12 my-3 text-end">';
        str += '<div class="col-md-12">';
        str += '<a href="/Dosya/DosyaIndir?ID=' + item.Id + '" target="_blank" class="btn btn-sm btn-light btn-active-light-primary me-3" data-bs-custom-class="tooltip-dark" data-popup="tooltip" title="İndir" data-placement="top"><i class="bi bi-download"></i> İndir</a>';
        str += '<a id="btnAracDosyasiSil" data-dd-id="' + item.Id + '" class="btn btn-sm btn-danger me-3" data-bs-custom-class="tooltip-dark" data-popup="tooltip" title="Sil" data-placement="top"><i class="bi bi-folder-x"></i> Sil</a>';
        str += '</div>';
        str += '</div>';
        str += '</div>';
        str += '</div>';
        str += '</div>';

    });
    str += '</div>';
    $('#aracYuklenmisDosyalar .modal-body').empty().append(str);
    ModalOpenClose($('#aracYuklenmisDosyalar'), "Araç Yüklenen Dosyalar", str);
    $('[data-popup="tooltip"]').tooltip();
    LoadingPageHide();
});
$(document).on('touchstart click', '#btnAracDosyasiSil', function (e) {
    e.preventDefault();
    $element = $(this);
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: Number($element.attr("data-dd-id"))
        },
        url: '/Dosya/DosyaSil',
        beforeSend: function () {
            LoadingPageShow();
        },
        success: function (veri) {
            swalInit.fire({
                title: 'Araç Dosyası Silme İşlemi Başarılı!',
                icon: "success",
            }).then(function () {
                $element.closest('#byd_' + Number($element.attr("data-dd-id"))).remove();
                var aracId = Number($('#frmAracKaydet #Id').val());
                AracDuzenlePenceresi(aracId);
            });
            LoadingPageHide();
        },
        error: function () {
        },
        complete: function () {
        }
    });
});
$(document).on('touchstart click', '#btnAracTemizle', async function (e) {
    $("#frmAracKaydet")[0].reset();
    MakeDropdownSelec2InModal($('#frmAracKaydet'));
});
var FileUpload = function () {
    var _componentFileUpload = function () {
        if (!$().fileinput) {
            console.warn('Warning - fileinput.min.js is not loaded.');
            return;
        }

        // Modal template
        var modalTemplate = '<div class="modal-dialog mw-1000px" role="document">\n' +
            '  <div class="modal-content">\n' +
            '    <div class="modal-header align-items-center">\n' +
            '      <h6 class="modal-title">{heading} <small><span class="kv-zoom-title"></span></small></h6>\n' +
            '      <div class="kv-zoom-actions btn-group"><div class="btn btn-icon btn-sm btn-active-light-primary ms-2" data-bs-dismiss="modal" aria-label="Close"><i class="bi bi-x-lg"></i></div></div>\n' +//{toggleheader}{fullscreen}{borderless}{close}
            '    </div>\n' +
            '    <div class="modal-body">\n' +
            '      <div class="floating-buttons btn-group"></div>\n' +
            '      <div class="kv-zoom-body file-zoom-content"></div>\n' + '{prev} {next}\n' +
            '    </div>\n' +
            '  </div>\n' +
            '</div>\n';

        // Buttons inside zoom modal
        var previewZoomButtonClasses = {
            toggleheader: 'btn btn-light btn-icon btn-header-toggle btn-sm',
            fullscreen: 'btn btn-light btn-icon btn-sm',
            borderless: 'btn btn-light btn-icon btn-sm',
            close: 'btn btn-light btn-icon btn-sm'
        };

        // Icons inside zoom modal classes
        var previewZoomButtonIcons = {
            prev: '<i class="icon-arrow-left32"></i>',
            next: '<i class="icon-arrow-right32"></i>',
            toggleheader: '<i class="icon-menu-open"></i>',
            fullscreen: '<i class="icon-screen-full"></i>',
            borderless: '<i class="icon-alignment-unalign"></i>',
            close: '<i class="icon-cross2 font-size-base"></i>'
        };

        // File actions
        var fileActionSettings = {
            uploadIcon: '<i class="icon-upload"></i>',
            zoomClass: '',
            zoomIcon: '<i class="icon-zoomin3"></i>',
            dragClass: 'p-2',
            dragIcon: '<i class="icon-three-bars"></i>',
            removeClass: '',
            removeErrorClass: 'text-danger',
            removeIcon: '<i class="icon-bin"></i>',
            indicatorNew: '<i class="icon-file-plus text-success"></i>',
            indicatorSuccess: '<i class="icon-checkmark3 file-icon-large text-success"></i>',
            indicatorError: '<i class="icon-cross2 text-danger"></i>',
            indicatorLoading: '<i class="icon-spinner2 spinner text-muted"></i>'
        };

        $('.file-input').fileinput({
            browseLabel: 'Dosya Seçimi',
            dropZoneTitle: "Dosyaları buraya sürükleyip bırakın",
            removeLabel: "Sil",
            msgPlaceholder: "Dosya seçilmedi",
            browseIcon: '<i class="icon-file-plus me-2"></i>',
            uploadIcon: '<i class="icon-file-upload2 me-2"></i>',
            removeIcon: '<i class="icon-cross2 font-size-base me-2"></i>',
            layoutTemplates: {
                icon: '<i class="icon-file-check"></i>',
                modal: modalTemplate
            },
            initialCaption: "Dosya seçilmedi",
            hideThumbnailContent: true,
            language: 'tr',
            showUpload: false,
            maxFileSize: 500000000,
        });
    };
    return {
        init: function () {
            _componentFileUpload();
        }
    }
}();
function InnerPageContentLoaded() {
    ValidasyonTetikleme.init();
    DataTableArac();
    FileUpload.init();
}