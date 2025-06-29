﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Dal.Models
{
    public class Categories
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }
    }
}
