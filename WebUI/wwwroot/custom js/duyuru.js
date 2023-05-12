var duyuruListeTablo = 0;
function DataTableDuyuru() {
    duyuruListeTablo = $('#DuyuruListeTablo').dataTable({
        ajax: {
            "cache": false,
            "global": false,
            "async": true,
            "url": '/Duyuru/ListeGetir',
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
            { "data": "kategori.ad", "name": "kategori.ad", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "basligi", "name": "basligi", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "yayinTarih", "name": "yayinTarih", "orderable": false, "searchable": false, "className": "text-dark", "render": function (data, type, row) { return moment(data).format('DD.MM.YYYY HH:mm:ss'); } },
            { "data": "yayinBitisTarih", "name": "yayinBitisTarih", "orderable": false, "searchable": false, "className": "text-dark", "render": function (data, type, row) { return moment(data).format('DD.MM.YYYY HH:mm:ss'); } },
            { "data": "sliderGoster", "name": "sliderGoster", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "sliderSirasi", "name": "sliderSirasi", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "yorumEkle", "name": "yorumEkle", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "begenme", "name": "begenme", "orderable": false, "searchable": false, "className": "text-dark" },
            {
                "defaultContent": "<div class='text-end'><a class='btnDuyuruDuzenle btn btn-icon btn-bg-light btn-active-color-primary btn-sm me-1'><i class='bi bi-pencil fs-4'></i></a></div>",
                "className": "text-dark"
            }
        ],
        createdRow: function (row, data, index) {
            data.sliderGoster === 1 ? $('td', row).eq(5).html(data.sliderSirasi) : $('td', row).eq(5).html("-");
            data.sliderGoster === 1 ? $('td', row).eq(4).html("Slider Göster") : $('td', row).eq(4).html("Slider Gösterme");
            data.yorumEkle === 1 ? $('td', row).eq(6).html("Yorum Ekleme Aktif") : $('td', row).eq(6).html("Yorum Ekleme Pasif");
            data.begenme === 1 ? $('td', row).eq(7).html("Beğen Butonu Aktif") : $('td', row).eq(7).html("Beğen Butonu Pasif");
        },
    });
}
$(document).on('touchstart click', '#btnDuyuruKaydet', async function (e) {
    var data = new FormData($('#kt_account_profile_details_form')[0]);
    data = await DosyaYuklemeIslemi('#kt_account_profile_details_form', data);

    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/Duyuru/Kaydet",
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
                    window.location = '/Duyuru/ListeleView';
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
$(document).on('touchstart click', '#btnDuyuruGuncelle', async function (e) {
    var data = new FormData($('#kt_account_profile_details_form')[0]);

    if ($('#kt_account_profile_details_form').find('input[type=file]')[0].files.length > 0) {
        var dosyaBase64 = await FileToBase64($('#kt_account_profile_details_form').find('input[type=file]')[0].files[0]);
        var dosyaAdi = $('#kt_account_profile_details_form').find('input[type=file]')[0].files[0].name;
        var dosyaUzantisi = $('#kt_account_profile_details_form').find('input[type=file]')[0].files[0].type;

        data.append("dosyaYukle.dosya", dosyaBase64);
        data.append("dosyaYukle.dosyaAdi", dosyaAdi);
        data.append("dosyaYukle.dosyaUzantisi", dosyaUzantisi);
    }
    
    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/Duyuru/Guncelle",
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
                    window.location = '/Duyuru/ListeleView';
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
$(document).on('touchstart click', '.btnDuyuruDuzenle', function (e) {    
    e.preventDefault();
    var data = duyuruListeTablo.fnGetData($(this).parents('tr'));
    DuyuruDuzenlePenceresi(data.id)
});
$(document).on('touchstart click', '#btnDuyuruSil', function (e) {    
    e.preventDefault();
    var id = $('#kt_account_profile_details_form #Id').val();
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: id
        },
        url: '/Duyuru/Sil',
        beforeSend: function () {
        },
        success: function (veri) {
            swalInit.fire({
                title: 'Silme İşlemi Başarılı!',
                icon: "success",
            }).then(function () {
                window.location = '/Duyuru/ListeleView';
            });
            LoadingPageHide();  
        },
        error: function () {
        },
        complete: function () {
        }
    });
});
$(document).on('touchstart click', '#chckSliderGoster', function (e) {
    $('#txtSliderGoster').val($(this).is(':checked') ? 1 : 2);
});
$(document).on('touchstart click', '#chckYorumEkle', function (e) {
    $('#txtYorumEkle').val($(this).is(':checked') ? 1 : 2);
});
$(document).on('touchstart click', '#chckBegenme', function (e) {
    $('#txtBegenme').val($(this).is(':checked') ? 1 : 2);
});
function DuyuruDuzenlePenceresi(id) {
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: id
        },
        url: '/Duyuru/DuyuruPopUpDuzenleView',
        beforeSend: function () {
        },
        success: function (veri) {
            ModalOpenClose($('#kt_modal_bidding'), "Duyuru Güncelle", veri);
            $('#kt_modal_bidding #txtSliderGoster').val() == 1 ? $('#chckSliderGoster').attr('checked', true) : $('#chckSliderGoster').attr('checked', false);
            $('#kt_modal_bidding #txtYorumEkle').val() == 1 ? $('#chckYorumEkle').attr('checked', true) : $('#chckYorumEkle').attr('checked', false);
            $('#kt_modal_bidding #txtBegenme').val() == 1 ? $('#chckBegenme').attr('checked', true) : $('#chckBegenme').attr('checked', false);
            ValidasyonTetikleme.init();
            MakeDropdownSelec2InModal($('#kt_modal_bidding'));
            FileUpload.init();
        },
        error: function () {
        },
        complete: function () {
        }
    });
}
$(document).on('touchstart click', '#btnDuyuruYuklenmisDosya', function (e) {    
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
        str += '<a id="btnDuyuruDosyasiSil" data-dd-id="' + item.Id + '" class="btn btn-sm btn-danger me-3" data-bs-custom-class="tooltip-dark" data-popup="tooltip" title="Sil" data-placement="top"><i class="bi bi-folder-x"></i> Sil</a>';
        str += '</div>';
        str += '</div>';        
        str += '</div>';
        str += '</div>';
        str += '</div>';

    });
    str += '</div>';
    $('#duyuruYuklenmisDosyalar .modal-body').empty().append(str);
    ModalOpenClose($('#duyuruYuklenmisDosyalar'), "Duyuru Yüklenen Dosyalar", str);
    $('[data-popup="tooltip"]').tooltip();    
    LoadingPageHide();
});
$(document).on('touchstart click', '#btnDuyuruDosyasiSil', function (e) {    
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
                title: 'Duyuru Dosyası Silme İşlemi Başarılı!',
                icon: "success",
            }).then(function () {                
                $element.closest('#byd_' + Number($element.attr("data-dd-id"))).remove();
                var duyuruId = Number($('#kt_account_profile_details_form #Id').val());
                DuyuruDuzenlePenceresi(duyuruId);
            });
            LoadingPageHide();
        },
        error: function () {
        },
        complete: function () {
        }
    });
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

$(document).on('touchstart click', '#btnSliderSirasiArtir', function (e) {    
    var varOlanSayi = Number($('#SliderSirasi').val());
    var yeniSayi = varOlanSayi + 1;
    $('#SliderSirasi').val(yeniSayi);
});
$(document).on('touchstart click', '#btnSliderSirasiAzalt', function (e) {    
    var varOlanSayi = Number($('#SliderSirasi').val());
    if (varOlanSayi > 1) {
        var yeniSayi = varOlanSayi - 1;
        $('#SliderSirasi').val(yeniSayi);
    }
    else {
        $('#SliderSirasi').val(varOlanSayi);
    }
});
$(document).on('touchstart click', '#btnDuyuruTemizle', function (e) {
    $("#kt_account_profile_details_form")[0].reset();
    MakeDropdownSelec2InModal($('#kt_account_profile_details_form'));
});
function InnerPageContentLoaded() {    
    DataTableDuyuru();
    ValidasyonTetikleme.init();
    FileUpload.init();
}