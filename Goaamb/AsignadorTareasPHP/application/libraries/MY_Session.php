<?php
require_once "kernel/libraries/Session.php";

class MY_Session extends CI_Session
{

    public function __construct()
    {
        if (! isset($_SESSION)) {
            
            session_start();
        }
    }

    /*
     *
     * (non-PHPdoc) @see CI_Session::set_userdata()
     *
     */
    public function set_userdata($newdata, $newval = '')
    {
        $_SESSION[$newdata] = $newval;
    }

    /*
     *
     * (non-PHPdoc) @see CI_Session::unset_userdata()
     *
     */
    public function unset_userdata($newdata)
    {
        if (isset($_SESSION[$newdata]))
            
            unset($_SESSION[$newdata]);
    }

    /*
     *
     * (non-PHPdoc) @see CI_Session::userdata()
     *
     */
    public function userdata($item)
    {
        return isset($_SESSION[$item]) ? $_SESSION[$item] : false;
    }
}

?>