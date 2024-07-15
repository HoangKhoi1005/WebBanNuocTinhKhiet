const io=new IntersectionObserver((e,t)=>{e.forEach(e=>{e.isIntersecting&&(e.target.src=e.target.dataset.src,e.target.classList.add("loaded"),t.unobserve(e.target))})}),bo=new IntersectionObserver((e,t)=>{e.forEach(e=>{if(e.isIntersecting){const r=e.target;r.style.backgroundImage=r.dataset.background,e.target.classList.add("loaded"),t.unobserve(e.target)}})});

document.addEventListener("DOMContentLoaded", function() {
	const arr = document.querySelectorAll('.lazy')
	arr.forEach((v) => {
		io.observe(v);
	})
	const arrBg = document.querySelectorAll('.lazy_bg')
	arrBg.forEach((v) => {
		bo.observe(v);
	})
})

const formSearch = document.getElementById('js-search-form');
const m_login = document.getElementById('m_login');
const colLeft = document.getElementById('col-left-mew');
const bodyOverlay = document.getElementById('body_overlay');
const menu = document.getElementById('menu_pc');
const contactButton = document.getElementById('js-contact-toggle');
const m_mb_bar = document.getElementById('mb_bar');
const bodyM = document.getElementById('body_m');
let isMobile = window.matchMedia("(min-width: 992px)").matches;
let vW = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;

/*Quick Search*/
$(".open_search").on('click', function(){
	$('.search-block').toggleClass('open');
	bodyOverlay.classList.remove("d-none");
});
if (formSearch){
	formSearch.addEventListener('focusin', (event) => {
		//event.target.parentNode.classList.add('active');
		$('.sidebar_mobi').removeClass('openf');
	});
	formSearch.addEventListener('focusout', (event) => {
		window.setTimeout(function() { 
			//event.target.parentNode.classList.remove('active');
			document.querySelectorAll('.searchResult').forEach(el => el.classList.add('d-none'));
		}, 200);
	});
}
/*Menu mobi*/
$(".open_menu").on('click', function(){
	$('.navigation-block').toggleClass('open');
	bodyOverlay.classList.remove("d-none");
});
$(".close_menu").on('click', function(){
	$('.navigation-block').removeClass('open');
	bodyOverlay.classList.add("d-none");
});
if( menu ){
	menu.addEventListener('click', event => {
		if (event.target.className.includes('js-submenu')) {
			event.target.parentNode.classList.toggle('open');
			event.target.parentNode.classList.toggle('cls')
		}
	})
}
/*Body Overlay*/
bodyOverlay.addEventListener('click', function(e){
	bodyOverlay.classList.add("d-none");
	formSearch.classList.remove("open");
	document.querySelector('body').classList.remove('modal-open');
	m_mb_bar.classList.remove("active");
	$('.mobile_open_box_swatch').removeClass('active');
	$('.sidebar_mobi').removeClass('openf');
	$('.search-block').removeClass('open');
	$('.navigation-block').removeClass('open');
	$('.open-filters').removeClass('active');
	//animationMenu();
})

window.addEventListener('resize', throttle( function(){
	let vW = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
	if(vW > 991){
		bodyOverlay.classList.add("d-none");
	}
}, 200));

/*Back to Top*/
var goTopBtn = document.querySelector('.back_top');
function trackScroll() {
	var scrolled = window.pageYOffset;
	var coords = document.documentElement.clientHeight/3;
	if (scrolled > coords) {
		goTopBtn.classList.add('back_show');
	}
	if (scrolled < coords) {
		goTopBtn.classList.remove('back_show');
	}
}

window.addEventListener('scroll', trackScroll);
function scrollToTop (duration) {
	if (document.scrollingElement.scrollTop === 0) return;

	const cosParameter = document.scrollingElement.scrollTop / 2;
	let scrollCount = 0, oldTimestamp = null;

	function step (newTimestamp) {
		if (oldTimestamp !== null) {
			scrollCount += Math.PI * (newTimestamp - oldTimestamp) / duration;
			if (scrollCount >= Math.PI) return document.scrollingElement.scrollTop = 0;
			document.scrollingElement.scrollTop = cosParameter + cosParameter * Math.cos(scrollCount);
		}
		oldTimestamp = newTimestamp;
		window.requestAnimationFrame(step);
	}
	window.requestAnimationFrame(step);
}

var $jscomp=$jscomp||{};$jscomp.scope={};$jscomp.createTemplateTagFirstArg=function(a){return a.raw=a};$jscomp.createTemplateTagFirstArgWithRaw=function(a,b){a.raw=b;return a};function checkElOverViewPort(a,b,c){b=a.parentNode.querySelector(":scope> "+b);null!==b&&(a.parentNode.getBoundingClientRect().right+b.clientWidth>vW?b.classList.add(c):b.classList.remove(c))};
window.addEventListener('resize', throttle( function(){
	vW = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
	isMobile = window.matchMedia("(min-width: 992px)").matches;
	isMobile && document.querySelectorAll('.js-checkMenu').forEach(item => {
		checkElOverViewPort(item, 'ul', 'sub-right');
	})}, 300)
					   )
document.addEventListener('readystatechange', function(e){
	document.readyState === 'complete' && isMobile && document.querySelectorAll('.js-checkMenu').forEach(item => {
		checkElOverViewPort(item, 'ul', 'sub-right')
	})
});