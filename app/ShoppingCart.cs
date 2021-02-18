using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MyStore.App
{
    public class ShoppingCart : INotifyPropertyChanged
    {
        public List<CatalogItem> Items { get; } = new();

        public int Count => Items.Count;

        public void AddItem(CatalogItem item)
        {
            Items.Add(item);
            OnPropertyChanged(nameof(Count));
        }

        public void ClearCart()
        {
            Items.Clear();
            OnPropertyChanged(nameof(Count));
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public OrderItem[] CreateOrderItems() => Items.GroupBy(ci => new {ci.Id, ci.Price})
            .Select(ci => new OrderItem(ci.Key.Id, ci.Count(), ci.Key.Price))
            .ToArray();
    }
}
