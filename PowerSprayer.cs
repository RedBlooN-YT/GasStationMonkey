using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppSystem.Collections.Generic;
using GasStationMonkey.Displays.Projectiles;

namespace GasStationMonkey.Upgrades.TopPath;

public class PowerSprayer : ModUpgrade<GasStationMonkey>
{
    public override int Path => TOP;

    public override int Tier => 3;

    public override int Cost => 2700;

    public override string DisplayName => "Power Sprayer";

    public override string Description => "He's spraying premium gas now! Nothing can stop him!!!";

    public override string Icon => "300";

    public override string Portrait => "300";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        weaponModel.projectile.ApplyDisplay<FireDisplay>();

        towerModel.range += 5;
        towerModel.GetAttackModel().range += 5;

        projectileModel.GetDamageModel().damage += 2;
       
        weaponModel.rate -= 0.05f;

        projectileModel.pierce += 1;

        //Burn

        AddBehaviorToBloonModel burn = Game.instance.model.GetTower("WizardMonkey", 0, 3, 0).GetDescendant<AddBehaviorToBloonModel>().Duplicate();
        towerModel.GetDescendants<ProjectileModel>().ForEach(x => x.AddBehavior(burn));

        towerModel.GetDescendants<ProjectileModel>().ForEach(x => x.UpdateCollisionPassList());



        var projectiles = new List<ProjectileModel>(
            towerModel.GetDescendants<ProjectileModel>()
        );

        foreach (var proj in projectiles)
        {
            var dot = proj.GetBehavior<DamageOverTimeModel>();
            if (dot != null)
            {
                dot.damage = 3f;
                dot.interval = 1f;
            }
        }
    }
}