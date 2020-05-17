namespace Contracts.Services
{
    using System.Collections.Generic;
    using Common.Contracts;
    using Contracts.Models;

    public interface ISnippetMapper
    {
        Snippet Get(
            string id);

        IEnumerable<Snippet> GetMany(
            int limit,
            int skip);

        void Insert(
            Snippet snippet);

        void Update(
            string id,
            UpdateInstructions<Snippet> updateInstructions);

        void Remove(
            string id);

        void Remove(
            Snippet snippet);
    }
}
