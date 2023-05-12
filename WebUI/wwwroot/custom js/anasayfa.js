function StorageKontrol() {
    var buGun = new Date().toISOString();
    var dogumGunleriListe = localStorage.getItem("dogumGunleriListesi");
    if (dogumGunleriListe === undefined || dogumGunleriListe === null
        /*|| (dogumGunleriListe !== null && new Date(JSON.parse(dogumGunleriListe).storageGuncellemeTarih) < buGun)*/) {
        $.ajax({
            cache: false,
            global: false,
            async: true,
            url: "/AnaSayfa/DogumGunleriGetir",
            datatype: "json",
            type: "GET",
            contentType: false,
            beforeSend: function () {
            },
            success: function (veri) {
                localStorage.setItem("dogumGunleriListesi", JSON.stringify(veri));
            },
            error: function () {
            },
            complete: function () {
            }
        });
    }
}
function SayfaYuklemeDogumGunuAtama() {
    var ilkDogumGunu = JSON.parse(localStorage.getItem("dogumGunleriListesi")).liste[0];
    $('#imgDogumGunuForLightTheme').attr('src', ilkDogumGunu.imgYol);
    $('#imgDogumGunuForDarkTheme').attr('src', ilkDogumGunu.imgYol);
    $('#spanDogumGunuAdSoyad').html(ilkDogumGunu.ad + " " + ilkDogumGunu.soyad);
    $('#spanDogumGunuAd').html(ilkDogumGunu.ad);
}
function SayfaYuklemeHaberleriStoreAtama() {
    localStorage.setItem("sliderHaberler", $('#sliderHaberlerListesi').html());
    $('#sliderHaberlerListesi').html("");
}
function SayfaYuklemeDuyurulariStoreAtama() {
    localStorage.setItem("duyurular", $('#duyuruListesi').html());
    $('#duyuruListesi').html("");
}

$(document).on('touchstart click', '#btnDogumGunuSonraki', function (e) {
    var dogumGunleriListe = JSON.parse(localStorage.getItem("dogumGunleriListesi")).liste;
    var aktifDogumGunuIndex = Number($(this).attr("data-dg-index"));
    var birSonrakiDogumGunuIndex = aktifDogumGunuIndex + 1 >= dogumGunleriListe.length ? 0 : aktifDogumGunuIndex + 1;

    $(this).attr("data-dg-index", birSonrakiDogumGunuIndex);
    $('#btnDogumGunuOnceki').attr("data-dg-index", birSonrakiDogumGunuIndex);
    var yeniDogumGunu = dogumGunleriListe[birSonrakiDogumGunuIndex];

    $('#imgDogumGunuForLightTheme').attr('src', yeniDogumGunu.imgYol);
    $('#imgDogumGunuForDarkTheme').attr('src', yeniDogumGunu.imgYol);
    $('#spanDogumGunuAdSoyad').html(yeniDogumGunu.ad + " " + yeniDogumGunu.soyad);
    $('#spanDogumGunuAd').html(yeniDogumGunu.ad);
});
$(document).on('touchstart click', '#btnDogumGunuOnceki', function (e) {
    var dogumGunleriListe = JSON.parse(localStorage.getItem("dogumGunleriListesi")).liste;
    var aktifDogumGunuIndex = Number($(this).attr("data-dg-index"));
    var birOncekiDogumGunuIndex = aktifDogumGunuIndex - 1 < 0 ? dogumGunleriListe.length - 1 : aktifDogumGunuIndex - 1;


    $(this).attr("data-dg-index", birOncekiDogumGunuIndex);
    $('#btnDogumGunuSonraki').attr("data-dg-index", birOncekiDogumGunuIndex);
    var yeniDogumGunu = dogumGunleriListe[birOncekiDogumGunuIndex];

    $('#imgDogumGunuForLightTheme').attr('src', yeniDogumGunu.imgYol);
    $('#imgDogumGunuForDarkTheme').attr('src', yeniDogumGunu.imgYol);
    $('#spanDogumGunuAdSoyad').html(yeniDogumGunu.ad + " " + yeniDogumGunu.soyad);
    $('#spanDogumGunuAd').html(yeniDogumGunu.ad);
});
$(document).on('touchstart click', '#btnDuyuruDetay', function (e) {    
    var duyuruId = $(this).attr("data-d-id");
    var duyuruListesi = JSON.parse(localStorage.getItem("duyurular"));
    var duyuru = duyuruListesi.find(e => e.Id == duyuruId);
    var str = "";
    str += "<div id='kt_app_content' class='app-content  flex-column-fluid '>";
    str += "    <div id='kt_app_content_container' class='app-container  container-fluid '>";
    str += "        <div class='card mb-5 mb-xl-10'>";
    str += "            <div class='card-header border-0 cursor-pointer' role='button' data-bs-toggle='collapse'";
    str += "                 data-bs-target='#kt_account_profile_details' aria-expanded='true'";
    str += "                 aria-controls='kt_account_profile_details'>";
    str += "                <div class='card-title m-0'>";
    str += "                    <h3 class='fw-bold m-0'>" + duyuru.Basligi + "</h3>";
    str += "                </div>";
    str += "            </div>";
    str += "            <div id='' class='collapse show'>";
    str += "                <div class='card-body border-top p-9'>";
    str += "                    <div class='row mb-6'>";
    str += "                        <label class='col-lg-12 col-form-label fw-semibold fs-6'> Yayın Tarihi : " + moment(duyuru.YayinTarih).format('DD.MM.YYYY HH:mm:ss') + "</label>";   
    str += "                    </div>";
    str += "                    <div class='row mb-6'>";
    str += "                        <label class='col-lg-12 col-form-label fw-semibold fs-6'>" + duyuru.Metin + "</label>";   
    str += "                    </div>";
    str += "                </div>";
    str += "            </div>";
    str += "        </div>";
    str += "    </div>";
    str += "</div>";
    ModalOpenClose($('#modalDuyuruDetay'), "Duyuru Detayı", str);
});
$(document).on('touchstart click', '#btnTumDuyurular', function (e) {    
    $.ajax({
        cache: false,
        global: false,
        async: true,
        url: "/AnaSayfa/DuyurulariGetir",        
        datatype: "json",
        type: "GET",
        contentType: false,
        processData: false,
        mimeType: "multipart/form-data",
        beforeSend: function () {
        },
        success: function (veri) {            
            ModalOpenClose($('#modalTumDuyurular'), "Tüm Duyurular", veri);
            localStorage.setItem("duyurular", $('#modalTumDuyurular #duyuruListesi').html());
            $('#modalTumDuyurular #duyuruListesi').html("");
        },
        error: function () {            
        },
        complete: function () {
        }
    });    
});
$(document).on('touchstart click', '#btnTumDogumGunleri', function (e) {    
    var dogumGunleriListe = JSON.parse(localStorage.getItem("dogumGunleriListesi")).liste;
    var str = "";
    if (dogumGunleriListe.length > 0) {
        str += "<div class='card card-xl-stretch mb-xl-8'>"
        str += "<div class='card-body pt-2'>";
        $.each(dogumGunleriListe, function (index, item) {            
            str += "<div class='d-flex align-items-center";

            if (index !== dogumGunleriListe.length - 1)
                str += " mb-7";
            
            if (index === 0) 
                str += " mt-5"
            
            str += "'>";
            str += "  <div class='symbol symbol-50px me-5'>";
            str += "    <img src='" + item.imgYol +"' class='' alt=''>";
            str += "  </div>";
            str += "  <div class='flex-grow-1'>";
            str += "    <a class='text-dark fw-bold text-hover-primary fs-6'>" + item.ad+" " + item.soyad + "</a>";
            str += "    <span class='text-muted d-block fw-bold'>Doğum Günü</span>";
            str += "  </div>";
            str += "</div>  ";
        });
        str += "</div>";
        str += "</div>";
        ModalOpenClose($('#modalTumDogumGunleri'), "Tüm Doğum Günleri", str);
    }
});


$(document).ready(function () {
    SayfaYuklemeHaberleriStoreAtama();
    SayfaYuklemeDuyurulariStoreAtama();
});

function InnerPageContentLoaded() {
    StorageKontrol();
    SayfaYuklemeDogumGunuAtama();
}