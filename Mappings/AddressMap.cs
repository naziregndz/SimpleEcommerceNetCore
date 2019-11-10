using Entities;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mappings
{
    public class AddressMap : ClassMap<Address>
    {
        public AddressMap()
        {
            Table("Address");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.AddressTypeId);
            Map(x => x.City);
            Map(x => x.Town);
            Map(x => x.ZipCode);
            Map(x => x.AddressLine);
            Map(x => x.AddressLine2);
            Map(x => x.AddressLine3);
        }
    }
}
