var kullaniciListeTablo = 0;
function DataTableKullanici() {
    kullaniciListeTablo = $('#KullaniciListeTablo').dataTable({
        ajax: {
            "cache": false,
            "global": false,
            "async": true,
            "url": '/Kullanici/ListeGetir',
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
            { "data": "tc", "name": "tc", "visible": false, "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "adSoyad", "name": "adSoyad", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "eposta", "name": "eposta", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "birim.adi", "name": "birim.adi", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "gorev.adi", "name": "gorev.adi", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "adres", "name": "adres", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "cepTelefon", "name": "cepTelefon", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "evTelefon", "name": "evTelefon", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "kanGrubu", "name": "kanGrubu", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "cinsiyet", "name": "cinsiyet", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "medeniDurum", "name": "medeniDurum", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "askerlikDurum", "name": "askerlikDurum", "orderable": false, "searchable": false, "className": "text-dark" },
            { "data": "calismaTur.adi", "name": "calismaTur.adi", "orderable": false, "searchable": false, "className": "text-dark" },

            {
                "defaultContent": "<div class='text-end'><a class='btnKullaniciDuzenle btn btn-icon btn-bg-light btn-active-color-primary btn-sm me-1'><i class='bi bi-pencil fs-4'></i></a></div>",
                "className": "text-dark"
            }
        ],
        createdRow: function (row, data, index) {
            data.medeniDurum === 1 ? $('td', row).eq(10).html("Bekar") : $('td', row).eq(10).html("Evli");
            data.cinsiyet === 1 ? $('td', row).eq(9).html("Kadın") : $('td', row).eq(9).html("Erkek");
            data.askerlikDurum === 1 ? $('td', row).eq(11).html("Muaf") : data.askerlikDurum === 2 ? $('td', row).eq(11).html("Tecilli") : $('td', row).eq(11).html("Yapıldı");
        },
    });
}

$(document).on('touchstart click', '#btnKullaniciKaydet', async function (e) {
    var data = new FormData($('#frmKullaniciKaydet')[0]);
    data = await DosyaYuklemeIslemi('#frmKullaniciKaydet', data);

    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/Kullanici/Kaydet",
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
                    window.location = '/Kullanici/ListeleView';
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

$(document).on('touchstart click', '#btnKullaniciGuncelle', async function (e) {
    var data = new FormData($('#frmKullaniciKaydet')[0]);

    if ($('#frmKullaniciKaydet').find('input[type=file]')[0].files.length > 0) {
        var dosyaBase64 = await FileToBase64($('#frmKullaniciKaydet').find('input[type=file]')[0].files[0]);
        var dosyaAdi = $('#frmKullaniciKaydet').find('input[type=file]')[0].files[0].name;
        var dosyaUzantisi = $('#frmKullaniciKaydet').find('input[type=file]')[0].files[0].type;

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
        success: async function (veri) {
            var sonuc = JSON.parse(veri);
            if (await ValidasyonKontrol(sonuc)) {
                swalInit.fire({
                    title: 'Güncelleme İşlemi Başarılı!',
                    icon: "success",
                }).then(function () {
                    window.location = '/Kullanici/ListeleView';

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

$(document).on('touchstart click', '.btnKullaniciDuzenle', function (e) {
    e.preventDefault();
    var data = kullaniciListeTablo.fnGetData($(this).parents('tr'));
    KullaniciDuzenlePenceresi(data.id)
});

$(document).on('touchstart click', '#btnKullaniciSil', function (e) {
    e.preventDefault();
    var id = $('#frmKullaniciKaydet #Id').val();
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: id
        },
        url: '/Kullanici/Sil',
        beforeSend: function () {
        },
        success: function (veri) {
            swalInit.fire({
                title: 'Silme İşlemi Başarılı!',
                icon: "success",
            }).then(function () {
                window.location = '/Kullanici/ListeleView';
            });
            LoadingPageHide();
        },
        error: function () {
        },
        complete: function () {
        }
    });
});

$(document).on('touchstart click', '#btnKullaniciDosyaYuke', function (e) {
    var str = "";
    str += "<div class='form-group'>";
    str += "  <div class='dropzone dropzone-queue mb-2' id='kt_modal_upload_dropzone'>";
    str += "      <div class='dropzone-panel mb-4'>";
    //str += "          <input type='file' class='file-input' multiple='multiple' data-fouc accept='jpeg' />";
    str += "          <a class='dropzone-select btn btn-sm btn-primary me-2 dz-clickable'>Dosya Seç</a>";
    str += "          <a class='dropzone-upload btn btn-sm btn-light-primary me-2'>Tümünü Yükle</a>";
    str += "          <a class='dropzone-remove-all btn btn-sm btn-light-primary'>Tümünü Sil</a>";
    str += "      </div>";
    str += "      <div class='dropzone-items wm-200px'>";
    str += "      </div>";
    str += "      <div class='dz-default dz-message'>";
    str += "          <button class='dz-button' type='button'>";
    str += "              Drop files here to";
    str += "              upload";
    str += "          </button>";
    str += "      </div>";
    str += "  </div>";
    str += "  <span class='form-text fs-6 text-muted'>Maksimum dosya boyutu, dosya başına 1 MB'dir.</span>";
    str += "</div>";
    ModalOpenClose($('#modalKullaniciDosyaYukle'), "", str);
    FileUpload.init();
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

function KullaniciDuzenlePenceresi(id) {
    $.ajax({
        cache: false,
        global: false,
        async: true,
        type: 'POST',
        datatype: "json",
        data: {
            Id: id
        },
        url: '/Kullanici/KullaniciPopUpDuzenleView',
        beforeSend: function () {
        },
        success: function (veri) {
            ModalOpenClose($('#modalKullaniciGuncelle'), "Kullanıcı Güncelle", veri);
            ValidasyonTetikleme.init();
            $('#cinsiyetSelect').val($('#Cinsiyet').html()).change();
            $('#medeniDurumSelect').val($('#MedeniDurum').html()).change();
            $('#askerlikDurumSelect').val($('#AskerlikDurum').html()).change();
            $('#parola').val($('#Parola').html()).change();
            MakeDropdownSelec2InModal($('#modalKullaniciGuncelle'));
            FileUpload.init();
        },
        error: function () {
        },
        complete: function () {
        }
    });
}


$(document).on('touchstart click', '#btnKullaniciYuklenmisDosya', function (e) {
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
    $('#kullaniciYuklenmisDosyalar .modal-body').empty().append(str);
    ModalOpenClose($('#kullaniciYuklenmisDosyalar'), "Kullanıcı Yüklenen Dosyalar", str);
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
                var kullaniciId = Number($('#frmKullaniciKaydet #Id').val());
                KullaniciDuzenlePenceresi(kullaniciId);
            });
            LoadingPageHide();
        },
        error: function () {
        },
        complete: function () {
        }
    });
});
$(document).on('touchstart click', '#btnGiris', async function (e) {
    var data = new FormData($('#frmGiris')[0]);
    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/Giris/KullaniciGiris",
        data: data,
        datatype: "json",
        type: "POST",
        contentType: false,
        processData: false,
        mimeType: "multipart/form-data",
        beforeSend: function () {
        },
        success: function (veri) {
            var sonuc = JSON.parse(veri);
            if (sonuc.sonuc !== 0) {
                window.location = '/AnaSayfa/Index';
            }
            else {
                swalInit.fire({
                    title: 'Girilen E-Posta veya Parola Hatalı!',
                    icon: "error",
                }).then();
            }
        },
        error: function () {
        },
        complete: function () {
        }
    });
});
$(document).on('touchstart click', '#btnModalClose', async function (e) {
    window.location.reload();
});
$(document).on('touchstart click', '#btnKullaniciTemizle', function (e) {
    $("#frmKullaniciKaydet")[0].reset();
    MakeDropdownSelec2InModal($('#frmKullaniciKaydet'));
});
function InnerPageContentLoaded() {
    DataTableKullanici();
    ValidasyonTetikleme.init();
    FileUpload.init();
}