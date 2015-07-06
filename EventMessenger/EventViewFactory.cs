using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventMessenger
{
    public class EventViewFactory
    {
        static Dictionary<EventView, EventViewModel> _instances;

        static EventViewFactory()
        {
            _instances = new Dictionary<EventView, EventViewModel>();
        }

        public static EventView CreateInstance()
        {
            var playerRepository = ((App)App.Current).Resolve<IPlayerRepository>();

            var nextId = _instances.Count != 0 ? _instances.Values.Max(vm => vm.EventId) + 1 : 1;
            var newVM = new EventViewModel(nextId, playerRepository);
            var newView = new EventView();
            
            newView.DataContext = newVM;
            newView.Title = "Event " + nextId;
            _instances.Add(newView, newVM);

            return newView;
        }

        public static EventView GetInstance(int eventId)
        {
            var instance = _instances.FirstOrDefault(pair => pair.Value.EventId == eventId);
            return !instance.Equals(null) ? instance.Key : null;
        }
    }
}
