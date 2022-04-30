using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Xamarin.Forms.MultiSelectListView;

namespace MobileClient.Extensions
{
    public static class ListViewExtensions
    {
        public static async Task RefreshAsync<T>(
            this MultiSelectObservableCollection<T> collection,
            Expression<Func<Task<List<T>>>> refreshFunc
        )
        {
            collection.Clear();

            var action = refreshFunc.Compile();

            var fromApi = await action();
            foreach (var elem in fromApi)
            {
                collection.Add(elem);
            }
        }
    }
}
