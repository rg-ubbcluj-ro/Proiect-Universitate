using University.Models;
using University.DTOs;
namespace University.Mappers;   

public static class UserInfoMappers
{
    public static UserInfoDTO UserInfoToDTO(UserInfo userInfo) =>
        new UserInfoDTO()
        {
            Id = userInfo.Id,
            FirstName = userInfo.FirstName,
            LastName = userInfo.LastName,
            Email = userInfo.Email,
            Password = userInfo.Password,
            CreatedAt = userInfo.CreatedAt,
            Role = userInfo.Role,
        };

    public static UserInfo DTOtoUserInfo(UserInfoDTO userInfoDTO) =>
        new UserInfo()
        {
            Id = userInfoDTO.Id,
            FirstName = userInfoDTO.FirstName,
            LastName = userInfoDTO.LastName,
            Email = userInfoDTO.Email,
            Password = userInfoDTO.Password,
            CreatedAt = userInfoDTO.CreatedAt,
            Role = userInfoDTO.Role,
        };
}