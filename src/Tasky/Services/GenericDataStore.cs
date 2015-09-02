using Microsoft.AspNet.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasky.Services
{
    public class GenericDataStore<T> : IDataStore<T>
    {
        private readonly string root;

        public GenericDataStore(IHostingEnvironment hostEnv)
        {
            var typeName = typeof(T).FullName;

            this.root = Path.Combine(hostEnv.WebRootPath, "../data", typeName);
            Directory.CreateDirectory(root);
        }

        public IEnumerable<IdentityWrapper<T>> Get()
        {
            return Directory.EnumerateDirectories(root)
                .Select(p => new IdentityWrapper<T>(
                    id: int.Parse(Path.GetFileName(p)),
                    value: JsonConvert.DeserializeObject<T>(File.ReadAllText(Path.Combine(p, "value.json")))));
        }

        public IdentityWrapper<T> Get(int id)
        {
            return new IdentityWrapper<T>(
                    id: id,
                    value: JsonConvert.DeserializeObject<T>(File.ReadAllText(Path.Combine(root, id.ToString(), "value.json"))));
        }

        public void Add(T value)
        {
            var id = Directory.EnumerateDirectories(root)
                .Select(Path.GetFileName)
                .Concat(new[] { "0" })
                .Max(int.Parse) + 1;

            var itemPath = Path.Combine(root, id.ToString(), "value.json");
            Directory.CreateDirectory(Path.GetDirectoryName(itemPath));
            File.WriteAllText(itemPath, JsonConvert.SerializeObject(value));
        }

        public void Update(int id, T value)
        {
            var itemPath = Path.Combine(root, id.ToString(), "value.json");
            File.WriteAllText(itemPath, JsonConvert.SerializeObject(value));
        }

        public void Remove(int id)
        {
            var itemPath = Path.Combine(root, id.ToString(), "value.json");
            Directory.Delete(itemPath, true);
        }
    }

    public class Id<T> { }
    public class Id<T1, T2> { }
    public class Id<T1, T2, T3> { }
    public class Id<T1, T2, T3, T4> { }

    public class IdentityWrapper<T>
    {
        public int Id { get; }
        public T Value { get; }

        public IdentityWrapper(int id, T value)
        {
            this.Id = id;
            this.Value = value;
        }
    }
}
