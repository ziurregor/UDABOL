/**
 * 
 */
function showTasks() {
	sendAjax("tarea", false, function(o) {
		if (o != null) {
			if (!o.texto) {
				if (o.length > 0) {
					
				}
			}
		}
	}, true, "GET");
}