using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BertScout2018XF.Models;

namespace BertScout2018XF.Services
{
    public class MockDataStore : IDataStore<Team>
    {
        List<Team> items;

        public MockDataStore()
        {
            items = new List<Team>();
            var mockItems = new List<Team>
            {
                new Team { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Team { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Team { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Team { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Team { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Team { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Team item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Team item)
        {
            var oldItem = items.Where((Team arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = items.Where((Team arg) => arg.Id == id).FirstOrDefault();
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Team> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Team>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}