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
            //����Detail��ť������
            this.detailsHyperLink.NavigateUrl = string.Format("~/Authenticated/WorkflowInstance.aspx?{0}={1}",
                    Global.QuerystringKeys.WorkflowGuid,
                    Server.UrlEncode(QueryStringHelper.GetWorkflowGuid(this.Page).ToString()));

            //ȷ�����񼺾�ִ�����
            if (!ActivityIsIncomplete())
                return;

            //ȷ����ǰ���û���Ȩ��ִ�л
            else if (!UserActivitiesHelper.CanUserWorkOnActivity(QueryStringHelper.GetActivityGuid(this.Page),
                     (Guid)Membership.GetUser().ProviderUserKey))
            {
                //�����û����ܴ�������񲢽��ñ�����ύ��ť
                JavascriptHelper.Alert(this.Page,
                        "Sorry but you do not have the required role to work on this task\\n\\nSaving has been disabled.",
                        "savingDisabled");
                //���ñ�����ύ��ť
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
    ///��ȡ��ǰ��Ļ���ݼ�
    /// </summary>
    public DataSet TaskDataSet
    {
        get
        {
            DataSet dataSet = null;
            //Global.SessionKeys��һ������Ự�����ַ������ֵ࣬�ý����
            object obj = this.Session[Global.SessionKeys.TaskDataSet];
            //����Ự�в��������ݼ�
            if (obj == null)
            {
                //�ӵ�ǰ�Ļ�л�ȡ���ݼ�
                dataSet = ActivityDataInterface.GetActivityData(QueryStringHelper.GetActivityGuid(this.Page), this.UserActivityType);
                //Ȼ�󱣴浽�Ự��
                this.Session[Global.SessionKeys.TaskDataSet] = dataSet;
            }
            else
            {
                dataSet = (DataSet)obj;
            }
            //���ص�ǰ������ݼ�
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
        //��ȡ����Ľ��
        bool isCancelled = !this.Save(false);
        //�������ɹ�
        if (!isCancelled)
        {
            //���������BeforeSubmit�¼�����ȡ���Ƿ�ȡ�����������
            isCancelled = this.OnBeforeSubmit().Cancel;
            //����һ�����ؽ����Ϣ��Result�ṹ
            Result result;
            //����������棬�����UserActivitiesHelper����ִ�б������
            if (!isCancelled)
            {
                Guid workflowGuid = QueryStringHelper.GetWorkflowGuid(this.Page);
                Guid activityGuid = QueryStringHelper.GetActivityGuid(this.Page);
                Guid userGuid = (Guid)Membership.GetUser().ProviderUserKey;
                //����û��Ƿ񼺱����䵽һ������
                if (!UserActivitiesHelper.UserIsAssignedToActivity(activityGuid, userGuid))
                {
                    //����Ϊ�û����������Ա�����ɹ�����������
                    result = UserActivityService.Singleton.AssignUserActivity(activityGuid,
                            userGuid,
                            userGuid,
                            "Assigning to self so task can be completed");
                    //�������ʧ�ܣ��򵯳���ʾ��Ϣ
                    if (!result.IsSuccessful)
                    {
                        JavascriptHelper.Alert(this.Page, result.Message, "assignActivityResult");
                        return false;
                    }
                }
                //��������������ɺ󣬾Ϳ�����ɸù�������TaskDataSet��һ�����ԣ����ڻ�ȡ��ǰ���WorkItemDataSet���ݼ�
                result = UserActivityService.Singleton.CompleteUserActivity(workflowGuid,
                        activityGuid,
                        this.TaskDataSet,
                        userGuid);
                //�ɹ���ɺ󣬵�������ҳ��
                Response.Redirect(string.Format("~/Default.aspx?{0}={1}&{2}={3}",
                        Global.QuerystringKeys.Message,
                        Server.UrlEncode(result.Message),
                        Global.QuerystringKeys.Result,
                        Server.UrlEncode(result.IsSuccessful.ToString())));
            }
        }
        //���سɹ�������Ϣ
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
