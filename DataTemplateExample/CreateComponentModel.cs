using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using DataTemplateExample.Components;
using IComponent = DataTemplateExample.Components.IComponent;

namespace DataTemplateExample
{
    public class CreateComponentModel : INotifyPropertyChanged
    {
        private readonly ICollection<IComponent> _componentsRepository;
        private string _type;
        private string _id;
        private string _ipv4Address;
        private string _macAddress;
        private int _red;
        private int _green;
        private int _blue;

        public string Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged("Type");
            }
        }

        public string Id
        {
            get => _id;
            set
            {
                _id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Ipv4Address
        {
            get => _ipv4Address;
            set
            {
                _ipv4Address = value; 
                OnPropertyChanged("Ipv4Address");
            }
        }

        public string MacAddress
        {
            get => _macAddress;
            set
            {
                _macAddress = value;
                OnPropertyChanged("MacAddress");
            }
        }

        public int Red
        {
            get => _red;
            set
            {
                _red = value;
                OnPropertyChanged("Red");
            }
        }

        public int Green
        {
            get => _green;
            set
            {
                _green = value;
                OnPropertyChanged("Green");
            }
        }

        public int Blue
        {
            get => _blue;
            set
            {
                _blue = value;
                OnPropertyChanged("Blue");
            }
        }

        public ICommand CreateCommand { get; }

        public CreateComponentModel()
        {
        }

        public CreateComponentModel(ICollection<IComponent> componentsRepository)
        {
            _componentsRepository = componentsRepository;
            CreateCommand = new Command(Create);
        }

        private void Create()
        {
            var parameters = GetParameters();
            var component = new ComponentFactory().Create(Type, parameters);
            _componentsRepository.Add(component);

            Type = "";
            Id = "";
            Ipv4Address = "";
            MacAddress = "";
            Red = 0;
            Green = 0;
            Blue = 0;
        }

        private Dictionary<string, object> GetParameters()
        {
            var parameters = new Dictionary<string, object>();

            if (Type == "SFP module")
            {
                parameters["id"] = Id;
            }
            if (Type == "Ethernet module")
            {
                parameters["id"] = Id;
                parameters["ipv4"] = Ipv4Address;
                parameters["mac"] = MacAddress;
            }
            if (Type == "Color module")
            {
                parameters["red"] = Convert.ToByte(Red);
                parameters["green"] = Convert.ToByte(Green);
                parameters["blue"] = Convert.ToByte(Blue);
            }

            return parameters;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}