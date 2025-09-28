using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using System.Linq;

namespace GasStationMonkey.Upgrades.MiddlePath;

public class GoodDrivers : ModUpgrade<GasStationMonkey>
{
    public override int Path => BOTTOM;

    public override int Tier => 3;

    public override int Cost => 1050;

    public override string DisplayName => "Good Drivers";

    public override string Description => "They're too good at driving! They don't hurt the bloons enough.";

    public override string Icon => "003";

    public override string Portrait => "003";

    public override void ApplyUpgrade(TowerModel towerModel)
    {

        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;


//Nercomancer attack
        var druid300 = Game.instance.model.GetTowerModel("WizardMonkey", 0, 0, 4);
        var tornadoTpl = druid300.GetAttackModels().First(a => a.name.Contains("Necromancer"));

        var tornadoAttack = tornadoTpl.Duplicate("HairDryer_T5_TornadoAttack");

        tornadoAttack.RemoveFilter<FilterInvisibleModel>();
        tornadoAttack.weapons[0].projectile.SetHitCamo(true);

        var tornadoWeapon = tornadoAttack.weapons[0];

        tornadoWeapon.projectile.pierce = 5;
        tornadoWeapon.projectile.GetDamageModel().damage = 5;



        var necroZone = druid300.behaviors.First(b => b.name == "NecromancerZoneModel_").Duplicate("NecroZone_HS");



        towerModel.AddBehavior(tornadoAttack);
        towerModel.AddBehavior(necroZone);

    }
}