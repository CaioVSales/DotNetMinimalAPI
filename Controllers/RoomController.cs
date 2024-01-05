// RoomController.cs
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;  // Add this using directive
using DotNetMinimalAPI.DTOs;
using DotNetMinimalAPI.Services;

namespace DotNetMinimalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly RoomService _roomService;

        public RoomController(RoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _roomService.GetAllRoomsAsync();
            return Ok(rooms);  // Assuming GetAllRoomsAsync returns a List<RoomDTO>
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await _roomService.GetRoomByIdAsync(id);
            
            if (room == null)
                return NotFound();  // Return 404 if the room is not found
            
            return Ok(room);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] RoomDTO roomDto)
        {
            var roomId = await _roomService.CreateRoomAsync(roomDto);
            return CreatedAtAction(nameof(GetRoomById), new { id = roomId }, roomDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] RoomDTO roomDto)
        {
            await _roomService.UpdateRoomAsync(id, roomDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            await _roomService.DeleteRoomAsync(id);
            return NoContent();
        }
    }
}
