using Microsoft.EntityFrameworkCore;
using Store.Application.Interfaces.Contexs;
using Store.Application.Services.ContactsUs.Queries.GetAlarmContactUs;
using Store.Application.Services.Langueges.Queries;
using Store.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Services.Notification.Queries.GetAllNotification
{
    public interface IGetAllNotificationService
    {
        Task<ListNotification> Execute();
    }
    public class GetAllNotificationService : IGetAllNotificationService
    {
        private readonly IDatabaseContext _context;
        private readonly IGetSelectedLanguageServices _language;
        public GetAllNotificationService(IDatabaseContext context, IGetSelectedLanguageServices languege)
        {
            _context = context;
            _language = languege;
        }
        public async Task<ListNotification> Execute()
        {
            string languageId = _language.Execute().Result.Data.Id ?? "";
            if (string.IsNullOrEmpty(languageId))
            {
                return new ListNotification
                {

                };
            }
            //Notif ContactUs
            var ListNotifContactUs = await _context.ContactUs
                .Where(w => w.LanguageId == languageId &&w.Seen == false)
                .OrderByDescending(e=>e.InsertTime).
                Take(5).ToListAsync();
            //Notif RegisterCarpet
            var ListRegisterCarpet = await _context.RegisterCarpets
                .Where(w => w.LanguageId == languageId && w.Seen == false)
                .OrderByDescending(e => e.InsertTime).
                Take(5).ToListAsync();
            return new ListNotification
            { 

            ListContactUS=ListNotifContactUs.Select(w=>new ContactUs
            {
                Id=w.Id,
                Name = w.Name,
                Description = w.Text,
                InsertTime= Assistants.ConvertToMorningAndEvening(w.InsertTime),
            }).ToList(),
            //
            ListRegisterCarpets= ListRegisterCarpet.Select(w => new RegisterCarpet
            {
                Id = w.Id,
                Name = w.Name,
                Email = w.Email,
                InsertTime = Assistants.ConvertToMorningAndEvening(w.InsertTime),
            }).ToList()
            };
        }
    }
    public class ListNotification
    {
        public List<ContactUs> ListContactUS { get; set; }
        public List<RegisterCarpet> ListRegisterCarpets { get; set; }
    }
   public class ContactUs
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? InsertTime { get; set; }
        public string? Description { get; set; }
    }
    public class RegisterCarpet
    {
        public string Id { get; set; }
        public string? Name { get; set; }
        public string? InsertTime { get; set; }
        public string? Email { get; set; }
    }

}
