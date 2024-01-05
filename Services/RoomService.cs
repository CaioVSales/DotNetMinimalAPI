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
        private readonly ILogger<RoomService> _logger;

        public RoomService(CinemaApiDbContext context, IMapper mapper, ILogger<RoomService> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<RoomDTO>> GetAllRoomsAsync()
        {
            try
            {
                var rooms = await _context.Rooms.ToListAsync();
                return _mapper.Map<List<RoomDTO>>(rooms);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetAllRoomsAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<RoomDTO> GetRoomByIdAsync(int id)
        {
            try
            {
                var room = await _context.Rooms.FirstOrDefaultAsync(r => r.RoomId == id);
                return _mapper.Map<RoomDTO>(room);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in GetRoomByIdAsync: {ex.Message}");
                throw;
            }
        }

        public async Task<int> CreateRoomAsync(RoomDTO roomDto)
        {
            try
            {
                var room = _mapper.Map<Room>(roomDto);
                _context.Rooms.Add(room);
                await _context.SaveChangesAsync();
                return room.RoomId;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in CreateRoomAsync: {ex.Message}");
                throw;
            }
        }

        public async Task UpdateRoomAsync(int id, RoomDTO roomDto)
        {
            try
            {
                var existingRoom = await _context.Rooms.FirstOrDefaultAsync(r => r.RoomId == id);

                if (existingRoom != null)
                {
                    _mapper.Map(roomDto, existingRoom);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in UpdateRoomAsync: {ex.Message}");
                throw;
            }
        }

        public async Task DeleteRoomAsync(int id)
        {
            try
            {
                var roomToDelete = await _context.Rooms.FirstOrDefaultAsync(r => r.RoomId == id);

                if (roomToDelete != null)
                {
                    _context.Rooms.Remove(roomToDelete);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error in DeleteRoomAsync: {ex.Message}");
                throw;
            }
        }
    }
}
