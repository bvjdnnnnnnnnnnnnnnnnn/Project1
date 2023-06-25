using ASP.NETCoreIdentityCustom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class ManagerController : Controller
{
    private readonly TaskManagementContext _dbContext;

    public ManagerController(TaskManagementContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET: /manager
    public IActionResult Index()
    {
        var model = new ManagerViewModel
        {
            Assignments = _dbContext.Assignments.ToList()
        };

        return View(model);
    }

    // GET: /manager/create
    public IActionResult Create()
    {
        var model = new ManagerViewModel();
        LoadAssigneeList();
        return View(model);
    }

    // POST: /manager/create
    [HttpPost]
    public IActionResult Create(ManagerViewModel model)
    {
        if (ModelState.IsValid)
        {
            var assignment = new Assignment
            {
                Task = model.Task,
                AssigneeId = model.AssigneeId,
                DueDate = model.DueDate
            };

            _dbContext.Assignments.Add(assignment);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        LoadAssigneeList();
        return View(model);
    }

    private void LoadAssigneeList()
    {
        var assigneeList = _dbContext.Users
            .Select(u => new SelectListItem
            {
                Value = u.Id,
                Text = u.UserName
            })
            .ToList();

        ViewBag.AssigneeList = assigneeList;
    }
}

