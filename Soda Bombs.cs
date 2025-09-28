using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2Cpp;
using GasStationMonkey.Displays.Projectiles;

namespace GasStationMonkey.Upgrades.MiddlePath;

public class SodaBombs : ModUpgrade<GasStationMonkey>
{
    public override int Path => MIDDLE;

    public override int Tier => 3;

    public override int Cost => 4820;

    public override string DisplayName => "Soda Bombs";

    public override string Description => "These bombs can destroy lead! They are small, so they can be throw quickly.";

    public override string Icon => "030";

    public override string Portrait => "030";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;


        weaponModel.projectile.ApplyDisplay<SodaDisplay>();

        towerModel.range += 2;
        towerModel.GetAttackModel().range += 2;

        weaponModel.rate -= 0.22f;

        projectileModel.GetDamageModel().damage += 1;


        projectileModel.pierce += 1;
        
        weaponModel.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
        


    }
}