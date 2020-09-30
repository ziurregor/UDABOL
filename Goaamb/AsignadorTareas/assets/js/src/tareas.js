/**
 * 
 */
function showTasks() {
	sendAjax("tarea",false, function(o) {
		console.log(o);
	}, true, "GET");
}