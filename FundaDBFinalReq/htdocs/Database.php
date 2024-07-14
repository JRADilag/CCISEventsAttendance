<?php


error_reporting(E_ALL);
ini_set('display_errors', 'On');

$username = $_GET['username'];                  // Use your username
$password = $_GET['password'];// and your password
$page = $_GET['page'];
$database = "localhost/XEPDB1";   // and the connect string to connect to your database

$c = oci_connect($username, $password, $database, 'AL32UTF8');
if (!$c) {
    $m = oci_error();
    echo "A";
    trigger_error('Could not connect to database: '. $m['message'], E_USER_ERROR);
}

if ($page == 'events'){

$query = "select * from ccisevents";
$s = oci_parse($c, $query);
if (!$s) {
    $m = oci_error($c);
    echo "A";
    trigger_error('Could not parse statement: '. $m['message'], E_USER_ERROR);
}
$r = oci_execute($s);
if (!$r) {
    $m = oci_error($s);
    echo "A";
    trigger_error('Could not execute statement: '. $m['message'], E_USER_ERROR);
}

while (($row = oci_fetch_array($s, OCI_ASSOC+OCI_RETURN_NULLS)) != false) {
    foreach ($row as $item) {
        echo $item!==null?htmlspecialchars($item, ENT_QUOTES|ENT_SUBSTITUTE):"EMPTY";
    echo ",";
    }
echo ";";
}
}

if ($page == 'attendance'){


$query = "select * from attendanceview";
$s = oci_parse($c, $query);
if (!$s) {
    $m = oci_error($c);
    echo "A";
    trigger_error('Could not parse statement: '. $m['message'], E_USER_ERROR);
}
$r = oci_execute($s);
if (!$r) {
    $m = oci_error($s);
    echo "A";
    trigger_error('Could not execute statement: '. $m['message'], E_USER_ERROR);
}

while (($row = oci_fetch_array($s, OCI_ASSOC+OCI_RETURN_NULLS)) != false) {
    foreach ($row as $item) {
        echo $item!==null?htmlspecialchars($item, ENT_QUOTES|ENT_SUBSTITUTE):"EMPTY";
    echo ",";
    }
echo ";";
}

}

?>