using GTA;
using RageComponent.Core;
using System;

namespace WombooVehicle.Core
{
    /// <summary>Provides Womboo vehicle extensions such as boost and jump.</summary>
    public class Womboo : IComponentObject
    {
        /// <summary>Unique identificator for <see cref="ComponentObjectCollection"/>.</summary>
        public int Handle => _vehicle.Handle;

        /// <summary>Vehicle, on which Womboo actions will be applied.</summary>
        public Vehicle Vehicle => _vehicle;

        private readonly Vehicle _vehicle;
        private readonly WombooComponents _components;

        /// <summary>Creates a new <see cref="Womboo"/> instance from given vehicle.</summary>
        public Womboo(Vehicle vehicle)
        {
            _vehicle = vehicle;
            _components = new WombooComponents(this);
        }

        /// <summary>Gets all Womboo components.</summary>
        public ComponentCollection GetComponents()
        {
            return _components;
        }


        /// <summary>Disposes this <see cref="Womboo"/> and <see cref="Vehicle"/>.</summary>
        public void Dispose()
        {
            _vehicle.Delete();
        }
    }
}
