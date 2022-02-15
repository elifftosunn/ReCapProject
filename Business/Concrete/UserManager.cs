using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(Users user)
        {
            if(user.FirstName == ""  || user.FirstName.Length<2 || user.LastName == "" || user.LastName.Length<2 || user.Password.Length<3)
            {
                return new ErrorResult(Messages.NameInvalid);
            }
            _userDal.Add(user);
            return new SuccessResult(Messages.Added);

        }

        public IResult Delete(Users user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Users> Get(int id)
        {
            return new SuccessDataResult<Users>(_userDal.Get(u => u.Id == id));
        }

        public IDataResult<List<Users>> GetAll()
        {
            return new SuccessDataResult<List<Users>>(_userDal.GetAll());
        }
        public IResult Update(Users user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Updated);
        }

        public IDataResult<List<UserDetailDto>> GetUserDetails()
        {
            return new SuccessDataResult<List<UserDetailDto>>();
        }
        public IDataResult<Users> GetByMail(string email)
        {
            return new SuccessDataResult<Users>(_userDal.Get(u => u.Email == email));
        }
    }
}
