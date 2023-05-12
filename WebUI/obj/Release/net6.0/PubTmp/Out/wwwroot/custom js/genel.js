const RequestType = Object.freeze({ "POST": 'POST', "GET": 'GET' });

var swalInit = swal.mixin({
    buttonsStyling: false,
    customClass: {
        confirmButton: 'btn btn-primary',
        cancelButton: 'btn btn-light'
    },
    buttonsStyling: false,
    allowOutsideClick: false,
    allowEscapeKey: false,
    allowEnterKey: false,
    confirmButtonText: 'Tamam',
});


async function DosyaUploadKontrol(formName) {    
    $files = $(formName).find('input[type=file]');
    var strUyari = "";
    $files.each(function (e) {
        var DosyaZorunluMu = $(this).attr('val');
        var DosyaYuklenmismi = $(this).closest('.mb-5.col-md-6').find('.mt-5').length;
        if (DosyaZorunluMu === 'true' && DosyaYuklenmismi === 0 && $(this)[0].files.length === 0) {
            strUyari += `<li class='text-danger' style='list-style-type: none;'>${$(this)[0].title} Dosyası Zorunludur.</li>`;
        }
    });

    if (strUyari != "") {
        swalInit.fire({
            title: "Zorunlu Bilgiler",
            html: strUyari,
            icon: "error",
        });
        return false;
    }
    return true;
};
async function ValidasyonKontrol(data) {    
    if (data.errorCode !== undefined && data.errorCode === 1001) {
        var str = "<ul>";
        $.each(data.result, function (index, item) {
            str += "<li class='text-danger' style='list-style-type: none;'>" + item + "</li>";
        });
        str += "</ul>";
        swalInit.fire({
            title: "Zorunlu Alanlar",
            html: str.replaceAll('<li>', '').replaceAll('</li>', '<br/>'),
            icon: "error",
        }).then(function () {
            LoadingPageHide();
        });
        return false;
    }
    return true;
}

async function SendAjaxRequest(url, type, data = null) {
    var sonuc = null;
    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: url,
        data: data,
        datatype: "json",
        type: type,
        contentType: false,
        processData: false,
        mimeType: "multipart/form-data",
        beforeSend: function () {
        },
        success: function (veri) {
            sonuc = veri;
        },
        error: function () {            
        },
        complete: function () {
        }
    });
    return sonuc;
}
var ModalOpenClose = function ($openingElement, header, data) {
    $openingElement.find('.modal-backdrop.show').remove();
    $openingElement.prepend('<div class="modal-backdrop show"></div>');
    $openingElement.modal({
        focus: false,
        backdrop: 'static',
        keyboard: false,
    });
    $openingElement.find('.model-header-text').empty().append(header);
    $openingElement.find('.modal-body').empty().append(data);
    $openingElement.modal("show");
}
var ValidasyonTetikleme = function () {
    var genelTarihValidasyon = function () {
        if ($('.genelTARIH').length > 0) {

            $('.genelTARIH').each(function () {

                var pAutoUpdateInput = false;
                if ($(this).val() != "" && $(this).val() != undefined) {
                    pAutoUpdateInput = true;
                }

                $(this).daterangepicker({
                    drops: 'auto',
                    autoUpdateInput: pAutoUpdateInput,
                    singleDatePicker: true,
                    showDropdowns: true,
                    autoApply: true,/*Seçilir seçilmez uygulaması için*/

                    locale: {
                        format: "DD.MM.YYYY",
                        separator: " - ",
                        applyLabel: "Seç",
                        cancelLabel: "Vazgeç",
                        fromLabel: "From",
                        toLabel: "To",
                        customRangeLabel: "Custom",
                        weekLabel: "W",
                        daysOfWeek: [
                            "Pz",
                            "Pzt",
                            "Sa",
                            "Çrş",
                            "Prş",
                            "Cu",
                            "Cts"
                        ],
                        monthNames: [
                            "Ocak",
                            "Şubat",
                            "Mart",
                            "Nisan",
                            "Mayıs",
                            "Haziran",
                            "Temmuz",
                            "Ağustos",
                            "Eylül",
                            "Ekim",
                            "Kasım",
                            "Aralık"
                        ],
                        firstDay: 1
                    },

                });
            });



            $.validator.methods.date = function (value, element) {
                var validDate = /^(\d{1,2}).(\d{1,2}).(\d{4})$/i.test(value);

                if ($(element).hasClass('genelTARIH'))
                    return this.optional(element) || (validDate);
                else
                    return this.optional(element) || (validDate && value.length == 10);
            }



            $('.genelTARIH').on('apply.daterangepicker', function (ev, picker) {
                $(this).val(picker.startDate.format('DD.MM.YYYY'));
            });
            $('.genelTARIH').on('hide.daterangepicker', function (ev, picker) {
                if ($(this).val() != "") {
                    $(this).val(picker.startDate.format('DD.MM.YYYY'));
                }
            });

            $('.genelTARIH').on('click', function (ev, picker) {
                $('.daterangepicker.show-calendar').css('z-index', ($(this).closest('.modal-dialog').css('z-index')) + 5);
            });

            //$('.genelTARIH').on('click', function () {
            //    $('.daterangepicker.show-calendar').each(function () {
            //        if ($(this).is(':visible')) {
            //            $(this).css('z-index', (parseInt($(this).closest('.modal-dialog').css('z-index')) + 5));
            //        }
            //    });

            //});

            Inputmask({
                "mask": "99.99.9999"
            }).mask(".genelTARIH");
        }
    };
    var select2Genel = function () {
        if ($('.ddlselect2Genel').length > 0) {
            $('.ddlselect2Genel').select2({
                ignore: '',
                placeholder: "Seçiniz",
                allowClear: true,
                language: 'tr',
            });
        }
    };
    var TextAreaAutoGrow = function () {
        if ($('.genelAUTOGROW').length > 0) {
            autosize($('.genelAUTOGROW'));
        }

    }
    function validasyonKayitTetikle() {
        genelTarihValidasyon();
        select2Genel();
        TextAreaAutoGrow();
    }

    return {
        init: function () {
            validasyonKayitTetikle();
        }
    }
}();
var MakeDropdownSelec2InModal = function ($Modal) {
    $Modal.find('.ddlselect2Genel').select2({
        dropdownParent: $Modal,
        placeholder: "Seçiniz",
        allowClear: true,
        /*width: 'resolve',*/
        language: 'tr',
    });

}
var MakeDataTable = function (url) {    
    $.extend($.fn.dataTable.defaults, {
        deferRender: true,
        searching: false,
        processing: true,
        serverSide: true,
        sScrollX: "100%",
        sScrollXInner: "100%",
        //bDestroy: true,
        /*dom: '<"datatable-header length-left"l <"datatable_buttons"f> >rt<"datatable-footer"ip>',*/
        language: {
            sDecimal: ",",
            thousands: ".",
            sInfoThousands: ",",
            sEmptyTable: "Tabloda herhangi bir veri mevcut değil",
            sInfo: "_TOTAL_ kayıttan _START_ - _END_ arasındaki kayıtlar gösteriliyor",
            sInfoEmpty: "Kayıt yok",
            sInfoFiltered: "(_MAX_ kayıt içerisinden bulunan)",
            sInfoPostFix: "",
            sLengthMenu: "Sayfada _MENU_ kayıt göster",
            sLoadingRecords: "Yükleniyor...",
            sProcessing: "İşleniyor...",
            sSearch: "Ara:",
            sZeroRecords: "Eşleşen kayıt bulunamadı",
            oPaginate: {
                sFirst: "İlk",
                sLast: "Son",
                sNext: "Sonraki",
                sPrevious: "Önceki"
            },
            oAria: {
                sSortAscending: ": artan sütun sıralamasını aktifleştir",
                sSortDescending: ": azalan sütun soralamasını aktifleştir"
            },
            buttons: {
                pageLength: {
                    _: "%d kayıt"
                }
            }
        },
        lengthMenu: [[10, 20, 40], [10, 20, 40]],
        order: [[0, "desc"]],

    });
}();

async function DosyaYuklemeIslemi(formName, formData) {    
    if ($(formName).find('input[type=file]').length === 0 || $(formName).find('input[type=file]')[0].files.length === 0)
        return formData;

    if ($(formName).find('input[type=file]')[0].files.length === 1) {
        var dosyaBase64 = await FileToBase64($(formName).find('input[type=file]')[0].files[0]);
        var dosyaAdi = $(formName).find('input[type=file]')[0].files[0].name;
        var dosyaUzantisi = $(formName).find('input[type=file]')[0].files[0].type;

        formData.append("dosyaYukle.dosya", dosyaBase64);
        formData.append("dosyaYukle.dosyaAdi", dosyaAdi);
        formData.append("dosyaYukle.dosyaUzantisi", dosyaUzantisi);
        return formData;
    } else if ($(formName).find('input[type=file]')[0].files.length > 1) {        
        for (var i = 0; i < $(formName).find('input[type=file]')[0].files.length; i++) {
            var dosya = $(formName).find('input[type=file]')[0].files[i];
            var dosyaBase64 = await FileToBase64(dosya);
            var dosyaAdi = dosya.name;
            var dosyaUzantisi = dosya.type;
            formData.append("dosyaYukle[" + i + "].dosya", dosyaBase64);
            formData.append("dosyaYukle[" + i + "].dosyaAdi", dosyaAdi);
            formData.append("dosyaYukle[" + i + "].dosyaUzantisi", dosyaUzantisi);
        }        
        return formData;
    }
}

var FileToBase64 = async file => {
    var reader = new FileReader();
    reader.readAsDataURL(file);
    return new Promise(resolve => {
        reader.onloadend = () => {
            var res = reader.result;
            resolve(res.substr(res.indexOf(",") + 1, res.length));
        };
    });
};

var GetFileName = filename => {
    var nameLength = filename.lastIndexOf(".") > 0 ? filename.lastIndexOf(".") : filename.length;
    var res = filename.substr(0, nameLength);
    res = res.length > 50 ? res.substr(0, 49) : res;
    return res;
};

var LoadingPageShow = function () {
    $.blockUI({
        message: '<div class="blockui-message"><span class="spinner-border text-primary"></span> İşleminiz yapılıyor...</div>',
        /* timeout: 1000, */
        overlayCSS: {
            backgroundColor: '#ffffff',
            opacity: 0.8,
            cursor: 'wait'
        },
        css: {
            zIndex: 1052,
            position: 'fixed',
            padding: '15px',
            margin: '0px',
            width: 'auto',
            top: '45%',
            left: '45%',
            textAlign: 'center',
            color: '#ffffff',
            border: 0,
            backgroundColor: '#ffffff',
            cursor: 'wait',
            borderRadius: '3px'
        }
    });
}
var LoadingPageHide = function () {
    $.unblockUI();
}


KTUtil.onDOMContentLoaded(function () {
    if (InnerPageContentLoaded !== undefined) {
        InnerPageContentLoaded();
    }
});