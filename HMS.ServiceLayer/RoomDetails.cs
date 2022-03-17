using HMS.DomainLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.ServiceLayer
{
    public class RoomDetails :IRoomDetails
    {
        HMSDBContext context;
        public RoomDetails()
        {
            context = new HMSDBContext();
        }
        public bool AddRoomDetails(RoomDetail rdobj)
        {
            context.RoomDetails.Add(rdobj);
            if (context.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EditRoomDetails(RoomDetail rdUpdate)
        {
           var room= FindById(rdUpdate.Roomnumber);

            room.Roomtype = rdUpdate.Roomtype;
            room.Roomstatus = rdUpdate.Roomstatus;
            if (context.SaveChanges() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public  IList<RoomDetail>FindByStatus(string status)
        {
          return  context.RoomDetails.Where(x=>x.Roomstatus == status).ToList();
        }
        public RoomDetail FindById(int id)
        {
            return context.RoomDetails.Where(x => x.Roomnumber == id).FirstOrDefault();
        }
    }
}
