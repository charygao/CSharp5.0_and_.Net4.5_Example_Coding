<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AssignAnotherUser.ascx.cs"
	Inherits="Controls_AssignAnotherUser" %>
<h4>指派给其他用户</h4>
		<asp:DropDownList ID="dropDownList" runat="server" /><br />
	
	<asp:RadioButtonList ID="radioButtonList" runat="server" /><br />
	描述<br />
	<asp:TextBox ID="commentTextBox" runat="server" Height="50px" Width="98%" TextMode="MultiLine" /><br />
	<asp:ImageButton runat="server" ID="reassignImageButton" ImageUrl="~/Images/btn-reassignTask.gif"
		ImageAlign="Right" OnClick="reassignImageButton_Click" />

