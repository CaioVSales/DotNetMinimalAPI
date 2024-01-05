using DotNetMinimalAPI.DTOs;

namespace DotNetMinimalAPI.Services
{
    public interface IRoomService
    {
        Task<List<RoomDTO>> GetAllRoomsAsync();
        Task<RoomDTO> GetRoomByIdAsync(int id);
        Task<int> CreateRoomAsync(RoomDTO roomDto);
        Task UpdateRoomAsync(int id, RoomDTO roomDto);
        Task DeleteRoomAsync(int id);
    }
}
