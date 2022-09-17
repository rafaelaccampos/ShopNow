using FluentAssertions;
using NUnit.Framework;

namespace ShopNow.Tests
{
    public class CouponTests
    {
        [Test]
        public void ShouldBeAbleToCalculateDiscount()
        {
            var coupon = new Coupon("VALE35", 35);

            coupon.AddDiscount(1000);

            coupon.GetDiscount()
                .Should()
                .Be(350);
        }

    }
}
