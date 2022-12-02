using System.Windows.Forms;

namespace CoffeeShop
{
    internal class Biding : Binding
    {
        public Biding(string propertyName, object dataSource, string dataMember) : base(propertyName, dataSource, dataMember)
        {
        }

        public Biding(string propertyName, object dataSource, string dataMember, bool v, DataSourceUpdateMode never) : base(propertyName, dataSource, dataMember)
        {
        }
    }
}