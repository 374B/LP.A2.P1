namespace LP.University.API.Interfaces
{
    public interface IMapper<in TIn, out TOut>
    {
        TOut Map(TIn obj);
    }
}
