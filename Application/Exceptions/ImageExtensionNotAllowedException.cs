using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class ImageExtensionNotAllowedException : Exception
    {
        public ImageExtensionNotAllowedException() : base("Image extension is not allowed")
        {

        }
    }
}
