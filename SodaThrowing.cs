using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppSystem.Collections.Generic;

namespace GasStationMonkey.Upgrades.MiddlePath;

public class SodaThrowing : ModUpgrade<GasStationMonkey>
{
    public override int Path => MIDDLE;

    public override int Tier => 1;

    public override int Cost => 210;

    public override string DisplayName => "Soda Throwing";

    public override string Description => "He throws hard cans of soda at the bloons.";

    public override string Icon => "010";

    public override string Portrait => "010";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        towerModel.range += 5;
        towerModel.GetAttackModel().range += 5;

        projectileModel.GetDamageModel().damage += 1;

        weaponModel.rate -= 0.03f;
        
        projectileModel.pierce += 1;

    }
}