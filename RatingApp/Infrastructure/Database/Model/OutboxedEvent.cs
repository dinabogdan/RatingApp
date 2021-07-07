using System;

#nullable disable

namespace RatingApp.Infrastructure.Database.Model
{
    public partial class OutboxedEvent
    {
        public int Seq { get; set; }
        public string Type { get; set; }
        public string AggregateId { get; set; }
        public string AggregateType { get; set; }
        public DateTime? OccurredAt { get; set; }
        public byte[] Payload { get; set; }
        public string Version { get; set; }
        public string PayloadContentType { get; set; }
        public string PayloadSchemaId { get; set; }
        public string PayloadSchema { get; set; }
        public string Metadata { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
