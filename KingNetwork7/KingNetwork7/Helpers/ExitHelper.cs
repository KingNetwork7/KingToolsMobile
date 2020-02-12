using KingNetwork7.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingNetwork7.Helpers
{
    public static class ExitHelper
    {
        public static void Exit()
        {
            Xamarin.Forms.DependencyService.Get<IExitService>().Exit();
        }
    }
}
