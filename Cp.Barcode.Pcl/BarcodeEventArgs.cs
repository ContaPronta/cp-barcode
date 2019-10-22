using System;

namespace Cp.Barcode.Pcl
{
   public class BarcodeEventArgs : EventArgs
   {
        public Barcode Barcode { get; private set; }
        
        public BarcodeEventArgs(Barcode barcode)
        {
            Barcode = barcode;
        }
   }
}
