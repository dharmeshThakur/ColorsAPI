using System;
using System.Collections.Generic;
using System.Text;

namespace Colors.Data
{
    public class Colors : BaseEntity
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public string Type { get; set; }        
        public string[] RGBA { get; set; }
        public string Hex { get; set; }
    }

    public class Code
    {        
        public List<RGBA> RGBA { get; set; }
        public string Hex { get; set; }
    }
    public class RGBA
    {
        public int value { get; set; }
    }
}
