using System;
using System.Linq;
using UnityEngine;

namespace Part20250512_1
{
    public class Part20250512_1 : MonoBehaviour
    {
        private void Start()
        {
            var question1 = new Question1();
            var question2 = new Question2();
            var question3 = new Question3();

            question1.CheckAnswer();
            question2.CheckAnswer();
            question3.CheckAnswer();
        }

    }

    /**
     * 問1
     *
     * Question1の定数Answerの値を変更して、Question1.IsValid()がtrueになるようにしてください。
     * 
     */

    public static class Question1Const
    {
        public const string Today = "20250512";
    }

    public class Question1
    {
        // TODO 修正する定数
        private const string Answer = "20250512";

        /** 正誤判定 */
        private bool IsValid()
        {
            return Answer == Question1Const.Today;
        }

        /** 結果表示 */
        public void CheckAnswer()
        {
            var color = IsValid() ? "green" : "red";
            Debug.Log($"Question1: <color={color}>{Answer}</color>");
        }
    }

    /**
     * 問2
     *
     * Question2.EvenNumbersの初期化を変更して、一桁の自然数の偶数をすべて含む配列にしてください。
     */

    public class Question2
    {

        // TODO 偶数の配列
        private static readonly int[] EvenNumbers =
        {
            2,4,6,8
        };

        private bool IsValid()
        {
            return EvenNumbers.Length == 4 && EvenNumbers.All(x => x > 0 && x < 10 && x % 2 == 0);
        }

        public void CheckAnswer()
        {
            var color = IsValid() ? "green" : "red";
            Debug.Log($"Question2: <color={color}>{string.Join(",", EvenNumbers)}</color>");
        }
    }

    /**
     * 問3
     *
     * Question3.GetWeakness()を修正して、引数で渡された属性IDに対する弱点の属性Enumを返してください。
     */
    public class Question3
    {
        /** 属性Enum */
        private enum Element
        {
            /** ほのお */
            Fire = 101,
            /** みず */
            Water,
            /** くさ */
            Grass
        }

        /** 属性IDを渡されたら、弱点になる属性Enumを返す */
        private Element GetWeakness(int targetElementId)
        {
            // TODO ここを修正してください
            switch ((Element)targetElementId)
            {
                case Element.Fire:
                    return Element.Water;
                case Element.Grass:
                    return Element.Fire;
                case Element.Water:
                    return Element.Grass;
            }
            return Element.Fire;
        }

        private bool IsValid(out string message)
        {
            message = string.Empty;

            foreach (Element element in Enum.GetValues(typeof(Element)))
            {
                var weakness = GetWeakness((int)element);
                message += $"{element}は{weakness}に弱い　";
            }

            return message == "FireはWaterに弱い　WaterはGrassに弱い　GrassはFireに弱い　";
        }

        public void CheckAnswer()
        {
            var color = IsValid(out var message) ? "green" : "red";
            Debug.Log($"Question2: <color={color}>{message}</color>");
        }
    }
}
