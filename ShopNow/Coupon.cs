namespace ShopNow
{
    public class Coupon
    {
        public Coupon(string code, decimal percentual)
        {
            Code = code;
            Percentual = percentual;
        }

        public string Code { get; private set; }
        public decimal Percentual { get; private set; }
        public decimal Discont { get; private set; }

        public void AddDiscount(decimal value)
        {
            Discont = value * (Percentual/100);
        }

        public decimal GetDiscount()
        {
            return Discont;
        }
    }
}
