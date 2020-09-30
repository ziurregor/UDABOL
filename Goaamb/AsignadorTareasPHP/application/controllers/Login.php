<?php
defined('BASEPATH') or exit('No direct script access allowed');

class Login extends CI_Controller
{

    public function index()
    {
        $usuario = $this->input->post("usuario");
        $contrasena = $this->input->post("contrasena");
        $url = "http://10.0.0.154:5000/";
        
        $response = request($url . "login/", [
            "usuario" => $usuario,
            "contrasena" => $contrasena
        ], "POST");
        if ($response) {
            if (isset($response->texto)) {
                $this->session->set_userdata("mensaje", $response->texto);
            }
            if (isset($response->llave)) {
                $this->session->set_userdata("sessionId", $response->llave);
            }
        }
        redirect("/");
    }
}
?>
