using Afex.WarehouseMan.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afex.WarehouseMan.BusinessPartners.Dto
{
    public class CreateBusinessPartnerInput
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

        public string IsActive { get; set; }

        public string ContactPersonName { get; set; }

        public string ContactPersonLastName { get; set; }

        
        public string ContactPersonFullName
        {
            get { return ContactPersonName + " " + ContactPersonLastName; }
        }

        public string ContactEmail { get; set; }

        public string ContactPhone { get; set; }
    }
}
