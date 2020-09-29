/**
 * Autor: Goaamb
 */

function loadTasks() {
}

function loadLogin() {
	$.ajax({
		url : "views/login.gtp",
		method : "get",
		success : function(data) {
			$("#mainSection").html(data);
			loadLoginJS();
		}
	});
}

function loadLoginJS() {
	G.util.includeJS("assets/js/src/login.js", function() {
		console.log("login loaded.");
	});
}

function isLoggedIn() {
	var s = G.cookie.get("sessionId");
	if (s) {
		var bd=G.base64.decode(s);
		bd=bd!=null?bd.split(","):null;
		if (bd != null && bd.length > 1 && bd[1]!=null){
			console.log(bd[1]);
			
			var s = bd[1];
			var t = +s.substring(0, s.length-4);
			var e = Date.UTC(1601,0,1);
			var dt = new Date(e + t);
			if(dt>Date.now()){
				return true;
			}
			G.cookie.set("sessionId","");
		}
	}
	return false;
}
G.DBObj = false;
$(window).on("load", function() {
	G.DBObj = G.DB.startDB();
	if (isLoggedIn()) {
		loadTasks();
	} else {
		loadLogin();
	}
});
