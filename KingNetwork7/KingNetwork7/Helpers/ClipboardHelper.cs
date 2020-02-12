using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace KingNetwork7.Helpers
{
    public static class ClipboardHelper
    {
        public static async Task SetClipboard(string text)
        {
            await Clipboard.SetTextAsync(text);
        }

        public static async Task<string> GetClipboard()
        {
            return await Clipboard.GetTextAsync();
        }
    }
}
