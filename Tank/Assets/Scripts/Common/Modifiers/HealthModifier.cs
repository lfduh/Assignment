using Assets.Scripts.Table;
using Assets.Scripts.Tank.Enumerations;

namespace Assets.Scripts.Common.Modifiers
{
    public class HealthModifier
    {
        public HealthModifier ( IDamageReceiver _receiver, TankType _damageType )
        {
            if( _receiver == null ) return;
            var damagePoint = TableService.Instance.GetDamagePoint( _damageType );
            _receiver.TakeDamage( damagePoint );
        }
    }
}
