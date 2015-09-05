using Microsoft.AspNet.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Tasky.Services
{
    public class IdentityWrapper<TModel>
    {
        public int Id { get; }
        public TModel Value { get; }

        public IdentityWrapper(int id, TModel value)
        {
            this.Id = id;
            this.Value = value;
        }
    }

    public class IdentityWrapper<TParent1, TModel>
    {
        public int Id { get; }
        public int ParentId1 { get; }
        public TModel Value { get; }

        public IdentityWrapper(int parentId1, int id, TModel value)
        {
            this.Id = id;
            this.ParentId1 = parentId1;
            this.Value = value;
        }
    }

    public class IdentityWrapper<TParent1, TParent2, TModel>
    {
        public int Id { get; }
        public int ParentId1 { get; }
        public int ParentId2 { get; }
        public TModel Value { get; }

        public IdentityWrapper(int parentId1, int parentId2, int id, TModel value)
        {
            this.Id = id;
            this.ParentId1 = parentId1;
            this.ParentId2 = parentId2;
            this.Value = value;
        }
    }

    public class IdentityWrapper<TParent1, TParent2, TParent3, TModel>
    {
        public int Id { get; }
        public int ParentId1 { get; }
        public int ParentId2 { get; }
        public int ParentId3 { get; }
        public TModel Value { get; }

        public IdentityWrapper(int parentId1, int parentId2, int parentId3, int id,TModel value)
        {
            this.Id = id;
            this.ParentId1 = parentId1;
            this.ParentId2 = parentId2;
            this.ParentId3 = parentId3;
            this.Value = value;
        }
    }
}
