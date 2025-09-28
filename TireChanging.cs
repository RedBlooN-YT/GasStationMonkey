using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using System.Linq;

namespace GasStationMonkey.Upgrades.MiddlePath;

public class TireChanging : ModUpgrade<GasStationMonkey>
{
    public override int Path => BOTTOM;

    public override int Tier => 1;

    public override int Cost => 320;

    public override string DisplayName => "Tire Changing";

    public override string Description => "Increases attack speed";

    public override string Icon => "001";

    public override string Portrait => "001Portrait";

    public override void ApplyUpgrade(TowerModel towerModel)
    {

        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        weaponModel.rate -= 0.05f;

    }
}