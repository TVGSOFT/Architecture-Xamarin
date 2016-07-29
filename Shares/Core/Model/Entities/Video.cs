using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core.Model.Entities
{
    public class Video : Entity
    {

        #region Properties

        [JsonProperty(PropertyName = "subtitle")]
        public string Subtitle { get; set; }

        [JsonProperty(PropertyName = "sources")]
        public IEnumerable<Source> Sources { get; set; }

        [JsonProperty(PropertyName = "image-480x270")]
        public string Thumb { get; set; }

        [JsonProperty(PropertyName = "image-780x1200")]
        public string Image { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "studio")]
        public string Studio { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public long Duration { get; set; }

        #endregion

        #region Constructors

        public Video() : base()
        {

        }

        #endregion

    }
}
