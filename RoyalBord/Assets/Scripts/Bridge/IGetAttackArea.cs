namespace Bridge
{
    interface IGetAttackArea
    {
        // 攻撃できる範囲を渡すインターフェース
        int[,] GetAttackArea();
    }
}