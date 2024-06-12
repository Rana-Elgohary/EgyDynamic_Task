using AutoMapper;
using EgyDynamic_Task.DTO;
using EgyDynamic_Task.Models;

namespace EgyDynamic_Task.Config
{
    public class AutoMapperConfig :Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<العميل, CustomerGetDTO>()
                .ForMember(distinastion => distinastion.ادخال_بواسطة,
                            source => source.MapFrom(from => from.ادخال_بواسطةNavigation.اسم_الموظف))
                .ForMember(distination => distination.اخر_تعديل,
                            source => source.MapFrom(from => from.اخر_تعديلNavigation.اسم_الموظف));

            CreateMap<CustomerPostDTO, العميل>();

            CreateMap<CustomerPutDTO, العميل>();
            CreateMap<العميل, CustomerPutDTO>();


            CreateMap<مكالمه_العميل, CallsGetDTO>()
                .ForMember(distinastion => distinastion.ادخال_بواسطه,
                            source => source.MapFrom(from => from.ادخال_بواسطهNavigation.اسم_الموظف))
                .ForMember(distination => distination.اخر_تعديل,
                            source => source.MapFrom(from => from.اخر_تعديلNavigation.اسم_الموظف))
                .ForMember(distination => distination.العميل,
                            source => source.MapFrom(from => from.العميلNavigation.اسم_العميل))
                .ForMember(distination => distination.الموظف,
                            source => source.MapFrom(from => from.الموظفNavigation.اسم_الموظف));

            CreateMap<CallsPostDTO, مكالمه_العميل>();

            CreateMap<CallsPutDTO, مكالمه_العميل>();
            CreateMap<مكالمه_العميل, CallsPutDTO>();
        }
    }
}
