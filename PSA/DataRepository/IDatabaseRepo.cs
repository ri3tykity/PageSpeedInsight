using PSA.DataModel;

namespace PSA.DataRepository
{
    /// <summary>
    ///  Interface for data repository.
    ///  
    /// </summary>
    public interface IDatabaseRepo
    {
        void SaveResult(PageSpeedData pData);
    }
}
