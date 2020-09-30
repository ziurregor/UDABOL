<?php
defined('BASEPATH') or exit('No direct script access allowed');
?>
<!DOCTYPE html>
<html lang="en">
<head>
<base href="<?=base_url()?>" />
<meta charset="utf-8" />
<title>Asignador de Tareas</title>
<link rel="stylesheet" href="assets/css/style.css" />
<script type="text/javascript"
	src="assets/js/jquery/jquery-3.5.1.min.js"></script>
<script type="text/javascript" src="assets/js/goaamb/G.js"></script>
<script type="text/javascript" src="assets/js/src/main.js"></script>
</head>
<body>
	<section id="contenidoSeccion"><?=$contenido?></section>
	<section id="mensajeSection">
		<h1><?=$mensaje?><h1></section>
</body>
</html>