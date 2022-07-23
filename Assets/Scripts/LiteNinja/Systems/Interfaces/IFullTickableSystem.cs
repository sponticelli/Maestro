namespace LiteNinja.Systems
{
    public interface IFullTickableSystem : IInitializable, IPausable, ITickable, IFixedTickable
    {
    }
}