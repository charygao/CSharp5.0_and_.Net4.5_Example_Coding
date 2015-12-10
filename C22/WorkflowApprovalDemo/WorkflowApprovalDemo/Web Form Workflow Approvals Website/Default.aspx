<%@ Page Language="C#" MasterPageFile="~/MasterPages/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" Title="City Power &amp; Light" %>

<%@ Register Src="Controls/TaskList.ascx" TagName="TaskList" TagPrefix="uc1" %>
<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="bodyContentPlaceHolder">
    <div class="box" style="width: 265px;">
        <div class="blueBox">
            <h4>
                ������
            </h4>
            <h5>
                <asp:LinkButton ID="approvalRequestLinkButton" runat="server" OnClick="approvalRequestLinkButton_Click"
                    Text="��ʼ�������" />
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
                                Text="ˢ�������б�" />
                        </h4>
                    </div>
                    <uc1:TaskList ID="usersTaskList" runat="server" BodyCssClass="orangeBorderBox clearfix"
                        ImageUrl="~/images/icn-mytasks.gif" ListType="UsersTasks" Title="ָ�ɸ��ҵ�����">
                    </uc1:TaskList>
                    <uc1:TaskList ID="rolesTaskList" runat="server" BodyCssClass="greenBorderBox clearfix"
                        ImageUrl="~/images/icn-tasks.gif" ListType="RolesTasks" Title="ָ����ɫ������">
                    </uc1:TaskList>
                </div>
            </LoggedInTemplate>
            <AnonymousTemplate>
                <div class="box right" style="width: 695px;">
                    <div class="blueBorderBox clearfix">
                        ��������б��еĹ�����ģ�Ϳ�ʼһ���µĹ�����ʵ��
                        <br />
                        <br />
                        ��¼��ע��鿴����ѡ��<br />
                        <br />
                        ����ʹ��Charles��Jane��Rachel��¼��ʾ���������Ϊpassword��Charles��Administrator��Jane��Manager��Rachel������������Ա
                    </div>
                </div>
            </AnonymousTemplate>
        </asp:LoginView>
   </div> 
</asp:Content>
