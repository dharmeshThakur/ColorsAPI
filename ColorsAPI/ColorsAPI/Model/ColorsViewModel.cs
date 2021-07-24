using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColorsAPI.Model
{
    public class ColorsViewModel
    {
        /// <summary>
        /// Unique Id
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Category
        /// </summary>
        public string Category { get; set; }
        /// <summary>
        /// Type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Code class to store other fields
        /// </summary>
        public Code Code { get; set; }
    }   

    public class Code
    {
        /// <summary>
        /// RGBA list
        /// </summary>
        public List<int> RGBA { get; set; }
        /// <summary>
        /// Hex
        /// </summary>
        public string Hex { get; set; }
    }
}
