﻿using Microsoft.Extensions.Configuration;

namespace Pump
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("//MainPage", typeof(MainPage));
        }
    }
}