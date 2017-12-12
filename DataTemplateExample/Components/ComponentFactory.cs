using System.Collections.Generic;

namespace DataTemplateExample.Components
{
    public interface IComponent
    {
    }

    public class ComponentFactory
    {
        public IComponent Create(string type, Dictionary<string, object> data)
        {
            if (type == "SFP module")
            {
                return new SfpComponent
                {
                    Id = data["id"] as string
                };
            }
            if (type == "Ethernet module")
            {
                return new EthernetComponent
                {
                    Id = data["id"] as string,
                    Ipv4Address = data["ipv4"] as string,
                    MacAddress = data["mac"] as string
                };
            }
            if (type == "Color module")
            {
                return new ColorComponent
                {
                    Red = (byte)data["red"],
                    Green = (byte)data["green"],
                    Blue = (byte)data["blue"]
                };
            }

            return null;
        }
    }
}