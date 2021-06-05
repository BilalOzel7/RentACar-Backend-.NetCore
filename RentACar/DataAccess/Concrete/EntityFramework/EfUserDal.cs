using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
   public class EfUserDal : EfEntityRepositoryBase<User,ReCapProjectContext>, IUserDal
    {//db deki ıd lere bakıp user id ile eşleştiriyor ve claim lerini çıkarıyor
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapProjectContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public UserDetailDto GetUserDetail(Expression<Func<UserDetailDto, bool>> filter)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.UserId equals c.UserId
                             join r in context.Rentals
                             on c.CustomerId equals r.CustomerId
                             join car in context.Cars on r.CarId equals car.CarId
                             join b in context.Brands on car.BrandId equals b.BrandId
                             

                             select new UserDetailDto()
                             {
                                 CarName = car.CarName,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = c.CompanyName,
                                 Email = u.Email,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 BrandName = b.Brandname,
                                 UserId = u.UserId,
                             };
                return result.SingleOrDefault(filter);
            }
        }
        public List<UserDetailDto> GetUserDetails(Expression<Func<User, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from u in context.Users
                             join c in context.Customers
                             on u.UserId equals c.UserId
                             join r in context.Rentals
                             on c.CustomerId equals r.CustomerId
                             join car in context.Cars on r.CarId equals car.CarId
                             join b in context.Brands on car.BrandId equals b.BrandId
                            

                             select new UserDetailDto
                             {

                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CompanyName = c.CompanyName,
                                 Email = u.Email,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate,
                                 CarName = car.CarName,
                                 BrandName = b.Brandname,
                                 UserId = u.UserId,
                                



                             };
                return result.ToList();
            }

        }
    }
}
