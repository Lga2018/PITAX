<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gzmx_upload.aspx.cs" Inherits="PITAX.gzmx_upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <meta charset="UTF-8" />
    <title>个人工资明细上传</title>
    <meta name="renderer" content="webkit" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width,user-scalable=yes, minimum-scale=0.4, initial-scale=0.8,target-densitydpi=low-dpi" />
    <link rel="stylesheet" href="./css/font.css" />
    <link rel="stylesheet" href="./css/style.css" />
    <script type="text/javascript" src="https://cdn.bootcss.com/jquery/3.2.1/jquery.min.js"></script>
    <script type="text/javascript" src="./lib/layui/layui.js" charset="utf-8"></script>
    <script type="text/javascript" src="./js/xadmin.js"></script>
    <script type="text/javascript" src="./js/cookie.js"></script>
 
</head>
<body>
    <div class="x-nav">
      <span class="layui-breadcrumb">
        <a>首页</a>
        <a>
          <cite>工资明细上传</cite></a>
      </span>
    </div>
    <div class="x-body">
      <div class="layui-row">
        <form id="Form1" class="layui-form layui-col-md12 x-so layui-form-pane"  runat="server" >
         <div class="layui-input-inline">
            <label class="layui-form-label">选择年月</label>
          </div>
          <div class="layui-input-inline">
            <select name="slt_year" id="slt_year" runat="server">             
            </select>
          </div>
          <div class="layui-input-inline">
            <select name="slt_month" id="slt_month" runat="server">

            </select>
          </div>
          <xblock></xblock>
          <fieldset class="layui-elem-field">
            <legend style="font-size:14px">文件选择并上传</legend>
            <div class="layui-field-box">
                <table class="layui-table" lay-skin="line">
                    <tbody>
                        <tr>
                            <td >
                                <asp:FileUpload ID="fud_fileName" runat="server" Height="37.5px" Width="450px" />
                                <!--  <input type="file" accept="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet,application/vnd.ms-excel" style="height:37.5px; width:450px" />-->
                                <asp:Button ID="btn_upload" runat="server" class="layui-btn" Text="开始上传" 
                                    onclick="btn_upload_Click" />
                            </td>
                        </tr>                       
                    </tbody>
                </table>
            </div>
        </fieldset>
        </form>
      </div>
      <blockquote class="layui-elem-quote">
        <span class="x-red" id="strStatus" runat="server">上传提示信息</span>
     </blockquote>
    </div>
  </body>
</html>