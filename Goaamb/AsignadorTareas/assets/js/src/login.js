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
	
}