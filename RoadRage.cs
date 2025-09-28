using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using System.Linq;
using Il2CppAssets.Scripts.Data.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;

namespace GasStationMonkey.Upgrades.MiddlePath;

public class RaodRage : ModUpgrade<GasStationMonkey>
{
    public override int Path => BOTTOM;

    public override int Tier => 5;

    public override int Cost => 74600;

    public override string DisplayName => "Raod Rage";

    public override string Description => "They are crazy!!! TAKE COVER!!!";

    public override string Icon => "005";

    public override string Portrait => "005";

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

        tornadoWeapon.projectile.pierce = 223;
        tornadoWeapon.projectile.GetDamageModel().damage = 224;



        var necroZone = druid300.behaviors.First(b => b.name == "NecromancerZoneModel_").Duplicate("NecroZone_HS");

       

        towerModel.AddBehavior(tornadoAttack);
        towerModel.AddBehavior(necroZone);

    }
}