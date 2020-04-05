using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebAppChernyavskiy.Models.Account;

namespace WebAppChernyavskiy.Models.Collections {
    public class Collection {

        public int Id { get; set; }
        
        [Display(Name = "Название коллекции")]
        public string Name { get; set; }
        [Display(Name = "Дополнительная информация")]
        public string Text { get; set; }
        public int? TopicId { get; set; }
        public Topic Topic { get; set; }
        [Display(Name = "Владелец коллекции")]
        public string UserId { get; set; }
    }
}
