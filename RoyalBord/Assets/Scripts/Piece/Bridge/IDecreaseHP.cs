namespace Bridge
{
    interface IDecreaseHP
    {
        // 駒のHPを減らすインターフェース(基本ワンパンで倒せるけど)
        int DecreaseHP(int dec);
    }
}