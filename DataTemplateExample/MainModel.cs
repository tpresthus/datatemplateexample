using System.Collections.ObjectModel;
using DataTemplateExample.Components;

namespace DataTemplateExample
{
    public class MainModel
    {
        public ObservableCollection<IComponent> Components { get; set; } = new ObservableCollection<IComponent>();
        public CreateComponentModel CreateComponentModel { get; }

        public MainModel()
        {
            CreateComponentModel = new CreateComponentModel(Components);

            Components.Add(new SfpComponent {Id = "foobar"});
            Components.Add(new EthernetComponent { Id = "eth0", Ipv4Address = "192.168.1.10", MacAddress = "01:23:45:67:89:ab" });
            Components.Add(new ColorComponent { Red = 200, Green = 50, Blue = 50 });
        }
    }
}