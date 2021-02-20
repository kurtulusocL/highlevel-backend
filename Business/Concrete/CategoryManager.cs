using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        [ValidationAspect(typeof(CategoryValidator), Priority = 1)]
        public IResult Create(Category model)
        {
            _categoryDal.Add(model);
            return new SuccessResult(Messages.CategoryAdded);
        }

        [ValidationAspect(typeof(CategoryValidator), Priority = 1)]
        public IResult Delete(Category model)
        {
            _categoryDal.Delete(model);
            return new SuccessResult(Messages.CategoryDeleted);
        }

        public IDataResult<List<Category>> GetAll()
        {
            return new SuccessDataResult<List<Category>>(_categoryDal.GetAll(),Messages.CategoryListed);
        }

        public IDataResult<Category> GetById(int categoryId)
        {
           return new SuccessDataResult<Category>(_categoryDal.Get(i => i.CategoryId == categoryId),Messages.CategoryListed);
        }

        [ValidationAspect(typeof(CategoryValidator), Priority = 1)]
        public IResult Update(Category model)
        {
            _categoryDal.Update(model);
            return new SuccessResult(Messages.CategoryUpdated);
        }
    }
}
