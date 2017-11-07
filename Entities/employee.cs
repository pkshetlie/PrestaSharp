using RestSharp.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bukimedia.PrestaSharp.Entities
{
    [XmlType(Namespace = "Bukimedia/PrestaSharp/Entities")]
    public class employee : PrestaShopEntity
    {
        public long? id { get; set; }
        public long? id_profile { get; set; }
        public long? id_lang { get; set; }

        /// <summary>
        /// Required. MaxSize = 32. Default MinSize = 5 (can change depending on the shop settings)
        /// If you don't change the passwd after getting the entity, the password won't change when saving.
        /// </summary>
        public string passwd { get; set; }

        /// <summary>
        /// Required. MaxSize = 32.
        /// </summary>
        public string lastname { get; set; }

        /// <summary>
        /// Required. MaxSize = 32.
        /// </summary>
        public string firstname { get; set; }

        /// <summary>
        /// Required. MaxSize = 128. Must be an email.
        /// </summary>
        public string email { get; set; }
        /// <summary>
        /// Format YYYY-MM-DD
        /// </summary>

        public int active { get; set; }


        public employee()
        {
            //this.associations = new AuxEntities.AssociationsCustomer();
        }
    }
}
