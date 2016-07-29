using Newtonsoft.Json;
using System;

namespace Core.Model.Entities
{
    public abstract class Entity
    {

        #region Properties

        [JsonProperty(PropertyName = "id", Required = Required.Default)]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "createdAt", Required = Required.Default)]
        public DateTime CreatedAt { get; set; }

        #endregion

        #region Constructors

        public Entity()
        {

        }

        #endregion

    }
}
