<?php
defined('BASEPATH') or exit('No direct script access allowed');

class Welcome extends CI_Controller
{

    public function index()
    {
        $mensaje = "";
        $auxmensaje = $this->session->userdata("mensaje");
        if ($auxmensaje) {
            $mensaje = $auxmensaje;
            $this->session->unset_userdata("mensaje");
        }
        $contenido = "";
        $sessionId = $this->session->userdata("sessionId");
        if (($sessionId != null && ! validarSesion($sessionId)) || $sessionId == null) {
            $contenido = $this->load->view('login', false, true);
        }
        $this->load->view('index', [
            "contenido" => $contenido,
            "mensaje" => $mensaje
        ]);
    }
}
?>