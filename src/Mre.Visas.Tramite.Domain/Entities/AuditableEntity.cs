using System;

namespace Mre.Visas.Tramite.Domain.Entities
{
    public class AuditableEntity : BaseEntity
    {
        public DateTime LastModified { get; set; }

        public Guid LastModifierId { get; set; }

        public DateTime Created { get; set; }

        public Guid CreatorId { get; set; }

    }
}