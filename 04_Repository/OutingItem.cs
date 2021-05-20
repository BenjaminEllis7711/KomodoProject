using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Repository
{
    public enum EventType { Golf, Bowling, AmusementPark, Concert }
    public class OutingItem
    {
        public EventType TypeOfEvent { get; set; }
        public int Attendance { get; set; }
        public DateTime DateOfEvent { get; set; }
        public decimal TotalCostOfEvent { get; set; }
        public decimal CostPerPerson
        {
            get
            {
                return TotalCostOfEvent / (decimal)Attendance;
            }
        }
        public OutingItem() { }
        public OutingItem(EventType typeOfEvent, int attendance, DateTime dateOfEvent, decimal totalCostOfEvent) 
        {
            TypeOfEvent = typeOfEvent;
            Attendance = attendance;
            DateOfEvent = dateOfEvent;
            TotalCostOfEvent = totalCostOfEvent;
        }

    }
}

