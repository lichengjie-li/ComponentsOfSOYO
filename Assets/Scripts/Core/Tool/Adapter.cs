using System;

public static class Adapter
{
    /// <summary>
    ///     根据一个 bool设置大于它或小于它时，传入的 value的值
    /// </summary>
    /// <param name="value">需要被更改的值</param>
    /// <param name="accordingTo">判断条件</param>
    /// <param name="onTrue">True时的值</param>
    /// <param name="onFalse">False时的值</param>
    /// <typeparam name="T"></typeparam>
    /// <exception cref="ArgumentNullException"></exception>
    public static void SetAdapterValue<T>(ref T value, bool accordingTo, T onTrue, T onFalse)
    {
        if (value == null) throw new ArgumentNullException(nameof(value));

        value = accordingTo ? onTrue : onFalse;
    }
}