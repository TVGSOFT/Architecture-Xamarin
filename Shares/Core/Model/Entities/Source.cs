using Newtonsoft.Json;

namespace Core.Model.Entities
{
    public class Source : Entity
    {

        #region Properties

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "mime")]
        public string Mime { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        #endregion

        #region Constructors

        public Source() : base()
        {

        }

        #endregion

    }
}
