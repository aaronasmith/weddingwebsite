
// jQuery for page scrolling feature - requires jQuery Easing plugin
$(function() {
    $('body').on('click', '.page-scroll a', function(event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top
        }, 1500, 'easeInOutExpo');
        event.preventDefault();
    });
});

// Floating label headings for the contact form
$(function() {
    $("body").on("input propertychange", ".floating-label-form-group", function(e) {
        $(this).toggleClass("floating-label-form-group-with-value", !! $(e.target).val());
    }).on("focus", ".floating-label-form-group", function() {
        $(this).addClass("floating-label-form-group-with-focus");
    }).on("blur", ".floating-label-form-group", function() {
        $(this).removeClass("floating-label-form-group-with-focus");
    });
});

$(function () {
    var sections = $('section:odd');
    //sections.css("background-color", "#e7e7e7");
    sections.css("background-image", "url(/Content/binding_light.png)");
    sections.css("border-bottom", "solid 1px #6C6C5F");
    sections.css("border-top", "solid 1px #6C6C5F");
});

// Highlight the top nav as scrolling occurs
$('body').scrollspy({
    target: '.navbar-fixed-top'
})

// Closes the Responsive Menu on Menu Item Click
$('.navbar-collapse ul li a').click(function() {
    $('.navbar-toggle:visible').click();
});

var date = new Date(Date.UTC(2015, 9, 23, 22, 30));
var now = new Date();
var diff = (date.getTime() - now.getTime()) / 1000;

var clock = $('.countdownClock').FlipClock(diff, {
    clockFace: 'DailyCounter',
    countdown: true,
    showSeconds: false
});


$(function () {
    var mapCanvas = document.getElementById('map-canvas');
    var mapOptions = {
        center: new google.maps.LatLng(36.080976, -86.774807),
        zoom: 11,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    }
    var map = new google.maps.Map(mapCanvas, mapOptions);
    
    var infoWindow = new google.maps.InfoWindow();

    var airport = new google.maps.Marker({
        position: new google.maps.LatLng(36.126814, -86.671112),
        map: map,
        title: 'Airport'
    });

    google.maps.event.addListener(airport, 'click', function () {
        infoWindow.setContent("Airport")
        infoWindow.open(map, airport);
    });

    var flyingSaucer = new google.maps.Marker({
        position: new google.maps.LatLng(36.156727, -86.783956),
        map: map,
        title: 'The Flying Saucer'
    });

    google.maps.event.addListener(flyingSaucer, 'click', function () {
        infoWindow.setContent("The Flying Saucer")
        infoWindow.open(map, flyingSaucer);
    });

    var belleMeade = new google.maps.Marker({
        position: new google.maps.LatLng(36.1060241, -86.8655007),
        map: map,
        title: 'Belle Meade Plantation'
    });

    google.maps.event.addListener(belleMeade, 'click', function () {
        infoWindow.setContent("Belle Meade Plantation")
        infoWindow.open(map, belleMeade);
    });
});