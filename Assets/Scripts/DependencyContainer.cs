using System;
using System.Collections.Generic;

public static class DependencyContainer
{
    //容器中儲存所有生成的Instance
    private static Dictionary<Type, object> _instances;

    //從容器中取得所需的Instance
    public static object GetDependantInstance<T>()
    {
        if (_instances == null)
        {
            _instances = new Dictionary<Type, object>();
        }

        Type objType = typeof(T);
        _instances.TryGetValue(objType, out var dependantInstance);

        if (dependantInstance == null)
        {
            dependantInstance = Activator.CreateInstance<T>() as object;
            _instances.Add(objType, dependantInstance);
        }

        return dependantInstance;
    }

    //容器中都是靜態成員不會自動被GC,記得要手動去回收
    public static void Clear()
    {
        foreach (KeyValuePair<Type, object> kvp in _instances)
        {
            (kvp.Value as IDisposable)?.Dispose();
        }

        _instances.Clear();
    }
}