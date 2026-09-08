namespace SL.DAL.Contracts
{
    /// <summary>
    /// Interfaz generica para adapter, donde T es una entidad de dominio y U es su contraparte respectiva de EntityFramework.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="U"></typeparam>
    public interface IGenericAdapter<T, U>
    {
        T Adapt(U Entity);
        U Adapt(T obj);
        T Adapt(object[] values);
    }
}
