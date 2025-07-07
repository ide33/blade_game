using AutoBattle.Vc;
using Cysharp.Threading.Tasks;

namespace AutoBattle.Lc
{
    public class LcStartBattle : LogicCommand
    {
        protected override UniTask Execute()
        {
            // 味方生成
            var warrior = new Unit(Belonging.Ally, 0, "Warrior", 100, 20);
            var mage = new Unit(Belonging.Ally, 1, "Mage", 50, 40);
            var rogue = new Unit(Belonging.Ally, 2, "Rogue", 80, 30);
            
            BattleManager.AddUnit(warrior, true);
            BattleManager.AddUnit(mage, true);
            BattleManager.AddUnit(rogue, true);
            
            // 敵生成
            var goblin = new Unit(Belonging.Enemy, 0, "Goblin", 60, 15);
            var orc = new Unit(Belonging.Enemy, 1, "Orc", 120, 25);
            var dragon = new Unit(Belonging.Enemy, 2, "Dragon", 200, 50);
            
            BattleManager.AddUnit(goblin, false);
            BattleManager.AddUnit(orc, false);
            BattleManager.AddUnit(dragon, false);
            
            new VcOnStageUnit(BattleManager.AllyList, BattleManager.EnemyList)
                .AddToQueue();
            
            return UniTask.CompletedTask;
        }
    }
}