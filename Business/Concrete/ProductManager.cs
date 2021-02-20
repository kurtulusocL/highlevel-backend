using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Create(Product product)
        { 
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        [ValidationAspect(typeof(ProductValidator), Priority = 1)]
        public IResult Delete(Product model)
        {
            _productDal.Delete(model);
            return new SuccessResult(Messages.ProductDeleted);
        }

        public IDataResult<List<Product>> GetAll()
        {            
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id));
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(i => i.ProductId == id));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(i => i.UnitPrice >= min && i.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetials()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetials());
        }

        [ValidationAspect(typeof(ProductValidator), Priority = 1)]
        public IResult Update(Product model)
        {
            _productDal.Update(model);
            return new SuccessResult(Messages.ProductDeleted);
        }
    }
}
