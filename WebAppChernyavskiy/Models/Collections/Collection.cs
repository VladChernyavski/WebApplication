using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppChernyavskiy.Models.Account;

namespace WebAppChernyavskiy.Models.Collections {
    public class Collection {

        public int Id { get; set; }
        public string Name { get; set; }
        public int? TopicId { get; set; }
        public Topic Topic { get; set; }
        public string UserId { get; set; }
    }
}
