using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<Users, NorthwindContext>, IUserDal
    {
        /*
        public List<UserDetailDto> GetUserDetails()
        {
            
            using (NorthwindContext context=new NorthwindContext())
            {
                var result=from u in context.Users
                           join c in context.Customer
                           on 
            }
        }*/
    }
}
