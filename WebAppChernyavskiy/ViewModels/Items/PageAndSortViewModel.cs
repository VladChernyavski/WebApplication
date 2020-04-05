using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppChernyavskiy.Models.Collections;

namespace WebAppChernyavskiy.ViewModels.Items {
    public class PageAndSortViewModel {

        public IEnumerable<Item> Items { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }

    }
}
