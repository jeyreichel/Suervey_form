using System;
using System.Collections.Generic;
using System.Linq;

namespace SurveyJSDemo.Models
{
    public static class EventRepository
    {
        private static List<EventModel> _events = new List<EventModel>();
        private static int _nextId = 1;

        public static List<EventModel> GetAll()
        {
            return _events;
        }

        public static EventModel GetById(int id)
        {
            return _events.FirstOrDefault(e => e.Id == id);
        }

        public static int Create(EventModel eventModel)
        {
            eventModel.Id = _nextId++;
            _events.Add(eventModel);
            return eventModel.Id;
        }

        public static bool Update(EventModel eventModel)
        {
            var existingEvent = _events.FirstOrDefault(e => e.Id == eventModel.Id);
            if (existingEvent == null)
                return false;

            var index = _events.IndexOf(existingEvent);
            _events[index] = eventModel;
            return true;
        }

        public static bool Delete(int id)
        {
            var existingEvent = _events.FirstOrDefault(e => e.Id == id);
            if (existingEvent == null)
                return false;

            _events.Remove(existingEvent);
            return true;
        }
    }
}