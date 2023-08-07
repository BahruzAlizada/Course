using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.BusinessAspects.Autofac;
using BusinessLayer.Constants;
using CoreLayer.Aspects.Caching;
using CoreLayer.Utilities.Business;
using CoreLayer.Utilities.Results.Abstract;
using CoreLayer.Utilities.Results.Concrete;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using EntityLayer.DTOs;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;
        private readonly IMapper _mapper;
        public CategoryManager(ICategoryDal categoryDal,IMapper mapper)
        {
            _categoryDal= categoryDal;
            _mapper = mapper;
        }
        [SecuredOperation("admin")]
        [CacheRemoveAspect(("ICategoryService.Get"))]
        public IResult Add(CategoryForHomeDto category)
        {
            var result = BusinessRules.Run(CheckIfCategoryNameExisted(category.CategoryName));
            if(result !=null)
            {
                return result;
            }
            var cat = _mapper.Map<Category>(category);
            _categoryDal.Add(cat);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            _categoryDal.Delete(_categoryDal.Get(x=>x.Id==id));
            return new SuccessResult();
        }

        public IDataResult<List<CategoryForHomeDto>> GetAll()
        {
            var result = _mapper.Map<List<CategoryForHomeDto>>(_categoryDal.GetAll());
            return new SuccessDataResult<List<CategoryForHomeDto>>(result);
        }

        public IDataResult<CategoryForHomeDto> GetById(int id)
        {
           var result = _mapper.Map<CategoryForHomeDto>(_categoryDal.Get(x=>x.Id==id));
            return new SuccessDataResult<CategoryForHomeDto>(result);
        }

        public IResult Update(CategoryForHomeDto category)
        {
            var result = BusinessRules.Run(CheckIfCategoryNameExistedForUpdate(category.CategoryName, category.Id));
            if(result !=null)
            {
                return result;
            }
            var cat = _mapper.Map<Category>(category);
            _categoryDal.Update(cat);
            return new SuccessResult();
        }

        #region Business Code
        private IResult CheckIfCategoryNameExisted(string categoryName)
        {
            var result = _categoryDal.GetAll(x => x.CategoryName == categoryName).Any();
            if (result)
            {
                return new ErrorResult(Messages.CheckNameExisted);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryNameExistedForUpdate(string categoryName,int categoryId)
        {
            var result = _categoryDal.GetAll(x=>x.CategoryName==categoryName && x.Id!=categoryId).Any();
            if (result)
            {
                return new ErrorResult(Messages.CheckNameExisted);
            }
            return new SuccessResult();
        }
        #endregion
    }
}
