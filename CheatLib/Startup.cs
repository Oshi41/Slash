﻿using System;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace CheatLib
{
    static class Startup
    {
        /// <summary>
        /// Enter point from DLL loading
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        [STAThread]
        static int Main(string arg)
        {
            Main();
            return 0;
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += (sender, args) =>
            {
                Console.Error.WriteLine(args.Exception);
                MessageBox.Show("Exception");
            };

            if (!CookieManager.INSTANCE.CheckAuthenticationAsync().Result)
            {
                var form = new AuthForm();
                var dialogResult = form.ShowDialog();
                if (dialogResult != DialogResult.OK && form.DialogResult != DialogResult.OK)
                    return;
            }

            Application.Run(new Form1());
        }
    }
}