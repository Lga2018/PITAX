<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="welcome.aspx.cs" Inherits="PITAX.welcome" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html class="x-admin-sm" xmlns="http://www.w3.org/1999/xhtml">
    <head>
        <meta charset="UTF-8" />
        <title>欢迎页面</title>
        <meta name="renderer" content="webkit" />
        <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
        <meta name="viewport" content="width=device-width,user-scalable=yes, minimum-scale=0.4, initial-scale=0.8,target-densitydpi=low-dpi" />
        <link rel="stylesheet" href="./css/font.css" />
        <link rel="stylesheet" href="./css/style.css" />
    </head>
    <body>
    <div class="x-body">
        <blockquote class="layui-elem-quote">欢迎管理员：
            <span class="x-red" id="txt_name" runat="server">admin</span>！当前时间:2018-04-25 20:50:53</blockquote>
        <fieldset class="layui-elem-field">
            <legend>操作步骤说明</legend>
            <div class="layui-field-box">
                <table class="layui-table" lay-skin="line">
                    <tbody>
                        <tr>
                            <td >
                                <a class="x-a">1，上传当前月专项扣除操作列表 </a>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <a class="x-a">2，上传当前月的工资明细（主要包括应发工资、社保、公积金等项）</a>
                            </td>
                        </tr>
                        <tr>
                            <td >
                                <a class="x-a">3，个税生成页生成当前月应缴个税列表</a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </fieldset>
    </div>
    </body>
</html>
