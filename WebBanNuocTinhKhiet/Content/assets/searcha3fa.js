let urlParams = new URLSearchParams(window.location.search);
let keyword = urlParams.get('query');
let type = urlParams.get('type') || 'product';
let searchResultCateLinks = Array.from(document.getElementsByClassName('js-search-cate'));
if(keyword === ''){
	searchResultCateLinks.forEach(el => el.classList.remove('active'))
} else {
	searchResultCateLinks.forEach(el => el.classList.remove('active'));
	searchResultCateLinks.filter(item => item.classList.contains(type)).forEach(el => el.classList.add('active'));
}