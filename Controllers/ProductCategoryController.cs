using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MyApp.BAL;
using MyApp.Models;
using System.Collections.Generic;
using System.Linq;
using System;
using MyApp.Models.Base;
using X.PagedList.Extensions;

namespace MyApp.Controllers
{
    [CustomAuthenticationFilter]
    public class ProductCategoryController : BaseController
    {
        private string MenuCode = "M0011";
        public ProductCategoryController(IConfiguration configuration) : base(configuration)
        {
        }


        [HttpGet]
        public IActionResult Save(string? id)
        {
            ProductCategoryDto res = new ProductCategoryDto();
            ViewBag.Button = "Submit";
            res.IsActive = true;
            if (id != null)
            {
                res = ProductCategoryService.GetProductCategory(id);
                ViewBag.Button = "Update";
            }
            return View(res);
        }

        public JsonResult Save([FromBody] ProductCategoryDto productCategory)
        {
            var result = (CommonResponseDto?)null;
            if (productCategory.ProductCategoryGuid == Guid.Empty)
            {
                result = ProductCategoryService.CheckProductCategory(productCategory.ProductCategoryCode);
                if (result != null) 
                {
                    return Json(result);
                }
            }
            if (productCategory.ProductCategoryGuid == Guid.Empty)
            {
                result = ProductCategoryService.SaveProductCategory(productCategory);
            }
            else
            {
                result = ProductCategoryService.UpdateProductCategory(productCategory);
            }

            return Json(result);
        }
        [HttpGet]
        public IActionResult Index(int? page)
        {
            var authres = CommonService.GetAddEditAuthorization(MenuCode);
            ViewBag.Add = authres.ForAdd;
            ViewBag.Edit = authres.ForEdit;
            List<ProductCategoryDto> res = ProductCategoryService.GetProductCategoryList();
            return View(res.ToPagedList(page ?? 1, PageRecordCount));
        }
        public IActionResult GetPagedProductCategory(int page, int rowperpage, string prdcatcode, string producttype, string zmgrp)
        {
            var pageSize = rowperpage != 0 ? rowperpage : PageRecordCount;
            var res = ProductCategoryService.GetProductCategoryList();

            var filters = new Dictionary<string, string>
                   {
                     { "ProductCategoryCode", prdcatcode },
                     { "ProductType", producttype },
                     { "ZMGRP",zmgrp }
                   };
            IQueryable<ProductCategoryDto> query = res.AsQueryable(); // employeeList is your data source
            query = query.ApplyFilters(filters);
            return PartialView("_ProductCategoryTable", query.ToPagedList(page, pageSize));

        }

        public IActionResult CheckProductCategoryCode(long ProductCategoryCode)
        {
            CommonResponseDto res = ProductCategoryService.CheckProductCategory(ProductCategoryCode);
            return Json(res);
        }
    }
}
