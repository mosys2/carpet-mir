using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastracture.MessageManager
{
    public class MessageManager<T>
    {
        private readonly Dictionary<string, Dictionary<string, T>> _languageMessages;

        public MessageManager()
        {
            _languageMessages = new Dictionary<string, Dictionary<string, T>>();
        }

        public void AddLanguage(string languageCode, Dictionary<string, T> messages)
        {
            _languageMessages[languageCode] = messages;
        }

        public T GetMessage(string languageCode, string messageKey)
        {
            if (_languageMessages.ContainsKey(languageCode) && _languageMessages[languageCode].ContainsKey(messageKey))
            {
                return _languageMessages[languageCode][messageKey];
            }
            // در صورتی که پیامی برای زبان یا کلید مشخص شده یافت نشود، می‌توانید یک پیشفرض یا پیام خطایی برگردانید.
            return default(T);
        }
    }
}
