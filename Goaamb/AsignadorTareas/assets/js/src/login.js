/**
 * 
 */

$("#loginSection form").on("submit", submitLoginForm);

function submitLoginForm() {
	var u = this.user.value;
	var p = this.password.value;
	if (loginValidator(u, p)) {

	}
	return false;
}

function loginValidator(u,p){
	$.ajax({
		url:"http://200.105.154.18:5000/login",
		data: {
			usuario:u,
			contrasena:p
		},
		type:"POST",
		dataType:"json"
		
	});
}