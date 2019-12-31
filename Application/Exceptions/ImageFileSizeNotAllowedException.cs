using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Exceptions
{
    public class ImageFileSizeNotAllowedException : Exception
    {
        public ImageFileSizeNotAllowedException(long size) : base(size + " is not allowed, max 2mb")
        {

        }
    }
}
