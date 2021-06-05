using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal cardDal)
        {
            _creditCardDal = cardDal;
        }

        public IResult Add(CreditCard card)
        {
            _creditCardDal.Add(card);
            return new SuccessResult();
        }

        public IResult Delete(CreditCard card)
        {
            _creditCardDal.Delete(card);
            return new SuccessResult();
        }

        public IResult DeleteById(int cardId)
        {
            var card = _creditCardDal.Get(x => x.CardId == cardId);
            _creditCardDal.Delete(card);
            return new SuccessResult(Messages.CardDeleted);
        }

        public IDataResult<List<CreditCard>> GetAll()
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll());
        }

        public IDataResult<List<CreditCard>> GetAllCreditCardByCustomerId(int customerId)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll().Where(x => x.CustomerId == customerId).ToList());
        }

        public IDataResult<List<CreditCard>> GetByCardNumber(string cardNumber)
        {
            return new SuccessDataResult<List<CreditCard>>(_creditCardDal.GetAll(c => c.CardNumber == cardNumber));
        }

        public IDataResult<CreditCard> GetById(int carId)
        {
            return new SuccessDataResult<CreditCard>(_creditCardDal.Get(c => c.CardId == carId));
        }

        public IResult IsCardExist(CreditCard card)
        {
            var result = _creditCardDal.Get(c => c.NameOnTheCard == card.NameOnTheCard && c.CardNumber == card.CardNumber && c.CardCvv == card.CardCvv);
            if (result == null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }

        public IResult Update(CreditCard card)
        {
            _creditCardDal.Update(card);
            return new SuccessResult();
        }
    }
}
