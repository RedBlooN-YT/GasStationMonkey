using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppSystem.Collections.Generic;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;

namespace GasStationMonkey.Upgrades.TopPath;

public class TheBigBurn : ModUpgrade<GasStationMonkey>
{
    public override int Path => TOP;

    public override int Tier => 5;

    public override int Cost => 21900;

    public override string DisplayName => "The Big Burn";

    public override string Description => "There's only one way to find out how big the burn is... to go through it.";

    public override string Icon => "500";

    public override string Portrait => "500";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        towerModel.range += 25;
        towerModel.GetAttackModel().range += 25;

        projectileModel.GetDamageModel().damage += 5;

        projectileModel.pierce += 5;

        weaponModel.rate -= 0.12f;


        towerModel.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 4, 0, 10, null, false, false);

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
                dot.damage = 25f;
                dot.interval = 1f;
            }
        }
    }
}