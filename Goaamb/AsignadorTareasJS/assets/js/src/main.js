/**
 * Autor: Goaamb
 */

var baseURL = "http://10.0.0.154:5000/";
function loadAjax(url, success) {
	$.ajax({
		url : url,
		method : "get",
		success : success
	});
}

function sendAjax(url, data, success, sesion, type) {
	sesion = sesion ? "/" + G.cookie.get("sessionId") : "";
	type = type ? type : "POST";
	var obj = {
		url : baseURL + url + sesion,
		dataType : "json",
		type : type,
		contentType : "application/json",
		success : success
	};
	if (type.toLowerCase() == "post") {
		obj.data = JSON.stringify(data);
	}
	$.ajax(obj);
}

function loadLogin() {
	loadAjax("views/login.gtp", function(data) {
		$("#mainSection").html(data);
		loadLoginJS();
	})
}

function loadLoginJS() {
	G.util.includeJS("assets/js/src/login.js", function() {
		console.log("login loaded.");
	});
}

function loadTasksJS() {
	G.util.includeJS("assets/js/src/tareas.js", function() {
		console.log("tareas loaded.");
		showTasks();
	});
}

function loadTasks() {
	loadAjax("views/tareas.gtp", function(data) {
		$("#mainSection").html(data);
		loadTasksJS();
	})
}

function validSession(sesion) {
	if (sesion) {
		var bd = G.base64.decode(sesion);
		bd = bd != null ? bd.split(",") : null;
		if (bd != null && bd.length > 1 && bd[1] != null) {
			console.log(bd[1]);

			var s = bd[1];
			var t = +s.substring(0, s.length - 4);
			var e = Date.UTC(1601, 0, 1);
			var dt = new Date(e + t);
			if (dt > Date.now()) {
				return true;
			}
		}
	}
	return false
}

function isLoggedIn() {
	var s = G.cookie.get("sessionId");
	if (validSession(s)) {
		return true;
	}
	G.cookie.set("sessionId", "");
	return false;
}

// G.DBObj = false;
$(window).on("load", function() {
	// G.DBObj = G.DB.startDB();
	if (isLoggedIn()) {
		loadTasks();
	} else {
		loadLogin();
	}
});
