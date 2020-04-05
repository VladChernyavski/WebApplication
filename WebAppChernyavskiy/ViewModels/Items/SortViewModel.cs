using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAppChernyavskiy.Models.Collections;

namespace WebAppChernyavskiy.ViewModels.Items {
    public class SortViewModel {

        public SortState NameSort { get; private set; } 
        public SortState Current { get; private set; }
        public bool UpName { get; set; }

        public SortViewModel(SortState sortOrder) {
            NameSort = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            Current = sortOrder;
            UpName = false;

            if (sortOrder == SortState.NameDesc) {
                UpName = true;
            }
        }

    }
}
