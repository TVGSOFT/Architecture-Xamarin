using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core.Model.Entities
{
    public class Category : Entity
    {

        #region Properties

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "hls")]
        public string Hls { get; set; }

        [JsonProperty(PropertyName = "dash")]
        public string Dash { get; set; }

        [JsonProperty(PropertyName = "mp4")]
        public string Mp4 { get; set; }

        [JsonProperty(PropertyName = "images")]
        public string Images { get; set; }

        [JsonProperty(PropertyName = "videos")]
        public IEnumerable<Video> Videos { get; set; }

        #endregion

        #region Constructors

        public Category() : base()
        {

        }

        #endregion

    }
}
