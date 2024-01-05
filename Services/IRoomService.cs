using System.Collections.Generic;
using DotNetMinimalAPI.Models;

namespace DotNetMinimalAPI.Repositories
{
    public interface IRoomRepository
    {
        List<Room> GetRooms();
        Room GetRoomById(int id);
    }
}
