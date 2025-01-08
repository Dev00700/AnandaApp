using Dapper;
using MyApp.Models.Common;
using MyApp.Models;
using System.Collections.Generic;
using System;

namespace MyApp.BAL
{
    public static class ProductCategoryService
    {
        public static List<ProductCategoryDto> GetProductCategoryList()
        {
            List<ProductCategoryDto> res = new List<ProductCategoryDto>();
            try
            {
                string _proc = "Proc_ProductCategory";
                var queryparameter = new DynamicParameters();
                queryparameter.Add("@ProcId", 2);
                res = DBHelperDapper.GetAllModelList<ProductCategoryDto>(_proc, queryparameter);
            }
            catch (Exception ex) { }
            return res;
        }

        public static CommonResponseDto SaveProductCategory(ProductCategoryDto productCategory)
        {
            CommonResponseDto res = new CommonResponseDto();
            try
            {
                string _proc = "Proc_ProductCategory";
                var queryparameter = new DynamicParameters();
                queryparameter.Add("@ProcId", 1);
                queryparameter.Add("@PrdCatCode", productCategory.ProductCategoryCode);
                queryparameter.Add("@ZMGRP", productCategory.ZMGRP);
                queryparameter.Add("@ZSGRP1", productCategory.ZSGRP1);
                queryparameter.Add("@ZSGRP2", productCategory.ZSGRP2);
                queryparameter.Add("@ZSGRP3", productCategory.ZSGRP3);
                queryparameter.Add("@ZSGRP4", productCategory.ZSGRP4);
                queryparameter.Add("@ProductType", productCategory.ProductType);
                queryparameter.Add("@PackContains", productCategory.PackContains);
                queryparameter.Add("@ConversionRatio", productCategory.ConversionRatio);
                queryparameter.Add("@createdBy", SessionManager.UserId);
                queryparameter.Add("@IsActive", productCategory.IsActive);
                queryparameter.Add("@createdBy", SessionManager.UserId);
                CommonFunction.Printparameter(queryparameter, "Product Category paramer for saving:");//FOR WRITE LOG'
                res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            }
            catch (Exception ex) { }
            return res;
        }
        public static ProductCategoryDto GetProductCategory(string PrdCatGuid)
        {
            ProductCategoryDto res = new ProductCategoryDto();
            try
            {
                string _proc = "Proc_ProductCategory";
                var queryparameter = new DynamicParameters();
                queryparameter.Add("@ProcId", 3);
                queryparameter.Add("@PrdCatGuid", PrdCatGuid);
                CommonFunction.Printparameter(queryparameter, "Get Product Category:");//FOR WRITE LOG'
                res = DBHelperDapper.GetAllModel<ProductCategoryDto>(_proc, queryparameter);
            }
            catch (Exception ex) { }
            return res;
        }
        public static CommonResponseDto UpdateProductCategory(ProductCategoryDto productCategory)
        {
            CommonResponseDto res = new CommonResponseDto();
            try
            {
                string _proc = "Proc_ProductCategory";
                var queryparameter = new DynamicParameters();
                queryparameter.Add("@ProcId", 4);
                queryparameter.Add("@PrdCatCode", productCategory.ProductCategoryCode);
                queryparameter.Add("@ZMGRP", productCategory.ZMGRP);
                queryparameter.Add("@ZSGRP1", productCategory.ZSGRP1);
                queryparameter.Add("@ZSGRP2", productCategory.ZSGRP2);
                queryparameter.Add("@ZSGRP3", productCategory.ZSGRP3);
                queryparameter.Add("@ZSGRP4", productCategory.ZSGRP4);
                queryparameter.Add("@ProductType", productCategory.ProductType);
                queryparameter.Add("@PackContains", productCategory.PackContains);
                queryparameter.Add("@ConversionRatio", productCategory.ConversionRatio);
                queryparameter.Add("@ModifiedBy", SessionManager.UserId);
                queryparameter.Add("@IsActive", productCategory.IsActive);
                queryparameter.Add("@PrdCatGuid", productCategory.ProductCategoryGuid);
                CommonFunction.Printparameter(queryparameter, "Product Category paramer for updating:");//FOR WRITE LOG'
                res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            }
            catch (Exception ex) { }
            return res;
        }

        public static CommonResponseDto CheckProductCategory(long productcategorycode)
        {
            CommonResponseDto res = new CommonResponseDto();
            try
            {
                string _proc = "Proc_ProductCategory";
                var queryparameter = new DynamicParameters();
                queryparameter.Add("@ProcId", 5);
                queryparameter.Add("@PrdCatCode", productcategorycode);
                res = DBHelperDapper.GetAllModel<CommonResponseDto>(_proc, queryparameter);
            }
            catch (Exception ex) { }
            return res;
        }
    }
}
