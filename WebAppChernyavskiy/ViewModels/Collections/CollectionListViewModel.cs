using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WebAppChernyavskiy.Models.Collections;

namespace WebAppChernyavskiy.ViewModels.Collections {
    public class CollectionListViewModel {

        public IEnumerable<Collection> Collections { get; set; }
        public SelectList Topics { get; set; }
        public string Name { get; set; }

    }
}
