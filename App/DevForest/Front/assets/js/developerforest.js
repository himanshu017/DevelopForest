
$(document).ready(function(){
	$('.header__list--with-dropdown').click(function(){
		$(this).toggleClass('active');
		$(this).find('.header__dropdown').toggleClass('active');
	});
	$(".register-tab__item").click(function(){
		var trgt = $(this).attr('trgt');
		$('.register-tab__item').removeClass('active');
		$(this).addClass('active');
		$('.register-tab-con').hide();
		$(trgt).show();

	});						   
});

var scrolTopflg1  =  1;
$(window).scroll(function() {  
	if($(window).width() > 767){				  
 	var scrollAmnt1 = $(window).scrollTop();
		if (scrollAmnt1 > 20) {
			if(scrolTopflg1 == 1)
			{
				$("header").addClass("addbg");
				scrolTopflg1 = 0;
			}
		}
		else{
		  $("header").removeClass("addbg");
		   scrolTopflg1 = 1;
		}  
	  }
}); 