// JavaScript Document
; (function ($) {
	$(document).ready(function (e) {
		var tab = $(this);
		var tabHeaders = tab.find('.tabHeaders').first();

		// Menu principale della summoner page
		$(">.tabHeader", tabHeaders).on('click', function (a, isForce) {
			var self = this;

			// Imposta come attivo solo il pulsante del menù summoner che è stato cliccato
			tabHeaders.children().removeClass("active");
			$(self).addClass("active");

			var showClass = $(self).data('tab-show-class');

			// Nasconde tutti i DIV. Successivamente verrà reso visibile solo quello necessario
			$("#summoner-content-wrap").children().hide();

			// Imposta il div "already loaded"
			var tempAlreadyLoaded = $("#" + showClass).data('already-loaded');
			if (tempAlreadyLoaded === true) {
				$("#" + showClass).show();
			}
			else {
				var href = $('a', self).attr('href');

				var showClassElementDataId = $(self).data('summoner-id');
				var showClassElementDataRegion = $(self).data('region');
				var showClassElementDataTooltipname = $(self).data('tooltipname');

				$.post(href, { id: showClassElementDataId, region: showClassElementDataRegion }, function (data) {
					$("#" + showClass).data('already-loaded', true);
					$("#" + showClass).html(data);
					$("." + showClassElementDataTooltipname).tooltip({ html: true, container: 'body' });
				});

				$("#" + showClass).show();
			}
			return false;
		});

		// Click del bottone "all" "ranked solo" "normal" ".recent-20game>.game-filters>.btn-group>button"
		$("body").on('click', ".recent-20game>.game-filters>.btn-group>button", function () {
			var self = this;
			/*
			//
			var tempAlreadyLoaded = $("#" + showClass).data('already-loaded');
			if (tempAlreadyLoaded === true) {
				$("#" + showClass).show();
			}*/

			var showClassElementDataId = $(self).data('summoner-id');
			var showClassElementDataRegion = $(self).data('region');
			var queuetype = $(self).data('queuetype');

			var showClass = "matchs .gamelist-wrap";

			$.post("/summoner/SummonerGameFilters", { id: showClassElementDataId, region: showClassElementDataRegion, queueType: queuetype }, function (data) {
				$("#" + showClass).data('already-loaded', true);
			    //$("#" + showClass).html(data);
				$("#matchs").html(data);
			});
		});
		
		// Click del bottone "Live game"
		$("body").on('click', ".summonerProfileWrap>.profile>.buttons>button.livegame", function () {
			var self = this;

			var showClassElementDataId = $(self).data('summoner-id');
			var showClassElementDataRegion = $(self).data('region');

			var showClass = "livegame-wrap";

			$.post("/summoner/SummonerLiveGame", { id: showClassElementDataId, region: showClassElementDataRegion }, function (data) {
				$("." + showClass).data('already-loaded', true);
				$("." + showClass).html(data);
				$("." + showClass).css("display", "block");
			});
		});

	    // Click del bottone "Refresh"
		$("body").on('click', ".summonerProfileWrap>.profile>.buttons>button.pagerefresh", function () {
		    var self = this;

		    var showClassElementDataId = $(self).data('account-id');
		    var showClassElementDataRegion = $(self).data('region');

		    var showClass = "livegame-wrap";

		    $.post("/summoner/UpdateRecentMatch", { accountId: showClassElementDataId, region: showClassElementDataRegion }, function (data) {
		        location.reload();
		    });
		    
		});
	});

	$.fn.greenify = function () {
	    this.css("color", "green");
	};

    // Cronometro del tempo dei game
	$.fn.CottontailTimer = function () {
	    $(this).each(function (index, element) {
	        var startTime = Date.now();

	        setInterval(function (el, time, seconds) {
	            var currentTime = Date.now();
	            var totalSeconds = Math.floor((currentTime - time) / 1000) + seconds;
	            var totalMinutes = Math.floor(totalSeconds / 60);
	            var totalHours = Math.floor(totalSeconds / 3600);

	            // Seconds string
	            var secs = totalSeconds % 60 + "";
	            if (secs.length == 1)
	                secs = "0" + secs;

	            // Seconds string
	            var minutes = totalMinutes % 60 + "";
	            if (minutes.length == 1)
	                minutes = "0" + minutes;

	            // Seconds string
	            var hours = totalHours % 24 + "";
	            if (hours.length == 1)
	                hours = "0" + hours;

	            $(el).html(hours + ":" + minutes + ":" + secs);
	        }, 100, element, startTime, parseInt($(element).html()));
	    });
		return this;
	};

	// Rende il bottone appena cliccato "active"
	$.fn.UpdateButtonGroup = function () {
		$(".btn-group>.btn").click(function () {
			$(this).addClass("active").siblings().removeClass("active");
		});
	};
}(jQuery));
/*
// Rende il bottone appena cliccato "active"
function UpdateButtonGroup() {
	$(".btn-group>.btn").click(function () {
		$(this).addClass("active").siblings().removeClass("active");
	});
};
// Click del bottone "all" "ranked solo" "normal" ".recent-20game>.game-filters>.btn-group>button"
$("button").on('click', function () {
	var self = this;
	

	var showClassElementDataId = $(self).data('summoner-id');
	var showClassElementDataRegion = $(self).data('region');
	var queuetype = $(self).data('queuetype');

	var showClass = "matchs";

	$.post(href, { id: showClassElementDataId, region: showClassElementDataRegion, queueType: queuetype }, function (data) {
		$("#" + showClass).data('already-loaded', true);
		$("#" + showClass).html(data);
		$(".loolollolool").tooltip({ html: true, container: 'body' });
	});
});*/