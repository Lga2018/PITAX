<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PITAX.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <!-- 避免IE使用兼容模式 -->
    <meta http-equiv="X-UA-Compatible" content="IE=edge, chrome=1" />
    <meta name="renderer" content="webkit" />
    <!--href="/topjui/images/favicon.ico"-->
    <link href="/images/logo_100.png" rel="shortcut icon" />
    <link href="/css/bootstrap.min.css" rel="stylesheet" />
    <link href="plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" />
    <style type="text/css">
        html, body {
            height: 100%;
        }

        .box {
            background: url("/images/loginBg.jpg") no-repeat center center;
            background-size: cover;

            margin: 0 auto;
            position: relative;
            width: 100%;
            height: 100%;
        }

        .login-box {
            width: 100%;
            max-width: 500px;
            height: 400px;
            position: absolute;
            top: 50%;

            margin-top: -200px;
            /*设置负值，为要定位子盒子的一半高度*/

        }

        @media screen and (min-width: 500px) {
            .login-box {
                left: 50%;
                /*设置负值，为要定位子盒子的一半宽度*/
                margin-left: -250px;
            }
        }

        .form {
            width: 100%;
            max-width: 500px;
            height: 275px;
            margin: 2px auto 0px auto;
        }

        .login-content {
            border-bottom-left-radius: 8px;
            border-bottom-right-radius: 8px;
            height: 250px;
            width: 100%;
            max-width: 500px;
            background-color: rgba(255, 250, 2550, .6);
            float: left;
        }

        .input-group {
            margin: 30px 0px 0px 0px !important;
        }

        .form-control,
        .input-group {
            height: 40px;
        }

        .form-actions {
            margin-top: 30px;
        }

        .form-group {
            margin-bottom: 0px !important;
        }

        .login-title {
            border-top-left-radius: 8px;
            border-top-right-radius: 8px;
            padding: 20px 10px;
            background-color: rgba(0, 0, 0, .6);
        }

        .login-title h1 {
            margin-top: 10px !important;
        }

        .login-title small {
            color: #fff;
            margin-left: -50px;
        }

        .link p {
            line-height: 20px;
            margin-top: 30px;
        }

        .btn-sm {
            padding: 8px 24px !important;
            font-size: 16px !important;
        }

        .flag {
            position: absolute;
            top: 10px;
            right: 10px;
            color: #fff;
            font-weight: bold;
            font: 14px/normal "microsoft yahei", "Times New Roman", "宋体", Times, serif;
        }
    </style>
    <title>2019年个税计算</title>
</head>
<body>
<div class="box">
    <div class="login-box">
        <div class="login-title">
            <div style="margin-left: 10px; float: left;">
                <!--src="/public/images/logo_100.png"
                <img style="width: 60px; height: 60px;" alt="" src="images/logo_100.png">-->
            </div>
            <h1 class="text-center">
                <small><span>2019年个税计算</span></small>
            </h1>
        </div>
        <div class="login-content ">
            <div class="form">
                <form class="form-horizontal" id="modifyPassword" runat="server">
                    
                    <div class="form-group">
                        <div class="col-xs-10 col-xs-offset-1">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="glyphicon glyphicon-user"></span></span>
                                <input name="userNameId" class="form-control" id="userNameId" type="text" placeholder="用户名" runat="server" value="">
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-xs-10 col-xs-offset-1">
                            <div class="input-group">
                                <span class="input-group-addon"><span class="glyphicon glyphicon-lock"></span></span>
                                <input name="password" class="form-control" id="password" type="password" placeholder="密码" runat="server" value="" />
                            </div>
                        </div>
                    </div>
                    <div class="form-group form-actions">
                        <div class="col-xs-12 text-center">
                            <asp:Button ID="btn_login" runat="server" Text="登 录"   class="btn btn-sm btn-success" onclick="btn_login_Click" />
                            <asp:Button ID="btn_reset" runat="server" class="btn btn-sm btn-danger"     Text="重 置" onclick="btn_reset_Click" />
                           <!-- <button class="btn btn-sm btn-success" id="login" type="button" runat="server" onclick="btn_login_Click">
                                <span class="fa fa-check-circle"></span> 登录
                            </button>
                            <button class="btn btn-sm btn-danger" id="reset" type="button" runat="server">
                                <span class="fa fa-close"></span> 重置
                            </button>-->
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</div>

<div tabindex="-1" class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel">
    <div class="modal-dialog modal-sm" role="document">
        <div class="modal-content">
            <div class="modal-body">
                <span class="text-danger"><i class="fa fa-warning"></i> <span id="alertMsg">用户名或密码错误，请重试！</span></span>
            </div>
        </div>
    </div>
</div>


<script type="text/javascript">
    if (navigator.appName == "Microsoft Internet Explorer" &&
        (navigator.appVersion.split(";")[1].replace(/[ ]/g, "") == "MSIE6.0" ||
            navigator.appVersion.split(";")[1].replace(/[ ]/g, "") == "MSIE7.0" ||
            navigator.appVersion.split(";")[1].replace(/[ ]/g, "") == "MSIE8.0")
    ) {
        alert("您的浏览器版本过低，请使用360安全浏览器的极速模式或IE9.0以上版本的浏览器");
    }
</script>

</body>
</html>
