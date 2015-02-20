// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
#pragma warning disable 1591, 3008, 3009
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace Jarboo.Admin.Web.Controllers
{
    public partial class QuestionsController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public QuestionsController() { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected QuestionsController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Create()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public QuestionsController Actions { get { return MVC.Questions; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "Questions";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "Questions";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string QuestionList = "QuestionList";
            public readonly string Create = "Create";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string QuestionList = "QuestionList";
            public const string Create = "Create";
        }


        static readonly ActionParamsClass_QuestionList s_params_QuestionList = new ActionParamsClass_QuestionList();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_QuestionList QuestionListParams { get { return s_params_QuestionList; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_QuestionList
        {
            public readonly string questionFilter = "questionFilter";
            public readonly string taskName = "taskName";
        }
        static readonly ActionParamsClass_Create s_params_Create = new ActionParamsClass_Create();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Create CreateParams { get { return s_params_Create; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Create
        {
            public readonly string taskId = "taskId";
            public readonly string taskName = "taskName";
            public readonly string model = "model";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string _QuestionList = "_QuestionList";
                public readonly string AskQuestion = "AskQuestion";
            }
            public readonly string _QuestionList = "~/Views/Questions/_QuestionList.cshtml";
            public readonly string AskQuestion = "~/Views/Questions/AskQuestion.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_QuestionsController : Jarboo.Admin.Web.Controllers.QuestionsController
    {
        public T4MVC_QuestionsController() : base(Dummy.Instance) { }

        [NonAction]
        partial void QuestionListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Jarboo.Admin.BL.Filters.QuestionFilter questionFilter, string taskName);

        [NonAction]
        public override System.Web.Mvc.ActionResult QuestionList(Jarboo.Admin.BL.Filters.QuestionFilter questionFilter, string taskName)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.QuestionList);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "questionFilter", questionFilter);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "taskName", taskName);
            QuestionListOverride(callInfo, questionFilter, taskName);
            return callInfo;
        }

        [NonAction]
        partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int? taskId, string taskName);

        [NonAction]
        public override System.Web.Mvc.ActionResult Create(int? taskId, string taskName)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "taskId", taskId);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "taskName", taskName);
            CreateOverride(callInfo, taskId, taskName);
            return callInfo;
        }

        [NonAction]
        partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Jarboo.Admin.Web.Models.Question.QuestionViewModel model);

        [NonAction]
        public override System.Web.Mvc.ActionResult Create(Jarboo.Admin.Web.Models.Question.QuestionViewModel model)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "model", model);
            CreateOverride(callInfo, model);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009