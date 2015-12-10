<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" Title="City Power &amp; Light" %>

<%@ Register Src="Controls/TaskList.ascx" TagName="TaskList" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="bodyContentPlaceHolder">
    <div class="box" style="width: 265px;">
        <div class="blueBox">
            <h4>
                工作流
            </h4>
            <h5>
                <asp:LinkButton ID="approvalRequestLinkButton" runat="server" OnClick="approvalRequestLinkButton_Click"
                    Text="开始审核请求" />
            </h5>
        </div>
    </div>
   <div> 
        <asp:LoginView ID="loginView" runat="server">
            <LoggedInTemplate>
                <div class="box right" style="width: 695px;">
                    <div class="blueBorderBox clearfix">
                        <asp:Image ID="refreshImage" runat="server" AlternateText=" " CssClass="icon" ImageUrl="~/images/icn-refresh.gif" />
                        <h4>
                            <asp:LinkButton ID="refreshTaskListsLinkButton" runat="server" OnClick="refreshTaskListsLinkButton_Click"
                                Text="刷新任务列表" />
                        </h4>
                    </div>
                    <uc1:TaskList ID="usersTaskList" runat="server" BodyCssClass="orangeBorderBox clearfix"
                        ImageUrl="~/images/icn-mytasks.gif" ListType="UsersTasks" Title="指派给我的任务">
                    </uc1:TaskList>
                    <uc1:TaskList ID="rolesTaskList" runat="server" BodyCssClass="greenBorderBox clearfix"
                        ImageUrl="~/images/icn-tasks.gif" ListType="RolesTasks" Title="指定角色的任务">
                    </uc1:TaskList>
                </div>
            </LoggedInTemplate>
            <AnonymousTemplate>
                <div class="box right" style="width: 695px;">
                    <div class="blueBorderBox clearfix">
                        单击左侧列表中的工作流模型开始一个新的工作流实例
                        <br />
                        <br />
                        登录和注册查看更多选项<br />
                        <br />
                        可以使用Charles、Jane和Rachel登录该示例，密码均为password，Charles是Administrator，Jane是Manager，Rachel是数据输入人员
                    </div>
                </div>
            </AnonymousTemplate>
        </asp:LoginView>
   </div> 
</asp:Content>
