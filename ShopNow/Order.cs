namespace ShopNow
{
    public class Order
    {
        private IList<Item> products = new List<Item>();
        private readonly Coupon coupon;

        public Order(string rawCpf, Coupon coupon = null)
        {
            this.coupon = coupon;
            var cpf = new Cpf();

            if (!cpf.Validate(rawCpf))
            {
                throw new InvalidOperationException("Cpf is invalid!");
            }
        }

        public void AddItem(Item item)
        {
            products.Add(item);
        }

        public decimal GetTotal()
        {
            decimal total = 0;

            foreach(var product in products)
            {
               total += product.Price * product.Count;
            }

            if(coupon != null)
            {
                coupon.AddDiscount(total);
                total -= coupon.GetDiscount();
            }

            return total;
        }
    }
}
