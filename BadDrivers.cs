using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using System.Linq;
using Il2CppAssets.Scripts.Data.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;

namespace GasStationMonkey.Upgrades.MiddlePath;

public class BadDrivers : ModUpgrade<GasStationMonkey>
{
    public override int Path => BOTTOM;

    public override int Tier => 4;

    public override int Cost => 6080;

    public override string DisplayName => "Bad Drivers";

    public override string Description => "They're so bad at driving! They do way more damage to the bloons.";

    public override string Icon => "004";

    public override string Portrait => "004";

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

        tornadoWeapon.projectile.pierce = 23;
        tornadoWeapon.projectile.GetDamageModel().damage = 24;



        var necroZone = druid300.behaviors.First(b => b.name == "NecromancerZoneModel_").Duplicate("NecroZone_HS");

       

        towerModel.AddBehavior(tornadoAttack);
        towerModel.AddBehavior(necroZone);

    }
}