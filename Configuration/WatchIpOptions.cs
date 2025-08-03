using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchIp.SDK.Configuration
{
    public class WatchIpOptions
    {
        public string? TelegramBotToken { get; set; }
        public string? TelegramChatId { get; set; }
        public string[]? BlockCountries { get; set; } = { "RU", "BY" };
    }
}
