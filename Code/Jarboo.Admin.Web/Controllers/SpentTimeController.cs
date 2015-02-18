﻿using System.Linq;
using System.Web.Mvc;

using Jarboo.Admin.BL;
using Jarboo.Admin.BL.Filters;
using Jarboo.Admin.BL.Models;
using Jarboo.Admin.Web.Models.Time;
using Ninject;
using Jarboo.Admin.BL.Services.Interfaces;

namespace Jarboo.Admin.Web.Controllers
{
    public partial class SpentTimeController : BaseController
    {
        [Inject]
        public ISpentTimeService SpentTimeService { get; set; }
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        public virtual ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public virtual ActionResult GroupedList(SpentTimeFilter spentTimeFilter = null)
        {
            spentTimeFilter = (spentTimeFilter ?? new SpentTimeFilter()).ByAccepted(true);
            var items = SpentTimeService.GetAll(Query.ForSpentTime(spentTimeFilter));

            ViewBag.EmployeesList = new SelectList(EmployeeService.GetAll(Query.ForEmployee().Include(x => x.Positions())), "EmployeeId", "FullName");
            return this.View(items);
        }

        [ChildActionOnly]
        public virtual ActionResult List(SpentTimeFilter spentTimeFilter = null)
        {
            spentTimeFilter = spentTimeFilter ?? new SpentTimeFilter();
            var items = SpentTimeService.GetAll(Query.ForSpentTime(spentTimeFilter).Include(x => x.Task().Project().Customer().Employee()));
            return this.View(items);
        }

        [HttpPost]
        public virtual ActionResult Accept(int id, string returnUrl)
        {
            var result = this.RedirectToLocalUrl(returnUrl, MVC.SpentTime.Index());
            return Handle(id, SpentTimeService.Accept, result, result, "Accepted");
        }

        [HttpPost]
        public virtual ActionResult Deny(int id, string returnUrl)
        {
            var result = this.RedirectToLocalUrl(returnUrl, MVC.SpentTime.Index());
            return Handle(id, SpentTimeService.Deny, result, result, "Denied");
        }

        #region Times
       
        public virtual ActionResult TimeList(int taskId)
        {

            var timeFilter = new SpentTimeFilter().ByTask(taskId);
            var times = SpentTimeService.GetAll(Query.ForSpentTime(timeFilter).Include(x => x.Employee()));
 
            var model = new TimeListViewModel() { Times = times };
            return PartialView("_ListTime", model);
        }

        public virtual ActionResult Create(int taskId)
        {
           var  spentTimeFilter = new SpentTimeFilter().ByTask(taskId);
            var items = SpentTimeService.GetAll(Query.ForSpentTime(spentTimeFilter));
            var timeCreate = new TimeViewModel
            {
                TaskId = taskId, EmployeeId = UserEmployeeId ?? 1,
                 TotalHours =  items.GroupBy(time => time.Hours).ToString()
            };

            return PartialView("_AddTimeForm", timeCreate);
        }

        // POST: /Employees/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(TimeViewModel model)
        {
            var entity = model.MapTo<SpentTimeOnTask>();

            return Handle(entity, SpentTimeService.SpentTimeOnTask, () => RedirectToAction(MVC.SpentTime.Create(model.TaskId.Value)), new EmptyResult());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Delete(int id, int taskId)
        {
            return Handle(id, SpentTimeService.Delete, () => RedirectToAction(MVC.SpentTime.Create(taskId)), new EmptyResult(), "Time successfully deleted");
        }
        #endregion
	}
}