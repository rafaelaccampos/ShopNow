namespace ShopNow
{
    public class Coupon
    {
        public Coupon(string code, decimal percentual, DateTime? expiredDate = null, DateTime? actualDate = null)
        {
            Code = code;
            Percentual = percentual;
            ExpiredDate = expiredDate;
            ActualDate = actualDate;
        }

        public string Code { get; private set; }
        public decimal Percentual { get; private set; }
        public decimal Discont { get; private set; }
        public DateTime? ExpiredDate { get; private set; }
        public DateTime? ActualDate { get; private set; }

        public void AddDiscount(decimal value)
        {
            var couponIsExpired = IsExpired();
            if(!couponIsExpired)
            {
                Discont = value * (Percentual/100);
            }
        }

        public bool IsExpired()
        {
            if(ExpiredDate != null && ExpiredDate < ActualDate)
            {
                return true;
            }

            return false;
        }

        public decimal GetDiscount()
        {
            return Discont;
        }
    }
}
