using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
   public interface ICreditCardService 
    {
        IDataResult<List<CreditCard>> GetByCardNumber(string cardNumber);
        IDataResult<List<CreditCard>> GetAll();
        IDataResult<CreditCard> GetById(int carId);
        IResult IsCardExist(CreditCard card);
        IResult Add(CreditCard card);
        IResult Update(CreditCard card);
        IResult Delete(CreditCard card);
        IResult DeleteById(int cardId);
        IDataResult<List<CreditCard>> GetAllCreditCardByCustomerId(int customerId);
    }
}
