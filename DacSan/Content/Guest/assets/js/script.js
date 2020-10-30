$(function() {

	console.log("%c SIEUKINHDOANH Thiết kế và phát triển website hàng đầu.","font-size:25px; background-color: #0165bb; color: #fff;font-family: tahoma;padding:5px 10px;");

	//Fixed menu scroll
	var nav = $('.navigation');
	var nav_p = nav.position();
	$(window).scroll(function () {
		if ($(this).scrollTop() > nav_p.top) {
			nav.addClass('fixed');
		} else {
			nav.removeClass('fixed');
		}
	});

	$.ajaxSetup({
        beforeSend: function(xhr, settings) {
            if (settings.data.indexOf('csrf_test_name') === -1) {
                settings.data += '&csrf_test_name=' + encodeURIComponent(getCookie('csrf_cookie_name'));
            }
        }
    });

    new WOW().init();


	MainContentW = 1160;

	LeftBannerW  = 90;
	
	RightBannerW = 90;
	
	LeftAdjust   = 5;
	
	RightAdjust  = 5;
	
	TopAdjust    = 50;

    ShowAdDiv();

    window.onresize=ShowAdDiv;
});



//hiển thị thông báo
function show_message(text, icon) {
    $.toast({
        heading: "Alert",
        text: text,
        position: 'top-left',
        icon: icon,
        hideAfter: 5000,
    });
}

//kiểm tra đối tượng có tồn tại không
function isset($element) {
    if (typeof $element != 'undefined')
        return true;
    return false;
}

//slider chạy dọc
function vertical(element, interval, item, direction = 'up') {
    $(element).easyTicker({
		direction: 'up',
		easing: 'swing',
		speed: 'slow',
		interval: interval,
		visible: item,
		mousePause: 1,
	});
}

//slider chạy ngang
function horizontal(element, interval, item, rep, button = '') {
	var ol = $(element).owlCarousel({
	    items				:item,
	    margin				:10,
	    loop				:true,
	   	autoplay			:true,
	    autoplayTimeout		:interval,
	    autoplayHoverPause	:true,
		smartSpeed			: 1000,
	    responsive			: rep
	});

	if(button != '') {
		$(button+' .next').click(function() {
	    	ol.trigger('next.owl.carousel', [1000]);
		})
		$(button+' .prev').click(function() {
		    ol.trigger('prev.owl.carousel', [1000]);
		});
	}
}


function setCookie(cname, cvalue, exdays) {
    var d = new Date();
    d.setTime(d.getTime() + (exdays*24*60*60*1000));
    var expires = "expires="+ d.toUTCString();
    document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(cname) {
    var name = cname + "=";
    var decodedCookie = decodeURIComponent(document.cookie);
    var ca = decodedCookie.split(';');
    for(var i = 0; i <ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') {
            c = c.substring(1);
        }
        if (c.indexOf(name) == 0) {
            return c.substring(name.length, c.length);
        }
    }
    return "";
}

function delCookie(name) {
    document.cookie = name + ';expires= Thu, 01-Jan-1970 00:00:01 GMT;';
};


function FloatTopDiv()
{
	startLX = (($(window).width() -MainContentW)/2)-LeftBannerW-LeftAdjust , startLY = TopAdjust+80;
	startRX = (($(window).width() -MainContentW)/2)+MainContentW+RightAdjust , startRY = TopAdjust+80;
	var d = document;
	function ml(id)
	{
		 var el=d.getElementById?d.getElementById(id):d.all?d.all[id]:d.layers[id];
		 el.sP=function(x,y){this.style.left=x + 'px';this.style.top=y + 'px';};
		 el.x = startRX;
		 el.y = startRY;
		 return el;
	}
	function m2(id)
	{
		 var e2=d.getElementById?d.getElementById(id):d.all?d.all[id]:d.layers[id];
		 e2.sP=function(x,y){this.style.left=x + 'px';this.style.top=y + 'px';};
		 e2.x = startLX;
		 e2.y = startLY;
		 return e2;
	}
	window.stayTopLeft=function()
	{
		 if (document.documentElement && document.documentElement.scrollTop)
			  var pY =  document.documentElement.scrollTop;
		 else if (document.body)
			  var pY =  document.body.scrollTop;
		 if (document.body.scrollTop > 30){startLY = 3;startRY = 3;} else {startLY = TopAdjust;startRY = TopAdjust;};
		 ftlObj.y += (pY+startRY-ftlObj.y)/16;
		 ftlObj.sP(ftlObj.x, ftlObj.y);
		 ftlObj2.y += (pY+startLY-ftlObj2.y)/16;
		 ftlObj2.sP(ftlObj2.x, ftlObj2.y);
		 setTimeout("stayTopLeft()", 1);
	}
	ftlObj = ml("divAdRight");
	ftlObj2 = m2("divAdLeft");
	stayTopLeft();
}
function ShowAdDiv()
{
	var objAdDivRight = document.getElementById("divAdRight");
	var objAdDivLeft = document.getElementById("divAdLeft");       
	if ($(window).width() < 1200)
	{
		 objAdDivRight.style.display = "none";
		 objAdDivLeft.style.display = "none";
	}
	else
	{
		 objAdDivRight.style.display = "block";
		 objAdDivLeft.style.display = "block";
		 FloatTopDiv();
	}
}