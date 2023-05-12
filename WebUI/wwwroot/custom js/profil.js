$(document).on('touchstart click', '#btnProfilim', function (e) {
    var data = new FormData($('#frmKullaniciKaydet')[0]);

    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: data.id
        },
        url: '/Kullanici/KullaniciProfiliPopUpDuzenleView',
        beforeSend: function () {
        },
        success: function (veri) {
            ModalOpenClose($('#modalKullaniciProfil'), "Kullanıcı Profil Düzenle", veri);
            ValidasyonTetikleme.init();
            $('#modalKullaniciProfil #cinsiyetSelect').val($('#modalKullaniciProfil #Cinsiyet').html()).change();
            $('#modalKullaniciProfil #medeniDurumSelect').val($('#modalKullaniciProfil #MedeniDurum').html()).change();
            $('#modalKullaniciProfil #askerlikDurumSelect').val($('#modalKullaniciProfil #AskerlikDurum').html()).change();
            $('#modalKullaniciProfil #parola').val($('#modalKullaniciProfil #Parola').html()).change();
            $("#btnKullaniciGuncelle").attr("id", "btnModalKullaniciGuncelle");
            $("#btnKullaniciYuklenmisDosya").attr("id", "btnModalKullaniciProfilYuklenmisDosya");
            MakeDropdownSelec2InModal($('#modalKullaniciProfil'));
            FileUpload.init();
            document.getElementById("btnKullaniciSil").style.visibility = "hidden";
        },
        error: function (veri) {
        },
        complete: function () {
        }
    });
});

$(document).on('touchstart click', '#btnModalKullaniciGuncelle', async function (e) {
    var data = new FormData($('#modalKullaniciProfil #frmKullaniciKaydet')[0]);
    KullaniciGuncelle(data, '#modalKullaniciProfil #frmKullaniciKaydet');
    //data = await DosyaYuklemeIslemi('#modalKullaniciProfil #frmKullaniciKaydet', data);
});

async function KullaniciGuncelle(data, formName) {
    if ($(formName).find('input[type=file]')[0].files.length > 0) {
        var dosyaBase64 = await FileToBase64($(formName).find('input[type=file]')[0].files[0]);
        var dosyaAdi = $(formName).find('input[type=file]')[0].files[0].name;
        var dosyaUzantisi = $(formName).find('input[type=file]')[0].files[0].type;

        data.append("dosyaYukle.dosya", dosyaBase64);
        data.append("dosyaYukle.dosyaAdi", dosyaAdi);
        data.append("dosyaYukle.dosyaUzantisi", dosyaUzantisi);
    }
    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/Kullanici/Guncelle",
        data: data,
        datatype: "json",
        type: "POST",
        contentType: false,
        processData: false,
        mimeType: "multipart/form-data",
        beforeSend: function () {
            LoadingPageShow();
        },
        success: function (veri) {
            swalInit.fire({
                title: 'Güncelleme İşlemi Başarılı!',
                icon: "success",
            }).then(function () {
                if (window.location.pathname === '/Kullanici/KaydetView') {
                    window.location = '/Kullanici/ListeleView';
                }
                else {
                    window.location.reload();
                }
            });
            LoadingPageHide();
        },
        error: function () {
        },
        complete: function () {
        }
    });
}

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

$(document).on('touchstart click', '#btnModalKullaniciProfilYuklenmisDosya', function (e) {
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
        str += '<a id="btnKullaniciDosyasiSil" data-dd-id="' + item.Id + '" class="btn btn-sm btn-danger me-3" data-bs-custom-class="tooltip-dark" data-popup="tooltip" title="Sil" data-placement="top"><i class="bi bi-folder-x"></i> Sil</a>';
        str += '</div>';
        str += '</div>';
        str += '</div>';
        str += '</div>';
        str += '</div>';

    });
    str += '</div>';
    $('#kullaniciProfilYuklenmisDosyalar .modal-body').empty().append(str);
    ModalOpenClose($('#kullaniciProfilYuklenmisDosyalar'), "Kullanıcı Yüklenen Dosyalar", str);
    $('[data-popup="tooltip"]').tooltip();
    LoadingPageHide();
});

$(document).on('touchstart click', '#btnKullaniciDosyasiSil', function (e) {
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
                title: 'Kullanıcı Dosyası Silme İşlemi Başarılı!',
                icon: "success",
            }).then(function () {
                $element.closest('#byd_' + Number($element.attr("data-dd-id"))).remove();
                //var kullaniciId = Number($('#frmKullaniciKaydet #Id').val());
                //KullaniciDuzenlePenceresi(kullaniciId);
            });
            LoadingPageHide();
        },
        error: function () {
        },
        complete: function () {
        }
    });
});

