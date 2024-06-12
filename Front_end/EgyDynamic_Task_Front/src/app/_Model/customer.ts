export class Customer {
    كود_العميل: number;
    اسم_العميل: string;
    عنوان_العميل: string;
    الموبايل: string;
    تليفون_1: string;
    تليفون_2: string;
    واتس: string;
    ايميل: string;
    الجنسيه: string;
    محل_الاقامه: string;
    توصيف: string;
    الوظيفة: string;
    ادخال_بواسطة: string | number;
    تاريخ_الادخال: Date;
    اخر_تعديل: string | number;
    اخر_تعديل_في: Date;
    رجل_المبيعات: string;
    مصدر_العميل: string;
    تصنيف_العميل: string;
  
    constructor(data: any) {
      this.كود_العميل = data.كود_العميل;
      this.اسم_العميل = data.اسم_العميل;
      this.عنوان_العميل = data.عنوان_العميل;
      this.الموبايل = data.الموبايل;
      this.تليفون_1 = data.تليفون_1;
      this.تليفون_2 = data.تليفون_2;
      this.واتس = data.واتس;
      this.ايميل = data.ايميل;
      this.الجنسيه = data.الجنسيه;
      this.محل_الاقامه = data.محل_الاقامه;
      this.توصيف = data.توصيف;
      this.الوظيفة = data.الوظيفة;
      this.ادخال_بواسطة = data.ادخال_بواسطة;
      this.تاريخ_الادخال = data.تاريخ_الادخال;
      this.اخر_تعديل = data.اخر_تعديل;
      this.اخر_تعديل_في = data.اخر_تعديل_في;
      this.رجل_المبيعات = data.رجل_المبيعات;
      this.مصدر_العميل = data.مصدر_العميل;
      this.تصنيف_العميل = data.تصنيف_العميل;
    }
}
