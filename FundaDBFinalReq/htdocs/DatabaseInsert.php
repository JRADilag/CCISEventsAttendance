<?php

ini_set('display_errors', 'On');

$username = $_GET['username'];                  // Use your username
$password = $_GET['password'];// and your password
$page = $_GET['page'];

$database = "localhost/XEPDB1";   // and the connect string to connect to your database

$conn = oci_connect($username, $password, $database, 'AL32UTF8');

if (!$conn) {
    $e = oci_error();
    trigger_error(htmlentities($e['message'], ENT_QUOTES), E_USER_ERROR);
}

$stid = oci_parse($conn, 'INSERT INTO CCISEVENTS (evname, evloc, evdesc) VALUES(:evname, :evloc, :evdesc)');

$name = $_GET['evname'];
$loc = $_GET['evloc'];
$desc = $_GET['evdesc'];
//$start = $_GET['evstart'];
//$end = $_GET['evend'];

oci_bind_by_name($stid, ':evname', $name);
oci_bind_by_name($stid, ':evloc', $loc);
oci_bind_by_name($stid, ':evdesc', $desc);
//oci_bind_by_name($stid, ':evstart', $start);
//oci_bind_by_name($stid, ':evend', $end);

$r = oci_execute($stid);  // executes and commits

if ($r) {
    echo "One row inserted";
}

oci_free_statement($stid);
oci_close($conn);

?>