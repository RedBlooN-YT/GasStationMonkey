using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppSystem.Collections.Generic;
using Il2Cpp;

namespace GasStationMonkey.Upgrades.TopPath;

public class GasolineDripper : ModUpgrade<GasStationMonkey>
{
    public override int Path => TOP;

    public override int Tier => 1;

    public override int Cost => 320;

    public override string DisplayName => "Gasoline Dripper";

    public override string Description => "He drips gasoline on top of the bloons and it sets them on FIRE!!!";

    public override string Icon => "100";

    public override string Portrait => "100";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;

        towerModel.range += 3;
        towerModel.GetAttackModel().range += 3;

        projectileModel.GetDamageModel().damage += 1;

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
                dot.damage = 1f;
                dot.interval = 2f;
            }
        }
    }
}