$(document).ready(function () {
	/* body... */
	/*$("#sanpham").ownCarousel();*/
/*	slide sanpham*/

	var trangthai="dong";
	var menu=$('nav ul');
	// menu responsive dien thoai hien ra
	$('.handle').on('click',function (e) {
		/* body... */
		e.preventDefault();
		if(trangthai=="dong"){
			menu.slideDown('slow');
			trangthai="mo";
		}
		else if(trangthai=="mo") {
			menu.slideUp('slow');
			trangthai="dong";
		}
	});

//resize window menu desktop lai hien ra
$(window).resize(function(){
	var w = $(window).width();
	if(w > 320 && menu.is(':hidden')) {
		menu.removeAttr('style');
	}
});

$(window).scroll(function(event){
    var pageOffset = $('html,body').scrollTop();
	if(pageOffset>20){
		$('.header').addClass('co-dinh-menu');
	}
	else {
		$('.header').removeClass('co-dinh-menu');
	}
	if(pageOffset>=900){
		$('.back-to-top').addClass('hien-ra');
		$('.dichvu').addClass('chubay');
		$('.dichvu p').addClass('chubay');
	}
	else
	{
		$('.back-to-top').removeClass('hien-ra');
	}
	if(pageOffset>=1400){
		$('.lamdep p').addClass('sangphai');
		$('.lamdep img').addClass('sangtrai');
		$('.lamdep').addClass('xuathien');
	}

    })

$('.back-to-top').click(function(event) {
	$('html,body').animate({scrollTop: 0},1000);
    });

    //$('.itemsmall').hover(function () {
    //    $(this).addClass('appear');
     
    //}, function () {
    //    $(this).removeClass('appear');
    //})
})