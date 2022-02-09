using System;
using System.Collections.Generic;
using System.Text;

namespace Crawler
{
    /// <summary>
    /// This is used for WiKi API deserialization
    /// </summary>
    public class Query
    {
        public Dictionary<string, Page> pages { get; set; }
    }
}
