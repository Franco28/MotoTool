<?php
/* Database credentials. Assuming you are running MySQL
server with default setting (user 'root' with no password) */
define('DB_SERVER', '');
define('DB_USERNAME', '');
define('DB_PASSWORD', '');
define('DB_NAME', '');
 
/* Attempt to connect to MySQL database */
$link       = mysqli_connect(DB_SERVER, DB_USERNAME, DB_PASSWORD, DB_NAME);
$connection = mysqli_connect(DB_SERVER,DB_USERNAME,DB_PASSWORD,DB_NAME);
$mysqli     = new mysqli(DB_SERVER, DB_USERNAME, DB_PASSWORD, DB_NAME);
$con        = mysqli_connect(DB_SERVER, DB_USERNAME, DB_PASSWORD, DB_NAME);

// Check connection
if($link === false){
    die("ERROR: Could not connect. " . mysqli_connect_error());
}

if (mysqli_connect_errno()){
 echo "Could not connect with MySQL: " . mysqli_connect_error();
 die();
 }

date_default_timezone_set('America/Argentina/Buenos_Aires');
$error="";
?>