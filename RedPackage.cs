using System;
using System.Linq;

namespace JObjectDemo;

public class RedPackage
{
    ///红包算法
    ///钱传入转换为分 整数表示
    public static List<string> SplitRedPackage(decimal money, int count)
    {
        if (money > 10000000 || money < 0) throw new OverflowException("红包金额");
        if (count < 1 || count > 100) throw new OverflowException("红包个数");
        int note = (int)(money * 100);
        if (note < count) throw new OverflowException("红包金额");
        Random random = new Random();
        List<int> pieces = new(count);
        int left = note;
        for (var i = 0; i < count - 1; ++i)
        {
            var piece = (int)(random.NextDouble() * left);
            pieces.Add(piece);
            left = left - piece;
        }

        pieces.Add(note - pieces.Sum());

        //矫正零值
        pieces.RemoveAll(item => item == 0);
        while (pieces.Count < count)
        {
            pieces.Add(1);
            var maxIndex = pieces.IndexOf(pieces.Max());
            pieces[maxIndex] = pieces[maxIndex] - 1;
        }

        if (pieces.Sum() != note) throw new Exception("计算出错");

        //整理为字符串
        List<string> moneyNotes = new(count);
        foreach (var piece in pieces)
        {
            var pieceStr = ((double)piece / 100).ToString("F2");
            moneyNotes.Add(pieceStr);
        }

        return moneyNotes;
    }
}