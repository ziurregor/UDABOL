/**
 * 
 */

$("#loginSection form").on("submit", submitLoginForm);

function submitLoginForm() {
	var u = this.user.value;
	var p = this.password.value;
	loginValidator(u, p, function(mensaje, llave) {
		if (mensaje) {
			alert(mensaje);
		}
		if (llave) {
			G.cookie.set("sessionId", llave);
		}
	})
	return false;
}

function loginValidator(u, p, f) {
	$.ajax({
		url : "http://10.0.0.154:56961/login",
		data : JSON.stringify({
			usuario : u,
			contrasena : p
		}),
		dataType : "json",
		type : "POST",
		contentType : "application/json",
		success : function(o) {
			var llave = null;

			if (o != null) {
				f(o.texto, o.llave);
			}
		}

	});
}