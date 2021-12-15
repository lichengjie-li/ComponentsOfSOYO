public static class Adapter
{
    /// <summary>
    ///     根据一个 bool设置大于它或小于它时，传入的 value的值
    /// </summary>
    /// <param name="accordingTo">判断条件</param>
    /// <param name="onTrue">True时的值</param>
    /// <param name="onFalse">False时的值</param>
    public static T SetAdapterValue<T>(bool accordingTo, T onTrue, T onFalse)
    {
        return accordingTo ? onTrue : onFalse;
    }
}