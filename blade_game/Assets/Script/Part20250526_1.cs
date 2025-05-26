using System;
using UnityEngine;

namespace Part20250526_1
{
    public class Part20250526_1 : MonoBehaviour
    {
        private void Start()
        {
            new Question1().CheckAnswer();
            new Question2().CheckAnswer();
            new Question3().CheckAnswer();
        }

        // 基底クラス
        public abstract class Monster
        {
            public abstract string Name { get; }
        }

        // 派生クラス
        public class Goblin : Monster
        {
            public override string Name => "ゴブリン";
        }

        public class Dragon : Monster
        {
            public override string Name => "ドラゴン";
        }

        public class DragonZombie : Dragon
        {
            public override string Name => "ドラゴンゾンビ";

            //　唯一ゴールドを所持
            public int Gold => 100;
        }

        /**
         * 問1: GetType を使用して厳密な型を判定する
         * 期待される出力: 実態は Goblin です
         */
        private class Question1
        {
            /** 実態クラス名を取得する */
            private static Type GetDerivedType(Monster monster)
            {
                // TODO: 引数 monster の実態クラス名を取得
                return monster.GetType();
            }

            private bool IsValid(out string message)
            {
                Monster monster = new Goblin(); // 型はMonster、実体はGoblin
                var className = GetDerivedType(monster).Name;

                message = $"実態は {className} です";
                return className == "Goblin";
            }

            public void CheckAnswer()
            {
                Debug.Log($"Question1: <color={(IsValid(out var msg) ? "green" : "red")}>{msg}</color>");
            }
        }

        /**
         * 問2: is 演算子で型の継承関係を調べる
         * 期待される出力: ドラゴンの数: 2
         */
        private class Question2
        {

            /** Dragonクラスのインスタンス数をカウント */
            private int CountDragon(Monster[] monsters)
            {
                // TODO: monsters の中から Dragon の数をカウント
                int count = 0;
                foreach (var monster in monsters)
                {
                    if (monster is Dragon)
                    {
                        count++;
                    }
                }
                return count;
            }

            private bool IsValid(out string message)
            {
                var monsters = new Monster[]
                {
                    new Goblin(),
                    new Dragon(),
                    new DragonZombie(),
                    new Goblin(),
                    new Goblin()
                };

                var count = CountDragon(monsters);

                message = $"ドラゴンの数: {count}";
                return count == 2;
            }

            public void CheckAnswer()
            {
                Debug.Log($"Question2: <color={(IsValid(out var msg) ? "green" : "red")}>{msg}</color>");
            }
        }

        /**
         * 問3: as 演算子で型を変換し、nullで判定する
         * 期待される出力: monster1: 0, monster2: 0, monster3: 100
         */
        public class Question3
        {
            private static int GetDragonZombieGold(Monster monster)
            {
                var dz = monster as DragonZombie;
                if (dz != null)
                {
                    return dz.Gold;
                }
                return 0;
            }

            private bool IsValid(out string message)
            {
                var monster1 = new Goblin();
                var monster2 = new Dragon();
                var monster3 = new DragonZombie();

                message = $"monster1: {GetDragonZombieGold(monster1)}, " +
                          $"monster2: {GetDragonZombieGold(monster2)}, " +
                          $"monster3: {GetDragonZombieGold(monster3)}";
                return GetDragonZombieGold(monster1) == 0 &&
                       GetDragonZombieGold(monster2) == 0 &&
                       GetDragonZombieGold(monster3) == 100;
            }

            public void CheckAnswer()
            {
                Debug.Log($"Question3: <color={(IsValid(out var msg) ? "green" : "red")}>{msg}</color>");
            }
        }
    }

}
