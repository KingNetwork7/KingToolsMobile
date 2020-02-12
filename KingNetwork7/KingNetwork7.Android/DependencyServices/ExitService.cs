using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using KingNetwork7.Interfaces;
using Xamarin.Forms;

[assembly:Xamarin.Forms.Dependency(typeof(KingNetwork7.Droid.ExitService))]
namespace KingNetwork7.Droid
{
    public class ExitService : IExitService
    {
        [Obsolete]
        public void Exit()
        {
            var activity = (Activity)Forms.Context;
            activity.FinishAffinity();
        }
    }
}