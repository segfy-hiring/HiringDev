var w = document.body.clientWidth;
var h = window.innerHeight;

var wv = screen.width;
var hv = screen.height;

function is_landscape() {
    return (w > h);
}

function getMobileOperatingSystem() {

    var userAgent = navigator.userAgent || navigator.vendor || window.opera;

    // Windows Phone must come first because its UA also contains "Android"
    if (/windows phone/i.test(userAgent)) {
        return "win_phone";
    }

    if (/android/i.test(userAgent)) {
        return "android";
    }

    // iOS detection from: http://stackoverflow.com/a/9039885/177710
    if (/iPad|iPhone|iPod/.test(userAgent) && !window.MSStream) {
        return "ios";
    }

    return "desktop";
}


if (getMobileOperatingSystem() != 'ios' && getMobileOperatingSystem() != 'android') {
    var vid = document.getElementById("box-video");
    vid.play();
}



var player1;

var tag = document.createElement('script');

tag.src = "https://www.youtube.com/iframe_api";
var firstScriptTag = document.getElementsByTagName('script')[0];
firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

function onYouTubeIframeAPIReady() {
	player1 = new YT.Player('player1', {
		height: '100%',
		width: '100%',
		videoId: 'PBybWQ1hPg8',
		playerVars: {
			showinfo: false,
			rel: false,
			color: 'white'
		},
		events: {
			'onReady': onPlayerReady1,
			'onStateChange': onPlayerStateChange1
		}
	});
}

function onPlayerReady1() {
	$('.btPlay').show();
}

var done = false;
function onPlayerStateChange1(event) {
	if (event.data == YT.PlayerState.PLAYING && !done) {
		$('#tela, .bt_cancelar').hide();
		$('#share').hide();
		$('#share a.bt_inicial, #share ul').css('display','none');
		$('#video-youtube').show();
		$('#closeVideo').show();
		done = true;
	}
}
function playVideo1(src) {
	player1.loadVideoById(src)
	player1.playVideo();
	//player1.setSize(w, h);
    $('#video-youtube').show();
	$('#player1, #closeVideo1').show();

	// eventGA('Video', 'Play', 'Video 1');
}

function stopVideo1() {
	player1.stopVideo();
	$('#tela').show();
	$('#share').show();
	$('#share a.bt_inicial').css('display','block');
	$('#video-youtube, .bt_cancelar').hide();
	$('#closeVideo').hide();
	done = false;
}

function resizeVideo() {
	player1.setSize(wv, hv);
}
