namespace Bridge
{
    interface IGetMoveArea
    {
        // 駒が移動できる範囲を渡すインターフェース
         int[,] GetMoveArea();
    }
}