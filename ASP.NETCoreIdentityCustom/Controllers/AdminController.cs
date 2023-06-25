using ASP.NETCoreIdentityCustom.Areas.Identity.Data;
using ASP.NETCoreIdentityCustom.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

public class AdminController : Controller
{
    private readonly TaskManagementContext _dbContext;

    public AdminController(TaskManagementContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET: /admin
    public IActionResult Index()
    {
        var model = new AdminViewModel
        {
            Users = _dbContext.Users.ToList()
        };

        return View(model);
    }

    // POST: /admin/submit
    [HttpPost]
    public IActionResult Submit(AdminViewModel model)
    {
        if (ModelState.IsValid)
        {
            // Создание нового поручения
            var assignment = new Assignment
            {
                Task = model.Task,
                AssigneeId = model.AssigneeId,
                DueDate = model.DueDate,
                // Дополнительная логика для обработки файла
                // model.File содержит загруженный файл
            };

            _dbContext.Assignments.Add(assignment);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", "Manager");
        }

        // Если модель недопустима, возвращаем представление снова
        model.Users = _dbContext.Users.ToList();
        return View("Index", model);
    }
}

internal class TaskManagementContext : DbContext
{
    public DbSet<Assignment> Assignments { get; set; }
    public DbSet<ApplicationUser> Users { get; set; }

    public TaskManagementContext(DbContextOptions<TaskManagementContext> options)
        : base(options)
    {
    }
}

