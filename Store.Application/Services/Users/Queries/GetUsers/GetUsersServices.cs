﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Common;
using Store.Common.Constant.NoImage;
using Store.Domain.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersServices : IGetUsersServices
    {
        private readonly UserManager<User> _userManager;
        private readonly IDatabaseContext _databaseContext;
        public GetUsersServices(UserManager<User> userManager, IDatabaseContext databaseContext)
        {
          _userManager = userManager;
            _databaseContext= databaseContext;
        }
        public async Task<ResultGetUsersDto> Execute(RequestGetUsersDto request)
        {
            var users = _userManager.Users.Include(y => y.Contacts).ThenInclude(c => c.ContactType).AsQueryable();
            if (!string.IsNullOrWhiteSpace(request.SearchKey))
            {
                users = users.Where(p => p.FullName.Contains(request.SearchKey) || p.LastName.Contains(request.SearchKey));
            }
            //var contact = await _databaseContext.Contacts.Where(r => r.UserId == r.Id.ToString()).ToListAsync();
            int RowsCount = 0;
            return new ResultGetUsersDto
            {
                Rows = RowsCount,
                Users = users.Select(p => new GetUsersDto

                {
                    FullName = p.FullName,
                    Id = p.Id,
                    IsActived = p.IsActive,
                    Email = p.Email,
                    PhoneNumber = p.PhoneNumber,
                    Contacts = p.Contacts.Select(r => new ContactDto()
                    {
                        ContactValue = r.ContactType.Icon,
                        IconContact = r.Value,
                    }).ToList(),
                    ProfileImage=string.IsNullOrEmpty(p.ProfileImage)?ImageProductConst.ProfileAdmin:p.ProfileImage,
                }
               ).ToPaged(request.Page, request.PageSize, out RowsCount).ToList(),
                Pageinate= Pagination.PaginateAdmin(request.Page,request.PageSize,RowsCount,"users",request.SearchKey,request.Tag,request.Category),
            };
        }
    }
}
