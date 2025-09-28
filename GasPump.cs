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

public class GasPump : ModUpgrade<GasStationMonkey>
{
    public override int Path => TOP;

    public override int Tier => 4;

    public override int Cost => 5630;

    public override string DisplayName => "Gas Pump";

    public override string Description => "The gas pump automatically sprays gas at the bloons, so he has an extra hose spraying gasoline! MORE GASOLINE!";

    public override string Icon => "400";

    public override string Portrait => "400";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        towerModel.range += 5;
        towerModel.GetAttackModel().range += 5;


        towerModel.GetWeapon().emission = new ArcEmissionModel("ArcEmissionModel_", 2, 0, 10, null, false, false);

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
                dot.damage = 7f;
                dot.interval = 1f;
            }
        }
    }
}