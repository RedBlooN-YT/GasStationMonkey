using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.TowerSets;
using GasStationMonkey.Displays.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using System.Linq;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using MelonLoader;
using System.Reflection;

namespace GasStationMonkey;

public class GasStationMonkey : ModTower
{
    public override TowerSet TowerSet => TowerSet.Primary;

    public override string BaseTower => TowerType.DartMonkey;

    public override int Cost => 740;

    public override ParagonMode ParagonMode => ParagonMode.Base555;

    public override bool IncludeInRogueLegends => true;

    public override string Icon => "Icon";

    public override string Portrait => "Icon";

    public override string Description => "He's ready to throw anything at the bloons! Chips, Soda, Gas... you name it!";

    public override string DisplayName => "Gas Station Monkey";

    public override void ModifyBaseTowerModel(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        var projectile = attackModel.weapons[0].projectile;
        projectile.ApplyDisplay<ChipDisplay>();

        // range
        towerModel.range = 30;
        towerModel.GetAttackModel().range = 30;

        // attck speed
        weaponModel.rate = 0.95f;

        // Damage + pierce
        projectileModel.pierce = 3;
        projectileModel.GetDamageModel().damage = 1;


    }

    // Ultimate Crosspathing
    public override bool IsValidCrosspath(int[] tiers) =>
        ModHelper.HasMod("UltimateCrosspathing") || base.IsValidCrosspath(tiers);

}