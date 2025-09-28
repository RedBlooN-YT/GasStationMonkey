using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using System.Linq;

namespace GasStationMonkey.Upgrades.MiddlePath;

public class QuickRepair : ModUpgrade<GasStationMonkey>
{
    public override int Path => BOTTOM;

    public override int Tier => 2;

    public override int Cost => 920;

    public override string DisplayName => "Quick Repair";

    public override string Description => "Super Attack Speed";

    public override string Icon => "002";

    public override string Portrait => "002";

    public override void ApplyUpgrade(TowerModel towerModel)
    {

        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        weaponModel.rate -= 0.15f;

    }
}