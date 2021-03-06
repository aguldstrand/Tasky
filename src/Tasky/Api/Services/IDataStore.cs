﻿using Microsoft.AspNet.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace Tasky.Services
{
    public interface IDataStore<TModel>
    {
        ImmutableArray<IdentityWrapper<TModel>> GetAll();
        IdentityWrapper<TModel> Get(int id);
        void Add(TModel value);
        void Update(int id, TModel value);
        void Remove(int id);
    }

    public interface IDataStore<TParent1, TModel>
    {
        ImmutableArray<IdentityWrapper<TParent1, TModel>> GetAll(int parentId1);
        IdentityWrapper<TParent1, TModel> Get(int parentId1, int id);
        void Add(int parentId1, TModel value);
        void Update(int parentId1, int id, TModel value);
        void Remove(int parentId1, int id);
    }

    public interface IDataStore<TParent1, TParent2, TModel>
    {
        ImmutableArray<IdentityWrapper<TParent1, TParent2, TModel>> GetAll(int parentId1, int parentId2);
        IdentityWrapper<TParent1, TParent2, TModel> Get(int parentId1, int parentId2, int id);
        void Add(int parentId1, int parentId2, TModel value);
        void Update(int parentId1, int parentId2, int id, TModel value);
        void Remove(int parentId1, int parentId2, int id);
    }

    public interface IDataStore<TParent1, TParent2, TParent3, TModel>
    {
        ImmutableArray<IdentityWrapper<TParent1, TParent2, TParent3, TModel>> GetAll(int parentId1, int parentId2, int parentId3);
        IdentityWrapper<TParent1, TParent2, TParent3, TModel> Get(int parentId1, int parentId2, int parentId3, int id);
        void Add(int parentId1, int parentId2, int parentId3, TModel value);
        void Update(int parentId1, int parentId2, int parentId3, int id, TModel value);
        void Remove(int parentId1, int parentId2, int parentId3, int id);
    }

    public class CommonDataStore<TModel> : IDataStore<TModel>
    {
        private readonly string root;

        public CommonDataStore(IHostingEnvironment hostEnv)
        {
            this.root = Path.Combine(hostEnv.WebRootPath, "..", "data");
        }

        public void Add(TModel value)
        {
            var path = Path.Combine(root,
                typeof(TModel).ToString());

            Directory.CreateDirectory(path);

            var id = Directory.GetDirectories(path)
                .Select(Path.GetFileName)
                .Concat(new[] { "0" })
                .Max(int.Parse) + 1;

            var itemPath = Path.Combine(path, id.ToString(), "value.json");
            Directory.CreateDirectory(Path.GetDirectoryName(itemPath));
            File.WriteAllText(itemPath, JsonConvert.SerializeObject(value));
        }

        public ImmutableArray<IdentityWrapper<TModel>> GetAll()
        {
            var path = Path.Combine(root,
                typeof(TModel).ToString());

            Directory.CreateDirectory(path);

            return Directory.GetDirectories(path)
                .Select(d => new IdentityWrapper<TModel>(
                    id: int.Parse(Path.GetFileName(d)),
                    value: JsonConvert.DeserializeObject<TModel>(File.ReadAllText(Path.Combine(d, "value.json")))))
                .ToImmutableArray();
        }

        public IdentityWrapper<TModel> Get(int id)
        {
            var path = Path.Combine(root,
                typeof(TModel).FullName, id.ToString(),
                "value.json");

            return new IdentityWrapper<TModel>(
                id: id,
                value: JsonConvert.DeserializeObject<TModel>(File.ReadAllText(path)));
        }

        public void Remove(int id)
        {
            var path = Path.Combine(root,
                typeof(TModel).FullName, id.ToString());

            Directory.Delete(path, true);
        }

        public void Update(int id, TModel value)
        {
            var path = Path.Combine(root,
                typeof(TModel).FullName, id.ToString(),
                "value.json");

            File.WriteAllText(path, JsonConvert.SerializeObject(value));
        }
    }

    public class CommonDataStore<TParent1, TModel> : IDataStore<TParent1, TModel>
    {
        private readonly string root;

        public CommonDataStore(IHostingEnvironment hostEnv)
        {
            this.root = Path.Combine(hostEnv.WebRootPath, "..", "data");
        }

        public void Add(int parentId1, TModel value)
        {
            var parentPath = Path.Combine(root,
                typeof(TParent1).FullName, parentId1.ToString());

            if (!Directory.Exists(parentPath))
            {
                throw new Exception("Parent item not found.");
            }

            var path = Path.Combine(parentPath, typeof(TModel).ToString());
            Directory.CreateDirectory(path);

            var id = Directory.GetDirectories(path)
                .Select(Path.GetFileName)
                .Concat(new[] { "0" })
                .Max(int.Parse) + 1;

            var itemPath = Path.Combine(path, id.ToString(), "value.json");
            Directory.CreateDirectory(Path.GetDirectoryName(itemPath));
            File.WriteAllText(itemPath, JsonConvert.SerializeObject(value));
        }

        public ImmutableArray<IdentityWrapper<TParent1, TModel>> GetAll(int parentId1)
        {
            var parentPath = Path.Combine(root,
                typeof(TParent1).FullName, parentId1.ToString());

            if (!Directory.Exists(parentPath))
            {
                throw new Exception("Parent item not found.");
            }

            var path = Path.Combine(parentPath, typeof(TModel).ToString());
            Directory.CreateDirectory(path);

            return Directory.GetDirectories(path)
                .Select(d => new IdentityWrapper<TParent1, TModel>(
                    parentId1: parentId1,
                    id: int.Parse(Path.GetFileName(d)),
                    value: JsonConvert.DeserializeObject<TModel>(File.ReadAllText(Path.Combine(d, "value.json")))))
                .ToImmutableArray();
        }

        public IdentityWrapper<TParent1, TModel> Get(int parentId1, int id)
        {
            var path = Path.Combine(root,
                typeof(TParent1).FullName, parentId1.ToString(),
                typeof(TModel).FullName, id.ToString(),
                "value.json");

            return new IdentityWrapper<TParent1, TModel>(
                parentId1: parentId1,
                id: id,
                value: JsonConvert.DeserializeObject<TModel>(File.ReadAllText(path)));
        }

        public void Remove(int parentId1, int id)
        {
            var path = Path.Combine(root,
                typeof(TParent1).FullName, parentId1.ToString(),
                typeof(TModel).FullName, id.ToString());

            Directory.Delete(path, true);
        }

        public void Update(int parentId1, int id, TModel value)
        {
            var path = Path.Combine(root,
                typeof(TParent1).FullName, parentId1.ToString(),
                typeof(TModel).FullName, id.ToString(),
                "value.json");

            File.WriteAllText(path, JsonConvert.SerializeObject(value));
        }
    }

    public class CommonDataStore<TParent1, TParent2, TModel> : IDataStore<TParent1, TParent2, TModel>
    {
        private readonly string root;

        public CommonDataStore(IHostingEnvironment hostEnv)
        {
            this.root = Path.Combine(hostEnv.WebRootPath, "..", "data");
        }

        public void Add(int parentId1, int parentId2, TModel value)
        {
            var parentPath = Path.Combine(root,
                typeof(TParent1).FullName, parentId1.ToString(),
                typeof(TParent2).FullName, parentId2.ToString());

            if (!Directory.Exists(parentPath))
            {
                throw new Exception("Parent item not found.");
            }

            var path = Path.Combine(parentPath, typeof(TModel).ToString());
            Directory.CreateDirectory(path);

            var id = Directory.GetDirectories(path)
                .Select(Path.GetFileName)
                .Concat(new[] { "0" })
                .Max(int.Parse) + 1;

            var itemPath = Path.Combine(path, id.ToString(), "value.json");
            Directory.CreateDirectory(Path.GetDirectoryName(itemPath));
            File.WriteAllText(itemPath, JsonConvert.SerializeObject(value));
        }

        public ImmutableArray<IdentityWrapper<TParent1, TParent2, TModel>> GetAll(int parentId1, int parentId2)
        {
            var parentPath = Path.Combine(root,
                typeof(TParent1).FullName, parentId1.ToString(),
                typeof(TParent2).FullName, parentId2.ToString());

            if (!Directory.Exists(parentPath))
            {
                throw new Exception("Parent item not found.");
            }

            var path = Path.Combine(parentPath, typeof(TModel).ToString());
            Directory.CreateDirectory(path);

            return Directory.GetDirectories(path)
                .Select(d => new IdentityWrapper<TParent1, TParent2, TModel>(
                    parentId1: parentId1,
                    parentId2: parentId2,
                    id: int.Parse(Path.GetFileName(d)),
                    value: JsonConvert.DeserializeObject<TModel>(File.ReadAllText(Path.Combine(d, "value.json")))))
                .ToImmutableArray();
        }

        public IdentityWrapper<TParent1, TParent2, TModel> Get(int parentId1, int parentId2, int id)
        {
            var path = Path.Combine(root,
                typeof(TParent1).FullName, parentId1.ToString(),
                typeof(TParent2).FullName, parentId2.ToString(),
                typeof(TModel).FullName, id.ToString(),
                "value.json");

            return new IdentityWrapper<TParent1, TParent2, TModel>(
                parentId1: parentId1,
                parentId2: parentId2,
                id: id,
                value: JsonConvert.DeserializeObject<TModel>(File.ReadAllText(path)));
        }

        public void Remove(int parentId1, int parentId2, int id)
        {
            var path = Path.Combine(root,
                typeof(TParent1).FullName, parentId1.ToString(),
                typeof(TParent2).FullName, parentId2.ToString(),
                typeof(TModel).FullName, id.ToString());

            Directory.Delete(path, true);
        }

        public void Update(int parentId1, int parentId2, int id, TModel value)
        {
            var path = Path.Combine(root,
                typeof(TParent1).FullName, parentId1.ToString(),
                typeof(TParent2).FullName, parentId2.ToString(),
                typeof(TModel).FullName, id.ToString(),
                "value.json");

            File.WriteAllText(path, JsonConvert.SerializeObject(value));
        }
    }

    public class CommonDataStore<TParent1, TParent2, TParent3, TModel> : IDataStore<TParent1, TParent2, TParent3, TModel>
    {
        private readonly string root;

        public CommonDataStore(IHostingEnvironment hostEnv)
        {
            this.root = Path.Combine(hostEnv.WebRootPath, "..", "data");
        }

        public void Add(int parentId1, int parentId2, int parentId3, TModel value)
        {
            var parentPath = Path.Combine(root,
                typeof(TParent1).FullName, parentId1.ToString(),
                typeof(TParent2).FullName, parentId2.ToString(),
                typeof(TParent3).FullName, parentId3.ToString());

            if (!Directory.Exists(parentPath))
            {
                throw new Exception("Parent item not found.");
            }

            var path = Path.Combine(parentPath, typeof(TModel).ToString());
            Directory.CreateDirectory(path);

            var id = Directory.GetDirectories(path)
                .Select(Path.GetFileName)
                .Concat(new[] { "0" })
                .Max(int.Parse) + 1;

            var itemPath = Path.Combine(path, id.ToString(), "value.json");
            Directory.CreateDirectory(Path.GetDirectoryName(itemPath));
            File.WriteAllText(itemPath, JsonConvert.SerializeObject(value));
        }

        public ImmutableArray<IdentityWrapper<TParent1, TParent2, TParent3, TModel>> GetAll(int parentId1, int parentId2, int parentId3)
        {
            var parentPath = Path.Combine(root,
                typeof(TParent1).FullName, parentId1.ToString(),
                typeof(TParent2).FullName, parentId2.ToString(),
                typeof(TParent3).FullName, parentId3.ToString());

            if (!Directory.Exists(parentPath))
            {
                throw new Exception("Parent item not found.");
            }

            var path = Path.Combine(parentPath, typeof(TModel).ToString());
            Directory.CreateDirectory(path);

            return Directory.GetDirectories(path)
                .Select(d => new IdentityWrapper<TParent1, TParent2, TParent3, TModel>(
                    parentId1: parentId1,
                    parentId2: parentId2,
                    parentId3: parentId3,
                    id: int.Parse(Path.GetFileName(d)),
                    value: JsonConvert.DeserializeObject<TModel>(File.ReadAllText(Path.Combine(d, "value.json")))))
                .ToImmutableArray();
        }

        public void Remove(int parentId1, int parentId2, int parentId3, int id)
        {
            var path = Path.Combine(root,
                typeof(TParent1).FullName, parentId1.ToString(),
                typeof(TParent2).FullName, parentId2.ToString(),
                typeof(TParent3).FullName, parentId3.ToString(),
                typeof(TModel).FullName, id.ToString());

            Directory.Delete(path, true);
        }

        public IdentityWrapper<TParent1, TParent2, TParent3, TModel> Get(int parentId1, int parentId2, int parentId3, int id)
        {
            var path = Path.Combine(root,
                typeof(TParent1).FullName, parentId1.ToString(),
                typeof(TParent2).FullName, parentId2.ToString(),
                typeof(TParent3).FullName, parentId3.ToString(),
                typeof(TModel).FullName, id.ToString(),
                "value.json");

            return new IdentityWrapper<TParent1, TParent2, TParent3, TModel>(
                parentId1: parentId1,
                parentId2: parentId2,
                parentId3: parentId3,
                id: id,
                value: JsonConvert.DeserializeObject<TModel>(File.ReadAllText(path)));
        }

        public void Update(int parentId1, int parentId2, int parentId3, int id, TModel value)
        {
            var path = Path.Combine(root,
                typeof(TParent1).FullName, parentId1.ToString(),
                typeof(TParent2).FullName, parentId2.ToString(),
                typeof(TParent3).FullName, parentId3.ToString(),
                typeof(TModel).FullName, id.ToString(),
                "value.json");

            File.WriteAllText(path, JsonConvert.SerializeObject(value));
        }
    }
}
