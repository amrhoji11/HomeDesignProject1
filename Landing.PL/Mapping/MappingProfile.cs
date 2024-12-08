using AutoMapper;
using Landing.DAL.Models;
using Landing.PL.Areas.Dashboard.ViewModel;
using Landing.PL.ViewModel;

namespace Landing.PL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
           /* CreateMap<ServiceFormVM, Service>().ReverseMap();
            CreateMap<Service, ServiceVM>();
            CreateMap<Service,ServiceDetails>();*/

            CreateMap<Design, DesignVM>();
            CreateMap<DesignsFromVM, Design>().ReverseMap();
            CreateMap<Design, DesignDetails>();


            CreateMap<Item, ItemVM>();
            CreateMap<ItemFromVM, Item>().ForMember(dest => dest.Design, opt => opt.Ignore()).ReverseMap();
            CreateMap<Item, ItemDetails>().ForMember(dest => dest.Design, opt => opt.Ignore()).ReverseMap(); ;

            CreateMap<Social, SocialVM>().ReverseMap();
            CreateMap<Information, InfoVM>().ReverseMap();


            CreateMap<HLebelFromVM, HomeLabel>().ReverseMap();
            CreateMap<HomeLabel, HLebelVM>();
            CreateMap<HomeLabel, HLebelDetails>();

            CreateMap<ProfileVM,PProfile>().ReverseMap();
            CreateMap<Feedback, FeedbackVM>(); // تحويل من Feedback إلى FeedbackVM
            CreateMap<Feedback, FeedbackeDetails>();

            CreateMap<Massage, MassageVM>(); // تحويل من Feedback إلى FeedbackVM
            CreateMap<Massage, MassageDetails>();

            CreateMap<Comment, CommentVM>(); // تحويل من Feedback إلى FeedbackVM
            CreateMap<Comment, CommentDetailVM>();


            CreateMap<Blog, BlogVM>(); // تحويل من Feedback إلى FeedbackVM
            CreateMap<Blog, BlogDetail>();
            CreateMap<Blog, BlogFromVM>().ReverseMap();






            /*CreateMap<CommentFromVM, Comment>().ReverseMap();
            CreateMap<UserViewModel, ApplecationUser>().ReverseMap();*/
        }
    }
}
