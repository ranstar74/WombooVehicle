using GTA;
using RageComponent;
using RageComponent.Core;

namespace WombooVehicle.Core
{
    /// <summary>This class contains all components that is used by <see cref="Womboo"/>.</summary>
    public class WombooComponents : ComponentCollection
    {
        /// <summary><inheritdoc cref="BoostComponent"/></summary>
        public BoostComponent Boost { get; }

        /// <summary><inheritdoc cref="Jump"/></summary>
        public JumpComponent Jump { get; }

        /// <summary>Creates a new <see cref="WombooComponent"/> with given Womboo as parent.</summary>
        /// <param name="womboo">Womboo instance that will accessed by all components.</param>
        public WombooComponents(Womboo womboo) : base(womboo)
        {
            Boost = Create<BoostComponent>();
            Jump = Create<JumpComponent>();

            // Call start for all components after they are all created
            // So there won't be component dependency problem
            OnStart();
        }
    }

    /// <summary>Base class of all womboo components.</summary>
    public abstract class WombooComponent : Component
    {
        /// <summary>Womboo instance that owns this component.</summary>
        public Womboo Womboo { get; }

        protected WombooComponent(ComponentCollection components) : base(components)
        {
            Womboo = GetParent<Womboo>();
        }
    }

    /// <summary>Provides ability to toggle vehicle boost.</summary>
    public sealed class BoostComponent : WombooComponent
    {
        public BoostComponent(ComponentCollection components) : base(components)
        {

        }

        public override void Update()
        {
            if(Game.IsControlPressed(Control.VehicleRocketBoost))
            {
                Womboo.Vehicle.Velocity += Womboo.Vehicle.ForwardVector;
            }
        }
    }

    public sealed class JumpComponent : WombooComponent
    {
        public JumpComponent(ComponentCollection components) : base(components)
        {

        }

        public override void Update()
        {
            if (Game.IsControlPressed(Control.Jump))
            {
                Womboo.Vehicle.Velocity += Womboo.Vehicle.UpVector * 5;
            }
        }
    }
}
