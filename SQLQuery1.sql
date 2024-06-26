﻿use EgyDynamic_Task

CREATE TABLE الموظف (
    [كود الموظف] int PRIMARY KEY IDENTITY(1,1),
    [اسم الموظف] NVARCHAR(255) NOT NULL,
    [اسم المستخدم] NVARCHAR(255) NOT NULL,
    [كلمه المرور] NVARCHAR(255) NOT NULL,
);

INSERT INTO الموظف ([اسم الموظف], [اسم المستخدم], [كلمه المرور])
VALUES (N'محمد علي', N'mohamed.ali', N'password123');

INSERT INTO الموظف ([اسم الموظف], [اسم المستخدم], [كلمه المرور])
VALUES (N'رنا محمد', N'rana.Mohamed', N'password456');

CREATE TABLE العميل (
    كود_العميل int PRIMARY KEY IDENTITY(1,1),
    [اسم العميل] NVARCHAR(255),
	[عنوان العميل] NVARCHAR(255),
    [الموبايل] NVARCHAR(255),
    [تليفون 1] NVARCHAR(255),
    [تليفون 2] NVARCHAR(255),
    [واتس] NVARCHAR(255),
    [ايميل] NVARCHAR(255),
    [الجنسيه] NVARCHAR(255),
    [محل الاقامه] NVARCHAR(255),
    توصيف NVARCHAR(255),
    الوظيفة NVARCHAR(255),
    [ادخال بواسطة] int FOREIGN KEY REFERENCES الموظف([كود الموظف]),
    [تاريخ الادخال] Date,
    [اخر تعديل] int FOREIGN KEY REFERENCES الموظف([كود الموظف]),
    [اخر تعديل في] Date,
    [رجل المبيعات] NVARCHAR(255),
    [مصدر العميل] NVARCHAR(255),
    [تصنيف العميل] NVARCHAR(255),
);

INSERT INTO العميل (
    [اسم العميل], 
    [عنوان العميل], 
    [الموبايل], 
    [تليفون 1], 
    [تليفون 2], 
    [واتس], 
    [ايميل], 
    [الجنسيه], 
    [محل الاقامه], 
    توصيف, 
    الوظيفة, 
    [ادخال بواسطة], 
    [تاريخ الادخال], 
    [اخر تعديل], 
    [اخر تعديل في], 
    [رجل المبيعات], 
    [مصدر العميل], 
    [تصنيف العميل]
) 
VALUES (
    N'أحمد محمد', 
    N'123 شارع التحرير', 
    N'0123456789', 
    N'022345678', 
    N'033456789', 
    N'0123456789', 
    N'ahmed@example.com', 
    N'مصري', 
    N'القاهرة', 
    N'عميل مميز', 
    N'مهندس', 
    1, 
    '2024-06-11', 
    1, 
    '2024-06-11', 
    N'محمد علي', 
    N'إعلان', 
    N'مهم'
);

-- Insert the second row
INSERT INTO العميل (
    [اسم العميل], 
    [عنوان العميل], 
    [الموبايل], 
    [تليفون 1], 
    [تليفون 2], 
    [واتس], 
    [ايميل], 
    [الجنسيه], 
    [محل الاقامه], 
    توصيف, 
    الوظيفة, 
    [ادخال بواسطة], 
    [تاريخ الادخال], 
    [اخر تعديل], 
    [اخر تعديل في], 
    [رجل المبيعات], 
    [مصدر العميل], 
    [تصنيف العميل]
) 
VALUES (
    N'ليلى أحمد', 
    N'456 شارع النصر', 
    N'0987654321', 
    N'055432109', 
    N'066543210', 
    N'0987654321', 
    N'layla@example.com', 
    N'مصري', 
    N'الجيزة', 
    N'عميل جديد', 
    N'طبيبة', 
    2, 
    '2024-06-11', 
    2, 
    '2024-06-11', 
    N'سارة أحمد', 
    N'موقع الكتروني', 
    N'محتمل'
);

CREATE TABLE مكالمه_العميل (
    كود_مكالمه_العميل int PRIMARY KEY IDENTITY(1,1),
    التوصيف NVARCHAR(255),
    [عنوان المكالمة] int,
    التاريخ Date,
    المشروع NVARCHAR(255),
    الموظف int FOREIGN KEY REFERENCES الموظف([كود الموظف]),
    [هل تمت] bit,
    [نوع المكالمه] NVARCHAR(255),
    [هل وارد] bit,
    [ادخال بواسطه] int FOREIGN KEY REFERENCES الموظف([كود الموظف]),
    [تاريخ الادخال] Date,
	[اخر تعديل في] Date,
	العميل int FOREIGN KEY REFERENCES العميل(كود_العميل),	
    [اخر تعديل] int FOREIGN KEY REFERENCES الموظف([كود الموظف])
);

INSERT INTO مكالمه_العميل (
    التوصيف, 
    [عنوان المكالمة], 
    التاريخ, 
    المشروع, 
    الموظف, 
    [هل تمت], 
    [نوع المكالمه], 
    [هل وارد], 
    [ادخال بواسطه], 
    [تاريخ الادخال], 
    [اخر تعديل في], 
    العميل, 
    [اخر تعديل]
) 
VALUES (
    N'مكالمة متابعة', 
    1, 
    '2024-06-11', 
    N'مشروع ABC', 
    1, 
    1, 
    N'مكالمة هاتفية', 
    1, 
    1, 
    '2024-06-11', 
    '2024-06-11', 
    1, 
    1
);

select * from مكالمه_العميل

select * from العميل

delete from العميل where كود_العميل = 4