using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HMS.ServiceLayer;
using HMS.DomainLayer;




namespace HMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        IRoomDetails _Room;
        public RoomController(IRoomDetails room)
        {
            _Room = room;
        }
        [HttpPost]
        public ActionResult AddRoom(HMS.DomainLayer.Models.RoomDetail roomobj)
        {
            if (_Room.AddRoomDetails(roomobj))
            {
                return Ok("Room Added");
            }
            else
            {
                return BadRequest();
            }


        }
        [HttpPut]
        public ActionResult UpdateRoom(HMS.DomainLayer.Models.RoomDetail roomobj)
        {
            if (_Room.EditRoomDetails(roomobj))
            {
                return Ok("Room Updated");
            }
            else
            {
                return BadRequest();
            }


        }

        [HttpGet]
        public ActionResult SearchRoom(string status)
        {
           

            var Rooms = _Room.FindByStatus(status);
            if (Rooms != null && Rooms.Count > 1)
            {
                return Ok(Rooms);
            }
            return BadRequest("Not Found");

        }
    }
}
