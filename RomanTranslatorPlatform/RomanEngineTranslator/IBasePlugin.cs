using System;
using System.Collections.Generic;
using System.Text;

namespace DigitExtractorEngine.Interfaces
{
    /// <summary>
    /// Interface to handle numbers
    /// </summary>
    interface IBaseDigitPlugin
    {
        String Execute(int number);
    }
}
