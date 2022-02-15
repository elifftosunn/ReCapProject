using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<Users>> GetAll();
        IResult Add(Users user);
        IResult Delete(Users user);
        IResult Update(Users user);
        IDataResult<Users> Get(int id);
        IDataResult<List<UserDetailDto>> GetUserDetails();
        IDataResult<Users> GetByMail(string email);
    }
}
