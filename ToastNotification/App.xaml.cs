﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ToastFinalTest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            // Register AUMID, COM server, and activator
            DesktopNotificationManagerCompat.RegisterAumidAndComServer<MyNotificationActivator>("WindowsNotifications.DesktopToasts");
            DesktopNotificationManagerCompat.RegisterActivator<MyNotificationActivator>();

            // If launched from a toast
            // This launch arg was specified in our WiX installer where we register the LocalServer32 exe path.
            if (e.Args.Contains(DesktopNotificationManagerCompat.TOAST_ACTIVATED_LAUNCH_ARG))
            {
                // Our NotificationActivator code will run after this completes,
                // and will show a window if necessary.
            }

            else
            {
                // Show the window
                // In App.xaml, be sure to remove the StartupUri so that a window doesn't
                // get created by default, since we're creating windows ourselves (and sometimes we
                // don't want to create a window if handling a background activation).
                new MainWindow().Show();
            }

            base.OnStartup(e);
        }
    }
}
