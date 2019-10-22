using System;
using Android.Content;
using Android.Gms.Vision;
using Android.Gms.Vision.Barcodes;
using Com.Rebuy.Play.Services.Vision;
using Cp.Barcode.Droid.Camera;
using Cp.Barcode.Droid.View;
using Cp.Barcode.Pcl;
using RebuyCameraSource = Com.Rebuy.Play.Services.Vision.CameraSource;

namespace Cp.Barcode.Droid.Camera
{
    public class CameraServiceFactory
    {
        public CameraService Create(Context context, BarcodeScanner barcodeScanner, CameraConfigurator configurator)
        {
            var cameraSource = createCameraSource(context, barcodeScanner, configurator);

            return new CameraService(barcodeScanner, cameraSource, configurator);
        }

        private RebuyCameraSource createCameraSource(Context context, BarcodeScanner barcodeScanner, CameraConfigurator configurator)
        {
            var barcodeDetector = new BarcodeDetector.Builder(context).Build();
            var barcodeFactory = new BarcodeTrackerFactory(barcodeScanner);
            barcodeDetector.SetProcessor(new MultiProcessor.Builder(barcodeFactory).Build());

            return new RebuyCameraSource.Builder(context, barcodeDetector)
                .SetFacing(RebuyCameraSource.CameraFacingBack)
                .SetConfigurator(configurator)
                .Build();

        }
    }
}

