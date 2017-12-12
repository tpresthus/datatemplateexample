namespace DataTemplateExample.Components
{
    public class EthernetComponent : IComponent
    {
        public string Id { get; set; }
        public string Ipv4Address { get; set; }
        public string MacAddress { get; set; }
    }
}