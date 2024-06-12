namespace EgyDynamic_Task.DTO
{
    public class CustomerPostDTO
    {
        public string اسم_العميل { get; set; }
        public string عنوان_العميل { get; set; }
        public string الموبايل { get; set; }
        public string تليفون_1 { get; set; }
        public string تليفون_2 { get; set; }
        public string واتس { get; set; }
        public string ايميل { get; set; }
        public string الجنسيه { get; set; }
        public string محل_الاقامه { get; set; }
        public string توصيف { get; set; }
        public string الوظيفة { get; set; }
        // Employee ID
        public int ادخال_بواسطة { get; set; }
        public DateTime? تاريخ_الادخال { get; set; }
        // Employee ID
        public int اخر_تعديل { get; set; }
        public DateTime? اخر_تعديل_في { get; set; }
        public string رجل_المبيعات { get; set; }
        public string مصدر_العميل { get; set; }
        public string تصنيف_العميل { get; set; }
    }
}
