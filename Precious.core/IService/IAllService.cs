namespace Precious.core.IService
{
	public interface IAllService<T> where T : class
	{
		Task<List<T>> GetAll();
		Task<T> GetAsync(dynamic ID);
		Task<(bool k, string msg)> Add(T obj);
		Task<(bool k, string msg)> Update(T obj);
		Task<(bool k, string msg)> Delete(dynamic ID);
		Task<(bool k, string msg)> CheckUnique(string prod, object value);
	}
}
