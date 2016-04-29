﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using PinBuster.Data;
using PinBuster.Pages;
using PinBuster;
namespace PinBuster
{
    public class App : Application
    {
        static public double lat, lng;
        IGetCurrentPosition loc;

        private readonly static Locator _locator = new Locator();

        public static PinsManager PinsManager { get; private set; }

        public static Locator Locator
        {
            get { return _locator; }
        }

        public App()
        {


            // The root page of your application
            //PinsManager = new PinsManager();
            //MainPage = new MapPage();
            MainPage = new UserPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            loc = DependencyService.Get<IGetCurrentPosition>();
            loc.locationObtained += (object sender,
                ILocationEventArgs e) =>
            {
                lat = e.lat;
                lng = e.lng;
               // System.Diagnostics.Debug.WriteLine("Lat: " + lat + " Lon: " + lng);
            };
            loc.IGetCurrentPosition();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            System.Diagnostics.Debug.WriteLine("teste1");
        }
    }
}
