using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ICustomerService
    {
        IDataResult<List<Customer>> GetAll();
        IDataResult<Customer> GetByID(int ID);
        IResult Add(Customer entity);
        IResult Update(Customer entity);
        IResult Delete(Customer entity);
        IDataResult<List<CustomerDetailDto>> GetCustomerDetail();
        IDataResult<List<CustomerDetailDto>> GetCustomerDetailById(int customerId);
        IDataResult<CustomerDetailDto> getCustomerByEmail(string email);
    }
}
