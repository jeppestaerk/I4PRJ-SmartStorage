﻿using System;
using System.Web.Mvc;
using I4PRJ_SmartStorage.BLL.Dtos;
using I4PRJ_SmartStorage.BLL.Interfaces.Services;
using I4PRJ_SmartStorage.BLL.Services;
using I4PRJ_SmartStorage.DAL.Context;
using I4PRJ_SmartStorage.DAL.UnitOfWork;
using I4PRJ_SmartStorage.UI.ViewModels.Identity;

namespace I4PRJ_SmartStorage.UI.Controllers
{
  public class CategoriesController : Controller
  {
    private readonly ICategoryService _service;

    public CategoriesController()
      : this(new CategoryService(new UnitOfWork(new ApplicationDbContext())))
    {
    }

    public CategoriesController(ICategoryService service)
    {
      _service = service ?? new CategoryService(new UnitOfWork(new ApplicationDbContext()));
    }

    public ActionResult Index()
    {
      return View(User.IsInRole(UserRolesName.Admin) ? "Index" : "ReadOnlyIndex");
    }

    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Create()
    {
      return View("Create");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Create(CategoryDto entityDto)
    {
      if (!ModelState.IsValid) return View(entityDto);

      entityDto.Updated = DateTime.Now;
      entityDto.ByUser = User.Identity.Name;
      _service.Add(entityDto);

      return RedirectToAction("Index");
    }

    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Edit(int id)
    {
      var entityDto = _service.GetSingle(id);

      if (entityDto == null) return HttpNotFound();

      return View(entityDto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Edit(CategoryDto entityDto)
    {
      if (!ModelState.IsValid) return View(entityDto);

      entityDto.Updated = DateTime.Now;
      entityDto.ByUser = User.Identity.Name;
      _service.Update(entityDto);

      return RedirectToAction("Index");
    }
  }
}