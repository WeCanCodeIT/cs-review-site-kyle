using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReviewsSite.Models
{
    public class Tag
    {
        public int Id { get; set; }
        public string Text { get; set; }

        [JsonIgnore]
        public virtual List<ReviewTag> ReviewTags { get; set; }
    }
}
