using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;
using SSO.Domain.Models.Entities;

namespace SSO.Infra.Data.Configurations
{
    public static class BaseModelConfig
    {
        public static void Configure()
        {
            BsonClassMap.RegisterClassMap<BaseModel>(m =>
            {
                m.AutoMap();
                m.MapMember(x => x.Id)
                    .SetSerializer(new StringSerializer(BsonType.ObjectId))
                    .SetIdGenerator(StringObjectIdGenerator.Instance);
            });
        }
    }
}
