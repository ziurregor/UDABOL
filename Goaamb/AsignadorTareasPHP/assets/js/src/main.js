/**
 * Autor: Goaamb
 */

$(window).on("load", function() {
	$mensaje = $("#mensajeSection h1").html();
	if ($mensaje) {
		$("#mensajeSection").fadeIn("slow");
		setTimeout(() => {
			$("#mensajeSection").fadeOut("slow");
		}, 5000);
	}
});