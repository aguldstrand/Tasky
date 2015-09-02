using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Tasky.Services
{
    public interface IDataStore<T>
    {
        IEnumerable<IdentityWrapper<T>> Get();
        IdentityWrapper<T> Get(int id);
        void Add(T value);
        void Update(int id, T value);
        void Remove(int id);
    }

    public class Issue
    {
        [Required]
        [MaxLength(140)]
        public string Name { get; }

        [MaxLength(2048)]
        public string Description { get; }

        public Issue(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    public class Project
    {
        [Required]
        [MaxLength(140)]
        public string Name { get; }

        [MaxLength(2048)]
        public string Description { get; }

        public Project(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}