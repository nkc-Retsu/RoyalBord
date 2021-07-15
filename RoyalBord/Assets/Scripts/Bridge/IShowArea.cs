namespace Bridge
{
    interface IShowArea
    {
        // 移動と攻撃できる範囲を入力処理に渡すインターフェース
        int[,] ShowArea();
    }
}