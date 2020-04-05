using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAppChernyavskiy.ViewModels.Items;

namespace WebAppChernyavskiy.Models.Collections {
    public class Item {

        public int Id { get; set; }
        [Display(Name = "Название")]
        public string Name { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Дата добавления")]
        public string Date { get; set; }
        public int? CollectionId { get; set; }
        public Collection Collection { get; set; }

    }
}
