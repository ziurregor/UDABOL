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
			loadTasks();
		}
	})
	return false;
}



function loginValidator(u, p, f) {

	sendAjax("login", {
		usuario : u,
		contrasena : p
	}, function(o) {
		var llave = null;
		if (o != null) {
			f(o.texto, o.llave);
		}
	});
}