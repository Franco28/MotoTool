<?php
require_once "config.php";
extract($_POST);
$sql = "INSERT into contacto (name,email,message,created_date) VALUES('" . $name . "','" . $email . "','" . $message . "','" . date('Y-m-d') . "')";
$success = $mysqli->query($sql);
if (!$success) {
    die("Could not enter data, ERROR: ".$mysqli->error);
}
else
{
echo "Thanks for contacting me! I'll be reading your message soon!";
}
?>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="utf-8">
    <title>MotoTool Contact</title>
    <meta http-equiv="refresh" content="60" >
    <link rel="icon" type="image/png" sizes="16x16" href="https://raw.githubusercontent.com/Franco28/MotoTool/master/MotoTool/MotoTool/moto.ico" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta http-equiv="X-UA-Compatible" content="IE=8">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="msapplication-tap-highlight" content="no">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <meta property="og:type" content="website"/>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" >
    <link rel="stylesheet" href="plantilla.css" />
</head>
<body>

<a class="btn btn-success" href="https://beckhamtool.000webhostapp.com/">Back</a>

 <script src="https://code.jquery.com/jquery-3.4.1.min.js" integrity="sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo=" crossorigin="anonymous"></script>
</body>
</html>