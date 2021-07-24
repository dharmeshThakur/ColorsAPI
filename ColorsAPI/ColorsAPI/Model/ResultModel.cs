using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ColorsAPI.Model
{
    public class ResultModel
    {
        /// <summary>
        /// Status Code 
        /// </summary>
        public string StatusCode { get; set; }
        /// <summary>
        /// Message 
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// Body with return data
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// To show serialized output
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this); 
        }
    }
}
