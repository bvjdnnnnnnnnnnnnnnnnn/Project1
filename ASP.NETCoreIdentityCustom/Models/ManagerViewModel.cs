using ASP.NETCoreIdentityCustom.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class ManagerViewModel
{
    [Required(ErrorMessage = "Поле 'Задание' обязательно для заполнения.")]
    public string Task { get; set; }

    [Required(ErrorMessage = "Поле 'Дата исполнения' обязательно для заполнения.")]
    public DateTime DueDate { get; set; }

    [Required(ErrorMessage = "Поле 'Исполнитель' обязательно для выбора.")]
    public string AssigneeId { get; set; }

    public List<SelectListItem> AssigneeList { get; set; }

    public List<Assignment> Assignments { get; set; }

    public ManagerViewModel()
    {
        AssigneeList = new List<SelectListItem>();
        Assignments = new List<Assignment>();
    }
}

public class Assignment
{
    public string AssigneeId { get; internal set; }
    public string Task { get; internal set; }
    public DateTime DueDate { get; internal set; }
    public object Assignee { get; internal set; }
}