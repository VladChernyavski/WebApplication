using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppChernyavskiy.Models.Collections {
    public class Item {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public int? CollectionId { get; set; }
        public Collection Collection { get; set; }

    }
}
