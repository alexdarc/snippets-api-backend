namespace Infrastructure.Mappers
{
    using System.Collections.Generic;
    using Contracts.Models;
    using Contracts.Services;

    public class SnippetMapper
        : ISnippetMapper
    {
        public Snippet Get(
            string id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Snippet> GetMany(
            int limit)
        {
            throw new System.NotImplementedException();
        }

        public void Insert(
            Snippet snippet)
        {
            throw new System.NotImplementedException();
        }

        public void Save(
            Snippet snippet)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(
            string id)
        {
            throw new System.NotImplementedException();
        }

        public void Remove(
            Snippet snippet)
        {
            throw new System.NotImplementedException();
        }
    }
}
