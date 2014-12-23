﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Jarboo.Admin.BL.Models;
using Jarboo.Admin.DAL;
using Jarboo.Admin.DAL.Entities;
using Task = Jarboo.Admin.DAL.Entities.Task;

namespace Jarboo.Admin.BL.Services
{
    public interface ITaskService
    {
        Task GetById(int id);
        List<Task> GetAll();

        void Create(TaskCreate model, IBusinessErrorCollection errors);
    }

    public class TaskService : BaseEntityService<Task>, ITaskService
    {
        public TaskService(IUnitOfWork UnitOfWork)
            : base(UnitOfWork)
        { }

        protected override System.Data.Entity.IDbSet<Task> Table
        {
            get { return UnitOfWork.Tasks; }
        }

        public override Task GetById(int id)
        {
            return Table.Include(x => x.Project.Customer).FirstOrDefault(x => x.TaskId == id);
        }

        public List<Task> GetAll()
        {
            return Table.Include(x => x.Project)
                .AsEnumerable()
                .ToList();
        }

        public void Create(TaskCreate model, IBusinessErrorCollection errors)
        {
            if (!model.Validate(errors))
            {
                return;
            }

            var entity = Table.Add(new Task());
            Add(entity, model);
        }
    }
}
