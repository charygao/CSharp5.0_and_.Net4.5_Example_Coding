using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Workflows;
using System.ComponentModel;

public partial class MasterPages_WorkflowTask : MasterPage, IBaseWorkflowTaskMasterPage
{
    protected const string UserActivityTypeKey = "UserActivityType";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //设置Detail按钮的连接
            this.detailsHyperLink.NavigateUrl = string.Format("~/Authenticated/WorkflowInstance.aspx?{0}={1}",
                    Global.QuerystringKeys.WorkflowGuid,
                    Server.UrlEncode(QueryStringHelper.GetWorkflowGuid(this.Page).ToString()));

            //确保任务己经执行完成
            if (!ActivityIsIncomplete())
                return;

            //确保当前的用户有权力执行活动
            else if (!UserActivitiesHelper.CanUserWorkOnActivity(QueryStringHelper.GetActivityGuid(this.Page),
                     (Guid)Membership.GetUser().ProviderUserKey))
            {
                //提醒用户不能处理该任务并禁用保存和提交按钮
                JavascriptHelper.Alert(this.Page,
                        "Sorry but you do not have the required role to work on this task\\n\\nSaving has been disabled.",
                        "savingDisabled");
                //禁用保存和提交按钮
                this.saveImageButton.Enabled =
                        this.submitImageButton.Enabled = false;
            }
        }
    }

    public bool ActivityIsIncomplete()
    {
        if (!UserActivitiesHelper.ActivityIsIncomplete(QueryStringHelper.GetActivityGuid(this.Page)))
        {
            //JavascriptHelper.Alert(this.Page, result.Message, "completeActivityResult");
            Response.Redirect(string.Format("~/Default.aspx?{0}={1}",
                    Global.QuerystringKeys.Message,
                    Server.UrlEncode("This activity has already been completed and can no longer be worked on.")));

            return false;
        }
        else
            return true;
    }

    /// <summary>
    /// Gets or sets the <see cref="UserActivityType"/> for the page
    /// </summary>
    public UserActivityType UserActivityType
    {
        get
        {
            object obj = this.ViewState[UserActivityTypeKey];

            if (obj == null)
            {
                //Default
                obj = UserActivityType.EnterApprovalRequest;
            }

            return (UserActivityType)Enum.Parse(typeof(UserActivityType), obj.ToString());
        }
        set
        {
            this.ViewState[UserActivityTypeKey] = value;
        }
    }

    public string TaskName
    {
        get
        {
            return this.taskNameLabel.Text;
        }
        set
        {
            this.taskNameLabel.Text = value;
        }
    }

    public string TaskTip
    {
        get
        {
            return this.taskTipLabel.Text;
        }
        set
        {
            this.taskTipLabel.Text = value;
        }
    }

    /// <summary>
    ///获取当前活动的活动数据集
    /// </summary>
    public DataSet TaskDataSet
    {
        get
        {
            DataSet dataSet = null;
            //Global.SessionKeys是一个保存会话常量字符串的类，值得借鉴。
            object obj = this.Session[Global.SessionKeys.TaskDataSet];
            //如果会话中不存在数据集
            if (obj == null)
            {
                //从当前的活动中获取数据集
                dataSet = ActivityDataInterface.GetActivityData(QueryStringHelper.GetActivityGuid(this.Page), this.UserActivityType);
                //然后保存到会话中
                this.Session[Global.SessionKeys.TaskDataSet] = dataSet;
            }
            else
            {
                dataSet = (DataSet)obj;
            }
            //返回当前活动的数据集
            return dataSet;
        }
        set
        {
            this.Session[Global.SessionKeys.TaskDataSet] = value;
        }
    }

    public event EventHandler<CancelEventArgs> BeforeSave;

    private CancelEventArgs OnBeforeSave()
    {
        CancelEventArgs e = new CancelEventArgs();

        if (this.BeforeSave != null)
        {
            this.BeforeSave(this, e);
        }

        return e;
    }

    public event EventHandler<CancelEventArgs> BeforeSubmit;

    private CancelEventArgs OnBeforeSubmit()
    {
        CancelEventArgs e = new CancelEventArgs();

        if (this.BeforeSubmit != null)
        {
            this.BeforeSubmit(this, e);
        }

        return e;
    }

    public event EventHandler<CancelEventArgs> BeforeCancel;

    private CancelEventArgs OnBeforeCancel()
    {
        CancelEventArgs e = new CancelEventArgs();

        if (this.BeforeCancel != null)
        {
            this.BeforeCancel(this, e);
        }

        return e;
    }

    private bool Save()
    {
        return this.Save(true);
    }

    private bool Save(bool showMessage)
    {
        if (!ActivityIsIncomplete())
            return true;

        bool isCancelled = this.OnBeforeSave().Cancel;

        if (!isCancelled)
        {
            Result result = ActivityDataInterface.SaveActivityData(QueryStringHelper.GetActivityGuid(this.Page),
                    this.UserActivityType,
                    this.TaskDataSet);

            if (showMessage)
            {
                JavascriptHelper.Alert(this.Page,
                        result.Message,
                        "saveActivityResult");
            }
        }

        return !isCancelled;
    }

    private bool Submit()
    {
        if (!ActivityIsIncomplete())
            return true;
        //获取保存的结果
        bool isCancelled = !this.Save(false);
        //如果保存成功
        if (!isCancelled)
        {
            //如果订阅了BeforeSubmit事件，获取其是否被取消保存的设置
            isCancelled = this.OnBeforeSubmit().Cancel;
            //定义一个返回结果信息的Result结构
            Result result;
            //如果继续保存，则调用UserActivitiesHelper类来执行保存操作
            if (!isCancelled)
            {
                Guid workflowGuid = QueryStringHelper.GetWorkflowGuid(this.Page);
                Guid activityGuid = QueryStringHelper.GetActivityGuid(this.Page);
                Guid userGuid = (Guid)Membership.GetUser().ProviderUserKey;
                //检查用户是否己被分配到一个任务
                if (!UserActivitiesHelper.UserIsAssignedToActivity(activityGuid, userGuid))
                {
                    //尝试为用户分配任务，以便于完成工作流审批流
                    result = UserActivityService.Singleton.AssignUserActivity(activityGuid,
                            userGuid,
                            userGuid,
                            "Assigning to self so task can be completed");
                    //如果分配失败，则弹出提示信息
                    if (!result.IsSuccessful)
                    {
                        JavascriptHelper.Alert(this.Page, result.Message, "assignActivityResult");
                        return false;
                    }
                }
                //当任务分配过程完成后，就可以完成该工作流，TaskDataSet是一个属性，用于获取当前活动的WorkItemDataSet数据集
                result = UserActivityService.Singleton.CompleteUserActivity(workflowGuid,
                        activityGuid,
                        this.TaskDataSet,
                        userGuid);
                //成功完成后，导航到主页面
                Response.Redirect(string.Format("~/Default.aspx?{0}={1}&{2}={3}",
                        Global.QuerystringKeys.Message,
                        Server.UrlEncode(result.Message),
                        Global.QuerystringKeys.Result,
                        Server.UrlEncode(result.IsSuccessful.ToString())));
            }
        }
        //返回成功与否的消息
        return !isCancelled;
    }

    private bool Cancel()
    {
        bool isCancelled = this.OnBeforeCancel().Cancel;

        if (!isCancelled)
        {
            this.ReturnHome();
        }

        return !isCancelled;
    }

    private void ReturnHome()
    {
        this.Response.Redirect("~/Default.aspx");
    }

    protected void Save(object sender, ImageClickEventArgs e)
    {
        this.Save();
    }

    protected void Submit(object sender, ImageClickEventArgs e)
    {
        this.Submit();
    }

    protected void Cancel(object sender, ImageClickEventArgs e)
    {
        this.Cancel();
    }
}
