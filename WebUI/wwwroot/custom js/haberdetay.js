$(document).ready(function () {    
    var haberDetayId = Number($('#haberDetayId').html());
    var sliderHaberleri = JSON.parse(localStorage.getItem("sliderHaberler")).filter(e => e.Id !== haberDetayId);
    sliderHaberleri = sliderHaberleri.sort((a, b) => b.Id - a.Id).slice(0, 5);
    var str = "";
    for (var i = 0; i < sliderHaberleri.length; i++) {
        str += "<div class='d-flex flex-stack mb-7'>";
        str += "<div class='symbol symbol-60px symbol-2by3 me-4'>";
        str += "<div class='symbol-label' style='background-image: url(/uploaded_files/"+ sliderHaberleri[i].AnaResim +")'>"
        str += "</div>";
        str += "</div>";
        str += "<div class='m-0'>";
        str += "<a href='/AnaSayfa/HaberDetay/" + sliderHaberleri[i].Id +"' class='text-dark fw-bold text-hover-primary fs-6'>" + sliderHaberleri[i].Basligi.substring(0, 25) + "... </a>";
        str += "<span class='text-gray-600 fw-semibold d-block pt-1 fs-7'>" + sliderHaberleri[i].Metin.substring(0, 100) + "... </span>";
        str += "</div>";
        str += "</div>";
    }
    $('#digerHaberler').empty().append(str);
});


function InnerPageContentLoaded() {    
}