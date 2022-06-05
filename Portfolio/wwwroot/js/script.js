// JavaScript Document

 // Smooth Anchor Scrolling
  $('a').click(function(){
    $('html, body').animate({
        scrollTop: $($(this).attr('href')).offset().top
    }, 300);
    return false;
  });  
  
$(window).scroll(function(){
    if ($(this).scrollTop() > 50) {
       $('.kk').addClass('kk2 shadow-sm');
    } else {
       $('.kk').removeClass('kk2 shadow-sm');
    }
});
$('.navbar-collapse a').click(function(){
            $(".navbar-collapse").collapse('hide');
        });
// init Isotope
var $grid = $('.grid').isotope({
  itemSelector: '.element-item',
  layoutMode: 'fitRows'
});
 AOS.init({
	  offset: 320,
	  easing: 'ease-in-out',
	  duration: 800,
	  delay:10,
	  once: true
	  });
	  $('.owl-carousel').owlCarousel({
    loop:true,
    margin:20,
    nav:false,
    dots:true,
    responsive:{
        0:{
            items:1
        },
        600:{
            items:1
        },
        1000:{
            items:1
        }
    }
})
// filter functions
var filterFns = {
  // show if number is greater than 50
  numberGreaterThan50: function() {
    var number = $(this).find('.number').text();
    return parseInt( number, 10 ) > 50;
  },
  // show if name ends with -ium
  ium: function() {
    var name = $(this).find('.name').text();
    return name.match( /ium$/ );
  }
};
// bind filter button click
$('.filters-button-group').on( 'click', 'button', function() {
  var filterValue = $( this ).attr('data-filter');
  // use filterFn if matches value
  filterValue = filterFns[ filterValue ] || filterValue;
  $grid.isotope({ filter: filterValue });
});
// change is-checked class on buttons
$('.button-group').each( function( i, buttonGroup ) {
  var $buttonGroup = $( buttonGroup );
  $buttonGroup.on( 'click', 'button', function() {
    $buttonGroup.find('.is-checked').removeClass('is-checked');
    $( this ).addClass('is-checked');
  });
});