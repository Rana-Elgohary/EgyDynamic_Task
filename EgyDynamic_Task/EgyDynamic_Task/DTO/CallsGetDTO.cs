namespace EgyDynamic_Task.DTO
{
    public class CallsGetDTO
    {
        public int كود_مكالمه_العميل { get; set; }
        public string التوصيف { get; set; }
        public int? عنوان_المكالمة { get; set; }
        public DateTime? التاريخ { get; set; }
        public string المشروع { get; set; }
        // Employee Name
        public string الموظف { get; set; }
        public bool? هل_تمت { get; set; }
        public string نوع_المكالمه { get; set; }
        public bool? هل_وارد { get; set; }
        // Employee Name
        public string ادخال_بواسطه { get; set; }
        public DateTime? تاريخ_الادخال { get; set; }
        public DateTime? اخر_تعديل_في { get; set; }
        // Customer Name
        public string العميل { get; set; }
        // Employee Name
        public string اخر_تعديل { get; set; }

    }
}
