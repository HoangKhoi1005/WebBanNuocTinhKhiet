//window.addEventListener('DOMContentLoaded', (event) => {
let videos = document.querySelectorAll('.open_video');
let popupVideo = document.querySelector('.popup_video');
let close_vd = document.querySelectorAll('.close_video');
videos.forEach(v => v.addEventListener('click', function(e){
	e.preventDefault();
	popupVideo.classList.add('open');
	popupVideo.querySelector('.b_video').innerHTML  = `<div class="embed-responsive embed-responsive-16by9"><iframe class="embed-responsive-item" src="https://www.youtube.com/embed/${e.target.dataset.video}?enablejsapi=1" allow="autoplay; encrypted-media" allowfullscreen></iframe></div>`
}));
close_vd.forEach(v => v.addEventListener('click', function(e){
	e.preventDefault();
	popupVideo.classList.remove('open');
	setTimeout(function(){
		popupVideo.querySelector('.b_video').innerHTML  = ``
	}, 500);
}));
var swiperHomeSlider = new Swiper('.mew_slide', {
	spaceBetween: 10,
	navigation: {
		nextEl: '.msl_next',
		prevEl: '.msl_prev',
	},
	//effect: 'fade',
	loop: false,
	speed:600,
	slidesPerView: 1,
	autoplay: {
		delay: 6000,
		disableOnInteraction: true,
	}
});
var swiperHomeSlider = new Swiper('.m_people', {
	spaceBetween: 15,
	loop: false,
	speed:1500,
	slidesPerView: 1,
	pagination: {
		el: '.mrv_pagi',
		clickable: true,
	},
	breakpoints: {
		320: {
			slidesPerView: 1
		},
		768: {
			slidesPerView: 2,
			spaceBetween: 20,
		},
		992: {
			slidesPerView: 2,
			spaceBetween: 30,
		},
		1200: {
			slidesPerView: 2,
			spaceBetween: 40,
		}
	}
});
var swiperProductSaleSlider = new Swiper('.mew_product_5', {
	spaceBetween: 18,
	loop: false,
	speed: 1000,
	autoplay: false,
	slidesPerColumnFill: 'row',
	slidesPerColumn: 2,
	navigation: {
		nextEl: '.mf_next',
		prevEl: '.mf_prev',
	},
	breakpoints: {
		320: {
			slidesPerView: 2
		},
		768: {
			slidesPerView: 3
		},
		992: {
			slidesPerView: 3
		},
		1200: {
			slidesPerView: 4
		}
	}
});
var swiperBrand = new Swiper('.brand_sl', {
	spaceBetween: 15,
	loop: false,
	speed: 1000,
	autoplay: true,
	slidesPerView: 2,
	breakpoints: {
		480: {
			slidesPerView: 3
		},
		576: {
			slidesPerView: 3
		},
		768: {
			slidesPerView: 4
		},
		992: {
			slidesPerView: 5,
			spaceBetween: 20
		},
		1200: {
			slidesPerView: 6,
			spaceBetween: 30
		}
	}
});

var swiperBlogSlider = new Swiper('.mew_blog', {
	spaceBetween: 20,
	loop: false,
	speed: 1000,
	autoplay: false,
	navigation: {
		nextEl: '.ml_next',
		prevEl: '.ml_prev',
	},
	breakpoints: {
		375: {
			slidesPerView: 1.2
		},
		768: {
			slidesPerView: 2.3
		},
		992: {
			slidesPerView: 3
		},
		1200: {
			slidesPerView: 3
		}
	}
});
//});