/// <summary>
///     监听一个类型的值，在该值发生变化时，广播事件
/// </summary>
/// <typeparam name="T"></typeparam>
public class EventListener<T>
{
    public delegate void OnValueChanged(T newVal);

    private T value;

    public T Value
    {
        set
        {
            if (this.value.Equals(value)) return;
            OnValueChangedEvent?.Invoke(value);
            this.value = value;
        }
    }

    public event OnValueChanged OnValueChangedEvent;
}