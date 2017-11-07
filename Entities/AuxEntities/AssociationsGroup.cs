using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities.AuxEntities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities/AuxEntities")]
    public class AssociationsGroup : PrestaShopEntity
    {
        public List<AuxEntities.category> categories { get; set; }

        public AssociationsGroup()
        {
            this.categories = new List<category>();
        }
    }
}
