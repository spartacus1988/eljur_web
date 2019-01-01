using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eljur_web.Models
{
    public enum SortState
    {
        EventIdAsc,// по возрастанию
        EventIdDesc,// по убыванию
        EventNameAsc,    
        EventNameDesc,   
        NotifyEnableAsc,
        NotifyEnableDesc,
        NotifyWasSendAsc,
        NotifyWasSendDesc,
        EventTimeAsc,
        EventTimeDesc,
        PupilIdOldAsc,
        PupilIdOldDesc,
        EljurAccountIdAsc,
        EljurAccountIdDesc,
        FullFioAsc,
        FullFioDesc,
        ClasAsc,
        ClasDesc
    }

    public class SortViewModel
    {
        public SortState EventIdSort { get; private set; }
        public SortState EventNameSort { get; private set; }
        public SortState NotifyEnableSort { get; private set; }
        public SortState NotifyWasSendSort { get; private set; }
        public SortState EventTimeSort { get; private set; }
        public SortState PupilIdOldSort { get; private set; }
        public SortState EljurAccountIdSort { get; private set; }
        public SortState FullFioSort { get; private set; }
        public SortState ClasSort { get; private set; }
        public SortState Current { get; private set; }

        public SortViewModel(SortState sortOrder)
        {
            EventIdSort = sortOrder == SortState.EventIdAsc ? SortState.EventIdDesc : SortState.EventIdAsc;
            EventNameSort = sortOrder == SortState.EventNameAsc ? SortState.EventNameDesc : SortState.EventNameAsc;
            NotifyEnableSort = sortOrder == SortState.NotifyEnableAsc ? SortState.NotifyEnableDesc : SortState.NotifyEnableAsc;
            NotifyWasSendSort = sortOrder == SortState.NotifyWasSendAsc ? SortState.NotifyWasSendDesc : SortState.NotifyWasSendAsc;
            EventTimeSort = sortOrder == SortState.EventTimeAsc ? SortState.EventTimeDesc : SortState.EventTimeAsc;
            PupilIdOldSort = sortOrder == SortState.PupilIdOldAsc ? SortState.PupilIdOldDesc : SortState.PupilIdOldAsc;
            EljurAccountIdSort = sortOrder == SortState.EljurAccountIdAsc ? SortState.EljurAccountIdDesc : SortState.EljurAccountIdAsc;
            FullFioSort = sortOrder == SortState.FullFioAsc ? SortState.FullFioDesc : SortState.FullFioAsc;
            ClasSort = sortOrder == SortState.ClasAsc ? SortState.ClasDesc : SortState.ClasAsc;     
            Current = sortOrder;
        }
    }
}
