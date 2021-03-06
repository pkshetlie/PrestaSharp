﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class AssociationsCustomer : PrestaShopEntity
    {
        public List<AuxEntities.group> groups { get; set; }
        public List<AuxEntities.employee> employees { get; set; }

		public AssociationsCustomer()
        {
			this.groups = new List<group>();
			this.employees = new List<employee>();
        }
    }
}
