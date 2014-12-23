﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Jarboo.Admin.BL.Models;
using Jarboo.Admin.BL.Services;
using Jarboo.Admin.DAL.Entities;

using Ninject;

namespace Jarboo.Admin.Web.Controllers
{
    public partial class TasksController : BaseController
    {
        [Inject]
        public ITaskService TaskService { get; set; }

        [Inject]
        public IProjectService ProjectService { get; set; }

        // GET: /Tasks/
        public virtual ActionResult Index()
        {
            return View(TaskService.GetAll());
        }

        // GET: /Tasks/View/5
        public virtual ActionResult View(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Task task = TaskService.GetById(id.Value);
            if (task == null)
            {
                return HttpNotFound();
            }
            return View(task);
        }

        // GET: /Task/Create
        public virtual ActionResult Create(int? projectId)
        {
            var task = new TaskCreate();
            if (projectId.HasValue)
            {
                task.ProjectId = projectId.Value;
            }

            ViewBag.ProjectsList = new SelectList(ProjectService.GetAll(), "ProjectId", "Name", "Customer.Name", task.ProjectId);
            return View(task);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Create(TaskCreate model)
        {
            return Handle(
                model,
                TaskService.Create,
                () => RedirectToAction(MVC.Tasks.View(model.TaskId)),
                RedirectToAction(MVC.Tasks.Create()));
        }
    }
}