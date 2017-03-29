using Abp.Application.Services.Dto;
using Afex.WarehouseMan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.BusinessPartners.Dto
{
    public class UpdateBusinessPartnerInput : CreationAuditedEntityDto
    {
        public string CardCode { get; set; }

        public string CardName { get; set; }

        public CardTypes? CardType { get; set; }

        public string Location { get; set; }

        public string State { get; set; }

        public string Country { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Website { get; set; }

        public string ContactPerson { get; set; }
    }
}
