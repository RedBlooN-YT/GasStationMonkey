using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Projectiles;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppSystem.Collections.Generic;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using Il2Cpp;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using System.Linq;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using BTD_Mod_Helper.Api;
using GasStationMonkey.Displays.Projectiles;

namespace GasStationMonkey.Upgrades.MiddlePath;

public class MOABMentos : ModUpgrade<GasStationMonkey>
{
    public override int Path => MIDDLE;

    public override int Tier => 4;

    public override int Cost => 7880;

    public override string DisplayName => "MOAB Mentos";

    public override string Description => "He throws soda bombs with mentos in them!!! It can even do damage to MOAB-class bloons. Ability: Rowdy Rush for a short time, he attacks faster and with double shot, also causes his attacks to explode.";

    public override string Icon => "040";

    public override string Portrait => "040";

    public override void ApplyUpgrade(TowerModel towerModel)
    {
        var attackModel = towerModel.GetAttackModel();
        var weaponModel = towerModel.GetWeapon();
        var projectileModel = weaponModel.projectile;

        towerModel.range += 3;
        towerModel.GetAttackModel().range += 3;

        weaponModel.rate -= 0.14f;

        projectileModel.GetDamageModel().damage += 9;


        projectileModel.pierce += 1;
        //Ability

        var ability = Game.instance.model.GetTowerModel("DartlingGunner", 1, 4, 0).GetAbility().Duplicate("RowdyRush");
        ability.cooldown = 40;

        var activate = ability.GetBehavior<ActivateAttackModel>();
        activate.lifespan = 10;

        var Bomb300 = Game.instance.model.GetTowerModel("BombShooter", 3, 0, 0);
        var tornadoTemplate = Bomb300.GetAttackModels()[0];


        var tornadoAttack = tornadoTemplate.Duplicate("RowdyRushattack");

        tornadoAttack.RemoveFilter<FilterInvisibleModel>();
        tornadoAttack.weapons[0].projectile.SetHitCamo(true);



        activate.attacks[0] = tornadoAttack;

        var tornadoWeapon = tornadoAttack.weapons[0];

        tornadoWeapon.Rate = 0.25f;
        tornadoWeapon.emission = new ArcEmissionModel("ArcEmissionModel_", 2, 0, 10, null, false, false);

       

        
        towerModel.AddBehavior(ability);
        towerModel.GetAbility().icon = GetSpriteReference("ability");


    }
}