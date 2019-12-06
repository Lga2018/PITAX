<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gzmx_list.aspx.cs" Inherits="PITAX.gzmx_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <meta charset="UTF-8" />
    <title>工资明细列表</title>
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
          <cite>工资明细列表</cite></a>
      </span>

    </div>
    <div class="x-body">
      <div class="layui-row">
        <form id="Form1" class="layui-form layui-col-md12 x-so layui-form-pane" runat="server">
         <div class="layui-input-inline">
            <label class="layui-form-label">选择年月</label>
          </div>
          <div class="layui-input-inline">

            <asp:DropDownList ID="slt_year" runat="server"></asp:DropDownList>
          </div>
          <div class="layui-input-inline">           
            <asp:DropDownList ID="slt_month" runat="server" AutoPostBack="true"></asp:DropDownList>
          </div>
          <asp:TextBox ID="empid" runat="server" CssClass="layui-input"></asp:TextBox>
         
          <asp:Button ID="btn_sreach" runat="server" class="layui-btn" Text="开始查询" onclick="btn_sreach_Click"  />
        </form>
      </div>
      <xblock>
        <button class="layui-btn" onclick="x_admin_show('批量上传','./gzmx_upload.aspx')"><i class="layui-icon"></i>批量上传</button>
       <!--<a _href="zxkc_upload.aspx" target="x-iframe"  class="layui-btn layui-btn-danger"><i class="layui-icon"><td><%= (++idx).ToString() %></td></i>批量上传</a>-->
        <button class="layui-btn" onclick="x_admin_show('添加专项扣除','./gzmx_add.aspx')"><i class="layui-icon"></i>添加</button>
        <span class="x-right" style="line-height:40px" >共有数据：<span id="txtTotalCount" runat="server">88</span> 条</span>
      </xblock>
      <table class="layui-table">
        <thead>
          <tr>
            <th>年/月</th>
            <th>工号</th>
            <th>姓名</th>
            <th>应发金额</th>
            <th>扣其他款</th>
            <th>扣款</th>
            <th>工伤扣</th>
            <th>公积金2</th>
            <th>金积金</th>
            <th>保险扣款</th>
            <th>实发金额</th>
            <th>操作</th>
           </tr> 
        </thead>
        <tbody>
            <asp:Repeater ID="rpt_list" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("year").ToString() +"/"+ Eval("month").ToString()%></td>
                        <td><%# Eval("empid") %></td>
                        <td><%# Eval("name") %></td>
                        <td><%# Eval("yfje") %></td>
                        <td><%# Eval("kqtk") %></td>
                        <td><%# Eval("kk") %></td>
                        <td><%# Eval("gsk") %></td>
                        <td><%# Eval("gjj2") %></td>
                        <td><%# Eval("gjj") %></td>
                        <td><%# Eval("bxkk") %></td>
                        <td><%# Eval("sfje") %></td>
                        <td class="td-manage">
                          <a title="编辑"  onclick="x_admin_show('编辑','gzmx_edit.html')" href="javascript:;">
                            <i class="layui-icon">&#xe642;</i>
                          </a>
                          <a title="删除" href="javascript:;">
                            <i class="layui-icon">&#xe640;</i>
                          </a>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
         
        </tbody>
      </table>
      <div class="page">
        <div id="PageContent" runat="server">
          <a class="prev" href="">&lt;&lt;</a>
          <a class="num" href="">1</a>
          <span class="current">2</span>
          <a class="num" href="">3</a>
          <a class="num" href="">489</a>
          <a class="next" href="">&gt;&gt;</a>
        </div>
      </div>

    </div>
  </body>
</html>
