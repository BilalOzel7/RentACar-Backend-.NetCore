using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapProjectContext>, ICarDal
    {


        //public List<CarDetailDto> GetCarDetails()
        //{
        //    using (ReCapProjectContext context = new ReCapProjectContext())
        //    {
        //        var result = from c in context.Cars
        //                     join b in context.Brands on c.BrandId equals b.BrandId
        //                     join clr in context.Colors on c.ColorId equals clr.ColorId
        //                     select new CarDetailDto()
        //                     {
        //                         CarId = c.CarId,
        //                         BrandId = c.BrandId,
        //                         BrandName = b.Brandname,
        //                         ColorName = clr.ColorName,
        //                         modelYear = c.ModelYear,
        //                         Images = (from i in context.CarImages where i.CarId == c.CarId select i.ImagePath).ToList(),
        //                         DailyPrice = c.DailyPrice,
        //                         Description = c.Description,
        //                     };
        //        return result.ToList();
        //    }
        //}

        //public List<CarDetailDto> GetCarDetailsById(Expression<Func<Car, bool>> filter)
        //{
        //    using (ReCapProjectContext context = new ReCapProjectContext())
        //    {
        //        var result =
        //            from car in filter == null ? context.Cars : context.Cars.Where(filter)
        //            join brand in context.Brands on car.BrandId equals brand.BrandId
        //            join color in context.Colors on car.ColorId equals color.ColorId
        //            select new CarDetailDto()
        //            {
        //                CarId = car.CarId,
        //                BrandName = brand.Brandname,
        //                ColorName = color.ColorName,
        //                modelYear = car.ModelYear,
        //                Images =
        //                    (from i in context.CarImages where i.CarId == car.CarId select i.ImagePath).ToList(),
        //                DailyPrice = car.DailyPrice,
        //                Description = car.Description
        //            };
        //        return result.ToList();
        //    }

        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto, bool>> filter=null )
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var result = from ca in context.Cars
                             join b in context.Brands
                             on ca.BrandId equals b.BrandId
                             join co in context.Colors
                             on ca.ColorId equals co.ColorId
                             select new CarDetailDto
                             {

                                 CarId = ca.CarId,
                                 BrandId = ca.BrandId,
                                 ColorId = ca.ColorId,
                                 CarName = ca.CarName,
                                 BrandName = b.Brandname,
                                 ColorName = co.ColorName,
                                 DailyPrice = ca.DailyPrice,
                                 modelYear = ca.ModelYear,
                                 Description = ca.Description,
                                 CarImage = (from i in context.CarImages
                                             where ca.CarId == i.CarId
                                             select new CarImage { Id = i.Id, CarId = i.CarId, ImagePath = i.ImagePath, Date = i.Date }).ToList()


                             };

                return filter == null ? result.ToList() : result.Where(filter).ToList();
            }
        }

        
    }
}

       
    

