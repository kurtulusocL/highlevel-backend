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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        [ValidationAspect(typeof(CustomerValidator), Priority = 1)]
        public IResult Create(Customer model)
        {
            _customerDal.Add(model);
            return new SuccessResult(Messages.CustomerAdded);
        }

        [ValidationAspect(typeof(CustomerValidator), Priority = 1)]
        public IResult Delete(Customer model)
        {
            _customerDal.Delete(model);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll(), Messages.CusromerListed);
        }

        public IDataResult<Customer> GetById(string customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(i => i.CustomerId == customerId),Messages.CusromerListed);
        }

        [ValidationAspect(typeof(CustomerValidator), Priority = 1)]
        public IResult Update(Customer model)
        {
            _customerDal.Update(model);
            return new SuccessResult(Messages.CustomerUpdated);
        }
    }
}
