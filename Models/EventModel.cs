using System;
using System.ComponentModel.DataAnnotations;

namespace SurveyJSDemo.Models
{
    public class EventModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string AssignedTo { get; set; }
    }
}