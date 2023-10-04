using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Common.Constant;
using Store.Common.Constant.TypeOfCategoryFeature;
using Store.Common.Dto;
using Store.Domain.Entities.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Products.Commands.RemoveCategoryFeature
{
    public interface IRemoveCategoryFeatureService
    {
        Task<ResultDto> Execute(string Id,string TypeOfCategoeyFature);
    }
    public class RemoveCategoryFeatureService : IRemoveCategoryFeatureService
    {
        private readonly IDatabaseContext _context;

        public RemoveCategoryFeatureService(IDatabaseContext context)
        {
            _context = context;
        }
        public async Task<ResultDto> Execute(string Id, string TypeOfCategoeyFature)
        {
            //Remove Logical
            //if(TypeOfCategoryFeature.Color==TypeOfCategoeyFature)
            //{
            //    var color = await _context.ItemColors.FindAsync(Id);
            //    if (color == null)
            //    {
            //        return new ResultDto()
            //        {
            //            IsSuccess = false,
            //            Message = MessageInUser.NotFind
            //        };
            //    }
            //    color.RemoveTime = DateTime.Now;
            //    color.IsRemoved = true;
            //    await _context.SaveChangesAsync();
            //    return new ResultDto()
            //    {
            //        IsSuccess = true,
            //        Message = MessageInUser.Delete
            //    };
            //}
            //if (TypeOfCategoryFeature.Material == TypeOfCategoeyFature)
            //{
            //    var material = await _context.ItemMaterials.FindAsync(Id);
            //    if (material == null)
            //    {
            //        return new ResultDto()
            //        {
            //            IsSuccess = false,
            //            Message = MessageInUser.NotFind
            //        };
            //    }
            //    material.RemoveTime = DateTime.Now;
            //    material.IsRemoved = true;
            //    await _context.SaveChangesAsync();
            //    return new ResultDto()
            //    {
            //        IsSuccess = true,
            //        Message = MessageInUser.Delete
            //    };
            //}
            //if (TypeOfCategoryFeature.Size == TypeOfCategoeyFature)
            //{
            //    var size = await _context.ItemSizes.FindAsync(Id);
            //    if (size == null)
            //    {
            //        return new ResultDto()
            //        {
            //            IsSuccess = false,
            //            Message = MessageInUser.NotFind
            //        };
            //    }
            //    size.RemoveTime = DateTime.Now;
            //    size.IsRemoved = true;
            //    await _context.SaveChangesAsync();
            //    return new ResultDto()
            //    {
            //        IsSuccess = true,
            //        Message = MessageInUser.Delete
            //    };
            //}
            //if (TypeOfCategoryFeature.Shape == TypeOfCategoeyFature)
            //{
            //    var shape = await _context.ItemColors.FindAsync(Id);
            //    if (shape == null)
            //    {
            //        return new ResultDto()
            //        {
            //            IsSuccess = false,
            //            Message = MessageInUser.NotFind
            //        };
            //    }
            //    shape.RemoveTime = DateTime.Now;
            //    shape.IsRemoved = true;
            //    await _context.SaveChangesAsync();
            //    return new ResultDto()
            //    {
            //        IsSuccess = true,
            //        Message = MessageInUser.Delete
            //    };
            //}
            //else
            //{
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = MessageInUser.NotFind
                };
            //}
        }
    }

}
