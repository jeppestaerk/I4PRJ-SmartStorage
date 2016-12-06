﻿using SmartStorage.BLL.Dtos;
using SmartStorage.BLL.Interfaces.Services;
using SmartStorage.BLL.Services;
using SmartStorage.DAL.Context;
using SmartStorage.DAL.UnitOfWork;
using SmartStorage.UI.ViewModels;
using SmartStorage.UI.ViewModels.Identity;
using System;
using System.Net;
using System.Web.Mvc;

namespace SmartStorage.UI.Controllers
{
  public class ProductsController : Controller
  {
    private readonly IProductService _productService;
    private readonly ICategoryService _categoryService;
    private readonly ISupplierService _supplierService;
    private readonly IWholesalerService _wholesalerService;

    public ProductsController()
      : this(new ProductService(new UnitOfWork(new ApplicationDbContext())), new CategoryService(new UnitOfWork(new ApplicationDbContext())), new SupplierService(new UnitOfWork(new ApplicationDbContext())), new WholesalerService(new UnitOfWork(new ApplicationDbContext())))
    {
    }

    public ProductsController(IProductService productService, ICategoryService categoryService, ISupplierService supplierService, IWholesalerService wholesalerService)
    {
      _productService = productService ?? new ProductService(new UnitOfWork(new ApplicationDbContext()));
      _categoryService = categoryService ?? new CategoryService(new UnitOfWork(new ApplicationDbContext()));
      _supplierService = supplierService ?? new SupplierService(new UnitOfWork(new ApplicationDbContext()));
      _wholesalerService = wholesalerService ?? new WholesalerService(new UnitOfWork(new ApplicationDbContext()));
    }

    public ActionResult Index(int? id)
    {
      if (id == null)
        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
      return View(User.IsInRole(UserRolesName.Admin) ? "Index" : "ReadOnlyIndex");
    }

    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Create()
    {
      var viewModel = new ProductViewModel
      {
        Product = new ProductDto(),
        Categories = _categoryService.GetAllActive(),
        Suppliers = _supplierService.GetAllActive(),
        Wholesalers = _wholesalerService.GetAllActive()
      };
      return View("Create", viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Create(ProductViewModel entityDto)
    {
      if (!ModelState.IsValid) return View(entityDto);

      entityDto.Product.Updated = DateTime.Now;
      entityDto.Product.ByUser = User.Identity.Name;
      _productService.Add(entityDto.Product);

      return RedirectToAction("Index");
    }

    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Edit(int id)
    {
      var entityDto = _productService.GetSingle(id);

      if (entityDto == null) return HttpNotFound();

      return View(entityDto);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = UserRolesName.Admin)]
    public ActionResult Edit(ProductDto entityDto)
    {
      if (!ModelState.IsValid) return View(entityDto);

      entityDto.Updated = DateTime.Now;
      entityDto.ByUser = User.Identity.Name;
      _productService.Update(entityDto);

      return RedirectToAction("Index");
    }
  }
}