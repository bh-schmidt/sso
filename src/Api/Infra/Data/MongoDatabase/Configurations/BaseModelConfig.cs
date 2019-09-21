using Api.Domain;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.IdGenerators;
using MongoDB.Bson.Serialization.Serializers;

namespace Api.Infra.Data.MongoDatabase.Configurations
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
                m.UnmapMember(x => x.Invalid);
                m.UnmapMember(x => x.Valid);
                m.UnmapMember(x => x.ValidationResult);
            });
        }
    }
}
