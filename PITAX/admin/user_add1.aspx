<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="user_add1.aspx.cs" Inherits="PITAX.admin.user_add1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta charset="UTF-8" />
    <title>添加用户</title>
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
    <div class="x-body">
        <form id="Form1" class="layui-form">
             <div class="layui-form-item">
              <label for="L_email" class="layui-form-label">
                  <span class="x-red">*</span>姓名
              </label>
              <div class="layui-input-inline">
                  <input type="text" id="txt_name" name="name" required="" lay-verify="name"
                  autocomplete="off" class="layui-input">
              </div>
              <div class="layui-form-mid layui-word-aux">
                  <span class="x-red">*</span>
              </div>
          </div>` 
          <div class="layui-form-item">
              <label for="L_email" class="layui-form-label">
                  <span class="x-red">*</span>部门
              </label>
              <div class="layui-input-inline">
                  <input type="text" id="txt_departid" name="departid" required="" lay-verify="required"
                  autocomplete="off" class="layui-input" value="财务部">
              </div>
              <div class="layui-form-mid layui-word-aux">
                  <span class="x-red">*</span>
              </div>
          </div>  
        <div class="layui-form-item">
              <label for="username" class="layui-form-label">
                  <span class="x-red">*</span>用户名
              </label>
              <div class="layui-input-inline">
                  <input type="text" id="txt_username" name="username" required="" lay-verify="required"
                  autocomplete="off" class="layui-input">
              </div>
              <div class="layui-form-mid layui-word-aux">
                  <span class="x-red">*</span>用户登入名
              </div>
          </div>
          <div class="layui-form-item">
              <label class="layui-form-label"><span class="x-red">*</span>角色</label>
              <div class="layui-input-block">
                <input type="checkbox" name="like1[read]" lay-skin="primary" title="用户" checked="">
                <input type="checkbox" name="like1[write]" lay-skin="primary" title="超级管理员">
              </div>
          </div>
          <div class="layui-form-item">
              <label for="L_pass" class="layui-form-label">
                  <span class="x-red">*</span>密码
              </label>
              <div class="layui-input-inline">
                  <input type="password" id="L_pass" name="pass" required="" lay-verify="pass"
                  autocomplete="off" class="layui-input">
              </div>
              <div class="layui-form-mid layui-word-aux">
                  6到16个字符
              </div>
          </div>
          <div class="layui-form-item">
              <label for="L_repass" class="layui-form-label">
                  <span class="x-red">*</span>确认密码
              </label>
              <div class="layui-input-inline">
                  <input type="password" id="L_repass" name="repass" required="" lay-verify="repass"
                  autocomplete="off" class="layui-input">
              </div>
          </div>
          <div class="layui-form-item">
              <label class="layui-form-label">备注</label>
              <div class="layui-input-block">
                <textarea id="txt_note"  name="Description" v-model="Description"  placeholder="请输入" autocomplete="off" class="layui-textarea"></textarea>
              </div>
          </div>
          <div class="layui-form-item">
              <label for="L_repass" class="layui-form-label">
              </label>
              <button  class="layui-btn" lay-filter="add" lay-submit="">
                  增加
              </button>
          </div>
      </form>
    </div>
    <script>
        layui.use(['form', 'layer'], function () {
            $ = layui.jquery;
            var form = layui.form
          , layer = layui.layer;

            //自定义验证规则
            form.verify({
                nikename: function (value) {
                    if (value.length < 5) {
                        return '昵称至少得5个字符啊';
                    }
                }
            , pass: [/(.+){6,12}$/, '密码必须6到12位']
            , repass: function (value) {
                if ($('#L_pass').val() != $('#L_repass').val()) {
                    return '两次密码不一致';
                }
            }
            });

            //监听提交
            form.on('submit(add)', function (data) {
                // console.log(data);
                //发异步，把数据提交给ajax
                $.ajax({
                    type: "post",
                    url: "../WebService.asmx/AddUser",
                    datatype: "json",
                    data: {
                        name: $('#txt_name').val(),
                        departid: $('#txt_departid').val(),
                        username: $('#txt_username').val(),
                        password: $('#L_pass').val(),
                        note: $('#txt_note').val()
                    },
                    success: function (res) {
                        var obj = eval('(' + res + ')');
                        layer.msg(JSON.stringify(obj.toString()), function () {
                            location.href = 'user_list.aspx';
                        });
                        if (obj.Success) {
                            layer.alert(obj.Msg, { icon: 6 }, function () {
                                // 获得frame索引
                                var index = parent.layer.getFrameIndex(window.name);
                                //关闭当前frame
                                parent.layer.close(index);
                                // 可以对父窗口进行刷新 
                                x_admin_father_reload();
                                // layer.msg(data, { icon: 1, time: 1000 });
                            });
                            return false;
                        }
                        else {
                            layer.msg(obj.Msg, { icon: 1, time: 1000 });
                        }

                    }
                });


                //  return false;
            });


        });
    </script>
  </body>
</html>
