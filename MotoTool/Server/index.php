<?php
require_once "config.php";
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

<div class="wrapper">
    <form action="pro.php" method="POST">

<div class="form-group">
    <label>Name</label>
    <input type="name" class="form-control" name="name" id="name" placeholder="Enter your name" required>
</div>
<div class="form-group">
    <label for="email">Email</label>
    <input type="email" name="email" class="form-control" id="email" aria-describedby="emailHelp" placeholder="Enter your email" required>
    <small id="emailHelp" class="form-text">Your email will never be shared.</small>
  </div>
        <div class="form-group">
            <label>Message:</label>
            <textarea class="form-control" name="message" placeholder="Enter your message" style="resize: none;" required></textarea>
        </div>
        <div class="form-group">
            <button class="btn btn-success" type="submit">Send</button>
            <a class="btn btn-success" href="https://t.me/francom28">Telegram Contact</a>
        </div>
    </form>
</div>

 <script src="https://code.jquery.com/jquery-3.4.1.min.js" integrity="sha256-CSXorXvZcTkaix6Yvo6HppcZGetbYMGWSFlBw8HfCJo=" crossorigin="anonymous"></script>
</body>
</html>