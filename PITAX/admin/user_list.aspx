<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_list.aspx.cs" Inherits="PITAX.admin.user_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <meta charset="UTF-8" />
    <title>用户列表</title>
    <meta name="renderer" content="webkit" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1" />
    <meta name="viewport" content="width=device-width,user-scalable=yes, minimum-scale=0.4, initial-scale=0.8,target-densitydpi=low-dpi" />
    <link rel="stylesheet" href="../css/font.css" />
    <link rel="stylesheet" href="../css/style.css" />
    <script type="text/javascript" src="https://cdn.bootcss.com/jquery/3.2.1/jquery.min.js"></script>
    <script type="text/javascript" src="../lib/layui/layui.js" charset="utf-8"></script>
    <script type="text/javascript" src="../js/xadmin.js"></script>
    <script type="text/javascript" src="../js/cookie.js"></script>
  </head>
<body>
    <div class="x-nav">
      <span class="layui-breadcrumb">
        <a>首页</a>
        <a>
          <cite>用户列表</cite></a>
      </span>
    </div>
    <div class="x-body">
      <xblock>
        <button class="layui-btn" onclick="x_admin_show('添加用户','./user_add.aspx')"><i class="layui-icon"></i>添加用户</button>
        <span class="x-right" style="line-height:40px" >共有数据：<span id="txtTotalCount" runat="server">88</span> 条</span>
      </xblock>
      <table class="layui-table">
        <thead>
          <tr>
            <th>姓名</th>
            <th>部门</th>
            <th>用户名</th>
            <th>角色</th>
            <th>添加时间</th>
            <th>备注</th>
            <th>操作</th>
           </tr> 
        </thead>
        <tbody>
            <asp:Repeater ID="rpt_list" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("name") %></td>
                        <td><%# Eval("departid") %></td>
                        <td><%# Eval("username") %></td>
                        <td><%# Eval("role") %></td>
                        <td><%# Eval("addtime") %></td>
                        <td><%# Eval("note") %></td>
                        <td class="td-manage">
                          <a title="编辑"  onclick="x_admin_show('编辑','user_edit.html')" href="javascript:;">
                            <i class="layui-icon">&#xe642;</i>
                          </a>
                          <a title="删除" onclick="member_del(this,<%# Eval("id") %>)" href="javascript:;">
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
    <script>
        function member_del(obj, id) {
            layer.confirm('确认要删除吗？', function (index) {
                //发异步删除数据url: "../ajaxServer.aspx?id=" + id,
                $.ajax({
                    type: "post",
                    url: "../WebService.asmx/DeleteUser",
                    datatype: "json",
                    data: {
                        userid:id
                    },
                    success: function (data) { 
                        $(obj).parents("tr").remove();
                        layer.msg('已删除!', { icon: 1, time: 1000 });
                    }
                });
                
            });
        }
    </script>
  </body>
</html>
