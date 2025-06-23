using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal.Models
{
    public class Prompts
    {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }

            [BsonElement("userId")]
            [BsonRepresentation(BsonType.ObjectId)]
            public string UserId { get; set; }

            [BsonElement("prompt")]
            public string PromptText { get; set; }

            [BsonElement("response")]
            public string ResponseText { get; set; }

            [BsonElement("createdAt")]
            [BsonDateTimeOptions(Kind = DateTimeKind.Utc)]
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

            [BsonElement("subCategoryId")]
            [BsonRepresentation(BsonType.ObjectId)]
            public string SubCategoryId { get; set; }
        }
    }



