using AutoMapper;
using Project_ERP.DTOs.Account;
using Project_ERP.DTOs.Branch;
using Project_ERP.DTOs.City;
using Project_ERP.DTOs.JV;
using Project_ERP.DTOs.JVDetails;
using Project_ERP.DTOs.JVType;
using Project_ERP.DTOs.SubAccount;
using Project_ERP.DTOs.SubAccounts_Details;
using Project_ERP.DTOs.SubAccounts_Levels;
using Project_ERP.DTOs.SubAccountsClient;
using Project_ERP.DTOs.SubAccountType;
using Project_ERP.Models;

namespace Project_ERP.Mapper
{
    public class MappingConfig :Profile
    {
      
        public MappingConfig() 
        { 
            CreateMap<Account ,ReadAccountDto>()
                .ForMember(dest => dest.BranchNameAr, opt => opt.MapFrom(src => src.Branch.BranchNameAr))
                .ForMember(dest => dest.BranchNameEn, opt => opt.MapFrom(src => src.Branch.BranchNameEn))
                .ReverseMap();
            CreateMap<Account,CreateAccountDto>().ReverseMap();
            CreateMap<Account,UpdateAccountDto>().ReverseMap();
            CreateMap<Branch,ReadBranchDto>().ReverseMap();
            CreateMap<Branch,CreateBranchDto>().ReverseMap();
            CreateMap<Branch,UpdateBranchDto>().ReverseMap();
            CreateMap<City,ReadCityDto>()
                .ForMember(dest=>dest.BranchNameAr , opt=>opt.MapFrom(src=>src.Branch.BranchNameAr))
                .ForMember(dest=>dest.BranchNameEn , opt=>opt.MapFrom(src=>src.Branch.BranchNameEn))
                .ReverseMap();
            CreateMap<City,CreateCityDto>().ReverseMap();
            CreateMap<City,UpdateCityDto>().ReverseMap();
            CreateMap<JV , ReadJVDto>()
                .ForMember(dest=>dest.BranchNameAr , opt=>opt.MapFrom(src=>src.Branch.BranchNameAr))
                .ForMember(dest => dest.BranchNameEn, opt => opt.MapFrom(src => src.Branch.BranchNameEn))
                .ForMember(dest => dest.JVTypeNameAr, opt => opt.MapFrom(src => src.JVType.JVTypeNameAr))
                .ForMember(dest => dest.JVTypeNameEn, opt => opt.MapFrom(src => src.JVType.JVTypeNameEn))
                .ReverseMap();
            CreateMap<JV, CreateJVDto>().ReverseMap(); 
            CreateMap<JV, UpdateJVDto>().ReverseMap();
            CreateMap<JVType, ReadJVTypeDto>()
                .ForMember(dest => dest.BranchNameAr, opt => opt.MapFrom(src => src.Branch.BranchNameAr))
                .ForMember(dest => dest.BranchNameEn, opt => opt.MapFrom(src => src.Branch.BranchNameEn))
                .ReverseMap();
            CreateMap<JVType, CreateJVTypeDto>().ReverseMap();
            CreateMap<JVType, UpdateJVTypeDto>().ReverseMap();
            CreateMap<SubAccountsType, ReadSubAccountTypeDto>()
                .ForMember(dest => dest.BranchNameAr, opt => opt.MapFrom(src => src.Branch.BranchNameAr))
                .ForMember(dest => dest.BranchNameEn, opt => opt.MapFrom(src => src.Branch.BranchNameEn))
                .ReverseMap();
            CreateMap<SubAccountsType, CreateSubAccountTypeDto>().ReverseMap();
            CreateMap<SubAccountsType, UpdateSubAccountTypeDto>().ReverseMap();
            CreateMap<SubAccount, ReadSubAccountDto>().ReverseMap();
            CreateMap<SubAccount, CreateSubAccountDto>().ReverseMap();
            CreateMap<SubAccount, UpdateSubAccountDto>().ReverseMap();
            CreateMap<JVDetail, ReadJVDetailsDto>()
                .ForMember(dest=>dest.AccountNameAr , opt =>opt.MapFrom(src=>src.Account.AccountNameAr))
                .ForMember(dest => dest.AccountNameEn, opt => opt.MapFrom(src => src.Account.AccountNameEn))
                .ForMember(dest => dest.SubAccountNameAr, opt => opt.MapFrom(src => src.SubAccount.SubAccountNameAr))
                .ForMember(dest => dest.SubAccountNameEn, opt => opt.MapFrom(src => src.SubAccount.SubAccountNameEn))
                .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => src.Branch.BranchNameAr))
                .ReverseMap();
            CreateMap<JVDetail, CreateJVDetailsDto>().ReverseMap();
            CreateMap<JVDetail, UpdateJVDetailsDto>().ReverseMap();
            CreateMap<SubAccounts_Level ,ReadSubAccounts_LevelsDto>().ReverseMap();
            CreateMap<SubAccounts_Level, CreateSubAccounts_LevelsDto>().ReverseMap();
            CreateMap<SubAccounts_Level, UpdateSubAccounts_LevelsDto>().ReverseMap();
            CreateMap<SubAccounts_Detail , ReadSubAccounts_DetailsDto>().ReverseMap();
            CreateMap<SubAccounts_Detail, CreateSubAccounts_DetailsDto>().ReverseMap();
            CreateMap<SubAccounts_Detail, UpdateSubAccounts_DetailsDto>().ReverseMap();
            CreateMap<SubAccountsClient, ReadSubAccountsClientDto>().ReverseMap();
            CreateMap<SubAccountsClient, CreateSubAccountsClientDto>().ReverseMap();
            CreateMap<SubAccountsClient, UpdateSubAccountsClientDto>().ReverseMap();


        }

       
    }
}
