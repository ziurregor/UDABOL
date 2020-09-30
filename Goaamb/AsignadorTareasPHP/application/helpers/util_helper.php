<?php

function validarSesion($sesion)
{
    if ($sesion) {
        list ($p, $t) = explode(",", base64_decode($sesion));
        
        $magicnum = '116444735995904000';
        
        $t = bcsub($t, $magicnum);
        $t = bcdiv($t, '10000000', 0);
        return $t > time();
    }
    return false;
}

function request($url, $data, $metodo)
{
    $metodo = $metodo ? strtoupper($metodo) : "GET";
    
    $client = curl_init($url);
    if ($metodo == "POST") {
        curl_setopt($client, CURLOPT_CUSTOMREQUEST, $metodo);
        if ($data) {
            $data = json_encode($data);
            curl_setopt($client, CURLOPT_POSTFIELDS, $data);
            curl_setopt($client, CURLOPT_HTTPHEADER, array(
                'Content-Type:application/json',
                'Content-Length: ' . strlen($data)
            ));
        }
    }
    curl_setopt($client, CURLOPT_RETURNTRANSFER, true);
    
    $response = curl_exec($client);
    curl_close($client);
    return json_decode($response);
}

?>