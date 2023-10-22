using AutoMapper;
using RestaurantReview.Dto;
using RestaurantReview.Models;

namespace RestaurantReview.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Restaurant, RestaurantDto>();
            CreateMap<RestaurantDto, Restaurant>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

            CreateMap<Response, ResponseDto>();
            CreateMap<ResponseDto, Response>();

            CreateMap<Note, NoteDto>();
            CreateMap<NoteDto, Note>();

            CreateMap<Comment, CommentDto>(); 
            CreateMap<CommentDto, Comment>();
        }
    }
}
