<%@ Page Language="C#" MasterPageFile="~/MasterPages/WorkflowTask.master" AutoEventWireup="true"
	CodeFile="EnterApprovalRequestTask.aspx.cs" Inherits="Authenticated_EnterApprovalRequestTask"
	Title="City Power &amp; Light" %>

<%@ Register Assembly="Controls" Namespace="Samples.Controls" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="taskFieldsContentPlaceHolder" runat="Server">
	<table width="100%" cellpadding="5" cellspacing="5" border="0">
		<tr>
			<td>
				<cc1:FieldControl ID="nameFieldControl" Caption="Name" runat="server" DataTextField="WorkItemName"
					CaptionAlignment="Top" DataControlWidth="100%" Width="100%" IsRequired="true" ValidationDisplay="None"
					ValidationGroup="TaskFields" />
				<br />
				<cc1:FieldControl ID="descriptionFieldControl" Caption="Description" runat="server"
					DataTextField="Description" CaptionAlignment="Top" DataControlWidth="100%" Width="100%"
					IsRequired="true" ValidationDisplay="None" ValidationGroup="TaskFields" />
				<br />
				<asp:ValidationSummary ID="validationSummary" runat="server" ValidationGroup="TaskFields"
					HeaderText="提示! 不能进行保存..." />
			</td>
			<td style="width: 360px">
				<cc1:FieldControl ID="typeOfWorkFieldControl" Caption="Type of work" runat="server"
					DataTextField="WorkItemType" CaptionAlignment="Top" DataControlWidth="100%" Width="300px"
					OptionTextField="WorkTypeName" OptionValueField="WorkTypeName" IsLookup="true" />
				<br />
				<cc1:FieldControl ID="reasonFieldControl" Caption="Reason" runat="server" DataTextField="Reason"
					CaptionAlignment="Top" DataControlWidth="100%" Width="100%" IsRequired="true" ValidationDisplay="None"
					ValidationGroup="TaskFields" />
				<br />
				<cc1:FieldControl ID="dateRequestedFieldControl" Caption="Date requested" runat="server"
					DataTextField="DateRequested" CaptionAlignment="Top" DataControlWidth="100%" Width="100%" />
				<br />
				<cc1:FieldControl ID="fundingFieldControl" Caption="Funding cost center" runat="server"
					DataTextField="FundingCostCenter" CaptionAlignment="Top" DataControlWidth="100%"
					Width="100%" IsRequired="true" ValidationDisplay="None" ValidationGroup="TaskFields" />
				<br />
				<cc1:FieldControl ID="areaFieldControl" Caption="Area Affected" runat="server" DataTextField="AreaAffected"
					CaptionAlignment="Top" DataControlWidth="100%" Width="100%" IsRequired="true" ValidationDisplay="None"
					ValidationGroup="TaskFields" />
			</td>
		</tr>
	</table>
</asp:Content>
