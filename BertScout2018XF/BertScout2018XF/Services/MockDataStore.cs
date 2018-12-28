using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BertScout2018XF.Models;

namespace BertScout2018XF.Services
{
    public class MockDataStore : IDataStore<Team>
    {
        List<Team> teams;

        public MockDataStore()
        {
            teams = new List<Team>();
            var mockTeams = new List<Team>
            {
                new Team { Id = Guid.NewGuid().ToString(), Number = "First item", Name="This is an item description." },
                new Team { Id = Guid.NewGuid().ToString(), Number = "Second item", Name="This is an item description." },
                new Team { Id = Guid.NewGuid().ToString(), Number = "Third item", Name="This is an item description." },
                new Team { Id = Guid.NewGuid().ToString(), Number = "Fourth item", Name="This is an item description." },
                new Team { Id = Guid.NewGuid().ToString(), Number = "Fifth item", Name="This is an item description." },
                new Team { Id = Guid.NewGuid().ToString(), Number = "Sixth item", Name="This is an item description." },
            };

            foreach (var team in mockTeams)
            {
                teams.Add(team);
            }
        }

        public async Task<bool> AddItemAsync(Team team)
        {
            teams.Add(team);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Team team)
        {
            var oldItem = teams.Where((Team arg) => arg.Id == team.Id).FirstOrDefault();
            teams.Remove(oldItem);
            teams.Add(team);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = teams.Where((Team arg) => arg.Id == id).FirstOrDefault();
            teams.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Team> GetItemAsync(string id)
        {
            return await Task.FromResult(teams.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Team>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(teams);
        }
    }
}