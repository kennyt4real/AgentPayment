
$(function() {

  //open & close mobile nav
  $('.mobile_nav').click(function(e) {
    e.preventDefault();
    $('.navbar').addClass('open');
  });

  $('.close_close_btn').click(function(e) { 
    e.preventDefault();
    $('.navbar').removeClass('open');
  });



  // Expand and collapse builder nav

  $('.collapse_nav').click(function() {
    var $this = $('.main_body');

    // body...
    if ($this.hasClass('folded_nav')) {
      $this.removeClass('folded_nav');
      $(this).removeClass('ion-android-arrow-forward').addClass('ion-android-arrow-back');
    } else {
      $this.addClass('folded_nav');
      $(this).addClass('ion-android-arrow-forward').removeClass('ion-android-arrow-back');
    }

    return false;

  });


  // open modals
  $('.modal_click').click(function() {
  	var $this = $(this).attr('href');

  	$($this).modal({
      overlayClose: true,
      closeClass: "ion-android-close"
    });

  	return false;
  });


  // open form builder modal
  $('.builder_click').click(function() {
    var $this = $(this).data('element');

    var _wh = ($(window).height()) - 60
    var _hh = ($(window).width()) - 60

    $($this).modal({
      overlayClose: true,
      closeClass: "ion-android-close",
      maxHeight: _wh,
      maxWidth: _hh,
      minHeight: _wh,
      minWidth: _hh,
      containerCss: {
        "background": "#fff",
        "border-radius": "3px"
      }
      
    });

    return false;
  });


  // select forms
  $('.form_inner').click(function(e) {
  	// body...
  	e.preventDefault();

  	$('.form_inner').removeClass('active');
  	$(this).addClass('active');
  })


  //switch grid & list
  $('.grid_list_control a').click(function() {

    $('.grid_list_control a').removeClass('active');
    $(this).addClass('active');

    var $this = $('.all_forms_forms ul');

    if ($(this).hasClass('grid_view')) {
      $this.removeClass("list_style");
    } else {
      $this.addClass("list_style");
    }

    return false;
  });



});

