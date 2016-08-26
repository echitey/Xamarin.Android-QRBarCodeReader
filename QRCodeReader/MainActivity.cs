using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using ZXing.Mobile;
using System.Collections.Generic;

namespace QRCodeReader
{
    [Activity(Label = "QRCodeReader", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            MobileBarcodeScanner.Initialize(Application);
            // Get our button from the layout resource,
            // and attach an event to it
            Button button = FindViewById<Button>(Resource.Id.btnScan);

            button.Click += async delegate {
                var scanner = new MobileBarcodeScanner();
                var options = new MobileBarcodeScanningOptions();
                options.PossibleFormats = new List<ZXing.BarcodeFormat>() {
                        ZXing.BarcodeFormat.QR_CODE, ZXing.BarcodeFormat.CODE_128
                };

                var result = await scanner.Scan();
                Toast.MakeText(this, result.Text, ToastLength.Short).Show();
            };
        }
    }
}

