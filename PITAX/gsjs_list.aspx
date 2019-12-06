<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="gsjs_list.aspx.cs" Inherits="PITAX.gsjs_list" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
   <meta charset="UTF-8" />
    <title>计算个税</title>
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
          <cite>个税列表</cite></a>
      </span>

    </div>
    <div class="x-body">
      <div class="layui-row">
        <form id="Form1" class="layui-form layui-col-md12 x-so layui-form-pane" runat="server">
         <div class="layui-input-inline">
            <label class="layui-form-label">选择年月</label>
          </div>
          <div class="layui-input-inline">

            <asp:DropDownList ID="slt_year" runat="server" AutoPostBack="True"></asp:DropDownList>
          </div>
          <div class="layui-input-inline">           
            <asp:DropDownList ID="slt_month" runat="server" AutoPostBack="true"></asp:DropDownList>
          </div>
          <asp:TextBox ID="empid" runat="server" CssClass="layui-input"></asp:TextBox>
         
          <asp:Button ID="btn_sreach" runat="server" class="layui-btn" Text="开始查询" onclick="btn_sreach_Click"  />
         
       
      </div>
      <xblock> 
         <asp:Button ID="btn_report" runat="server" Text="生成个税报表"  class="layui-btn" onclick="btn_report_Click" />
         <asp:Button ID="btn_reportimprot" runat="server" Text="导出个税报表" class="layui-btn" onclick="btn_reportimprot_Click" />
           <span class="x-red" id="strStatus" runat="server"></span>
            <span  class="x-right" style="line-height:40px" >
                共有数据：<span id="txtTotalCount" runat="server">88</span> 条,
                本月个税汇总：<span id="txt_bygsCount" runat="server"></span>
            </span>
        <!--<button class="layui-btn" onclick="x_admin_show('批量上传','./gzmx_upload.aspx')"><i class="layui-icon"></i>生成个税报表</button>
       <a _href="zxkc_upload.aspx" target="x-iframe"  class="layui-btn layui-btn-danger"><i class="layui-icon"></i>批量上传</a>
        <button class="layui-btn" onclick="x_admin_show('添加专项扣除','./gzmx_add.aspx')"><i class="layui-icon"></i>添加</button>-->

      </xblock> </form>
      <table class="layui-table">
        <thead>
          <tr>
            <th>年/月</th>
            <th>工号</th>
            <th>姓名</th>
            <th>应发金额</th>
            <th>扣款</th>
            <th>金积金扣除</th>
            <th>保险扣款</th>
            <th>专项扣除</th>
            <th>基础扣除</th>
            <th>扣款总额</th>
            <th>应税工资总计</th>
            <th>个税总计</th>
            <th>本月个税</th>
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
                        <td><%# Eval("kk") %></td>
                        <td><%# Eval("gjj") %></td>
                        <td><%# Eval("bxkk") %></td>
                        <td><%# Eval("zxkk") %></td>
                        <td><%# Eval("jckk") %></td>
                        <td><%# Eval("total") %></td>
                        <td><%# Eval("ysgzlj") %></td>
                        <td><%# Eval("gslj") %></td>
                        <td><%# Eval("bygs") %></td>                      
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
