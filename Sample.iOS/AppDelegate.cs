﻿using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Sample.Pcl;
using Cp.Barcode.iOS;
using System.Collections.Generic;
using Cp.Barcode.Pcl;

namespace Sample.iOS
{
    [Register("AppDelegate")]
    public class AppDelegate : FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();
            BarcodeScannerRenderer.Init(
                new Configuration { 
                    Barcodes = new List<Barcode.BarcodeFormat> { 
                        Barcode.BarcodeFormat.Ean13,
                        Barcode.BarcodeFormat.Ean8,
                        Barcode.BarcodeFormat.Intervealed2of5
                    }
                }
            );

            LoadApplication(new App());

            return base.FinishedLaunching (app, options);
        }
    }
}
