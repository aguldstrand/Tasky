using Microsoft.AspNet.Hosting;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace Tasky.Services
{
    public class IdentityWrapper<TModel>
    {
        [Required]
        public int Id { get; }

        [Required]
        public TModel Value { get; }

        public IdentityWrapper(int id, TModel value)
        {
            this.Id = id;
            this.Value = value;
        }
    }

    public class IdentityWrapper<TParent1, TModel>
    {
        [Required]
        public int Id { get; }

        [Required]
        public int ParentId1 { get; }

        [Required]
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
        [Required]
        public int Id { get; }

        [Required]
        public int ParentId1 { get; }

        [Required]
        public int ParentId2 { get; }

        [Required]
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
        [Required]
        public int Id { get; }

        [Required]
        public int ParentId1 { get; }

        [Required]
        public int ParentId2 { get; }

        [Required]
        public int ParentId3 { get; }

        [Required]
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
