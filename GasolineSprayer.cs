using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppSystem.Collections.Generic;

namespace GasStationMonkey.Upgrades.TopPath;

public class GasolineSprayer : ModUpgrade<GasStationMonkey>
{
    public override int Path => TOP;

    public override int Tier => 2;

    public override int Cost => 780;

    public override string DisplayName => "Gasoline Sprayer";

    public override string Description => "He can spray gasoline WAY farther now.";

    public override string Icon => "200";

    public override string Portrait => "200";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        towerModel.range += 17;
        towerModel.GetAttackModel().range += 17;

        projectileModel.GetDamageModel().damage += 1;
       
        weaponModel.rate -= 0.1f;

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
                dot.interval = 1f;
            }
        }
    }
}