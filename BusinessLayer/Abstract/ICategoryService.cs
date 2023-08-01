using CoreLayer.Utilities.Results.Abstract;
using EntityLayer.DTOs;
using System;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        IDataResult<List<CategoryForHomeDto>> GetAll();
        IDataResult<CategoryForHomeDto> GetById(int id);
        IResult Add(CategoryForHomeDto category);
        IResult Update(CategoryForHomeDto category);
        IResult Delete(int id);
    }
}
