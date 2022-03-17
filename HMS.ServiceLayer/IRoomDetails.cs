using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.DomainLayer.Models;

namespace HMS.ServiceLayer
{
    public interface IRoomDetails
    {
        bool AddRoomDetails(RoomDetail rdobj);
        IList<RoomDetail>FindByStatus(string status);
        bool EditRoomDetails(RoomDetail rdUpdate);

    }
}
