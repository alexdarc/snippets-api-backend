namespace Contracts.Services
{
    using System.Collections.Generic;
    using Contracts.Models;

    public interface ISnippetMapper
    {
        Snippet Get(
            string id);

        IEnumerable<Snippet> GetMany(
            int limit);

        void Insert(
            Snippet snippet);

        void Save(
            Snippet snippet);

        void Remove(
            string id);

        void Remove(
            Snippet snippet);
    }
}
