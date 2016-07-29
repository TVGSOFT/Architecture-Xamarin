using Core.Model.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Core.Model.Responses
{
    public class ResponseCategory : Response
    {

        #region Properties

        [JsonProperty(PropertyName = "categories")]
        public IEnumerable<Category> Category { get; set; }

        #endregion

        #region Constructors

        public ResponseCategory() : base()
        {

        }

        #endregion

    }
}
