using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlantPodService.Services.Persistence;
using PlantPodService.ViewModel;
using System;

namespace PlantPodService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public RoomsController(IRoomService roomService, IMapper mapper)
        {
            _roomService = roomService;
            _mapper = mapper;
        }

        [Route("")]
        public IActionResult GetAllRooms()
        {
            var rooms = _mapper.Map<Room[]>(_roomService.GetAllRooms());

            return new OkObjectResult(rooms);
        }

        [Route("{id}")]
        public IActionResult GetRoomById([FromRoute(Name = "id")] string id)
        {
            if (!Guid.TryParse(id, out var roomId))
            {
                return BadRequest("id is not a valid Guid.");
            }

            var room = _roomService.GetRoomById(roomId);
            if (room == null)
            {
                return NotFound($"no room with id: {id}");
            }

            return Ok(_mapper.Map<Room>(room));
        }
    }
}
