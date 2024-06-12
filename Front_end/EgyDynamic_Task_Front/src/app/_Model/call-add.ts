export class CallAdd {
    التوصيف: string;
    عنوان_المكالمة: number;
    التاريخ: Date;
    المشروع: string;
    الموظف: string;
    هل_تمت: boolean;
    نوع_المكالمه: string;
    هل_وارد: boolean;
    ادخال_بواسطه: string;
    تاريخ_الادخال: Date;
    اخر_تعديل_في: Date;
    العميل: string;
    اخر_تعديل: string | number;
  
    constructor(data: any) {
      this.التوصيف = data.التوصيف;
      this.عنوان_المكالمة = data.عنوان_المكالمة;
      this.التاريخ = data.التاريخ;
      this.المشروع = data.المشروع;
      this.الموظف = data.الموظف;
      this.هل_تمت = data.هل_تمت;
      this.نوع_المكالمه = data.نوع_المكالمه;
      this.هل_وارد = data.هل_وارد;
      this.ادخال_بواسطه = data.ادخال_بواسطه;
      this.تاريخ_الادخال = data.تاريخ_الادخال;
      this.اخر_تعديل = data.اخر_تعديل;
      this.العميل = data.العميل;
      this.اخر_تعديل_في = data.اخر_تعديل_في;
    }
}
