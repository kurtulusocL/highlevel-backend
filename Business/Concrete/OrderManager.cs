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
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }

        [ValidationAspect(typeof(OrderValidator), Priority = 1)]
        public IResult Create(Order model)
        {
            _orderDal.Add(model);
            return new SuccessResult(Messages.OrderAdded);
        }

        [ValidationAspect(typeof(OrderValidator), Priority = 1)]
        public IResult Delete(Order model)
        {
            _orderDal.Delete(model);
            return new SuccessResult(Messages.OrderDeleted);
        }

        public IDataResult<List<Order>> GetAll()
        {
            return new SuccessDataResult<List<Order>>(_orderDal.GetAll(),Messages.OrdersListed);
        }

        public IDataResult<Order> GetById(int orderId)
        {
            return new SuccessDataResult<Order>(_orderDal.Get(i => i.OrderId == orderId),Messages.OrdersListed);
        }

        [ValidationAspect(typeof(OrderValidator), Priority = 1)]
        public IResult Update(Order model)
        {
            _orderDal.Update(model);
            return new SuccessResult(Messages.OrderUpdated);
        }
    }
}
