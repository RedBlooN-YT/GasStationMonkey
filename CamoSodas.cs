using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppSystem.Collections.Generic;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using UnityEngine;
using MelonLoader;

namespace GasStationMonkey.Upgrades.MiddlePath;

public class CamoSodas : ModUpgrade<GasStationMonkey>
{
    public override int Path => MIDDLE;

    public override int Tier => 2;

    public override int Cost => 1240;

    public override string DisplayName => "Camo Sodas";

    public override string Description => "New soda: Camo Edition!!! He takes one gulp of this magical drink and he can see camo bloons.";

    public override string Icon => "020";

    public override string Portrait => "020";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        

        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        

        towerModel.range += 5;
        towerModel.GetAttackModel().range += 5;

        weaponModel.rate -= 0.15f;
        
        towerModel.GetAttackModel().RemoveFilter<FilterInvisibleModel>();
        towerModel.GetAttackModel().weapons[0].projectile.SetHitCamo(true);

    }
}