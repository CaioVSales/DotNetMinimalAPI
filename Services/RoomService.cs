using AutoMapper;
using DotNetMinimalAPI.Data;
using DotNetMinimalAPI.DTOs;
using DotNetMinimalAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetMinimalAPI.Services
{
    public class RoomService : IRoomService
    {
        private readonly CinemaApiDbContext _context;
        private readonly IMapper _mapper;

        public RoomService(CinemaApiDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RoomDTO>> GetAllRoomsAsync()
        {
            var rooms = await _context.Rooms.ToListAsync();
            return _mapper.Map<List<RoomDTO>>(rooms);
        }

        public async Task<RoomDTO> GetRoomByIdAsync(int id)
        {
            var room = await _context.Rooms.FirstOrDefaultAsync(r => r.RoomId == id);
            return _mapper.Map<RoomDTO>(room);
        }

        public async Task<int> CreateRoomAsync(RoomDTO roomDto)
        {
            var room = _mapper.Map<Room>(roomDto);
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
            return room.RoomId;
        }

        public async Task UpdateRoomAsync(int id, RoomDTO roomDto)
        {
            var existingRoom = await _context.Rooms.FirstOrDefaultAsync(r => r.RoomId == id);

            if (existingRoom != null)
            {
                _mapper.Map(roomDto, existingRoom);
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteRoomAsync(int id)
        {
            var roomToDelete = await _context.Rooms.FirstOrDefaultAsync(r => r.RoomId == id);

            if (roomToDelete != null)
            {
                _context.Rooms.Remove(roomToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
