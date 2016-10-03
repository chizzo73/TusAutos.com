//Functiones On
Navigation_center();
Nav_auto_information();
res_promoters();
PopGoogleMap();

// :::: Funciones :::: 

// On PopGoogleMap
function PopGoogleMap() {
        
    $('.btn_map_pr').on('click', function () {
                
        $('#PopUp').fadeIn("slow");

        // Gmap3
        $('#mapa_pop')
             .gmap3({
                 center: [48.8620722, 2.352047],
                 zoom: 15
             })
             .marker([
               { position: [48.8620722, 2.352047] },
               { address: "86000 Poitiers, France" },
               { address: "66000 Perpignan, France", icon: "http://maps.google.com/mapfiles/marker_grey.png" }
             ])
             .on('click', function (marker) {
                 marker.setIcon('http://maps.google.com/mapfiles/marker_green.png');
             });

        $('#close_pop').on('click', function () {
                    
            $('#PopUp').fadeOut("slow");
        });
    });
}
// On GoogleMaps
function GoogleMaps() {

    $('#mapa_cons')
     .gmap3({
         center: [48.8620722, 2.352047],
         zoom: 15
     })
     .marker([
       { position: [48.8620722, 2.352047] },
       { address: "86000 Poitiers, France" },
       { address: "66000 Perpignan, France", icon: "http://maps.google.com/mapfiles/marker_grey.png" }
     ])
     .on('click', function (marker) {
         marker.setIcon('http://maps.google.com/mapfiles/marker_green.png');
     });

}

// Nav Navigation Center
function Navigation_center() {

       var width = $('#navegacion').width();
       $('#navegacion').css('width', width+30);
       $('#navegacion').css('margin', '0 auto');
       $('#navegacion').css('float', 'none');

}

// Nav Search 

function res_promoters() {

    var width = $(window).width();
    if (width < 500) {

        $('.li_promoter').attr('class', 'col-md-6');
        
    }
}

// View Auto Nav Information
function Nav_auto_information() {
        
    $('.btn_info_auto').on('click', function () {

        var IE = $(this).attr('id');

        if (IE == 'IE_contact_auto') {

            $('#ct_auto').fadeIn("slow");
            $('#tx_info_auto').hide();

            //Include Function
            GoogleMaps();

        } else if (IE == 'IE_info_auto') {

            $('#tx_info_auto').fadeIn("slow");
            $('#ct_auto').hide();
        }
    });
}
