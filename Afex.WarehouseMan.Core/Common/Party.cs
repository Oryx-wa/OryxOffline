using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.Common
{
    public class Party : CreationAuditedEntity
    {
        #region Properties

        public PartyTypes PartyType { get; set; }

        public int? SystemId { get; set; }

        [Required, MaxLength(100, ErrorMessage = "Cannot be more than 100 characters")]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage = "Cannot be more than 50 characters")]
        public string Code { get; set; }

        [MaxLength(255, ErrorMessage = "Cannot be more than 255 characters")]
        public string Email { get; set; }

        public string Website { get; set; }

        [MaxLength(255, ErrorMessage = "Cannot be more than 255 characters")]
        public string Phone { get; set; }

        [MaxLength(20, ErrorMessage = "Cannot be more than 20 characters")]
        public string Fax { get; set; }

        public bool IsActive { get; set; }

        #endregion
    }
}
